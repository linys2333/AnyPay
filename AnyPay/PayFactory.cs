using AnyPay.Interfaces;
using AnyPay.Models;
using AnyPay.Providers;
using System;
using System.Threading.Tasks;

namespace AnyPay
{
    public class PayFactory
    {
        /// <summary>
        /// 统一对外入口
        /// </summary>
        /// <param name="payPlatform"></param>
        /// <returns></returns>
        public static async Task<IPayProvider> GetPayPlatformAsync(PayPlatform payPlatform)
        {
            IPayProvider payProvider;

            switch (payPlatform.PayChannel)
            {
                case PayChannel.WeChatPay:
                    payProvider = new WechatPayProvider(payPlatform);
                    break;
                case PayChannel.AliPay:
                    payProvider = new AliPayProvider(payPlatform);
                    break;
                case PayChannel.UnionPay:
                    payProvider = new UnionPayProvider(payPlatform);
                    break;
                default:
                    throw new NotSupportedException($"没有实现{payPlatform.PayChannel.ToString()}支付接口");
            }

            await payProvider.InitSandboxAsync();
            return payProvider;
        }
    }
}
