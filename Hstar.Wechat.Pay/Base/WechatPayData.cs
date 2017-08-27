using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Hstar.Wechat.Pay.Base
{
    public class WechatPayData
    {
        private readonly Type typeInt = typeof(int);
        private readonly Type typeString = typeof(string);
        private readonly SortedDictionary<string, object> values = new SortedDictionary<string, object>();

        /// <summary>
        /// 设置字符串值
        /// </summary>
        /// <param name="key">KEY</param>
        /// <param name="value">VALUE</param>
        public bool SetStringValue(string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            this.values[key] = value;
            return true;
        }

        /// <summary>
        /// 获取字符串值
        /// </summary>
        /// <param name="key">KEY</param>
        /// <returns></returns>
        public string GetStringValue(string key)
        {
            object result = null;
            this.values.TryGetValue(key, out result);
            return result as string;
        }

        /// <summary>
        /// 设置整型值
        /// </summary>
        /// <param name="key">KEY</param>
        /// <param name="value">VALUE</param>
        /// <returns></returns>
        public bool SetIntValue(string key, int value)
        {
            this.values[key] = value;
            return true;
        }

        /// <summary>
        /// 获取整型值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetIntValue(string key)
        {
            object result = null;
            this.values.TryGetValue(key, out result);
            return Convert.ToInt32(result);
        }
        /// <summary>
        /// 是否设置了某个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsSetKey(string key)
        {
            return this.values.ContainsKey(key);
        }

        /// <summary>
        /// 将数据转换为XML字符串
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            var builder = new StringBuilder();
            if (this.values.Count == 0)
            {
                throw new WechatPayException("WechatPay数据为空!");
            }
            builder.Append("<xml>");
            foreach (var kv in this.values)
            {
                var valueType = kv.Value.GetType();
                if (valueType == typeInt)
                {
                    builder.Append($"<{kv.Key}>{kv.Value}</{kv.Key}>");
                }
                else if (valueType == typeString)
                {
                    builder.Append($"<{kv.Key}><![CDATA[{kv.Value}]]></{kv.Key}>");
                }
            }
            builder.Append("</xml>");
            return builder.ToString();
        }

        /// <summary>
        /// 转换为URL参数形式（k=v格式）
        /// </summary>
        /// <returns></returns>
        public string ToUrlParams()
        {
            var kvArr = this.values
                .Where(x => x.Key != "sign")
                .Select(x => $"{x.Key}={x.Value}")
                .ToArray();
            return string.Join("&", kvArr);
        }

        public SortedDictionary<string, object> FromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new WechatPayException("将空的xml串转换为WxPayData不合法!");
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                this.values[xe.Name] = xe.InnerText;//获取xml的键值对到WxPayData内部的数据中
            }
            return this.values;
        }
    }
}
