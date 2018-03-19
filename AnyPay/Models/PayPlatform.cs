namespace AnyPay.Models
{
    /// <summary>
    /// 支付平台
    /// </summary>
    public class PayPlatform
    {
        public PayPlatform()
        {
            Merchant = new Merchant();
        }
        
        /// <summary>
        /// 支付类型：0 - 微信，1 - 支付宝
        /// </summary>
        public PayChannel PayChannel { get; set; }
        
        /// <summary>
        /// 商户信息
        /// </summary>
        public Merchant Merchant { get; set; }
    }
}
