namespace Hstar.Wechat.Pay.Enums
{
    public enum TradeType
    {
        /// <summary>
        /// 公众号支付
        /// </summary>
        JSAPI,

        /// <summary>
        /// 原生扫码支付
        /// </summary>
        NATIVE,

        /// <summary>
        /// app支付 
        /// </summary>
        APP,

        /// <summary>
        /// 刷卡支付
        /// </summary>
        MICROPAY
    }
}
