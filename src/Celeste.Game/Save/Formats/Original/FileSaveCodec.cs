using Celeste.Game.Save.Data;
using Celeste.Core.Audio;
using Celeste.Simulation.Audio;
using Celeste.Formats.Save.Serialization;
using Celeste.Simulation;
using Celeste.Formats.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using W = Celeste.Formats.Save.Xml;

namespace Celeste.Game.Save.Formats.Original
{
    public static partial class FileSaveCodec
    {
        public static byte[] Serialize(OriginalSaveDataState save,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys)
        {
            if (save == null) throw new ArgumentNullException(nameof(save));
            return SaveXmlCodec.Serialize(ToWire(save, areaKeys));
        }

        public static OriginalSaveDataState Deserialize(byte[] bytes,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys,
            global::Celeste.Game.Execution.Session.OriginalSessionFactory sessions,
            global::Celeste.Game.Save.Runtime.IOriginalSaveAllocationPolicy allocation)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            return FromWire(SaveXmlCodec.Deserialize(bytes), areaKeys, sessions, allocation);
        }

        public static W.SaveData ToWire(OriginalSaveDataState save,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys)
        {
            var wire = new W.SaveData();
            CopyValues(save, wire);
            wire.Time = save.Time;
            wire.CheatMode = save.CheatMode;
            wire.AssistMode = save.AssistMode;
            wire.VariantMode = save.VariantMode;
            wire.UnlockedAreas = save.UnlockedAreas;
            wire.RevealedChapter9 = save.RevealedChapter9;
            wire.Assists = CopyValues(save.Assists, new W.Assists());
            wire.Assists.DashMode = (W.DashMode)(int)save.Assists.DashMode;
            wire.Flags = save.Flags.ToList();
            wire.Poem = save.Poem.ToList();
            wire.SummitGems = save.SummitGems == null ? null : (bool[])save.SummitGems.Clone();
            wire.HasModdedSaveData = save.HasModdedSaveData;
            wire.LastArea = ToKey(save.LastArea, areaKeys);
            wire.CurrentSession = ToSession(save.CurrentSession, areaKeys);
            wire.LastArea_Safe = ToKey(save.LastAreaSafe, areaKeys);
            wire.CurrentSession_Safe = ToSession(save.CurrentSessionSafe, areaKeys);
            wire.Areas = save.Areas.Select(a => ToArea(a)).ToList();
            wire.LevelSets = save.LevelSets?.Select(set => ToLevelSet(set)).ToList();
            wire.LevelSetRecycleBin =
                save.LevelSetRecycleBin?.Select(set => ToLevelSet(set)).ToList();
            return wire;
        }

        public static OriginalSaveDataState FromWire(W.SaveData wire,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys,
            global::Celeste.Game.Execution.Session.OriginalSessionFactory sessions,
            global::Celeste.Game.Save.Runtime.IOriginalSaveAllocationPolicy allocation)
        {
            if (wire == null) throw new SerializationException("The save XML has no SaveData root.");
            var areas = wire.Areas;
            var save = allocation.CreateSave();
            CopyValues(wire, save);
            save.HasModdedSaveData = wire.HasModdedSaveData;
            save.Time = wire.Time;
            save.UnlockedAreas = wire.UnlockedAreas;
            save.CheatMode = wire.CheatMode;
            save.AssistMode = wire.AssistMode;
            save.VariantMode = wire.VariantMode;
            save.RevealedChapter9 = wire.RevealedChapter9;
            save.Assists = CopyValues(wire.Assists, FileAssists.Default);
            if (wire.Assists != null)
                save.Assists.DashMode =
                    (Celeste.Simulation.Gameplay.Player.Configuration.DashMode)(int)wire.Assists.DashMode;
            save.Flags = new HashSet<string>(wire.Flags);
            save.Poem = new List<string>(wire.Poem);
            foreach (var area in areas) save.Areas.Add(FromArea(area));
            save.SummitGems = wire.SummitGems == null ? null : (bool[])wire.SummitGems.Clone();
            var last = wire.LastArea ?? new W.AreaKey();
            var actualLast = ReadKey(last, areaKeys);
            save.LastArea = actualLast;
            save.CurrentSession = FromSession(wire.CurrentSession, areaKeys, sessions);
            var safe = wire.LastArea_Safe ?? new W.AreaKey();
            save.LastAreaSafe = ReadKey(safe, areaKeys);
            save.CurrentSessionSafe = FromSession(wire.CurrentSession_Safe, areaKeys, sessions);
            save.LevelSets = wire.LevelSets?.Select(FromLevelSet).ToList();
            save.LevelSetRecycleBin = wire.LevelSetRecycleBin?.Select(FromLevelSet).ToList();
            return save;
        }

