using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Test.General.Extension
{
    public static class Url
    {
        public static string GetQueryString(this object obj, string url)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + GetValue(p, obj);

            return new Uri(url).ToString() + (properties.Any() ? "?" : "") + String.Join("&", properties.ToArray());
        }

        private static string GetValue(PropertyInfo p, object obj)
            => HttpUtility.UrlEncode(p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?)
                ? ((DateTime?)p.GetValue(obj, null))?.ToString("yyyy.MM.dd")
                : p.GetValue(obj, null).ToString());
    }
}
