using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Reporter
{
    class Program
    {
        static string OSRMHost = "http://210.59.250.220:5000/";
        static string SourceHost = "http://ptx.transportdata.tw/";
        static string RootPath = Directory.GetCurrentDirectory() + @"\";
        static string FileNameFormat = "yyyyMMdd";
        static string[] Citys = new string[] { "Taipei", "NewTaipei", "Taoyuan", "Taichung", "Tainan", "Kaohsiung", "KinmenCounty" };
        //static string[] Citys = new string[] { "Kaohsiung", "KinmenCounty" };
        static string GoogleMapKey = "AIzaSyAR9MPmm4qI15TtNN6U5aKwRybzpqApmjM";

        static void Main(string[] args)
        {
            Console.WriteLine("Start time : " + DateTime.Now);

            foreach (var city in Citys)
            {
                using (MyHttpClient Client = new MyHttpClient())
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    DateTime now = DateTime.Now;

                    Console.WriteLine(city);
                    var url = SourceHost + "MOTC/v2/Bus/Shape/City/" + city + "?$select=RouteUID%2CRouteName%2CGeometry%2CDirection&$format=JSON";
                    //var url = SourceHost + "MOTC/v2/Bus/Shape/City/Taipei?$filter=RouteID%20%20eq%20%2710142%27&$format=JSON";
                    //string ptxJson = RequestApi(Client, url).Content.ReadAsStringAsync().Result;
                    var ptxJson = RequestApiAsync(() => { return Client.GetAsync(url).Result.Content.ReadAsStringAsync(); }).Result;
                    var wkts = JArray.Parse(ptxJson).Select(a => new PTXWKT
                    {
                        RouteUID = a["RouteUID"].ToString(),
                        RouteName = a["RouteName"]["Zh_tw"].ToString(),
                        Direction = a["Direction"] == null ? null : (Direction?)Enum.Parse(typeof(Direction), a["Direction"].ToString(), true),
                        Type = a["Geometry"].ToString().Substring(0, a["Geometry"].ToString().IndexOf('(')).Trim(),
                        Geometry = a["Geometry"].ToString().Substring(a["Geometry"].ToString().IndexOf('(')).Trim(),
                    });
                    var allIllegalPoints = new List<IllegalPoint>();
                    foreach (var wkt in wkts)
                    {
                        List<LinestringPoint> illegalPoints = null;
                        switch (wkt.Type)
                        {
                            case "LINESTRING":
                                illegalPoints = VerifyLinestring(wkt.RouteName, wkt.Geometry);
                                break;
                            case "MULTILINESTRING":
                                illegalPoints = VerifyMultiline(wkt.RouteName, wkt.Geometry);
                                break;
                            default:
                                throw new Exception();
                        }

                        if (illegalPoints.Count == 0) continue;
                        var illegalPointCollection = illegalPoints.Select(a => new IllegalPoint()
                        {
                            City = city,
                            RouteUID = wkt.RouteUID,
                            RouteName = wkt.RouteName,
                            Direction = wkt.Direction,
                            Type = wkt.Type,
                            LineIndex = a.LineIndex,
                            PointIndex = a.Index,
                            Longitude = a.Longitude,
                            Latitude = a.Latitude,
                        });

                        allIllegalPoints.AddRange(illegalPointCollection);
                        CreateMapReportFile(illegalPointCollection, wkt.Geometry);

                        Console.WriteLine("\t Total:" + (allIllegalPoints.Count));
                    }
                    sw.Stop();
                    CreateReportFile(allIllegalPoints, now, sw.Elapsed);

                    Console.WriteLine(city + " routes verification is Done.");
                }
            }
        }

        public static List<LinestringPoint> VerifyLinestring(string RouteName, string Linestring)
        {
            Dictionary<int, LinestringPoint> nonMatch = new Dictionary<int, LinestringPoint>();

            var coordinates = GetPointsFromLinestring(Linestring);

            using (HttpClient hc = new HttpClient())
            {
                for (int i = 0; i < coordinates.Length / (double)100; i++)
                {
                    int startCoordinateIndex = 0;
                    if (coordinates.Length / (double)100 - i > 1)   //目前欲檢驗的座標數滿100個
                        startCoordinateIndex = i * 100;
                    else if (coordinates.Length > 100)  //欲檢驗的座標數不滿100個，但總座標數超過100個
                        startCoordinateIndex = i * 100 - (100 - coordinates.Length % 100);

                    Console.Write("\r" + RouteName + ":" + startCoordinateIndex + "~" + (startCoordinateIndex + 100) + " / " + coordinates.Length + "\t");

                    string coordinateString = string.Join(";", coordinates.Skip(startCoordinateIndex)
                        .Take(100)
                        .Select(a => a.Longitude.ToString() + "," + a.Latitude.ToString())
                        .ToArray());
                    var url = OSRMHost + "match/v1/car/" + coordinateString;

                    //HttpResponseMessage jsonString = null;
                    //RequestApi(() =>
                    //{
                    //    jsonString = hc.GetAsync(url).Result;
                    //    Console.WriteLine(jsonString);
                    //});

                    var jsonString = RequestApiAsync(() => { return hc.GetAsync(url); }).Result;

                    if (jsonString.StatusCode == HttpStatusCode.BadRequest)
                    {
                        for (int c = 0; c < coordinates.Length; c++)
                        {
                            nonMatch.Add(c, new LinestringPoint()
                            {
                                Index = c,
                                Longitude = coordinates[c].Longitude,
                                Latitude = coordinates[c].Latitude,
                            });
                        }
                    }
                    else
                    {
                        var tracepoints = JObject.Parse(jsonString.Content.ReadAsStringAsync().Result)["tracepoints"].Children().ToList();
                        for (int j = 0; j < tracepoints.Count(); j++)
                        {
                            var index = startCoordinateIndex + j + 1;
                            if (!tracepoints[j].HasValues && !nonMatch.ContainsKey(index))
                            {
                                nonMatch.Add(index, new LinestringPoint()
                                {
                                    Index = index,
                                    Longitude = coordinates[startCoordinateIndex + j].Longitude,
                                    Latitude = coordinates[startCoordinateIndex + j].Latitude,
                                });
                            }
                        }
                    }
                }
                Console.Write("\r" + RouteName + ":" + coordinates.Length + " points--->Done \t Illegal:" + nonMatch.Count);
            }
            return nonMatch.Values.ToList();
        }

        public static List<LinestringPoint> VerifyMultiline(string RouteName, string Multilinestring)
        {
            List<LinestringPoint> nonMatch = new List<LinestringPoint>();
            var linestrings = Multilinestring.Substring(Multilinestring.IndexOf('(') + 1, Multilinestring.LastIndexOf(')') - Multilinestring.IndexOf('(') - 1);
            byte lineIndex = 0;

            while (!string.IsNullOrEmpty(linestrings))
            {
                var linestring = linestrings.Substring(linestrings.IndexOf('('), linestrings.IndexOf(')') - linestrings.IndexOf('(') + 1);
                foreach (var i in VerifyLinestring(RouteName, linestrings))
                {
                    nonMatch.Add(new LinestringPoint()
                    {
                        LineIndex = lineIndex,
                        Index = i.Index,
                        Latitude = i.Latitude,
                        Longitude = i.Longitude,
                    });
                }
                linestrings = linestrings.Substring(linestrings.IndexOf(')') + 1);
                lineIndex++;
            }
            Console.Write("\r" + RouteName + ":" + lineIndex + " lines--->Done \t Illegal:" + nonMatch.Count);
            return nonMatch;
        }

        private static void CreateReportFile(IEnumerable<IllegalPoint> illegalPointsCollection, DateTime StartTime, TimeSpan timeSpan)
        {
            var city = illegalPointsCollection.First().City;
            List<string> textStrings = new List<string>();
            textStrings.Add("城市：" + city);
            textStrings.Add("檢驗日期：" + StartTime.ToString("yyyy/MM/dd hh:mm:ss"));
            textStrings.Add("檢驗耗時：" + timeSpan.ToString());
            textStrings.Add("本次檢驗結果共有" + illegalPointsCollection.Select(a => a.RouteUID).Distinct().Count() + "條路線異常");
            textStrings.Add("");
            textStrings.Add("");

            foreach (var route in illegalPointsCollection.GroupBy(a => new { a.RouteUID, a.RouteName, a.Direction }))
            {
                textStrings.Add("路線名稱：" + route.Key.RouteName);
                textStrings.Add("識別碼：" + route.Key.RouteUID);
                if (route.Key.Direction.HasValue)
                    textStrings.Add("去返程：" + route.Key.Direction.Value.ToString());
                else
                    textStrings.Add("去返程：無資料");

                foreach (var line in route.GroupBy(a => new { a.Type, a.LineIndex }))
                {
                    textStrings.Add("資料格式：" + line.Key.Type);
                    textStrings.Add("線序：" + line.Key.LineIndex);
                    textStrings.Add("座標列：");
                    textStrings.Add("\t點序\t經度\t緯度");

                    foreach (var point in line.Select(a => new { a.PointIndex, a.Longitude, a.Latitude }))
                        textStrings.Add("\t" + point.PointIndex + "\t" + point.Longitude + "\t" + point.Latitude);

                    textStrings.Add("");
                }
            }

            if (!File.Exists(RootPath + city))
                Directory.CreateDirectory(RootPath + city);

            File.WriteAllLines(RootPath + city + @"\" + DateTime.Now.ToString(FileNameFormat) + ".txt", textStrings.ToArray());
        }

        private static void CreateMapReportFile(IEnumerable<IllegalPoint> illegalPoints, string geometry)
        {
            List<List<LinestringPoint>> legality = new List<List<LinestringPoint>>();
            switch (illegalPoints.First().Type)
            {
                case "LINESTRING":
                    legality.Add(GetPointsFromLinestring(geometry).ToList());
                    break;
                case "MULTILINESTRING":
                    var linestrings = geometry.Substring(geometry.IndexOf('(') + 1, geometry.LastIndexOf(')') - geometry.IndexOf('(') - 1);
                    while (!string.IsNullOrEmpty(linestrings))
                    {
                        var linestring = linestrings.Substring(linestrings.IndexOf('('), linestrings.IndexOf(')') - linestrings.IndexOf('(') + 1);
                        legality.Add(GetPointsFromLinestring(linestring).ToList());
                        linestrings = linestrings.Substring(linestrings.IndexOf(')') + 1);
                    }
                    break;
                default:
                    break;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var legalityArray = serializer.Serialize(legality.Select(a => a.Select(b => new { lng = b.Longitude, lat = b.Latitude })));
            var illegalArray = serializer.Serialize(illegalPoints
                .GroupBy(a => a.LineIndex)
                .Select(a => a.Select(b => new { lng = b.Longitude, lat = b.Latitude, index = b.PointIndex }))
                .ToList());

            #region HtmlString
            string html = @"<html>
<head>
    <meta name=""viewport"" content=""initial-scale=1.0, user-scalable=no"">
    <meta charset=""utf-8"">
    <title>" + illegalPoints.First().RouteName + @"</title>
    <style>
        #map {
            height: 100%;
        }

        html,
        body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>
</head>

<body>
    <div id=""map""></div>
    <script>
        function status(response) {
            if (response.url === '/login') {
                return window.location.href = response.url;
            }

            if (response.status >= 200 && response.status < 300) {
                return Promise.resolve(response)
            } else {
                return Promise.reject(new Error(response.statusText))
            }
        }
        function json(response) {
            return response.json()
        }
        function initMap() {

            var legality = " + legalityArray + @";

            var illegality = " + illegalArray + @";

            function getMax(Array, LatLng) {
                return Math.max.apply(Math, Array.map(function (o) {
                    return Math.max.apply(Math, o.map(function (p) { return p[LatLng]; }));
                }));
            }

            function getMin(Array, LatLng) {
                return Math.min.apply(Math, Array.map(function (o) {
                    return Math.min.apply(Math, o.map(function (p) { return p[LatLng]; }));
                }));
            }

            function myLatLng() {

                var MLat = getMax(legality, 'lat') > getMax(illegality, 'lat') ? getMax(legality, 'lat') : getMax(illegality, 'lat');
                var mLat = getMin(legality, 'lat') > getMin(illegality, 'lat') ? getMin(legality, 'lat') : getMin(illegality, 'lat');
                var MLng = getMax(legality, 'lng') > getMax(illegality, 'lng') ? getMax(legality, 'lng') : getMax(illegality, 'lng');
                var mLng = getMin(legality, 'lng') > getMin(illegality, 'lng') ? getMin(legality, 'lng') : getMin(illegality, 'lng');

                var myLatLng = {
                    lat: (MLat + mLat) / 2,
                    lng: (MLng + mLng) / 2,
                }
                return myLatLng;
            };

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 14,
                center: myLatLng()
            });


            for (var i = 0; i < legality.length; i++) {
                var flightPath = new google.maps.Polyline({
                    path: legality[i],
                    geodesic: true,
                    strokeColor: 'block',
                    strokeOpacity: 1.0,
                    strokeWeight: 4
                });
            }

            for (var i = 0; i < illegality.length; i++) {
                for (var j = 0; j < illegality[i].length; j++) {
                    var marker = new google.maps.Marker({
                        position: {
                            lat: illegality[i][j].lat,
                            lng: illegality[i][j].lng
                        },
                        map: map,
                        title: 'LineIndex:' + i + ' ,PointIndex:' + illegality[i][j].index,
                    });
                }
            }

            flightPath.setMap(map);
        }
    </script>
    <script async defer src=""https://maps.googleapis.com/maps/api/js?key=" + GoogleMapKey + @"&callback=initMap"">
    </script>
</body>
</html>";
            #endregion

            if (!File.Exists(RootPath + illegalPoints.First().City))
                Directory.CreateDirectory(RootPath + illegalPoints.First().City);
            File.WriteAllText(RootPath + illegalPoints.First().City + @"\" + VerifyPath(illegalPoints.First().RouteName) + "_" + DateTime.Now.ToString(FileNameFormat) + ".html", html);
        }

        public static LinestringPoint[] GetPointsFromLinestring(string geometry)
        {
            return geometry.Substring(geometry.IndexOf('(') + 1, geometry.IndexOf(')') - geometry.IndexOf('(') - 1)
                       .Split(',')
                       .Select(a => a.Trim().Split(' '))
                       .Select(a => new LinestringPoint { Longitude = double.Parse(a[0]), Latitude = double.Parse(a[1]) })
                       .ToArray();
        }

        public static string VerifyPath(string path)
        {
            return path
                .Replace("\\", "")
                .Replace("/", "")
                .Replace(":", "")
                .Replace("*", "")
                .Replace("?", "")
                .Replace("\"", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }

        public static HttpResponseMessage RequestApi(HttpClient httpClient, string url, int frequency = 5)
        {
            while (frequency > 0)
            {
                try
                {
                    return httpClient.GetAsync(url).Result;
                }
                catch (AggregateException)
                {
                    Thread.Sleep(1000);
                    frequency--;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return null;
        }

        private static void RequestApi(Action func, int frequency = 5)
        {
            while (frequency > 0)
            {
                try
                {
                    func.Invoke();
                    break;
                }
                catch (AggregateException)
                {
                    Thread.Sleep(1000);
                    frequency--;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private static async Task<T> RequestApiAsync<T>(Func<Task<T>> func, int frequency = 5) 
        {
            while (frequency > 0)
            {
                try
                {
                    return await func();
                }
                catch (AggregateException)
                {
                    Thread.Sleep(1000);
                    frequency--;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return default(T);
        }

    }

    class PTXWKT
    {
        public string RouteUID { get; set; }
        public string RouteName { get; set; }
        public Direction? Direction { get; set; }
        public string Type { get; set; }
        public string Geometry { get; set; }
    }

    class IllegalPoint
    {
        public string City { get; set; }
        public string RouteUID { get; set; }
        public string RouteName { get; set; }
        public Direction? Direction { get; set; }
        public byte? LineIndex { get; set; }
        public int PointIndex { get; set; }
        /// <summary>
        /// 經度(120~122)
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 緯度(22~25)
        /// </summary>
        public double Latitude { get; set; }
        public string Type { get; internal set; }
    }

    enum Direction : byte
    {
        去程 = 0,
        返程 = 1,
    }

    class LinestringPoint
    {
        public byte? LineIndex { get; set; }
        public int Index { get; set; }
        /// <summary>
        /// 經度(120~122)
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 緯度(22~25)
        /// </summary>
        public double Latitude { get; set; }
    }
}