using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet
{
    class BitsoUtils
    {

        public static byte[] HMACSHA256(string message, string secret)
        {
            var encoding = new UTF8Encoding();
            var keyBytes = encoding.GetBytes(secret);
            var messageBytes = encoding.GetBytes(message);
            var hmac = new HMACSHA256(keyBytes);

            return hmac.ComputeHash(messageBytes);
        }

        public static string ToHexString(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public static string BuildQueryString<T>(T obj)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var queryBuilder = new StringBuilder();
            var index = 0;

            foreach (PropertyInfo p in properties)
            {
                if (index > 0)
                    queryBuilder.Append("&");

                var jsonPropertyAttribute = p.GetCustomAttribute(typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;
                var propertyName = jsonPropertyAttribute != null ? jsonPropertyAttribute.PropertyName : p.Name;
                var propertyValue = p.GetValue(obj);

                
                queryBuilder.AppendFormat("{0}={1}", propertyName, propertyValue);
                index++;
            }

            var query = queryBuilder.ToString();
            return !string.IsNullOrEmpty(query) ? ("?" + query) : string.Empty;
        }

        

        public static string BuildJson(Dictionary<string, string> dict)
        {
            if (dict == null) return "null";
            var builder = new StringBuilder("{");
            var index = 0;
            foreach(var field in dict.Keys)
            {
                if(index > 0)
                    builder.Append(",");
                builder.AppendFormat("\"{0}\":\"{1}\"", field, dict[field]);
                index++;
            }
            builder.Append("}");
            return builder.ToString();
        }

        public static string BuildQueryString(params string[] keyValues)
        {
            var queryBuilder = new StringBuilder();
            var isKey = true;
            if (keyValues == null) return string.Empty;
            var index = 0;
            foreach (var keyOrValue in keyValues)
            {
                if (index > 0 && isKey)
                    queryBuilder.Append("&");

                queryBuilder.AppendFormat(isKey ? "{0}=" : "{1}", keyOrValue);

                isKey = !isKey;
            }

            var query = queryBuilder.ToString();
            return !string.IsNullOrEmpty(query) ? ("?" + query) : string.Empty;
        }

        public static string BuildQueryString(Dictionary<string,string> keyValues)
        {
            var queryBuilder = new StringBuilder();
            if (keyValues == null) return string.Empty;
            var index = 0;
            foreach(var key in keyValues.Keys)
            {
                if (index > 0)
                    queryBuilder.Append("&");
                queryBuilder.AppendFormat("{0}={1}", key, keyValues[key]);
            }

            var query = queryBuilder.ToString();

            return !string.IsNullOrEmpty(query) ? ("?" + query) : string.Empty;
        }

    }
}
