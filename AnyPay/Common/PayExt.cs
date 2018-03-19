using System.Collections.Generic;
using System.Text;

namespace AnyPay.Common
{
    public static class PayExt
    {
        public static string WechatSign(this SortedDictionary<string, string> dict, string signKey)
        {
            var signBuilder = new StringBuilder();
            foreach (var item in dict)
            {
                if (item.Key != "sign" && !string.IsNullOrEmpty(item.Value))
                {
                    signBuilder.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
            }

            signBuilder.Append($"key={signKey}");

            return Util.SignMD5(signBuilder.ToString());
        }

        public static bool CheckSign(this SortedDictionary<string, string> dict, string signKey)
        {
            dict.TryGetValue("sign", out var signResult);
            if (string.IsNullOrEmpty(signResult))
            {
                return false;
            }

            var signTest = dict.WechatSign(signKey);
            return signTest == signResult;
        }
    }
}
