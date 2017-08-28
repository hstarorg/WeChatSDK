using Hstar.Wechat.Pay.Base;
using Hstar.Wechat.Pay.Entities;
using Hstar.Wechat.Pay.Enums;
using Hstar.Wechat.Pay.Helpers;
using System.Threading.Tasks;

namespace Hstar.Wechat.Pay
{
    public class WechatPayClient
    {
        /// <summary>
        /// 支付基础信息（appId,appSecret,mchId,key等）
        /// </summary>
        private readonly WechatPayBaseInfo PAY_BASE_INFO;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appId">公众账号ID</param>
        /// <param name="appSecret">APPID唯一凭证密钥</param>
        /// <param name="mchId">商户号</param>
        /// <param name="key">商户支付密钥Key，在商户平台（https://pay.weixin.qq.com）可以拿到</param>
        /// <param name="notifyUrl">通知URL地址，不能带参数</param>
        public WechatPayClient(string appId, string appSecret, string mchId, string key, string notifyUrl)
        {
            this.PAY_BASE_INFO = new WechatPayBaseInfo(appId, appSecret, mchId, key, notifyUrl);
        }

        /// <summary>
        /// 微信统一下单API
        /// 文档地址：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_1
        /// </summary>
        public void UnifiedOrder()
        {

        }

        /// <summary>
        /// 根据订单号（微信订单号、商户订单号二选一，优先微信订单号）查询订单信息
        /// 文档地址：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_2
        /// </summary>
        /// <param name="orderNumber">订单号码，支持微信订单号与商户订单号，优先微信订单号</param>
        /// <param name="nonceStr">随机字符串，默认null，自动生成</param>
        /// <param name="orderNoType">订单号类型，默认微信订单号</param>
        /// <param name="signType">签名类型（默认MD5）</param>
        public async Task<QueryOrderResponse> QueryOrder(string orderNumber, string nonceStr = null, OrderNumberType orderNoType = OrderNumberType.WechatOrderNumber, SignType signType = SignType.MD5)
        {
            var queryOrderReq = new QueryOrderRequest()
            {
                NonceStr = nonceStr ?? RandomHelper.GenerateNonceStr(),
                SignType = signType
            };
            if (orderNoType == OrderNumberType.MerchantOrderNumber)
            {
                queryOrderReq.OutTradeNo = orderNumber;
            }
            else
            {
                queryOrderReq.TransactionId = orderNumber;
            }
            return await WechatPayHelper.QueryOrder(PAY_BASE_INFO, queryOrderReq);
        }

        /// <summary>
        /// 关闭订单API
        /// 文档地址：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_3
        /// </summary>
        public void CloseOrder()
        {

        }

        /// <summary>
        /// 退款API
        /// 文档地址：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_4
        /// </summary>
        public void Refund()
        {

        }

        /// <summary>
        /// 查询退款API
        /// 文档地址：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_5
        /// </summary>
        public void QueryRefund()
        {

        }

        /// <summary>
        /// 下载对账单API
        /// 文档地址：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_6
        /// </summary>
        public void DownloadBill()
        {

        }

        /// <summary>
        /// 上报请求信息API
        /// 文档地址：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_8
        /// </summary>
        public void Report()
        {

        }

        /// <summary>
        /// 批量查询订单评论数据
        /// 文档地址：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_17&index=10
        /// </summary>
        public void BatchQueryComment()
        {

        }
    }
}
