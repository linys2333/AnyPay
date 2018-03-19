using AnyPay.Interfaces;
using AnyPay.Models;
using System;
using System.Threading.Tasks;

namespace AnyPay.Providers
{
    internal class UnionPayProvider : PayBase, IPayProvider
    {
        public UnionPayProvider(PayPlatform payPlatform) : base(payPlatform)
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
