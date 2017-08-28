using Hstar.Wechat.Pay.Extensions;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hstar.Wechat.Pay.Helpers
{
    public static class HttpClientHelper
    {
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }

        /// <summary>
        /// 发起POST请求，获取返回结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">要请求的地址</param>
        /// <param name="xml">要提交的数据，xml字符串</param>
        /// <returns></returns>
        public static async Task<T> Post<T>(string url, string xml) where T : class
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(xml, Encoding.UTF8, "text/xml"); // CONTENT-TYPE header
            try
            {
                var res = await client.SendAsync(request);
                var resString = await res.Content.ReadAsStringAsync();
                return resString.ConvertXmlToObject<T>();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// 发起GET请求，获取返回结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">要请求的地址</param>
        /// <returns></returns>
        public static async Task<T> Get<T>(string url) where T : class
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            try
            {
                var res = await client.SendAsync(request);
                var resString = await res.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return null;
        }
    }
}
