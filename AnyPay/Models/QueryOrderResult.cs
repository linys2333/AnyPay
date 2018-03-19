namespace AnyPay.Models
{
    public class QueryOrderResult : PayResponse
    {
        /// <summary>
        /// 支付平台订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string TradeState { get; set; }

        /// <summary>
        /// 交易状态描述
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// 货币类型，默认人民币：CNY
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        /// 现金支付金额，单位为分
        /// </summary>
        public int CashFee { get; set; }

        /// <summary>
        /// 应结订单金额，单位为分
        /// </summary>
        public int SettlementTotalFee { get; set; }

        /// <summary>
        /// 代金券金额，单位为分
        /// </summary>
        public int CouponFee { get; set; }
    }
}
