using System;
using System.Collections.Generic;
using System.Globalization;

namespace Celeste.Formats.Map.Entities.Attributes
{
    public static class EntityAttributeReader
    {
        public static bool Has(Dictionary<string, object> values, string key) => values.ContainsKey(key);

        public static string Attr(Dictionary<string, object> values, string key, string defaultValue = "")
        {
            if (values != null && values.TryGetValue(key, out var value))
                return value.ToString();
            return defaultValue;
        }

        public static float Float(Dictionary<string, object> values, string key, float defaultValue = 0f)
        {
            if (values != null && values.TryGetValue(key, out var value))
            {
                if (value is float number)
                    return number;
                if (float.TryParse(value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                    return result;
            }

            return defaultValue;
        }

        public static bool Bool(Dictionary<string, object> values, string key, bool defaultValue = false)
        {
            if (values != null && values.TryGetValue(key, out var value))
            {
                if (value is bool flag)
                    return flag;
                if (bool.TryParse(value.ToString(), out var result))
                    return result;
            }

            return defaultValue;
        }

        public static int Int(Dictionary<string, object> values, string key, int defaultValue = 0)
        {
            if (values != null && values.TryGetValue(key, out var value))
            {
                if (value is int number)
                    return number;
                if (int.TryParse(value.ToString(), out var result))
                    return result;
            }

            return defaultValue;
        }

        public static char Char(Dictionary<string, object> values, string key, char defaultValue = '\0')
        {
            if (values != null && values.TryGetValue(key, out var value) &&
                char.TryParse(value.ToString(), out var result))
                return result;
            return defaultValue;
        }

        public static T Enum<T>(Dictionary<string, object> values, string key, T defaultValue = default)
            where T : struct
        {
            if (values != null && values.TryGetValue(key, out var value) &&
                System.Enum.TryParse<T>(value.ToString(), true, out var result))
                return result;
            return defaultValue;
        }
    }
}
