using Hstar.Wechat.Pay.Base;
using Hstar.Wechat.Pay.Enums;
using Hstar.Wechat.Pay.Extensions;
using System;
using System.Xml.Serialization;

namespace Hstar.Wechat.Pay.Entities
{
    [XmlRoot("xml")]
    public class QueryOrderResponse : WechatPayBaseResponse
    {
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 用户在商户appid下的唯一标识
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        #region 是否关注

        /// <summary>
        /// 用户是否关注公众账号
        /// </summary>
        [XmlElement("is_subscribe")]
        public string IsSubscribeStr { get; set; }

        /// <summary>
        /// 用户是否关注公众账号
        /// </summary>
        public bool IsSubscribe
        {
            get
            {
                return this.IsSubscribeStr == "Y";
            }
        }

        #endregion

        #region 交易类型
        /// <summary>
        /// 支付/交易类型
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeTypeStr { get; set; }

        /// <summary>
        /// 支付/交易类型
        /// </summary>
        public TradeType? TradeType
        {
            get
            {
                return this.TradeTypeStr.ToEnum<TradeType>();
            }
        }

        #endregion

        #region 交易状态
        /// <summary>
        /// 交易状态
        /// </summary>
        [XmlElement("trade_state")]
        public string TradeStateStr { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public TradeState? TradeState
        {
            get
            {
                return this.TradeStateStr.ToEnum<TradeState>();
            }
        }

        #endregion

        /// <summary>
        /// 银行类型，采用字符串类型的银行标识
        /// </summary>
        [XmlElement("bank_type")]
        public string BankType { get; set; }

        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 当订单使用了免充值型优惠券后返回该参数，应结订单金额=订单金额-免充值优惠券金额。
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public int SettlementTotalFee { get; set; }

        #region 标价币种
        /// <summary>
        /// 标价币种
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeTypeStr { get; set; }

        /// <summary>
        /// 标价币种
        /// </summary>
        public CurrencyType? FeeType
        {
            get
            {
                return this.FeeTypeStr.ToEnum<CurrencyType>();
            }
        }
        #endregion

        /// <summary>
        /// 现金支付金额订单现金支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public int CashFee { get; set; }

        #region 现金支付币种

        /// <summary>
        /// 现金支付币种
        /// </summary>
        [XmlElement("cash_fee_type")]
        public string CashFeeTypeStr { get; set; }

        /// <summary>
        /// 现金支付币种
        /// </summary>
        public CurrencyType? CashFeeType
        {
            get
            {
                return this.CashFeeTypeStr.ToEnum<CurrencyType>();
            }
        }

        #endregion

        /// <summary>
        /// 代金券金额
        /// </summary>
        [XmlElement("coupon_fee")]
        public int? CouponFee { get; set; }

        /// <summary>
        /// 代金券使用数量
        /// </summary>
        [XmlElement("coupon_count")]
        public int CouponCount { get; set; } = 0;

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 附加数据，原样返回
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }

        #region 支付完成时间
        /// <summary>
        /// 支付完成时间
        /// </summary>
        [XmlElement("time_end")]
        public string TimeEndStr { get; set; }

        /// <summary>
        /// 支付完成时间
        /// </summary>
        public DateTime TimeEnd
        {
            get
            {
                return new DateTime();
            }
        }

        #endregion

        /// <summary>
        /// 交易状态描述
        /// </summary>
        [XmlElement("trade_state_desc")]
        public string TradeStateDesc { get; set; }
    }
}
