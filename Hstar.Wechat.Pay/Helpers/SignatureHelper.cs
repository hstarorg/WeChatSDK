using Hstar.Wechat.Pay.Enums;
using Hstar.Wechat.Pay.Extensions;

namespace Hstar.Wechat.Pay.Helpers
{
    public static class SignatureHelper
    {
        public static string CalcSignature(string wechatPayDataStr, string key, SignType signType = SignType.MD5)
        {
            var tempStr = $"{wechatPayDataStr}&key={key}";//注：key为商户平台设置的密钥key
            return signType == SignType.MD5 ? tempStr.ToMd5String() : tempStr.ToHMACSHA256String(key);
        }
    }
}
