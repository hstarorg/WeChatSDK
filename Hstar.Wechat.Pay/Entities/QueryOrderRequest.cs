using Hstar.Wechat.Pay.Enums;
namespace Hstar.Wechat.Pay.Entities
{
    public class QueryOrderRequest
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        public string NonceStr { get; set; }

        public string Sign { get; set; }

        public SignType SignType { get; set; }
    }
}