        public static W.ModSaveData ToModWire(OriginalModSaveData data,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys)
            => new W.ModSaveData
            {
                LevelSets = data.LevelSets?.Select(ToLevelSet).ToList(),
                LevelSetRecycleBin = data.LevelSetRecycleBin?.Select(ToLevelSet).ToList(),
                LastArea_Safe = ToKey(data.LastAreaSafe, areaKeys),
                CurrentSession_Safe = ToSession(data.CurrentSessionSafe, areaKeys)
            };

        public static global::Celeste.Game.Save.Data.OriginalModSaveData ReadModBackup(
            W.ModSaveData backup,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys,
            global::Celeste.Game.Execution.Session.OriginalSessionFactory sessions)
        {
            var key = backup.LastArea_Safe;
            var actualKey = ReadKey(key, areaKeys);
            return new global::Celeste.Game.Save.Data.OriginalModSaveData
            {
                LevelSets = backup.LevelSets.Select(FromLevelSet).ToList(),
                LevelSetRecycleBin = backup.LevelSetRecycleBin.Select(FromLevelSet).ToList(),
                LastAreaSafe = actualKey,
                CurrentSessionSafe = FromSession(backup.CurrentSession_Safe, areaKeys, sessions)
            };
        }

        private static global::Celeste.Game.Execution.Areas.OriginalAreaKey ReadKey(
            W.AreaKey wire, global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys)
        {
            // XML fills a zero-initialized struct; it does not call the gameplay constructor.
            var key = new global::Celeste.Game.Execution.Areas.OriginalAreaKey
            {
                ID = wire.ID, Mode = (int)wire.Mode
            };
            if (wire.SID != null) key = areaKeys.SetSID(key, wire.SID);
            return key;
        }

        private static W.AreaKey ToKey(
            global::Celeste.Game.Execution.Areas.OriginalAreaKey key,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys)
            => new W.AreaKey { ID = key.ID, Mode = (W.AreaMode)key.Mode, SID = areaKeys.GetSID(key) };

        private static W.AreaStats ToArea(global::Celeste.Simulation.Save.Progress.ChapterAreaProgress area) =>
            new W.AreaStats
            {
                ID = area.ID, Cassette = area.Cassette, SID = area.SID, Modes = area.Modes
                    .Select(mode =>
                    {
                        var item = CopyValues(mode, new W.AreaModeStats());
                        item.Strawberries = ToIDs(mode.Strawberries);
                        item.Checkpoints = mode.Checkpoints.ToList();
                        return item;
                    }).ToArray()
            };

        private static global::Celeste.Simulation.Save.Progress.ChapterAreaProgress FromArea(W.AreaStats area)
        {
            var result = new OriginalAreaStats() { ID = area.ID, Cassette = area.Cassette, SID = area.SID };
            result.Modes = area.Modes.Select(mode =>
            {
                var item = CopyValues(mode, new global::Celeste.Simulation.Save.Progress.ChapterModeProgress());
                item.Strawberries = FromEntityIDs(mode.Strawberries);
                item.Checkpoints = new HashSet<string>(mode.Checkpoints);
                return item;
            }).ToArray();
            return result;
        }

        private static W.LevelSetStats ToLevelSet(global::Celeste.Simulation.Save.Progress.ChapterLevelSetStats set) =>
            new W.LevelSetStats
            {
                Name = set.Name,
                Areas = set.Areas.Select(a => ToArea(a)).ToList(),
                Poem = new List<string>(set.Poem),
                UnlockedAreas = ((OriginalLevelSetStats)set).UnlockedAreas,
                TotalStrawberries = ((global::Celeste.Game.Save.Data.OriginalLevelSetStats)set)
                    .TotalStrawberries
            };

        private static global::Celeste.Simulation.Save.Progress.ChapterLevelSetStats
            FromLevelSet(W.LevelSetStats set) => new global::Celeste.Game.Save.Data.OriginalLevelSetStats
        {
            Name = set.Name, UnlockedAreas = set.UnlockedAreas, TotalStrawberries = set.TotalStrawberries,
            Poem = new List<string>(set.Poem), Areas = set.Areas.Select(FromArea).ToList()
        };

        private static List<W.EntityID> ToIDs(IEnumerable<global::Celeste.Core.Maps.MapEntityId> values) =>
            values.Select(v => new W.EntityID
            {
                Key = global::Celeste.Formats.Map.Identifiers.EntityIdCodec.Format(v)
            }).ToList();

