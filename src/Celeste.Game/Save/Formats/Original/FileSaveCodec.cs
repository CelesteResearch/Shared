using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using Celeste.Core.Audio;
using Celeste.Core.Maps;
using Celeste.Formats.Map.Identifiers;
using Celeste.Formats.Save.Serialization;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Save.Progress;
using W = Celeste.Formats.Save.Xml;

namespace Celeste.Game.Save.Formats.Original
{
    public static partial class FileSaveCodec
    {
        public static byte[] Serialize(OriginalSaveDataState save,
            IOriginalAreaKeyPolicy areaKeys)
        {
            return save == null
                ? throw new ArgumentNullException(nameof(save))
                : SaveXmlCodec.Serialize(ToWire(save, areaKeys));
        }

        public static OriginalSaveDataState Deserialize(byte[] bytes,
            IOriginalAreaKeyPolicy areaKeys,
            OriginalSessionFactory sessions,
            IOriginalSaveAllocationPolicy allocation)
        {
            return bytes == null
                ? throw new ArgumentNullException(nameof(bytes))
                : FromWire(SaveXmlCodec.Deserialize(bytes), areaKeys, sessions, allocation);
        }

        public static W.SaveData ToWire(OriginalSaveDataState save,
            IOriginalAreaKeyPolicy areaKeys)
        {
            var wire = new W.SaveData();
            CopyValues(save, wire);
            wire.Time = save.Time;
            wire.CheatMode = save.CheatMode;
            wire.AssistMode = save.AssistMode;
            wire.VariantMode = save.VariantMode;
            wire.UnlockedAreas = save.UnlockedAreas;
            wire.RevealedChapter9 = save.RevealedChapter9;
            wire.Assists = CopyValues(save.Assists, new());
            wire.Assists.DashMode = (W.DashMode)(int)save.Assists.DashMode;
            wire.Flags = [.. save.Flags];
            wire.Poem = [.. save.Poem];
            wire.SummitGems = save.SummitGems == null ? null : (bool[])save.SummitGems.Clone();
            wire.HasModdedSaveData = save.HasModdedSaveData;
            wire.LastArea = ToKey(save.LastArea, areaKeys);
            wire.CurrentSession = ToSession(save.CurrentSession, areaKeys);
            wire.LastArea_Safe = ToKey(save.LastAreaSafe, areaKeys);
            wire.CurrentSession_Safe = ToSession(save.CurrentSessionSafe, areaKeys);
            wire.Areas = [.. save.Areas.Select(a => ToArea(a))];
            wire.LevelSets = save.LevelSets?.Select(set => ToLevelSet(set)).ToList();
            wire.LevelSetRecycleBin =
                save.LevelSetRecycleBin?.Select(set => ToLevelSet(set)).ToList();
            return wire;
        }

        public static OriginalSaveDataState FromWire(W.SaveData wire,
            IOriginalAreaKeyPolicy areaKeys,
            OriginalSessionFactory sessions,
            IOriginalSaveAllocationPolicy allocation)
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
                    (DashMode)(int)wire.Assists.DashMode;
            save.Flags = /* ReSharper disable once UseCollectionExpression */ new(wire.Flags);
            save.Poem = [.. wire.Poem];
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
            IOriginalAreaKeyPolicy areaKeys)
        {
            return new()
            {
                LevelSets = data.LevelSets?.Select(ToLevelSet).ToList(),
                LevelSetRecycleBin = data.LevelSetRecycleBin?.Select(ToLevelSet).ToList(),
                LastArea_Safe = ToKey(data.LastAreaSafe, areaKeys),
                CurrentSession_Safe = ToSession(data.CurrentSessionSafe, areaKeys),
            };
        }

        public static OriginalModSaveData ReadModBackup(
            W.ModSaveData backup,
            IOriginalAreaKeyPolicy areaKeys,
            OriginalSessionFactory sessions)
        {
            var key = backup.LastArea_Safe;
            var actualKey = ReadKey(key, areaKeys);
            return new()
            {
                LevelSets = [.. backup.LevelSets.Select(FromLevelSet)],
                LevelSetRecycleBin = [.. backup.LevelSetRecycleBin.Select(FromLevelSet)],
                LastAreaSafe = actualKey,
                CurrentSessionSafe = FromSession(backup.CurrentSession_Safe, areaKeys, sessions),
            };
        }

        private static OriginalAreaKey ReadKey(
            W.AreaKey wire, IOriginalAreaKeyPolicy areaKeys)
        {
            // XML fills a zero-initialized struct; it does not call the gameplay constructor.
            var key = new OriginalAreaKey
            {
                ID = wire.ID, Mode = (int)wire.Mode,
            };
            if (wire.SID != null) key = areaKeys.SetSID(key, wire.SID);
            return key;
        }

        private static W.AreaKey ToKey(
            OriginalAreaKey key,
            IOriginalAreaKeyPolicy areaKeys)
        {
            return new() { ID = key.ID, Mode = (W.AreaMode)key.Mode, SID = areaKeys.GetSID(key) };
        }

        private static W.AreaStats ToArea(ChapterAreaProgress area)
        {
            return new()
            {
                ID = area.ID, Cassette = area.Cassette, SID = area.SID, Modes =
                [
                    .. area.Modes
                        .Select(mode =>
                        {
                            var item = CopyValues(mode, new());
                            item.Strawberries = ToIDs(mode.Strawberries);
                            item.Checkpoints = [.. mode.Checkpoints];
                            return item;
                        }),
                ],
            };
        }

