using Security;
using System;
using System.Net;
using System.Net.Http;

namespace Parctice
{
    public class MyHttpClient : HttpClient
    {
        public MyHttpClient() : base(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip })
        {
            string APPID = "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF";
            string APPKey = "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF";
            string xdate = DateTime.Now.ToUniversalTime().ToString("r");
            string SignDate = "x-date: " + xdate;
            string Signature = HMAC_SHA1.Signature(SignDate, APPKey);
            string sAuth = "hmac username=\"" + APPID + "\", algorithm=\"hmac-sha1\", headers=\"x-date\", signature=\"" + Signature + "\"";

            DefaultRequestHeaders.Add("Authorization", sAuth);
            DefaultRequestHeaders.Add("x-date", xdate);
        }
    }
}
