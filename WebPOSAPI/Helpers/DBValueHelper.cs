using System.Reflection;
using System.Collections.Concurrent;

namespace WebAPI.Helpers
{


    public static class DbValueHelper
    {
        private static readonly ConcurrentDictionary<string, PropertyInfo> _cache
            = new ConcurrentDictionary<string, PropertyInfo>();

        // __define-ocg__
        public static object? GetColumnValue<T>(T varOcg, string columnName)
        {
            if (varOcg == null || string.IsNullOrWhiteSpace(columnName))
                return null;

            var type = typeof(T);
            var key = $"{type.FullName}.{columnName}";

            var property = _cache.GetOrAdd(key,
                _ => type.GetProperty(columnName, BindingFlags.Public | BindingFlags.Instance));

            return property?.GetValue(varOcg);
        }
    }

}
