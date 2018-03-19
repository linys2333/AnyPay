using AnyPay.Common;
using AnyPay.Models;
using System.Collections.Generic;

namespace AnyPay.WeChatPay
{
    public class CreateOrderPost : WeChatPostBase<CreateOrderResult>
    {
        public override string PostUrl => $"{BaseUrl}/pay/unifiedorder";

        public CreateOrderPost(Merchant merchant, PayRequest request) : base(merchant, request)
        {
        }

        private string GetTradeType(TradeType tradeType)
        {
            switch (tradeType)
            {
                case TradeType.App:
                    return "APP";
                case TradeType.QRCode:
                    return "NATIVE";
                default:
                    return string.Empty;
            }
        }

        protected override void AddBizParams()
        {
            PayParams
                .SafeAdd("body", m_PayRequest.Order.Description)
                .SafeAdd("out_trade_no", m_PayRequest.Order.OrderId)
                .SafeAdd("total_fee", m_PayRequest.Order.Amount.ToString())
                .SafeAdd("spbill_create_ip", m_PayRequest.ClientIp)
                .SafeAdd("notify_url", m_PayRequest.NotifyUrl)
                .SafeAdd("trade_type", GetTradeType(m_PayRequest.TradeType))
                .SafeAdd("product_id", m_PayRequest.Order.ProductId);
        }

        protected override void SetSucceededResult(SortedDictionary<string, string> dict, CreateOrderResult result)
        {
            dict.TryGetValue("prepay_id", out var prepayId);
            dict.TryGetValue("nonce_str", out var nonceStr);
            dict.TryGetValue("code_url", out var codeUrl);

            result.AppId = m_Merchant.AppId;
            result.MerchantId = m_Merchant.Id;
            result.PrePayId = prepayId;
            result.Package = "Sign=WXPay";
            result.NonceStr = nonceStr;
            result.Timestamp = GenerateTimestamp();
            result.CodeUrl = codeUrl;

            result.Sign = result.ToSortDict().WechatSign(m_Merchant.SignKey);
        }
    }
}
