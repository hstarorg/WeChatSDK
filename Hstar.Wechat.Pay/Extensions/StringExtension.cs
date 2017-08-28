using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Hstar.Wechat.Pay.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 将XML字符串转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ConvertXmlToObject<T>(this string str) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var reader = new StringReader(str);
            return serializer.Deserialize(reader) as T;
        }

        /// <summary>
        /// 计算字符串的MD5值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">[可选]设置字符串编码，默认UTF8</param>
        /// <returns></returns>
        public static string ToMd5String(this string str, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var md5 = MD5.Create();
            var bytes = md5.ComputeHash(encoding.GetBytes(str));
            return bytes.ToHexString(true);
        }

        /// <summary>
        /// 计算字符串的HMACSHA256值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key">HMACSHA256的KEY</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToHMACSHA256String(this string str, string key, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var hash = new HMACSHA256(encoding.GetBytes(key));
            var bytes = hash.ComputeHash(encoding.GetBytes(str));
            return bytes.ToHexString(true);
        }

        /// <summary>
        /// 将字符串转换为指定的枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T? ToEnum<T>(this string str) where T : struct
        {
            T t;
            if (Enum.TryParse(str, out t))
            {
                return t;
            }
            return null;
        }
    }
}
