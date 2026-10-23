using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    internal static partial class SaveXmlWire
    {
        internal static XElement WriteEntityID(string name, EntityID value)
        {
            if (value == null) return null;
            var element = new XElement(name);
            if (value.Key != null) element.Add(new XAttribute("Key", value.Key));
            return element;
        }

        internal static EntityID ReadEntityID(XElement element, bool nullable)
        {
            ValidateType(element, "EntityID");
            if (nullable && IsNil(element)) return null;
            var value = new EntityID();
            var fieldKey = element.Attribute("Key");
            if (fieldKey != null) value.Key = fieldKey.Value;
            return value;
        }
    }
}
