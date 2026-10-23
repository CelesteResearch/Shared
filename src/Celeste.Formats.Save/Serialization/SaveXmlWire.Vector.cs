using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization;

internal static partial class SaveXmlWire
{
    internal static XElement WriteVector(string name, Vector value)
    {
        if (value == null) return null;
        var element = new XElement(name);
        element.Add(new XElement("X", XmlConvert.ToString(value.X)));
        element.Add(new XElement("Y", XmlConvert.ToString(value.Y)));
        return element;
    }

    internal static Vector ReadVector(XElement element, bool nullable)
    {
        ValidateType(element, "Vector");
        if (nullable && IsNil(element)) return null;
        var value = new Vector();
        var fieldX = element.Element("X");
        if (fieldX != null) value.X = XmlConvert.ToSingle(ReadText(fieldX));
        var fieldY = element.Element("Y");
        if (fieldY != null) value.Y = XmlConvert.ToSingle(ReadText(fieldY));
        return value;
    }
}
