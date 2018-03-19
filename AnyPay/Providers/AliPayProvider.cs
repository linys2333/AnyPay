using AnyPay.Interfaces;
using AnyPay.Models;
using System;
using System.Threading.Tasks;

namespace AnyPay.Providers
{
    internal class AliPayProvider : PayBase, IPayProvider
    {
        public AliPayProvider(PayPlatform payPlatform) : base(payPlatform)
        {
        }

        public Task InitSandboxAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CreateOrderResult> CreateOrderAsync(PayRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<QueryOrderResult> QueryOrderAsync(PayRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
