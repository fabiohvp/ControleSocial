using System.Collections.Generic;
using System.Reflection;

namespace System
{
    public static class SetValueExtension
    {
        public static void SetValue(this object obj, PropertyInfo property, string value)
        {
            var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            object safeValue = default;

            if (value != default)
            {
                if (type == typeof(bool))
                {
                    value = value.ToLower().Replace("sim", "True").Replace("não", "False");
                }
                else if (type == typeof(DateTime))
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        property.SetValue(obj, default, default);
                    }
                    else
                    {
                        property.SetValue(obj, DateTime.Parse(value), default);
                    }
                    return;
                }

                safeValue = Convert.ChangeType(value, type);
            }

            property.SetValue(obj, safeValue, default);
        }

        public static S SetValue<S, T>(this S obj, string propertyName, T valor)
            where S : class
        {
            var property = typeof(S)
                .GetProperty(propertyName);

            property
                .SetValue(obj, valor);

            return obj;
        }

        public static S SetValues<S, T>(this S obj, IEnumerable<KeyValuePair<string, T>> properties)
            where S : class
        {
            foreach (var item in properties)
            {
                obj.SetValue(item.Key, item.Value);
            }

            return obj;
        }

        public static S SetValue<S>(this S obj, string propertyName, string valor)
            where S : class
        {
            return obj.SetValue<S, string>(propertyName, valor);
        }

        public static S SetValues<S>(this S obj, IEnumerable<KeyValuePair<string, string>> properties)
            where S : class
        {
            return obj.SetValues<S, string>(properties);
        }

        public static S SetValue<S>(this S obj, string propertyName, decimal? valor)
            where S : class
        {
            return obj.SetValue<S, decimal?>(propertyName, valor);
        }

        public static S SetValues<S>(this S obj, IEnumerable<KeyValuePair<string, decimal?>> properties)
            where S : class
        {
            return obj.SetValues<S, decimal?>(properties);
        }
    }
}
