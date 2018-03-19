namespace AnyPay.Models
{
    /// <summary>
    /// 支付请求
    /// </summary>
    public class PayRequest
    {
        public PayRequest()
        {
            Order = new Order();
        }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIp { get; set; }

        /// <summary>
        /// 支付回调地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 交易类型：0 - App，1 - 二维码
        /// </summary>
        public TradeType TradeType { get; set; }

        /// <summary>
        /// 订单信息
        /// </summary>
        public Order Order { get; set; }
    }
}
