namespace Hstar.Wechat.Pay.Entities
{
    public class SceneInfo
    {
        /// <summary>
        /// id 门店id String(32)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// name 门店名称 String(64)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// area_code 门店行政区划码 String(6)
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// address 门店详细地址 String(128)
        /// </summary>
        public string Address { get; set; }
    }
}
