using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    internal static partial class SaveXmlWire
    {
        internal static XElement WriteLevelSetStats(string name, LevelSetStats value)
        {
            if (value == null) return null;
            var element = new XElement(name);
            if (value.Name != null) element.Add(new XAttribute("Name", value.Name));
            if (value.Areas != null)
            {
                var items = new XElement("Areas");
                foreach (var item in value.Areas)
                    items.Add(item == null ? Nil("AreaStats") : WriteAreaStats("AreaStats", item));
                element.Add(items);
            }

            if (value.Poem != null)
            {
                var items = new XElement("Poem");
                foreach (var item in value.Poem)
                    items.Add(item == null ? Nil("string") : TextElement("string", item));
                element.Add(items);
            }

            element.Add(new XElement("UnlockedAreas", XmlConvert.ToString(value.UnlockedAreas)));
            element.Add(new XElement("TotalStrawberries", XmlConvert.ToString(value.TotalStrawberries)));
            return element;
        }

        internal static LevelSetStats ReadLevelSetStats(XElement element, bool nullable)
        {
            ValidateType(element, "LevelSetStats");
            if (nullable && IsNil(element)) return null;
            var value = new LevelSetStats();
            var fieldName = element.Attribute("Name");
            if (fieldName != null) value.Name = fieldName.Value;
            foreach (var container in element.Elements("Areas"))
            {
                if (IsNil(container)) continue;
                foreach (var item in container.Elements("AreaStats"))
                    value.Areas.Add(ReadAreaStats(item, true));
            }

            foreach (var container in element.Elements("Poem"))
            {
                if (IsNil(container)) continue;
                foreach (var item in container.Elements("string"))
                    value.Poem.Add(IsNil(item) ? null : ReadText(item));
            }

            var fieldUnlockedAreas = element.Element("UnlockedAreas");
            if (fieldUnlockedAreas != null) value.UnlockedAreas = XmlConvert.ToInt32(ReadText(fieldUnlockedAreas));
            var fieldTotalStrawberries = element.Element("TotalStrawberries");
            if (fieldTotalStrawberries != null)
                value.TotalStrawberries = XmlConvert.ToInt32(ReadText(fieldTotalStrawberries));
            return value;
        }
    }
}
