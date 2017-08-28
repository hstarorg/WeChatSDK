using Hstar.Wechat.Pay.Base;
using Hstar.Wechat.Pay.Entities;
using System;
using System.Threading.Tasks;

namespace Hstar.Wechat.Pay.Helpers
{
    public static class WechatPayHelper
    {
        public static async Task<QueryOrderResponse> QueryOrder(WechatPayBaseInfo payBaseInfo, QueryOrderRequest req)
        {
            var payData = new WechatPayData();
            payData.SetStringValue("appid", payBaseInfo.AppId);
            payData.SetStringValue("mch_id", payBaseInfo.MchId);
            if (!string.IsNullOrEmpty(req.TransactionId))
            {
                payData.SetStringValue("transaction_id", req.TransactionId);
            }
            else
            {
                payData.SetStringValue("out_trade_no", req.OutTradeNo);
            }
            payData.SetStringValue("nonce_str", req.NonceStr);
            payData.SetStringValue("sign_type", req.SignType == Enums.SignType.MD5 ? "MD5" : "HMAC-SHA256");
            var sign = SignatureHelper.CalcSignature(payData.ToUrlParams(), payBaseInfo.Key, req.SignType);
            payData.SetStringValue("sign", sign);
            var orderQueryRes = await HttpClientHelper.Post<QueryOrderResponse>("https://api.mch.weixin.qq.com/pay/orderquery", payData.ToXml());
            return orderQueryRes;
        }
    }
}