        private static HashSet<global::Celeste.Core.Maps.MapEntityId> FromEntityIDs(IEnumerable<W.EntityID> values) =>
            new HashSet<global::Celeste.Core.Maps.MapEntityId>(values.Select(v =>
                global::Celeste.Formats.Map.Identifiers.EntityIdCodec.Parse(v.Key)));

        private static W.AudioTrackState ToTrack(EventTrackState track) => new W.AudioTrackState
        {
            Event = track.Event,
            Parameters = track.Parameters.Select(v => new W.MEP { Key = v.Key, Value = v.Value }).ToList()
        };

        private static EventTrackState FromTrack(W.AudioTrackState track)
        {
            var result = new EventTrackState(track.Event);
            foreach (var parameter in track.Parameters)
                result.Parameters.Add(new EventParameter(parameter.Key, parameter.Value));
            return result;
        }

        public static W.Session ToSession(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys)
        {
            if (session == null) return null;
            var result = CopyValues(session, new W.Session());
            result.CoreMode = (W.CoreMode)(int)session.CoreMode;
            result.Area = ToKey(areaKeys.GetSessionArea(session), areaKeys);
            result.RespawnPoint = session.RespawnPoint.HasValue
                ? new W.Vector { X = session.RespawnPoint.Value.X, Y = session.RespawnPoint.Value.Y }
                : null;
            result.Audio.Music = ToTrack(session.Audio.Music);
            result.Audio.Ambience = ToTrack(session.Audio.Ambience);
            result.Audio.AmbienceVolume = session.Audio.AmbienceVolume;
            result.Sliders = session.SlidersSerializationOnly
                .Select(slider => new W.Slider { Name = slider.Name, Value = slider.Value }).ToList();
            result.Inventory = CopyValues(session.Inventory, new W.PlayerInventory());
            result.Flags = session.Flags.ToList();
            result.LevelFlags = session.LevelFlags.ToList();
            result.Strawberries = ToIDs(session.Strawberries);
            result.DoNotLoad = ToIDs(session.DoNotLoad);
            result.Keys = ToIDs(session.Keys);
            result.Counters = session.Counters.Select(c => new W.Counter { Key = c.Key, Value = c.Value }).ToList();
            result.SummitGems = (bool[])session.SummitGems.Clone();
            result.OldStats = session.OldStats == null ? null : ToArea(session.OldStats);
            return result;
        }

        public static global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession FromSession(
            W.Session wire,
            global::Celeste.Game.Execution.Areas.IOriginalAreaKeyPolicy areaKeys,
            global::Celeste.Game.Execution.Session.OriginalSessionFactory sessions)
        {
            if (wire == null) return null;
            var result = CopyValues(wire, sessions.CreateDeserializedSession());
            result.CoreMode = (global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode)(int)wire.CoreMode;
            var area = ReadKey(wire.Area, areaKeys);
            result.AreaID = area.ID;
            result.Mode = area.Mode;
            result.AreaSID = area.SID;
            result.AreaSIDID = area.SIDID;
            result.RespawnPoint = wire.RespawnPoint == null
                ? (System.Numerics.Vector2?)null
                : new System.Numerics.Vector2(wire.RespawnPoint.X, wire.RespawnPoint.Y);
            result.Audio = new RoomAudioState
            {
                Music = FromTrack(wire.Audio.Music), Ambience = FromTrack(wire.Audio.Ambience),
                AmbienceVolume = wire.Audio.AmbienceVolume
            };
            result.SlidersSerializationOnly = wire.Sliders.Select(slider =>
                    new global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession.SerializationOnly.Slider
                        { Name = slider.Name, Value = slider.Value })
                .ToArray();
            result.Inventory = CopyValues(wire.Inventory,
                new global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory());
            result.Flags = new HashSet<string>(wire.Flags);
            result.LevelFlags = new HashSet<string>(wire.LevelFlags);
            result.Strawberries = FromEntityIDs(wire.Strawberries);
            result.DoNotLoad = FromEntityIDs(wire.DoNotLoad);
            result.Keys = FromEntityIDs(wire.Keys);
            result.Counters = wire.Counters
                .Select(c => new global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession.Counter
                    { Key = c.Key, Value = c.Value }).ToList();
            result.SummitGems = (bool[])wire.SummitGems.Clone();
            result.OldStats = wire.OldStats == null ? null : FromArea(wire.OldStats);
            result.JustStarted = true;
            return result;
        }
    }
}
