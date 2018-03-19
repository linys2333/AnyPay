using AnyPay.Models;
using System.Threading.Tasks;

namespace AnyPay.Interfaces
{
    public interface IPayProvider
    {
        /// <summary>
        /// 初始化沙箱环境
        /// </summary>
        /// <returns></returns>
        Task InitSandboxAsync();

        /// <summary>
        /// 获取支付平台信息
        /// </summary>
        /// <returns></returns>
        PayPlatform GetPayPlatform();

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateOrderResult> CreateOrderAsync(PayRequest request);

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<QueryOrderResult> QueryOrderAsync(PayRequest request);
    }
}
