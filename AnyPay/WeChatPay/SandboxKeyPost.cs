using AnyPay.Common;
using AnyPay.Models;
using System.Collections.Generic;

namespace AnyPay.WeChatPay
{
    public class SandboxKeyPost : WeChatPostBase<SandboxKeyResult>
    {
        public override string PostUrl => $"{BaseUrl}/pay/getsignkey";

        public SandboxKeyPost(Merchant merchant) : base(merchant, new PayRequest())
        {
        }

        protected override void InitParams()
        {
            PayParams.Clear();

            PayParams
                .SafeAdd("mch_id", m_Merchant.Id)
                .SafeAdd("nonce_str", GenerateNonceString());

            var sign = PayParams.ToSortDict().WechatSign(m_Merchant.ApiSecret);
            PayParams.SafeAdd("sign", sign);
        }

        protected override void AddBizParams()
        {
        }

        protected override bool CheckResult(SortedDictionary<string, string> dict)
        {
            dict.TryGetValue("sandbox_signkey", out var signkey);
            return !string.IsNullOrEmpty(signkey);
        }

        protected override void SetSucceededResult(SortedDictionary<string, string> dict, SandboxKeyResult result)
        {
            dict.TryGetValue("sandbox_signkey", out var signkey);
            result.Signkey = signkey;
        }
    }
}
