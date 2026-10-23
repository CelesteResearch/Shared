using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Celeste.Formats.Save.Xml;

namespace Celeste.Formats.Save.Serialization;

internal static partial class SaveXmlWire
{
    internal static XElement WriteSession(string name, Session value)
    {
        if (value == null) return null;
        var element = new XElement(name);
        if (value.Level != null) element.Add(new XAttribute("Level", value.Level));
        element.Add(new XAttribute("Time", XmlConvert.ToString(value.Time)));
        element.Add(new XAttribute("StartedFromBeginning", XmlConvert.ToString(value.StartedFromBeginning)));
        element.Add(new XAttribute("Deaths", XmlConvert.ToString(value.Deaths)));
        element.Add(new XAttribute("Dashes", XmlConvert.ToString(value.Dashes)));
        element.Add(new XAttribute("DashesAtLevelStart", XmlConvert.ToString(value.DashesAtLevelStart)));
        element.Add(new XAttribute("DeathsInCurrentLevel", XmlConvert.ToString(value.DeathsInCurrentLevel)));
        element.Add(new XAttribute("InArea", XmlConvert.ToString(value.InArea)));
        if (value.StartCheckpoint != null) element.Add(new XAttribute("StartCheckpoint", value.StartCheckpoint));
        element.Add(new XAttribute("FirstLevel", XmlConvert.ToString(value.FirstLevel)));
        element.Add(new XAttribute("Cassette", XmlConvert.ToString(value.Cassette)));
        element.Add(new XAttribute("HeartGem", XmlConvert.ToString(value.HeartGem)));
        element.Add(new XAttribute("Dreaming", XmlConvert.ToString(value.Dreaming)));
        if (value.ColorGrade != null) element.Add(new XAttribute("ColorGrade", value.ColorGrade));
        element.Add(new XAttribute("LightingAlphaAdd", XmlConvert.ToString(value.LightingAlphaAdd)));
        element.Add(new XAttribute("BloomBaseAdd", XmlConvert.ToString(value.BloomBaseAdd)));
        element.Add(new XAttribute("DarkRoomAlpha", XmlConvert.ToString(value.DarkRoomAlpha)));
        element.Add(new XAttribute("CoreMode", WriteCoreMode(value.CoreMode)));
        element.Add(new XAttribute("GrabbedGolden", XmlConvert.ToString(value.GrabbedGolden)));
        element.Add(new XAttribute("HitCheckpoint", XmlConvert.ToString(value.HitCheckpoint)));
        element.Add(WriteAreaKey("Area", value.Area));
        element.Add(value.RespawnPoint == null ? Nil("RespawnPoint") : WriteVector("RespawnPoint", value.RespawnPoint));
        element.Add(WriteAudioState("Audio", value.Audio));
        element.Add(WritePlayerInventory("Inventory", value.Inventory));
        if (value.Flags != null)
        {
            var items = new XElement("Flags");
            foreach (var item in value.Flags)
                items.Add(item == null ? Nil("string") : TextElement("string", item));
            element.Add(items);
        }

        if (value.LevelFlags != null)
        {
            var items = new XElement("LevelFlags");
            foreach (var item in value.LevelFlags)
                items.Add(item == null ? Nil("string") : TextElement("string", item));
            element.Add(items);
        }

        if (value.Strawberries != null)
        {
            var items = new XElement("Strawberries");
            foreach (var item in value.Strawberries)
                items.Add(item == null ? Nil("EntityID") : WriteEntityID("EntityID", item));
            element.Add(items);
        }

        if (value.DoNotLoad != null)
        {
            var items = new XElement("DoNotLoad");
            foreach (var item in value.DoNotLoad)
                items.Add(item == null ? Nil("EntityID") : WriteEntityID("EntityID", item));
            element.Add(items);
        }

        if (value.Keys != null)
        {
            var items = new XElement("Keys");
            foreach (var item in value.Keys)
                items.Add(item == null ? Nil("EntityID") : WriteEntityID("EntityID", item));
            element.Add(items);
        }

        if (value.Counters != null)
        {
            var items = new XElement("Counters");
            foreach (var item in value.Counters)
                items.Add(item == null ? Nil("Counter") : WriteCounter("Counter", item));
            element.Add(items);
        }

        if (value.SummitGems != null)
        {
            var items = new XElement("SummitGems");
            foreach (var item in value.SummitGems)
                items.Add(new XElement("boolean", XmlConvert.ToString(item)));
            element.Add(items);
        }

        element.Add(WriteAreaStats("OldStats", value.OldStats));
        element.Add(new XElement("UnlockedCSide", XmlConvert.ToString(value.UnlockedCSide)));
        element.Add(value.FurthestSeenLevel == null ? null : TextElement("FurthestSeenLevel", value.FurthestSeenLevel));
        element.Add(new XElement("BeatBestTime", XmlConvert.ToString(value.BeatBestTime)));
        element.Add(new XElement("RestartedFromGolden", XmlConvert.ToString(value.RestartedFromGolden)));
        if (value.Sliders != null)
        {
            var items = new XElement("Sliders");
            foreach (var item in value.Sliders)
                items.Add(item == null ? Nil("Slider") : WriteSlider("Slider", item));
            element.Add(items);
        }

        return element;
    }

