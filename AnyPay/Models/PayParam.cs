using System;

namespace AnyPay.Models
{
    /// <summary>
    /// 支付请求参数
    /// </summary>
    public class PayParam
    {
        private string m_Name;
        
        public PayParam(string parameterName, string parameterValue)
        {
            Name = parameterName;
            Value = parameterValue;
        }

        public string Name
        {
            get => m_Name;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(Name), "参数名不能为空");
                }

                m_Name = value;
            }
        }

        public string Value { get; set; }

        public bool IsValid => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Value);
    }
}
