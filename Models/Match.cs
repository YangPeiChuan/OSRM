using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public class Match
    {
        /// <summary>
        /// 呼叫服務的結果，若有錯誤message會敘述錯誤內容
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 路線的所有點位的資訊
        /// </summary>
        public Matching[] matchings { get; set; }

        /// <summary>
        /// 將點位Match至實際道路上的路線結果，以路徑點表示
        /// </summary>
        public Tracepoint[] tracepoints { get; set; }
        /// <summary>
        /// 錯誤內容敘述
        /// </summary>
        public string message { get; set; }
    }

    public class Matching: RouteBase
    {
        /// <summary>
        /// Match的信心程度，範圍從0到1，越接近1代表Match的越正確。
        /// </summary>
        public float confidence { get; set; }
           
        /// <summary>
        /// 路線的點位資訊，透過參數"geometries"可選"polyline"、"polyline6"和"geojson"等格式
        /// </summary>
        public string geometry { get; set; }

        /// <summary>
        /// 點位間(coordinates)的路徑資訊，數量會是tracepoints的個數-1
        /// </summary>
        public Leg[] legs { get; set; }

        /// <summary>
        /// The name of the weight profile used during extraction phase.
        /// </summary>
        public string weight_name { get; set; }
    }

    /// <summary>
    /// 兩點位間(coordinates)的路徑(Leg)詳細資訊
    /// </summary>
    public class Leg : RouteBase
    {
        /// <summary>
        /// Annotation of the whole route leg with fine-grained information about each segment or node id.
        /// </summary>
        public Annotation annotation { get; set; }

        /// <summary>
        /// Leg的詳細步驟資訊集合
        /// </summary>
        public StepBase[] steps { get; set; }

        /// <summary>
        /// 採用的路線摘要(路名)，以","分隔
        /// </summary>
        public string summary { get; set; }
    }

    /// <summary>
    /// Annotation of the whole route leg with fine-grained information about each segment or node id.
    /// </summary>
    public class Annotation
    {
        /// <summary>
        /// The OSM node ID for each coordinate along the route, excluding the first/last user-supplied coordinates.
        /// </summary>
        public long[] nodes { get; set; }

        /// <summary>
        /// The index of the datasource for the speed between each pair of coordinates. 0 is the default profile, other values are supplied via --segment-speed-file to osrm-contract
        /// </summary>
        public int[] datasources { get; set; }

        /// <summary>
        /// Convenience field, calculation of distance / duration rounded to one decimal place.
        /// </summary>
        public float[] speed { get; set; }

        /// <summary>
        /// The weights between each pair of coordinates. Does not include any turn costs.
        /// </summary>
        public float[] weight { get; set; }

        /// <summary>
        /// The duration between each pair of coordinates, in seconds. Does not include the duration of any turns.
        /// </summary>
        public float[] duration { get; set; }

        /// <summary>
        /// The distance, in metres, between each pair of coordinates
        /// </summary>
        public float[] distance { get; set; }
    }


    public class StepBase : RouteBase
    {
        /// <summary>
        /// 岔路處資料集
        /// </summary>
        public Intersection[] intersections { get; set; }

        /// <summary>
        /// 移動模式
        /// </summary>
        public string mode { get; set; }

        /// <summary>
        /// 導航詳細資訊
        /// </summary>
        public Maneuver maneuver { get; set; }

        /// <summary>
        /// The name of the way along which travel proceeds.
        /// </summary>
        public string name { get; set; }
    }

    public class StepPolyline: StepBase
    {
        /// <summary>
        /// 以Polyline的方式呈現路線點位
        /// </summary>
        public string geometry { get; set; }
    }

    public class StepGeoJson : StepBase
    {
        /// <summary>
        /// 以GeoJson的方式呈現路線點位
        /// </summary>
        public Geometry geometry { get; set; }
    }

    public class Maneuver
    {
        /// <summary>
        /// 引導點所在座標位址，陣列元素0為經度，陣列元素1為緯度
        /// </summary>
        public float[] location { get; set; }
        /// <summary>
        /// 轉彎前的方位角
        /// </summary>
        public int bearing_before { get; set; }
        /// <summary>
        /// 轉彎後的方位角
        /// </summary>
        public int bearing_after { get; set; }
        /// <summary>
        /// A string indicating the type of maneuver. new identifiers might be introduced without API change Types unknown to the client should be handled like the turn type, the existence of correct modifier values is guranteed.
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 轉彎方式
        /// </summary>
        public string modifier { get; set; }
    }

    /// <summary>
    /// 岔路的詳細資訊
    /// </summary>
    public class Intersection
    {
        /// <summary>
        /// 表示從陣列"bearings"離開的岔路
        /// </summary>
        public int _out { get; set; }
        /// <summary>
        /// 表示陣列"bearings"的岔路是否可駛入，若為"false"代表該岔路為逆向車道不可進入
        /// </summary>
        public bool[] entry { get; set; }
        /// <summary>
        /// 該路口各岔路的方位角
        /// </summary>
        public int[] bearings { get; set; }
        /// <summary>
        /// 岔路所在座標位址，陣列元素0為經度，陣列元素1為緯度
        /// </summary>
        public float[] location { get; set; }
        /// <summary>
        /// 表示從陣列"bearings"前進的岔路
        /// </summary>
        public int _in { get; set; }
    }

    public class Tracepoint
    {
        /// <summary>
        /// 此點可能替代的匹配點數量，若為0表示匹配結果非常明確
        /// </summary>
        public int alternatives_count { get; set; }
        /// <summary>
        /// 點位順序
        /// </summary>
        public int waypoint_index { get; set; }
        /// <summary>
        /// 路徑點座標位址，陣列元素0為經度，陣列元素1為緯度
        /// </summary>
        public float[] location { get; set; }
        /// <summary>
        /// 點位所在路名
        /// </summary>
        public string name { get; set; }
        public string hint { get; set; }
        public int matchings_index { get; set; }
    }
}
