using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    internal static partial class SaveXmlWire
    {
        internal static XElement WriteAreaKey(string name, AreaKey value)
        {
            if (value == null) return null;
            var element = new XElement(name);
            element.Add(new XAttribute("ID", XmlConvert.ToString(value.ID)));
            element.Add(new XAttribute("Mode", WriteAreaMode(value.Mode)));
            if (value.SID != null) element.Add(new XAttribute("SID", value.SID));
            return element;
        }

        internal static AreaKey ReadAreaKey(XElement element, bool nullable)
        {
            ValidateType(element, "AreaKey");
            if (nullable && IsNil(element)) return null;
            var value = new AreaKey();
            var fieldId = element.Attribute("ID");
            if (fieldId != null) value.ID = XmlConvert.ToInt32(fieldId.Value);
            var fieldMode = element.Attribute("Mode");
            if (fieldMode != null) value.Mode = ReadAreaMode(fieldMode.Value);
            var fieldSid = element.Attribute("SID");
            if (fieldSid != null) value.SID = fieldSid.Value;
            return value;
        }
    }
}
