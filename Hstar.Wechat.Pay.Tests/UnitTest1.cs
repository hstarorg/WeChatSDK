using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hstar.Wechat.Pay.Base;
using Hstar.Wechat.Pay.Helpers;
using Hstar.Wechat.Pay.Enums;

namespace Hstar.Wechat.Pay.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Description("测试获取订单信息API")]
        public void TestMethod1()
        {
            var wxOrderNo = "4004282001201708166560792958"; // 微信订单号
            //var mchOrderNo = "1006136120170816171957273"; // 商户订单号
            var payClient = new WechatPayClient(BaseConfig.AppId, BaseConfig.AppSecret, BaseConfig.MchId, BaseConfig.Key, BaseConfig.NotifyUrl);
            var res = payClient.QueryOrder(wxOrderNo).Result;
            Assert.IsNotNull(res);
            Assert.AreEqual(TradeType.JSAPI, res.TradeType);
            Assert.AreEqual(CurrencyType.CNY, res.FeeType);
        }

        [TestMethod]
        [Description("测试MD5签名算法是否OK")]
        public void TestMd5Signature()
        {
            var data = new WechatPayData();
            data.SetStringValue("appid", BaseConfig.AppId);
            data.SetStringValue("mch_id", BaseConfig.MchId);
            var md5Str = SignatureHelper.CalcSignature(data.ToUrlParams(), BaseConfig.Key);
            Assert.AreEqual<string>("9F64710000181B60AC5743C94455D2CB", md5Str);
        }

        [TestMethod]
        [Description("测试SHA256签名算法是否OK")]
        public void TestSHA256Signature()
        {
            var data = new WechatPayData();
            data.SetStringValue("appid", BaseConfig.AppId);
            data.SetStringValue("mch_id", BaseConfig.MchId);
            var sha256Str = SignatureHelper.CalcSignature(data.ToUrlParams(), BaseConfig.Key, SignType.SHA256);
            Assert.AreEqual<string>("81E64AC5312645C3DC7D3F55C358C8A0F8838FD28BF9C6A80A95BBAC87EC6CBD", sha256Str);
        }
    }
}
