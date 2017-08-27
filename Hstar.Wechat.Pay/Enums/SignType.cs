using System;
using System.Collections.Generic;
using System.Text;

namespace Hstar.Wechat.Pay.Enums
{
    /// <summary>
    /// 签名类型（签名算法类型）
    /// </summary>
    public enum SignType
    {
        /// <summary>
        /// MD5签名算法
        /// </summary>
        MD5 = 0,

        /// <summary>
        /// HMAC-SHA256签名算法
        /// </summary>
        SHA256 = 1
    }
}
