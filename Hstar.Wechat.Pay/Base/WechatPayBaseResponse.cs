using System;
using System.Collections.Generic;
using System.Text;

namespace Hstar.Wechat.Pay.Base
{
    public class WechatPayBaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }
    }
}
