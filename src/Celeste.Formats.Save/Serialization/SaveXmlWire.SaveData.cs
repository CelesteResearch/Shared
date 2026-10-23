using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization;

internal static partial class SaveXmlWire
{
    internal static XElement WriteSaveData(string name, SaveData value, bool includeEverestFields)
    {
        if (value == null) return null;
        var element = new XElement(name);
        element.Add(value.Version == null ? null : TextElement("Version", value.Version));
        element.Add(value.Name == null ? null : TextElement("Name", value.Name));
        element.Add(new XElement("Time", XmlConvert.ToString(value.Time)));
        element.Add(new XElement("LastSave",
            XmlConvert.ToString(value.LastSave, XmlDateTimeSerializationMode.RoundtripKind)));
        element.Add(new XElement("CheatMode", XmlConvert.ToString(value.CheatMode)));
        element.Add(new XElement("AssistMode", XmlConvert.ToString(value.AssistMode)));
        element.Add(new XElement("VariantMode", XmlConvert.ToString(value.VariantMode)));
        element.Add(WriteAssists("Assists", value.Assists));
        element.Add(value.TheoSisterName == null ? null : TextElement("TheoSisterName", value.TheoSisterName));
        element.Add(new XElement("UnlockedAreas", XmlConvert.ToString(value.UnlockedAreas)));
        element.Add(new XElement("TotalDeaths", XmlConvert.ToString(value.TotalDeaths)));
        element.Add(new XElement("TotalStrawberries", XmlConvert.ToString(value.TotalStrawberries)));
        element.Add(new XElement("TotalGoldenStrawberries", XmlConvert.ToString(value.TotalGoldenStrawberries)));
        element.Add(new XElement("TotalJumps", XmlConvert.ToString(value.TotalJumps)));
        element.Add(new XElement("TotalWallJumps", XmlConvert.ToString(value.TotalWallJumps)));
        element.Add(new XElement("TotalDashes", XmlConvert.ToString(value.TotalDashes)));
        if (value.Flags != null)
        {
            var items = new XElement("Flags");
            foreach (var item in value.Flags)
                items.Add(item == null ? Nil("string") : TextElement("string", item));
            element.Add(items);
        }

        if (value.Poem != null)
        {
            var items = new XElement("Poem");
            foreach (var item in value.Poem)
                items.Add(item == null ? Nil("string") : TextElement("string", item));
            element.Add(items);
        }

        if (value.SummitGems != null)
        {
            var items = new XElement("SummitGems");
            foreach (var item in value.SummitGems)
                items.Add(new XElement("boolean", XmlConvert.ToString(item)));
            element.Add(items);
        }

        element.Add(new XElement("RevealedChapter9", XmlConvert.ToString(value.RevealedChapter9)));
        element.Add(WriteAreaKey("LastArea", value.LastArea));
        element.Add(WriteSession("CurrentSession", value.CurrentSession));
        if (value.Areas != null)
        {
            var items = new XElement("Areas");
            foreach (var item in value.Areas)
                items.Add(item == null ? Nil("AreaStats") : WriteAreaStats("AreaStats", item));
            element.Add(items);
        }

        if (includeEverestFields)
        {
            if (value.LevelSets != null)
            {
                var items = new XElement("LevelSets");
                foreach (var item in value.LevelSets)
                    items.Add(item == null ? Nil("LevelSetStats") : WriteLevelSetStats("LevelSetStats", item));
                element.Add(items);
            }
        }

        if (includeEverestFields)
        {
            if (value.LevelSetRecycleBin != null)
            {
                var items = new XElement("LevelSetRecycleBin");
                foreach (var item in value.LevelSetRecycleBin)
                    items.Add(item == null ? Nil("LevelSetStats") : WriteLevelSetStats("LevelSetStats", item));
                element.Add(items);
            }
        }

        if (includeEverestFields)
        {
            element.Add(new XElement("HasModdedSaveData", XmlConvert.ToString(value.HasModdedSaveData)));
        }

        if (includeEverestFields)
        {
            element.Add(WriteAreaKey("LastArea_Safe", value.LastArea_Safe));
        }

        if (includeEverestFields)
        {
            element.Add(WriteSession("CurrentSession_Safe", value.CurrentSession_Safe));
        }

        return element;
    }

