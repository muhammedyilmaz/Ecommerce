using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Base.Client.Extensions
{
    public static class QueryStringEntension
    {
        #region Methods

        public static string ToQueryString(this object obj)
        {
            if (obj.GetType().IsValueType || obj is string)
            {
                return obj.ToString();
            }

            var result = new List<string>();

            var props = obj.GetType().GetProperties().Where(p => p.CanRead && p.GetValue(obj, null) != null);

            foreach (var p in props)
            {
                var value = p.GetValue(obj, null);
                if (value is ICollection enumerable)
                {
                    result.AddRange(from object v in enumerable
                                    select $"{p.Name}={HttpUtility.UrlEncode(v.ToString())}");
                }
                else
                {
                    result.Add($"{p.Name}={HttpUtility.UrlEncode(value?.ToString())}");
                }
            }
            return "?" + string.Join("&", result.ToArray());
        }

        #endregion
    }
}
