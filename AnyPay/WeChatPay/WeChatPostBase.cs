using AnyPay.Common;
using AnyPay.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnyPay.WeChatPay
{
    public abstract class WeChatPostBase<T> : PayPostBase<T> where T : PayResponse, new()
    {
        protected const string _SuccessCode = "SUCCESS";

        public string BaseUrl => "https://api.mch.weixin.qq.com" + (m_Merchant.IsSandbox ? "/sandboxnew" : string.Empty);
        
        protected WeChatPostBase(Merchant merchant, PayRequest request) : base(merchant, request)
        {
        }


        public override async Task<T> PostAsync()
        {
            InitParams();

            var xmlData = PayParams.ToSortDict().ToXml();
            var xmlResult = await Util.PostAsync(PostUrl, xmlData);
            var resultDict = xmlResult.ToSortDict();

            var response = ParseResult(resultDict);
            return response;
        }

        protected virtual void InitParams()
        {
            PayParams.Clear();

            PayParams
                .SafeAdd("appid", m_Merchant.AppId)
                .SafeAdd("mch_id", m_Merchant.Id)
                .SafeAdd("nonce_str", GenerateNonceString());

            AddBizParams();

            var sign = PayParams.ToSortDict().WechatSign(m_Merchant.SignKey);
            PayParams.SafeAdd("sign", sign);
        }
        
        protected virtual T ParseResult(SortedDictionary<string, string> dict)
        {
            dict.TryGetValue("return_code", out var returnCode);
            dict.TryGetValue("result_code", out var resultCode);

            var isReturnSuccess = String.Equals(returnCode, _SuccessCode);
            var isResultSuccess = String.Equals(resultCode ?? _SuccessCode, _SuccessCode);

            if (isReturnSuccess && isResultSuccess)
            {
                if (CheckResult(dict))
                {
                    var result = new T
                    {
                        Succeeded = true
                    };
                    SetSucceededResult(dict, result);
                    return result;
                }
                return GetErrorResult("WechatResponseError", "非法的请求响应");
            }

            dict.TryGetValue("err_code", out var errorCode);

            if (string.IsNullOrEmpty(errorCode))
            {
                dict.TryGetValue("return_msg", out var returnMsg);
                return GetErrorResult(returnCode, returnMsg);
            }

            dict.TryGetValue("err_code_des", out var errCodeDes);
            return GetErrorResult(errorCode, errCodeDes);
        }

        protected virtual bool CheckResult(SortedDictionary<string, string> dict)
        {
            var isChecked = Check(dict, "appid") && Check(dict, "mch_id");
            if (isChecked)
            {
                return dict.CheckSign(m_Merchant.SignKey);
            }
            return false;
        }

        /// <summary>
        /// 生成随机字符串，32位
        /// </summary>
        /// <returns></returns>
        protected string GenerateNonceString()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        /// <returns></returns>
        protected string GenerateTimestamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        protected bool Check(IDictionary<string, string> dict, string fieldName)
        {
            dict.TryGetValue(fieldName, out var result);
            var param = PayParams.GetValue(fieldName);
            return result != null && param != null && result == param;
        }

        protected T GetErrorResult(string errorCode, string errorMessage)
        {
            return new T
            {
                Succeeded = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }


        protected abstract void AddBizParams();

        protected abstract void SetSucceededResult(SortedDictionary<string, string> dict, T result);
    }
}
