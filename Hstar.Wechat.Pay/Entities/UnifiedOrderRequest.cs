using Hstar.Wechat.Pay.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hstar.Wechat.Pay.Entities
{
    public class UnifiedOrderRequest
    {
        /// <summary>
        /// nonce_str，随机字符串 String(32)
        /// 随机字符串，长度要求在32位以内
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// sign，签名 String(32)
        /// 通过签名算法计算得出的签名值
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// body，商品描述 String(128)
        /// 商品简单描述
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// out_trade_no 商户订单号 String(32)
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一
        /// </summary>
        public string OutTradeNO { get; set; }

        /// <summary>
        /// total_fee 标价金额 Int
        /// 订单总金额，单位为分
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        /// spbill_create_ip 终端IP String(16)
        /// APP和网页支付提交用户端ip，Native支付填调用微信支付API的机器IP
        /// </summary>
        public string SpbillCreateIp { get; set; }

        /// <summary>
        /// notify_url 通知地址 String(256)
        /// 异步接收微信支付结果通知的回调地址，通知url必须为外网可访问的url，不能携带参数
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// trade_type 交易类型 String(16)
        /// 取值如下：JSAPI，NATIVE，APP等
        /// </summary>
        public TradeType TradeType { get; set; }

        /// <summary>
        /// 场景信息
        /// </summary>
        public SceneInfo SceneInfo { get; set; }

        /// <summary>
        /// device_info 设备号 String(32)
        /// 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// sign_type 签名类型 String(32)
        /// 签名类型，默认为MD5，支持HMAC-SHA256和MD5。
        /// </summary>
        public SignType SignType { get; set; } = SignType.MD5;

        /// <summary>
        /// detail 商品详情 String(6000)
        /// 商品详细描述，对于使用单品优惠的商户，改字段必须按照规范上传
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// attach 附加数据 String(127)
        /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用
        /// </summary>
        public string Attach { get; set; }

        /// <summary>
        /// fee_type 标价币种 String(16)
        /// 符合ISO 4217标准的三位字母代码
        /// </summary>
        public CurrencyType FeeType { get; set; } = CurrencyType.CNY;

        /// <summary>
        /// time_start 交易起始时间 String(14)
        /// 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010
        /// </summary>
        public DateTime OrderStartTime { get; set; }

        /// <summary>
        /// time_expire 交易结束时间 String(14)
        /// 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010，最短失效时间间隔必须大于5分钟
        /// </summary>
        public DateTime OrderExpireTime { get; set; }

        public string goods_tag { get; set; }

        /// <summary>
        /// product_id 商品ID String(32)
        /// trade_type=NATIVE时（即扫码支付），此参数必传。此参数为二维码中包含的商品ID，商户自行定义。
        /// </summary>
        public string product_id { get; set; }

        /// <summary>
        /// limit_pay 指定支付方式 String(32)
        /// 上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        public string LimitPay { get; set; }

        /// <summary>
        /// openid 用户标识 String(128) trade_type=JSAPI时（即公众号支付），此参数必传，此参数为微信用户在商户对应appid下的唯一标识
        /// </summary>
        public string OpenId { get; set; }
    }
}
