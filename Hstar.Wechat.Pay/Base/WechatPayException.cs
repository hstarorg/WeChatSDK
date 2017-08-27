using System;

namespace Hstar.Wechat.Pay.Base
{
    public class WechatPayException : Exception
    {
        /// <summary>
        /// 记录微信支付异常
        /// </summary>
        /// <param name="msg"></param>
        public WechatPayException(string msg) : base(msg)
        {

        }
    }
}
