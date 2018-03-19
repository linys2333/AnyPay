using System.Collections.Generic;

namespace AnyPay.Models
{
    public class CreateOrderResult : PayResponse
    {
        /// <summary>
        /// 应用APPID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 预支付交易会话标识，有效期2小时
        /// </summary>
        public string PrePayId { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Package { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 二维码链接，扫码支付时返回，有效期2小时
        /// </summary>
        public string CodeUrl { get; set; }


        public SortedDictionary<string, string> ToSortDict()
        {
            var dict = new SortedDictionary<string, string>
            {
                {"appid", AppId},
                {"partnerid", MerchantId},
                {"prepayid", PrePayId},
                {"package", Package},
                {"noncestr", NonceStr},
                {"timestamp", Timestamp}
            };
            return dict;
        }
    }
}
