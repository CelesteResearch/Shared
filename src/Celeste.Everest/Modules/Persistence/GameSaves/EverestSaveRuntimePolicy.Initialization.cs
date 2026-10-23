using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public string GetFilename(int slot)
        {
            return slot == -1 ? "debug" : slot.ToString();
        }

        public void AfterInitialize(OriginalSaveDataState save,
            IOriginalSaveInitializationServices sourceServices)
        {
            var services = (IEverestSaveInitializationServices)sourceServices;
            var progress = save;
            if (progress.LevelSets == null) progress.LevelSets = [];
            if (progress.LevelSetRecycleBin == null) progress.LevelSetRecycleBin = [];
            if (progress.LevelSets.Count <= 1 && progress.LevelSetRecycleBin.Count == 0 && !save.HasModdedSaveData)
            {
                var filename = GetFilename(save.FileSlot);
                var backup = services.LoadModBackup(filename + "-modsavedata", false);
                if (backup != null)
                {
                    progress.LevelSets = backup.LevelSets;
                    progress.LevelSetRecycleBin = backup.LevelSetRecycleBin;
                    save.LastAreaSafe = backup.LastAreaSafe;
                    save.CurrentSessionSafe = backup.CurrentSessionSafe;
                    services.WarnBackupRestored(progress.LevelSets.Count, filename);
                }
            }

            save.HasModdedSaveData = true;
            if (progress.Areas == null) progress.Areas = [];
            InitializeLevelSets(save);
            if (save.LastAreaSafe.ID == 0)
                save.LastAreaSafe = save.LastArea;
            if (save.CurrentSessionSafe == null) save.CurrentSessionSafe = save.CurrentSession;
            save.LastArea = areaKeys.Default;
            save.CurrentSession = null;
            if (areaKeys.GetArea(save.LastAreaSafe) == null) save.LastAreaSafe = areaKeys.Default;
            if (save.LastAreaSafe.ID < 0 || save.LastAreaSafe.ID >= registry.Areas.Count)
                save.LastAreaSafe = areaKeys.Default;
            if (string.IsNullOrEmpty(save.TheoSisterName))
            {
                save.TheoSisterName = services.CleanDialog("THEO_SISTER_NAME");
                if (save.Name.IndexOf(save.TheoSisterName, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    save.TheoSisterName = services.CleanDialog("THEO_SISTER_ALT_NAME");
            }

            // Actual source AssistModeChecks writes the same selected input state once.
            save.AssistModeChecks(services);
            if (save.Version != null && new Version(save.Version) < new Version(1, 2, 1, 1))
                for (var i = 0; i < save.Areas.Count; i++)
                {
                    var area = save.Areas[i];
                    if (area == null) continue;
                    for (var j = 0; j < area.Modes.Length; j++)
                    {
                        var mode = area.Modes[j];
                        if (mode != null)
                        {
                            if (mode.BestTime > 0) mode.SingleRunCompleted = true;
                            mode.BestTime = 0;
                            mode.BestFullClearTime = 0;
                        }
                    }
                }

            CompleteAfterInitialize(save);
        }

        // Source AfterInitialize IL_00d1..IL_05ce. Backup restore precedes this body;
        // LastArea/session migration, assist/name checks and version migration follow it.
        public void InitializeLevelSets(OriginalSaveDataState save)
        {
            var progress = save;
            foreach (var area in registry.Areas)
            {
                var name = area.LevelSet;
                if (!progress.LevelSets.Exists(set => set.Name == name))
                {
                    var recycled = progress.LevelSetRecycleBin.FirstOrDefault(set => set.Name == name);
                    if (recycled != null)
                    {
                        progress.LevelSets.Add(recycled);
                        progress.LevelSetRecycleBin.Remove(recycled);
                    }
                    else
                    {
                        // SaveData backref is assigned in the following source loop.
                        progress.LevelSets.Add(new OriginalLevelSetStats
                        {
                            Name = name,
                            UnlockedAreas = name == "Celeste" ? progress.UnlockedAreas : 0,
                        });
                    }
                }
            }

            for (var i = 0; i < progress.LevelSets.Count; i++)
            {
                var set = (OriginalLevelSetStats)progress.LevelSets[i];
                set.SaveData = save;
                var areas = set.Areas;
                if (set.Name == "Celeste") areas = save.Areas;
                ComputeBounds(set);
                var offset = set.AreaOffset;
                if (offset == -1)
                {
                    var old = progress.LevelSetRecycleBin.FirstOrDefault(value => value.Name == set.Name);
                    if (old != null) progress.LevelSetRecycleBin.Remove(old);
                    progress.LevelSetRecycleBin.Add(set);
                    progress.LevelSets.RemoveAt(i);
                    i--;
                    continue;
                }

                var playable = registry.Areas.Count(area => area.LevelSet == set.Name
                                                            && string.IsNullOrEmpty(((EverestArea)area)?.Metadata
                                                                ?.Parent));
                var total = registry.Areas.Count(area => area.LevelSet == set.Name);
                for (var j = 0; j < areas.Count; j++)
                {
                    var area = GetAreaStats(areas[j]);
                    if (!string.IsNullOrEmpty(area?.Metadata?.Parent)) area = null;
                    areas[j].ID = area?.ID ?? int.MaxValue;
                }

                areas.Sort((a, b) => unchecked(a.ID - b.ID));
                while (areas.Count > 0 && areas[areas.Count - 1].ID == int.MaxValue)
                    areas.RemoveAt(areas.Count - 1);
                for (var j = 0; j < playable; j++)
                {
                    var id = unchecked(offset + j);
                    if (j >= areas.Count || areas[j].ID != id)
                    {
                        var area = new OriginalAreaStats(id, registry.Areas);
                        areas.Insert(j, area);
                    }
                }

                for (var j = playable; j < total; j++)
                    if (j >= areas.Count)
                        areas.Insert(j,
                            areas[
                                areaKeys.GetAreaBySID(GetAreaById(unchecked(offset + j)).Metadata.Parent).ID - offset]);
                for (var j = 0; j < areas.Count; j++)
                    areas[j].SID = areas[j].ID == -1 ? null : registry.Areas[areas[j].ID].SID;
                var completed = -1;
                for (var j = 0; j < playable; j++)
                    if (areas[j].Modes[0].Completed)
                        completed = j;
                if (set.Name == "Celeste")
                {
                    if (progress.UnlockedAreas < completed + 1 && set.MaxArea >= completed + 1)
                        progress.UnlockedAreas = completed + 1;
                    if (progress.DebugMode || progress.CheatMode) progress.UnlockedAreas = set.MaxArea;
                }
                else
                {
                    if (set.UnlockedAreas < completed + 1 && set.MaxArea >= completed + 1)
                        set.UnlockedAreas = completed + 1;
                    if (progress.DebugMode || progress.CheatMode) set.UnlockedAreas = set.MaxArea;
                }

                foreach (var area in areas) CleanCheckpoints(area);
            }

            foreach (var set in progress.LevelSetRecycleBin)
                ((OriginalLevelSetStats)set).SaveData = save;
            progress.LevelSets.Sort((a, b) => a.AreaOffset.CompareTo(b.AreaOffset));
        }

        private EverestArea GetAreaById(int id)
        {
            return (EverestArea)areaKeys.GetAreaById(id);
        }

        public int GetAreaStatsId(ChapterAreaProgress area)
        {
            if (!string.IsNullOrEmpty(area.SID)) return areaKeys.GetAreaBySID(area.SID)?.ID ?? area.ID;
            return area.ID;
        }

        private EverestArea GetAreaStats(ChapterAreaProgress area)
        {
            return area.SID == null ? GetAreaById(GetAreaStatsId(area)) : (EverestArea)areaKeys.GetAreaBySID(area.SID);
        }

        private void CleanCheckpoints(ChapterAreaProgress area)
        {
            if (string.IsNullOrEmpty(area.SID) && (area.ID < 0 || registry.Areas.Count <= area.ID))
                throw new(
                    $"SaveData contains invalid AreaStats with no SID and out-of-range ID of {area.ID} / {registry.Areas.Count}");
            var metadata = GetAreaById(GetAreaStatsId(area));
            for (var mode = 0; mode < area.Modes.Length; mode++)
            {
                var state = area.Modes[mode];
                var sourceMode = metadata.HasMode(mode) ? metadata.GetOriginalMode(mode) : null;
                var old = new HashSet<string>(state.Checkpoints);
                state.Checkpoints.Clear();
                if (sourceMode is { Checkpoints: not null })
                    foreach (var checkpoint in sourceMode.Checkpoints)
                        if (old.Contains(checkpoint.Level))
                            state.Checkpoints.Add(checkpoint.Level);
            }
        }
    }
}
