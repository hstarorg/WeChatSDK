namespace Hstar.Wechat.Pay.Enums
{
    public enum OrderNumberType
    {
        /// <summary>
        /// 微信订单号（由微信生成，优先）
        /// </summary>
        WechatOrderNumber = 0,

        /// <summary>
        /// 商户订单号（由业务程序生成）
        /// </summary>
        MerchantOrderNumber = 1
    }
}
