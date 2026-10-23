using System.Collections.Generic;
using System.Globalization;

namespace Celeste.Formats.Map.Binary.Source
{
    public class BinaryPackerElement
    {
        public string Package;

        public string Name;

        public Dictionary<string, object> Attributes;

        public List<BinaryPackerElement> Children;

        public bool HasAttr(string name)
        {
            if (Attributes != null) return Attributes.ContainsKey(name);

            return false;
        }

        public string Attr(string name, string defaultValue = "")
        {
            if (Attributes == null || !Attributes.TryGetValue(name, out var value)) value = defaultValue;

            return value.ToString();
        }

        public bool AttrBool(string name, bool defaultValue = false)
        {
            if (Attributes == null || !Attributes.TryGetValue(name, out var value)) value = defaultValue;

            if (value is bool) return (bool)value;

            return bool.Parse(value.ToString());
        }

        public float AttrFloat(string name, float defaultValue = 0f)
        {
            if (Attributes == null || !Attributes.TryGetValue(name, out var value)) value = defaultValue;

            if (value is float) return (float)value;

            return float.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }
    }
}