        private static ChapterAreaProgress FromArea(W.AreaStats area)
        {
            var result = new OriginalAreaStats { ID = area.ID, Cassette = area.Cassette, SID = area.SID };
            result.Modes =
            [
                .. area.Modes.Select(mode =>
                {
                    var item = CopyValues(mode, new());
                    item.Strawberries = FromEntityIDs(mode.Strawberries);
                    item.Checkpoints = /* ReSharper disable once UseCollectionExpression */ new(mode.Checkpoints);
                    return item;
                }),
            ];
            return result;
        }

        private static W.LevelSetStats ToLevelSet(ChapterLevelSetStats set)
        {
            return new()
            {
                Name = set.Name,
                Areas = [.. set.Areas.Select(a => ToArea(a))],
                Poem = [.. set.Poem],
                UnlockedAreas = ((OriginalLevelSetStats)set).UnlockedAreas,
                TotalStrawberries = ((OriginalLevelSetStats)set)
                    .TotalStrawberries,
            };
        }

        private static ChapterLevelSetStats
            FromLevelSet(W.LevelSetStats set)
        {
            return new OriginalLevelSetStats
            {
                Name = set.Name, UnlockedAreas = set.UnlockedAreas, TotalStrawberries = set.TotalStrawberries,
                Poem = [.. set.Poem], Areas = [.. set.Areas.Select(FromArea)],
            };
        }

        private static List<W.EntityID> ToIDs(IEnumerable<MapEntityId> values)
        {
            return
            [
                .. values.Select(v => new W.EntityID
                {
                    Key = EntityIdCodec.Format(v),
                }),
            ];
        }

        private static HashSet<MapEntityId> FromEntityIDs(IEnumerable<W.EntityID> values)
        {
            return /* ReSharper disable once UseCollectionExpression */ new(values.Select(v =>
                EntityIdCodec.Parse(v.Key)));
        }

        private static W.AudioTrackState ToTrack(EventTrackState track)
        {
            return new()
            {
                Event = track.Event,
                Parameters = [.. track.Parameters.Select(v => new W.MEP { Key = v.Key, Value = v.Value })],
            };
        }

        private static EventTrackState FromTrack(W.AudioTrackState track)
        {
            var result = new EventTrackState(track.Event);
            foreach (var parameter in track.Parameters)
                result.Parameters.Add(new(parameter.Key, parameter.Value));
            return result;
        }

        public static W.Session ToSession(ChapterCompletionSession session,
            IOriginalAreaKeyPolicy areaKeys)
        {
            if (session == null) return null;
            var result = CopyValues(session, new());
            result.CoreMode = (W.CoreMode)(int)session.CoreMode;
            result.Area = ToKey(areaKeys.GetSessionArea(session), areaKeys);
            result.RespawnPoint = session.RespawnPoint.HasValue
                ? new W.Vector { X = session.RespawnPoint.Value.X, Y = session.RespawnPoint.Value.Y }
                : null;
            result.Audio.Music = ToTrack(session.Audio.Music);
            result.Audio.Ambience = ToTrack(session.Audio.Ambience);
            result.Audio.AmbienceVolume = session.Audio.AmbienceVolume;
            result.Sliders =
            [
                .. session.SlidersSerializationOnly
                    .Select(slider => new W.Slider { Name = slider.Name, Value = slider.Value }),
            ];
            result.Inventory = CopyValues(session.Inventory, new());
            result.Flags = [.. session.Flags];
            result.LevelFlags = [.. session.LevelFlags];
            result.Strawberries = ToIDs(session.Strawberries);
            result.DoNotLoad = ToIDs(session.DoNotLoad);
            result.Keys = ToIDs(session.Keys);
            result.Counters = [.. session.Counters.Select(c => new W.Counter { Key = c.Key, Value = c.Value })];
            result.SummitGems = (bool[])session.SummitGems.Clone();
            result.OldStats = session.OldStats == null ? null : ToArea(session.OldStats);
            return result;
        }

        public static ChapterCompletionSession FromSession(
            W.Session wire,
            IOriginalAreaKeyPolicy areaKeys,
            OriginalSessionFactory sessions)
        {
            if (wire == null) return null;
            var result = CopyValues(wire, sessions.CreateDeserializedSession());
            result.CoreMode = (RoomCoreMode)(int)wire.CoreMode;
            var area = ReadKey(wire.Area, areaKeys);
            result.AreaID = area.ID;
            result.Mode = area.Mode;
            result.AreaSID = area.SID;
            result.AreaSIDID = area.SIDID;
            result.RespawnPoint = wire.RespawnPoint == null
                ? null
                : new Vector2(wire.RespawnPoint.X, wire.RespawnPoint.Y);
            result.Audio = new()
            {
                Music = FromTrack(wire.Audio.Music), Ambience = FromTrack(wire.Audio.Ambience),
                AmbienceVolume = wire.Audio.AmbienceVolume,
            };
            result.SlidersSerializationOnly =
            [
                .. wire.Sliders.Select(slider =>
                    new ChapterCompletionSession.SerializationOnly.Slider
                        { Name = slider.Name, Value = slider.Value }),
            ];
            result.Inventory = CopyValues(wire.Inventory,
                new());
            result.Flags = /* ReSharper disable once UseCollectionExpression */ new(wire.Flags);
            result.LevelFlags = /* ReSharper disable once UseCollectionExpression */ new(wire.LevelFlags);
            result.Strawberries = FromEntityIDs(wire.Strawberries);
            result.DoNotLoad = FromEntityIDs(wire.DoNotLoad);
            result.Keys = FromEntityIDs(wire.Keys);
            result.Counters =
            [
                .. wire.Counters
                    .Select(c => new ChapterCompletionSession.Counter
                        { Key = c.Key, Value = c.Value }),
            ];
            result.SummitGems = (bool[])wire.SummitGems.Clone();
            result.OldStats = wire.OldStats == null ? null : FromArea(wire.OldStats);
            result.JustStarted = true;
            return result;
        }
    }
}
