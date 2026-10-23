using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    internal static partial class SaveXmlWire
    {
        internal static XElement WriteMEP(string name, MEP value)
        {
            if (value == null) return null;
            var element = new XElement(name);
            if (value.Key != null) element.Add(new XAttribute("Key", value.Key));
            element.Add(new XAttribute("Value", XmlConvert.ToString(value.Value)));
            return element;
        }

        internal static MEP ReadMEP(XElement element, bool nullable)
        {
            ValidateType(element, "MEP");
            if (nullable && IsNil(element)) return null;
            var value = new MEP();
            var fieldKey = element.Attribute("Key");
            if (fieldKey != null) value.Key = fieldKey.Value;
            var fieldValue = element.Attribute("Value");
            if (fieldValue != null) value.Value = XmlConvert.ToSingle(fieldValue.Value);
            return value;
        }
    }
}
