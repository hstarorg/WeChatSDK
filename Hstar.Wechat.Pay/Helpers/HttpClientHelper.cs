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

        public static async Task<HttpResponseMessage> Post(string url, string xml)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(xml, Encoding.UTF8, "text/xml"); // CONTENT-TYPE header
            try
            {
                var res = await client.SendAsync(request);
                return res;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return null;
        }
    }
}
