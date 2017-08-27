using Hstar.Wechat.Pay.Enums;
using System.Security.Cryptography;
using System.Text;

namespace Hstar.Wechat.Pay.Helpers
{
    public static class SignatureHelper
    {
        public static string CalcSignature(string wechatPayDataStr, string key, SignType signType = SignType.MD5)
        {
            var tempStr = $"{wechatPayDataStr}&key={key}";//注：key为商户平台设置的密钥key
            return signType == SignType.MD5 ? CalcMd5Signature(tempStr) : CalcSHA256Signature(tempStr, key);
        }

        private static string CalcMd5Signature(string str, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(encoding.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToUpper();
        }

        private static string CalcSHA256Signature(string str, string key, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var hash = new HMACSHA256(encoding.GetBytes(key));
            var bs = hash.ComputeHash(encoding.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToUpper();
        }
    }
}
