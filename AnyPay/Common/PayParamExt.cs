using System.Collections.Generic;
using System.Linq;
using AnyPay.Models;

namespace AnyPay.Common
{
    public static class PayParamExt
    {
        public static ICollection<PayParam> SafeAdd(this ICollection<PayParam> parameters,
            string name, string value)
        {
            var existsParam = parameters.FirstOrDefault(p => p.Name == name);
            if (existsParam == null)
            {
                var param = new PayParam(name, value);
                parameters.Add(param);
            }
            else
            {
                existsParam.Value = value;
            }

            return parameters;
        }

        public static SortedDictionary<string, string> ToSortDict(this ICollection<PayParam> parameters)
        {
            var sortDict = new SortedDictionary<string, string>();
            foreach (var param in parameters)
            {
                if (param.IsValid)
                {
                    sortDict.Add(param.Name, param.Value);
                }
            }

            return sortDict;
        }

        public static string GetValue(this ICollection<PayParam> parameters, string name)
        {
            return parameters.FirstOrDefault(p => p.Name == name)?.Value;
        }
    }
}
