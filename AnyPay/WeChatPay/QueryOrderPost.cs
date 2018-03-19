using AnyPay.Common;
using AnyPay.Models;
using System.Collections.Generic;

namespace AnyPay.WeChatPay
{
    public class QueryOrderPost : WeChatPostBase<QueryOrderResult>
    {
        public override string PostUrl => $"{BaseUrl}/pay/orderquery";

        public QueryOrderPost(Merchant merchant, PayRequest request) : base(merchant, request)
        {
        }
        
        protected override void AddBizParams()
        {
            PayParams
                .SafeAdd("out_trade_no", m_PayRequest.Order.OrderId);
        }

        protected override void SetSucceededResult(SortedDictionary<string, string> dict, QueryOrderResult result)
        {
            dict.TryGetValue("transaction_id", out var transactionId);
            dict.TryGetValue("out_trade_no", out var orderId);
            dict.TryGetValue("trade_state", out var tradeState);
            dict.TryGetValue("trade_state_desc", out var stateDescription);
            dict.TryGetValue("fee_type", out var feeType);
            dict.TryGetValue("total_fee", out var totalFee);
            dict.TryGetValue("cash_fee", out var cashFee);
            dict.TryGetValue("settlement_total_fee", out var settlementTotalFee);
            dict.TryGetValue("coupon_fee", out var couponFee);

            result.TransactionId = transactionId;
            result.OrderId = orderId;
            result.TradeState = tradeState;
            result.StateDescription = stateDescription;
            result.FeeType = feeType;
            result.TotalFee = totalFee.ConvertType<int>();
            result.CashFee = cashFee.ConvertType<int>();
            result.SettlementTotalFee = settlementTotalFee.ConvertType<int>();
            result.CouponFee = couponFee.ConvertType<int>();
        }
    }
}
