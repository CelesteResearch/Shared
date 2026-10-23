using System.Globalization;
using Celeste.Formats.Map.Binary.Source;

namespace Celeste.Everest.Content.Maps.Binary
{
    public static class InstalledBinaryPackerElementAccess
    {
        public static bool TryGetInstalledAttribute(this BinaryPackerElement element, string name, out object value)
        {
            var attributes = element.Attributes;
            if (attributes == null)
            {
                value = null;
                return false;
            }

            return attributes.TryGetValue(name, out value) ||
                   attributes.TryGetValue(name.ToLowerInvariant(), out value);
        }

        public static string ReadInstalledString(this BinaryPackerElement element, string name,
            string defaultValue = "")
        {
            return element.TryGetInstalledAttribute(name, out var value) ? value.ToString() : defaultValue;
        }

        public static float ReadInstalledFloat(this BinaryPackerElement element, string name, float defaultValue = 0f)
        {
            if (!element.TryGetInstalledAttribute(name, out var value)) return defaultValue;
            return value is float single ? single : float.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        public static int ReadInstalledInt(this BinaryPackerElement element, string name, int defaultValue = 0)
        {
            return element.AttrInt(name, defaultValue);
        }

        public static bool ReadInstalledBool(this BinaryPackerElement element, string name, bool defaultValue = false)
        {
            if (!element.TryGetInstalledAttribute(name, out var value)) return defaultValue;
            return value is bool boolean ? boolean : bool.Parse(value.ToString());
        }
    }
}
