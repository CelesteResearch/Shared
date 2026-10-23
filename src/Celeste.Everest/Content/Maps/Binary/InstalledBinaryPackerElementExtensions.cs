using System;
using System.Collections.Generic;
using System.Globalization;
using Celeste.Formats.Map.Binary.Source;

namespace Celeste.Everest.Content.Maps.Binary
{
    public static class InstalledBinaryPackerElementExtensions
    {
        public static BinaryPackerElement SetAttr(this BinaryPackerElement el, string name, object value)
        {
            if (el.Attributes == null)
            {
                el.Attributes = new Dictionary<string, object>();
            }

            el.Attributes[name] = value;
            return el;
        }

        public static int AttrInt(this BinaryPackerElement el, string name, int defaultValue = 0)
        {
            if (el.Attributes == null || !el.Attributes.TryGetValue(name, out var value))
            {
                return defaultValue;
            }

            if (value is int)
            {
                return (int)value;
            }

            return int.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        public static int? AttrNullableInt(this BinaryPackerElement el, string name)
        {
            if (el.Attributes == null || !el.Attributes.TryGetValue(name, out var value))
            {
                return null;
            }

            if (value is int)
            {
                return (int)value;
            }

            return int.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        public static float? AttrNullableFloat(this BinaryPackerElement el, string name)
        {
            if (el.Attributes == null || !el.Attributes.TryGetValue(name, out var value))
            {
                return null;
            }

            if (value is float)
            {
                return (float)value;
            }

            return float.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        public static bool AttrRef(this BinaryPackerElement el, string name, ref string value)
        {
            if (el.HasAttr(name))
            {
                value = el.Attr(name);
                return true;
            }

            return false;
        }

        public static bool AttrRef(this BinaryPackerElement el, string name, ref bool value)
        {
            if (el.HasAttr(name))
            {
                value = el.AttrBool(name);
                return true;
            }

            return false;
        }

        public static bool AttrRef(this BinaryPackerElement el, string name, ref float value)
        {
            if (el.HasAttr(name))
            {
                value = el.AttrFloat(name);
                return true;
            }

            return false;
        }

        public static bool AttrRef(this BinaryPackerElement el, string name, ref int value)
        {
            if (el.HasAttr(name))
            {
                value = int.Parse(el.Attr(name));
                return true;
            }

            return false;
        }

        public static bool AttrIf(this BinaryPackerElement el, string name, Action<string> value)
        {
            if (el.HasAttr(name))
            {
                value(el.Attr(name));
                return true;
            }

            return false;
        }

        public static bool AttrIfBool(this BinaryPackerElement el, string name, Action<bool> value)
        {
            if (el.HasAttr(name))
            {
                value(el.AttrBool(name));
                return true;
            }

            return false;
        }

        public static bool AttrIfFloat(this BinaryPackerElement el, string name, Action<float> value)
        {
            if (el.HasAttr(name))
            {
                value(el.AttrFloat(name));
                return true;
            }

            return false;
        }

        public static bool AttrIfInt(this BinaryPackerElement el, string name, Action<int> value)
        {
            if (el.HasAttr(name))
            {
                value(int.Parse(el.Attr(name)));
                return true;
            }

            return false;
        }
    }
}
