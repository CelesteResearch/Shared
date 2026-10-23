using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization
{
    internal static partial class SaveXmlWire
    {
        internal static XElement WriteModSaveData(string name, ModSaveData value)
        {
            if (value == null) return null;
            var element = new XElement(name);
            if (value.LevelSets != null)
            {
                var items = new XElement("LevelSets");
                foreach (var item in value.LevelSets)
                    items.Add(item == null ? Nil("LevelSetStats") : WriteLevelSetStats("LevelSetStats", item));
                element.Add(items);
            }

            if (value.LevelSetRecycleBin != null)
            {
                var items = new XElement("LevelSetRecycleBin");
                foreach (var item in value.LevelSetRecycleBin)
                    items.Add(item == null ? Nil("LevelSetStats") : WriteLevelSetStats("LevelSetStats", item));
                element.Add(items);
            }

            element.Add(WriteAreaKey("LastArea_Safe", value.LastArea_Safe));
            element.Add(WriteSession("CurrentSession_Safe", value.CurrentSession_Safe));
            return element;
        }

        internal static ModSaveData ReadModSaveData(XElement element, bool nullable)
        {
            ValidateType(element, "ModSaveData");
            if (nullable && IsNil(element)) return null;
            var value = new ModSaveData();
            foreach (var container in element.Elements("LevelSets"))
            {
                if (IsNil(container)) continue;
                foreach (var item in container.Elements("LevelSetStats"))
                    value.LevelSets.Add(ReadLevelSetStats(item, true));
            }

            foreach (var container in element.Elements("LevelSetRecycleBin"))
            {
                if (IsNil(container)) continue;
                foreach (var item in container.Elements("LevelSetStats"))
                    value.LevelSetRecycleBin.Add(ReadLevelSetStats(item, true));
            }

            var fieldLastAreaSafe = element.Element("LastArea_Safe");
            if (fieldLastAreaSafe != null) value.LastArea_Safe = ReadAreaKey(fieldLastAreaSafe, false);
            var fieldCurrentSessionSafe = element.Element("CurrentSession_Safe");
            if (fieldCurrentSessionSafe != null)
                value.CurrentSession_Safe = ReadSession(fieldCurrentSessionSafe, false);
            return value;
        }
    }
}
