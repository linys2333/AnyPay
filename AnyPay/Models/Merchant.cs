namespace AnyPay.Models
{
    /// <summary>
    /// 商户信息
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 公众账号ID或应用APPID
        /// </summary>
        public string AppId { get; set; }
        
        /// <summary>
        /// 商户API密钥
        /// </summary>
        public string ApiSecret { get; set; }

        /// <summary>
        /// 沙箱API密钥
        /// </summary>
        public string SandboxKey { get; set; }

        /// <summary>
        /// 是否沙箱环境
        /// </summary>
        public bool IsSandbox { get; set; } = true;

        /// <summary>
        /// 签名Key，签名算法请使用该字段
        /// </summary>
        public string SignKey => IsSandbox ? SandboxKey : ApiSecret;
    }
}
