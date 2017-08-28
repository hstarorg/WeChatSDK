namespace Hstar.Wechat.Pay.Base
{
    public class WechatPayBaseInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appId">APP ID</param>
        /// <param name="appSecret">APP Secret</param>
        /// <param name="mchId">商户ID</param>
        /// <param name="key">商户KEY</param>
        /// <param name="notifyUrl">回调URL</param>
        public WechatPayBaseInfo(string appId, string appSecret, string mchId, string key, string notifyUrl)
        {
            this.AppId = appId;
            this.AppSecret = appSecret;
            this.MchId = mchId;
            this.Key = key;
            this.NotifyUrl = notifyUrl;
        }
        /// <summary>
        /// AppID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// AppID对应的App Secret
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 商户支付KEY
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 通知url，必须为直接可访问的url
        /// </summary>
        public string NotifyUrl { get; set; }
    }
}
