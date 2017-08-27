using System;
namespace Hstar.Wechat.Pay.Helpers
{
    public static class RandomHelper
    {
        /// <summary>
        /// 利用GUID生成随机字符串
        /// </summary>
        /// <returns></returns>
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
