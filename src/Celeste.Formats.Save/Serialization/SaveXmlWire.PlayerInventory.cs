using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization;

internal static partial class SaveXmlWire
{
    internal static XElement WritePlayerInventory(string name, PlayerInventory value)
    {
        if (value == null) return null;
        var element = new XElement(name);
        element.Add(new XElement("Dashes", XmlConvert.ToString(value.Dashes)));
        element.Add(new XElement("DreamDash", XmlConvert.ToString(value.DreamDash)));
        element.Add(new XElement("Backpack", XmlConvert.ToString(value.Backpack)));
        element.Add(new XElement("NoRefills", XmlConvert.ToString(value.NoRefills)));
        return element;
    }

    internal static PlayerInventory ReadPlayerInventory(XElement element, bool nullable)
    {
        ValidateType(element, "PlayerInventory");
        if (nullable && IsNil(element)) return null;
        var value = new PlayerInventory();
        var fieldDashes = element.Element("Dashes");
        if (fieldDashes != null) value.Dashes = XmlConvert.ToInt32(ReadText(fieldDashes));
        var fieldDreamDash = element.Element("DreamDash");
        if (fieldDreamDash != null) value.DreamDash = XmlConvert.ToBoolean(ReadText(fieldDreamDash));
        var fieldBackpack = element.Element("Backpack");
        if (fieldBackpack != null) value.Backpack = XmlConvert.ToBoolean(ReadText(fieldBackpack));
        var fieldNoRefills = element.Element("NoRefills");
        if (fieldNoRefills != null) value.NoRefills = XmlConvert.ToBoolean(ReadText(fieldNoRefills));
        return value;
    }
}
