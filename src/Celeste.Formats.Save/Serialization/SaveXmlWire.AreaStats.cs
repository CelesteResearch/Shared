using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization;

internal static partial class SaveXmlWire
{
    internal static XElement WriteAreaStats(string name, AreaStats value)
    {
        if (value == null) return null;
        var element = new XElement(name);
        element.Add(new XAttribute("ID", XmlConvert.ToString(value.ID)));
        element.Add(new XAttribute("Cassette", XmlConvert.ToString(value.Cassette)));
        if (value.SID != null) element.Add(new XAttribute("SID", value.SID));
        if (value.Modes != null)
        {
            var items = new XElement("Modes");
            foreach (var item in value.Modes)
                items.Add(item == null ? Nil("AreaModeStats") : WriteAreaModeStats("AreaModeStats", item));
            element.Add(items);
        }

        return element;
    }

    internal static AreaStats ReadAreaStats(XElement element, bool nullable)
    {
        ValidateType(element, "AreaStats");
        if (nullable && IsNil(element)) return null;
        var value = new AreaStats();
        var fieldID = element.Attribute("ID");
        if (fieldID != null) value.ID = XmlConvert.ToInt32(fieldID.Value);
        var fieldCassette = element.Attribute("Cassette");
        if (fieldCassette != null) value.Cassette = XmlConvert.ToBoolean(fieldCassette.Value);
        foreach (var fieldModes in element.Elements("Modes"))
        {
            if (IsNil(fieldModes)) continue;
            {
                var items = new List<AreaModeStats>();
                foreach (var item in fieldModes.Elements("AreaModeStats"))
                    items.Add(ReadAreaModeStats(item, true));
                value.Modes = items.ToArray();
            }
        }

        var fieldSID = element.Attribute("SID");
        if (fieldSID != null) value.SID = fieldSID.Value;
        return value;
    }
}