    internal static Session ReadSession(XElement element, bool nullable)
    {
        ValidateType(element, "Session");
        if (nullable && IsNil(element)) return null;
        var value = new Session();
        var fieldArea = element.Element("Area");
        if (fieldArea != null) value.Area = ReadAreaKey(fieldArea, false);
        var fieldRespawnPoint = element.Element("RespawnPoint");
        if (fieldRespawnPoint != null) value.RespawnPoint = ReadVector(fieldRespawnPoint, true);
        var fieldAudio = element.Element("Audio");
        if (fieldAudio != null) value.Audio = ReadAudioState(fieldAudio, false);
        var fieldInventory = element.Element("Inventory");
        if (fieldInventory != null) value.Inventory = ReadPlayerInventory(fieldInventory, false);
        foreach (var container in element.Elements("Flags"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("string"))
                value.Flags.Add(IsNil(item) ? null : ReadText(item));
        }

        foreach (var container in element.Elements("LevelFlags"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("string"))
                value.LevelFlags.Add(IsNil(item) ? null : ReadText(item));
        }

        foreach (var container in element.Elements("Strawberries"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("EntityID"))
                value.Strawberries.Add(ReadEntityID(item, true));
        }

        foreach (var container in element.Elements("DoNotLoad"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("EntityID"))
                value.DoNotLoad.Add(ReadEntityID(item, true));
        }

        foreach (var container in element.Elements("Keys"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("EntityID"))
                value.Keys.Add(ReadEntityID(item, true));
        }

        foreach (var container in element.Elements("Counters"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("Counter"))
                value.Counters.Add(ReadCounter(item, true));
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

        var fieldOldStats = element.Element("OldStats");
        if (fieldOldStats != null) value.OldStats = ReadAreaStats(fieldOldStats, false);
        var fieldUnlockedCSide = element.Element("UnlockedCSide");
        if (fieldUnlockedCSide != null) value.UnlockedCSide = XmlConvert.ToBoolean(ReadText(fieldUnlockedCSide));
        var fieldFurthestSeenLevel = element.Element("FurthestSeenLevel");
        if (fieldFurthestSeenLevel != null) value.FurthestSeenLevel = ReadText(fieldFurthestSeenLevel);
        var fieldBeatBestTime = element.Element("BeatBestTime");
        if (fieldBeatBestTime != null) value.BeatBestTime = XmlConvert.ToBoolean(ReadText(fieldBeatBestTime));
        var fieldLevel = element.Attribute("Level");
        if (fieldLevel != null) value.Level = fieldLevel.Value;
        var fieldTime = element.Attribute("Time");
        if (fieldTime != null) value.Time = XmlConvert.ToInt64(fieldTime.Value);
        var fieldStartedFromBeginning = element.Attribute("StartedFromBeginning");
        if (fieldStartedFromBeginning != null)
            value.StartedFromBeginning = XmlConvert.ToBoolean(fieldStartedFromBeginning.Value);
        var fieldDeaths = element.Attribute("Deaths");
        if (fieldDeaths != null) value.Deaths = XmlConvert.ToInt32(fieldDeaths.Value);
        var fieldDashes = element.Attribute("Dashes");
        if (fieldDashes != null) value.Dashes = XmlConvert.ToInt32(fieldDashes.Value);
        var fieldDashesAtLevelStart = element.Attribute("DashesAtLevelStart");
        if (fieldDashesAtLevelStart != null)
            value.DashesAtLevelStart = XmlConvert.ToInt32(fieldDashesAtLevelStart.Value);
        var fieldDeathsInCurrentLevel = element.Attribute("DeathsInCurrentLevel");
        if (fieldDeathsInCurrentLevel != null)
            value.DeathsInCurrentLevel = XmlConvert.ToInt32(fieldDeathsInCurrentLevel.Value);
        var fieldInArea = element.Attribute("InArea");
        if (fieldInArea != null) value.InArea = XmlConvert.ToBoolean(fieldInArea.Value);
        var fieldStartCheckpoint = element.Attribute("StartCheckpoint");
        if (fieldStartCheckpoint != null) value.StartCheckpoint = fieldStartCheckpoint.Value;
        var fieldFirstLevel = element.Attribute("FirstLevel");
        if (fieldFirstLevel != null) value.FirstLevel = XmlConvert.ToBoolean(fieldFirstLevel.Value);
        var fieldCassette = element.Attribute("Cassette");
        if (fieldCassette != null) value.Cassette = XmlConvert.ToBoolean(fieldCassette.Value);
        var fieldHeartGem = element.Attribute("HeartGem");
        if (fieldHeartGem != null) value.HeartGem = XmlConvert.ToBoolean(fieldHeartGem.Value);
        var fieldDreaming = element.Attribute("Dreaming");
        if (fieldDreaming != null) value.Dreaming = XmlConvert.ToBoolean(fieldDreaming.Value);
        var fieldColorGrade = element.Attribute("ColorGrade");
        if (fieldColorGrade != null) value.ColorGrade = fieldColorGrade.Value;
        var fieldLightingAlphaAdd = element.Attribute("LightingAlphaAdd");
        if (fieldLightingAlphaAdd != null) value.LightingAlphaAdd = XmlConvert.ToSingle(fieldLightingAlphaAdd.Value);
        var fieldBloomBaseAdd = element.Attribute("BloomBaseAdd");
        if (fieldBloomBaseAdd != null) value.BloomBaseAdd = XmlConvert.ToSingle(fieldBloomBaseAdd.Value);
        var fieldDarkRoomAlpha = element.Attribute("DarkRoomAlpha");
        if (fieldDarkRoomAlpha != null) value.DarkRoomAlpha = XmlConvert.ToSingle(fieldDarkRoomAlpha.Value);
        var fieldCoreMode = element.Attribute("CoreMode");
        if (fieldCoreMode != null) value.CoreMode = ReadCoreMode(fieldCoreMode.Value);
        var fieldGrabbedGolden = element.Attribute("GrabbedGolden");
        if (fieldGrabbedGolden != null) value.GrabbedGolden = XmlConvert.ToBoolean(fieldGrabbedGolden.Value);
        var fieldHitCheckpoint = element.Attribute("HitCheckpoint");
        if (fieldHitCheckpoint != null) value.HitCheckpoint = XmlConvert.ToBoolean(fieldHitCheckpoint.Value);
        var fieldRestartedFromGolden = element.Element("RestartedFromGolden");
        if (fieldRestartedFromGolden != null)
            value.RestartedFromGolden = XmlConvert.ToBoolean(ReadText(fieldRestartedFromGolden));
        foreach (var container in element.Elements("Sliders"))
        {
            if (IsNil(container)) continue;
            foreach (var item in container.Elements("Slider"))
                value.Sliders.Add(ReadSlider(item, true));
        }

        return value;
    }
}
