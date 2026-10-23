using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    internal static partial class SaveXmlWire
    {
        internal static XElement WriteSlider(string name, Slider value)
        {
            if (value == null) return null;
            var element = new XElement(name);
            if (value.Name != null) element.Add(new XAttribute("Name", value.Name));
            element.Add(new XAttribute("Value", XmlConvert.ToString(value.Value)));
            return element;
        }

        internal static Slider ReadSlider(XElement element, bool nullable)
        {
            ValidateType(element, "Slider");
            if (nullable && IsNil(element)) return null;
            var value = new Slider();
            var fieldName = element.Attribute("Name");
            if (fieldName != null) value.Name = fieldName.Value;
            var fieldValue = element.Attribute("Value");
            if (fieldValue != null) value.Value = XmlConvert.ToSingle(fieldValue.Value);
            return value;
        }
    }
}
