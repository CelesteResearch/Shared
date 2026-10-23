using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    internal static partial class SaveXmlWire
    {
        internal static XElement WriteCounter(string name, Counter value)
        {
            if (value == null) return null;
            var element = new XElement(name);
            if (value.Key != null) element.Add(new XAttribute("key", value.Key));
            element.Add(new XAttribute("value", XmlConvert.ToString(value.Value)));
            return element;
        }

        internal static Counter ReadCounter(XElement element, bool nullable)
        {
            ValidateType(element, "Counter");
            if (nullable && IsNil(element)) return null;
            var value = new Counter();
            var fieldKey = element.Attribute("key");
            if (fieldKey != null) value.Key = fieldKey.Value;
            var fieldValue = element.Attribute("value");
            if (fieldValue != null) value.Value = XmlConvert.ToInt32(fieldValue.Value);
            return value;
        }
    }
}
