﻿namespace Hstar.Wechat.Pay.Enums
{
    public enum TradeState
    {
        /// <summary>
        /// 支付成功
        /// </summary>
        SUCCES,

        /// <summary>
        /// 转入退款
        /// </summary>
        REFUND,

        /// <summary>
        /// 未支付
        /// </summary>
        NOTPAY,

        /// <summary>
        /// 已关闭
        /// </summary>
        CLOSED,

        /// <summary>
        /// 已撤销（刷卡支付）
        /// </summary>
        REVOKED,

        /// <summary>
        /// 用户支付中
        /// </summary>
        USERPAYING,

        /// <summary>
        /// 支付失败(其他原因，如银行返回失败)
        /// </summary>
        PAYERROR
    }
}
