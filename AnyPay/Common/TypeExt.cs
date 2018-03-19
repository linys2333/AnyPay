using System;

namespace AnyPay.Common
{
    public static class TypeExt
    {
        /// <summary>
        /// 安全类型转换，转换失败返回null，不抛出异常
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="obj">待转换的对象</param>
        /// <returns>null值将转换成类型默认值</returns>
        public static T ConvertType<T>(this object obj)
        {
            var result = ConvertType(typeof(T), obj);
            return (T)result;
        }

        /// <summary>
        /// 安全类型转换，转换失败返回null，不抛出异常
        /// </summary>
        /// <param name="type">转换类型</param>
        /// <param name="obj">待转换的对象</param>
        /// <returns>null值不做处理，返回null</returns>
        public static object ConvertType(Type type, object obj)
        {
            try
            {
                if (obj == null || obj == DBNull.Value)
                {
                    return null;
                }

                if (type.IsGenericType && type.Name.Contains("Nullable`"))
                {
                    var realType = type.GetGenericArguments()[0];
                    return ConvertType(realType, obj);
                }

                if (obj is string str)
                {
                    if (type == typeof(Guid))
                    {
                        return new Guid(str);
                    }

                    if (type == typeof(DateTime))
                    {
                        return DateTime.Parse(str);
                    }
                }

                return Convert.ChangeType(obj, type) ?? ConvertType(type, obj.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
