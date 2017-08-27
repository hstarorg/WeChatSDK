namespace Hstar.Wechat.Pay.Base
{
    public class WechatPayBaseInfo
    {
        public WechatPayBaseInfo(string appId, string appSecret, string mchId, string key)
        {
            this.AppId = appId;
            this.AppSecret = appSecret;
            this.MchId = mchId;
            this.Key = key;
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
    }
}
