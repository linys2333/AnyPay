namespace AnyPay.Models
{
    public class Order
    {
        /// <summary>
        /// 商户订单号，String(32)
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 商品ID，二维码支付必传，String(32)
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 商品描述，String(128)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
        public int Amount { get; set; }
    }
}