    internal static SaveData ReadSaveData(XElement element, bool nullable, bool includeEverestFields)
    {
        ValidateType(element, "SaveData");
        if (nullable && IsNil(element)) return null;
        var value = new SaveData();
        var fieldVersion = element.Element("Version");
        if (fieldVersion != null) value.Version = ReadText(fieldVersion);
        var fieldName = element.Element("Name");
        if (fieldName != null) value.Name = ReadText(fieldName);
        var fieldTime = element.Element("Time");
        if (fieldTime != null) value.Time = XmlConvert.ToInt64(ReadText(fieldTime));
        var fieldLastSave = element.Element("LastSave");
        if (fieldLastSave != null)
            value.LastSave = XmlConvert.ToDateTime(ReadText(fieldLastSave), XmlDateTimeSerializationMode.RoundtripKind);
        var fieldCheatMode = element.Element("CheatMode");
        if (fieldCheatMode != null) value.CheatMode = XmlConvert.ToBoolean(ReadText(fieldCheatMode));
        var fieldAssistMode = element.Element("AssistMode");
        if (fieldAssistMode != null) value.AssistMode = XmlConvert.ToBoolean(ReadText(fieldAssistMode));
        var fieldVariantMode = element.Element("VariantMode");
        if (fieldVariantMode != null) value.VariantMode = XmlConvert.ToBoolean(ReadText(fieldVariantMode));
        var fieldAssists = element.Element("Assists");
        if (fieldAssists != null) value.Assists = ReadAssists(fieldAssists, false);
        var fieldTheoSisterName = element.Element("TheoSisterName");
        if (fieldTheoSisterName != null) value.TheoSisterName = ReadText(fieldTheoSisterName);
        var fieldUnlockedAreas = element.Element("UnlockedAreas");
        if (fieldUnlockedAreas != null) value.UnlockedAreas = XmlConvert.ToInt32(ReadText(fieldUnlockedAreas));
        var fieldTotalDeaths = element.Element("TotalDeaths");
        if (fieldTotalDeaths != null) value.TotalDeaths = XmlConvert.ToInt32(ReadText(fieldTotalDeaths));
        var fieldTotalStrawberries = element.Element("TotalStrawberries");
        if (fieldTotalStrawberries != null)
            value.TotalStrawberries = XmlConvert.ToInt32(ReadText(fieldTotalStrawberries));
        var fieldTotalGoldenStrawberries = element.Element("TotalGoldenStrawberries");
        if (fieldTotalGoldenStrawberries != null)
            value.TotalGoldenStrawberries = XmlConvert.ToInt32(ReadText(fieldTotalGoldenStrawberries));
        var fieldTotalJumps = element.Element("TotalJumps");
        if (fieldTotalJumps != null) value.TotalJumps = XmlConvert.ToInt32(ReadText(fieldTotalJumps));
        var fieldTotalWallJumps = element.Element("TotalWallJumps");
        if (fieldTotalWallJumps != null) value.TotalWallJumps = XmlConvert.ToInt32(ReadText(fieldTotalWallJumps));
        var fieldTotalDashes = element.Element("TotalDashes");
        if (fieldTotalDashes != null) value.TotalDashes = XmlConvert.ToInt32(ReadText(fieldTotalDashes));
        foreach (var container in element.Elements("Flags"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("string"))
                value.Flags.Add(IsNil(item) ? null : ReadText(item));
        }

        foreach (var container in element.Elements("Poem"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("string"))
                value.Poem.Add(IsNil(item) ? null : ReadText(item));
        }

        foreach (var fieldSummitGems in element.Elements("SummitGems"))
        {
            if (IsNil(fieldSummitGems)) continue;
            {
                var items = new List<bool>();
                foreach (var item in fieldSummitGems.Elements("boolean"))
                    items.Add(XmlConvert.ToBoolean(ReadText(item)));
                value.SummitGems = items.ToArray();
            }
        }

        var fieldRevealedChapter9 = element.Element("RevealedChapter9");
        if (fieldRevealedChapter9 != null)
            value.RevealedChapter9 = XmlConvert.ToBoolean(ReadText(fieldRevealedChapter9));
        var fieldLastArea = element.Element("LastArea");
        if (fieldLastArea != null) value.LastArea = ReadAreaKey(fieldLastArea, false);
        var fieldCurrentSession = element.Element("CurrentSession");
        if (fieldCurrentSession != null) value.CurrentSession = ReadSession(fieldCurrentSession, false);
        foreach (var container in element.Elements("Areas"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("AreaStats"))
                value.Areas.Add(ReadAreaStats(item, true));
        }

        if (includeEverestFields)
        {
            foreach (var container in element.Elements("LevelSets"))
            {
                if (IsNil(container)) continue;
                foreach (var item in container.Elements("LevelSetStats"))
                    value.LevelSets.Add(ReadLevelSetStats(item, true));
            }
        }

        if (includeEverestFields)
        {
            foreach (var container in element.Elements("LevelSetRecycleBin"))
            {
                if (IsNil(container)) continue;
                foreach (var item in container.Elements("LevelSetStats"))
                    value.LevelSetRecycleBin.Add(ReadLevelSetStats(item, true));
            }
        }

        if (includeEverestFields)
        {
            var fieldHasModdedSaveData = element.Element("HasModdedSaveData");
            if (fieldHasModdedSaveData != null)
                value.HasModdedSaveData = XmlConvert.ToBoolean(ReadText(fieldHasModdedSaveData));
        }

        if (includeEverestFields)
        {
            var fieldLastArea_Safe = element.Element("LastArea_Safe");
            if (fieldLastArea_Safe != null) value.LastArea_Safe = ReadAreaKey(fieldLastArea_Safe, false);
        }

        if (includeEverestFields)
        {
            var fieldCurrentSession_Safe = element.Element("CurrentSession_Safe");
            if (fieldCurrentSession_Safe != null)
                value.CurrentSession_Safe = ReadSession(fieldCurrentSession_Safe, false);
        }

        return value;
    }
}
