using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Reporter
{
    public class MyHttpClient : HttpClient
    {
        public MyHttpClient() : base(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip })
        {
            string APPID = "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF";
            string APPKey = "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF";
            string xdate = DateTime.Now.ToUniversalTime().ToString("r");

            Encoding _encode = Encoding.GetEncoding("utf-8");
            byte[] _byteData = Encoding.GetEncoding("utf-8").GetBytes("x-date: " + xdate);
            HMACSHA1 _hmac = new HMACSHA1(_encode.GetBytes(APPKey));
            using (CryptoStream _cs = new CryptoStream(Stream.Null, _hmac, CryptoStreamMode.Write))
            {
                _cs.Write(_byteData, 0, _byteData.Length);
            }
            string Signature = Convert.ToBase64String(_hmac.Hash);

            string sAuth = "hmac username=\"" + APPID + "\", algorithm=\"hmac-sha1\", headers=\"x-date\", signature=\"" + Signature + "\"";

            DefaultRequestHeaders.Add("Authorization", sAuth);
            DefaultRequestHeaders.Add("x-date", xdate);
            Timeout = new TimeSpan(0, 0, 30);
        }
    }
}
