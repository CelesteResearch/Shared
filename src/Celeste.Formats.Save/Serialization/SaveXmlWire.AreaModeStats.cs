using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization;

internal static partial class SaveXmlWire
{
    internal static XElement WriteAreaModeStats(string name, AreaModeStats value)
    {
        if (value == null) return null;
        var element = new XElement(name);
        element.Add(new XAttribute("TotalStrawberries", XmlConvert.ToString(value.TotalStrawberries)));
        element.Add(new XAttribute("Completed", XmlConvert.ToString(value.Completed)));
        element.Add(new XAttribute("SingleRunCompleted", XmlConvert.ToString(value.SingleRunCompleted)));
        element.Add(new XAttribute("FullClear", XmlConvert.ToString(value.FullClear)));
        element.Add(new XAttribute("Deaths", XmlConvert.ToString(value.Deaths)));
        element.Add(new XAttribute("TimePlayed", XmlConvert.ToString(value.TimePlayed)));
        element.Add(new XAttribute("BestTime", XmlConvert.ToString(value.BestTime)));
        element.Add(new XAttribute("BestFullClearTime", XmlConvert.ToString(value.BestFullClearTime)));
        element.Add(new XAttribute("BestDashes", XmlConvert.ToString(value.BestDashes)));
        element.Add(new XAttribute("BestDeaths", XmlConvert.ToString(value.BestDeaths)));
        element.Add(new XAttribute("HeartGem", XmlConvert.ToString(value.HeartGem)));
        if (value.Strawberries != null)
        {
            var items = new XElement("Strawberries");
            foreach (var item in value.Strawberries)
                items.Add(item == null ? Nil("EntityID") : WriteEntityID("EntityID", item));
            element.Add(items);
        }

        if (value.Checkpoints != null)
        {
            var items = new XElement("Checkpoints");
            foreach (var item in value.Checkpoints)
                items.Add(item == null ? Nil("string") : TextElement("string", item));
            element.Add(items);
        }

        return element;
    }

    internal static AreaModeStats ReadAreaModeStats(XElement element, bool nullable)
    {
        ValidateType(element, "AreaModeStats");
        if (nullable && IsNil(element)) return null;
        var value = new AreaModeStats();
        var fieldTotalStrawberries = element.Attribute("TotalStrawberries");
        if (fieldTotalStrawberries != null) value.TotalStrawberries = XmlConvert.ToInt32(fieldTotalStrawberries.Value);
        var fieldCompleted = element.Attribute("Completed");
        if (fieldCompleted != null) value.Completed = XmlConvert.ToBoolean(fieldCompleted.Value);
        var fieldSingleRunCompleted = element.Attribute("SingleRunCompleted");
        if (fieldSingleRunCompleted != null)
            value.SingleRunCompleted = XmlConvert.ToBoolean(fieldSingleRunCompleted.Value);
        var fieldFullClear = element.Attribute("FullClear");
        if (fieldFullClear != null) value.FullClear = XmlConvert.ToBoolean(fieldFullClear.Value);
        var fieldDeaths = element.Attribute("Deaths");
        if (fieldDeaths != null) value.Deaths = XmlConvert.ToInt32(fieldDeaths.Value);
        var fieldTimePlayed = element.Attribute("TimePlayed");
        if (fieldTimePlayed != null) value.TimePlayed = XmlConvert.ToInt64(fieldTimePlayed.Value);
        var fieldBestTime = element.Attribute("BestTime");
        if (fieldBestTime != null) value.BestTime = XmlConvert.ToInt64(fieldBestTime.Value);
        var fieldBestFullClearTime = element.Attribute("BestFullClearTime");
        if (fieldBestFullClearTime != null) value.BestFullClearTime = XmlConvert.ToInt64(fieldBestFullClearTime.Value);
        var fieldBestDashes = element.Attribute("BestDashes");
        if (fieldBestDashes != null) value.BestDashes = XmlConvert.ToInt32(fieldBestDashes.Value);
        var fieldBestDeaths = element.Attribute("BestDeaths");
        if (fieldBestDeaths != null) value.BestDeaths = XmlConvert.ToInt32(fieldBestDeaths.Value);
        var fieldHeartGem = element.Attribute("HeartGem");
        if (fieldHeartGem != null) value.HeartGem = XmlConvert.ToBoolean(fieldHeartGem.Value);
        foreach (var container in element.Elements("Strawberries"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("EntityID"))
                value.Strawberries.Add(ReadEntityID(item, true));
        }

        foreach (var container in element.Elements("Checkpoints"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("string"))
                value.Checkpoints.Add(IsNil(item) ? null : ReadText(item));
        }

        return value;
    }
}
