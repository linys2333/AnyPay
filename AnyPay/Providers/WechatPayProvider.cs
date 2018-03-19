using AnyPay.Common;
using AnyPay.Interfaces;
using AnyPay.Models;
using AnyPay.WeChatPay;
using System;
using System.Threading.Tasks;

namespace AnyPay.Providers
{
    internal class WechatPayProvider : PayBase, IPayProvider
    {
        public WechatPayProvider(PayPlatform payPlatform) : base(payPlatform)
        {
        }

        public async Task InitSandboxAsync()
        {
            var merchant = m_PayPlatform.Merchant;
            if (merchant.IsSandbox)
            {
                var result = await new SandboxKeyPost(merchant).PostAsync();
                if (result.Succeeded)
                {
                    merchant.SandboxKey = result.Signkey;
                }
                else
                {
                    throw new Exception($"沙箱环境初始化失败：{result.ErrorMessage}");
                }
            }
        }
        
        public async Task<CreateOrderResult> CreateOrderAsync(PayRequest request)
        {
            Require.NotNull(request, nameof(request));

            var post = new CreateOrderPost(m_PayPlatform.Merchant, request);
            var result = await post.PostAsync();
            return result;
        }

        public async Task<QueryOrderResult> QueryOrderAsync(PayRequest request)
        {
            Require.NotNull(request, nameof(request));

            var post = new QueryOrderPost(m_PayPlatform.Merchant, request);
            var result = await post.PostAsync();
            return result;
        }
    }
}
