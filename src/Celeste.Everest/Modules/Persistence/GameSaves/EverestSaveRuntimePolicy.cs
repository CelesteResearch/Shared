using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy : IOriginalSaveCheckpointQueries, IOriginalAreaInterludePolicy,
        IOriginalSaveDebugPolicy, IOriginalSaveTimePolicy, IOriginalStrawberrySavePolicy, IOriginalSaveHeartPolicy,
        IOriginalSaveCollectibleTotalsPolicy, IOriginalSavePoemPolicy, IOriginalSaveCompletionPolicy,
        IOriginalSaveCassettePolicy, IEverestSaveModuleState, IOriginalSaveDeletionPolicy,
        IOriginalSaveSessionStartPolicy,
        IOriginalSaveAllocationPolicy, IOriginalSaveStartPolicy, IOriginalSavePreparationPolicy,
        IOriginalAreaStatsPolicy,
        IOriginalSaveCounterQueries, IOriginalSaveSessionSelectionPolicy, IOriginalSaveProgressionPolicy,
        IOriginalSaveInitializationPolicy, IOriginalSaveLevelSetQueries
    {
        private readonly IEverestSaveModulesEnvironment saveModules;
        private readonly IOriginalSaveCompletionEnvironment environment;
        private readonly IOriginalAreaSourceTable registry;
        private readonly IOriginalGameSaveContext context;
        private readonly IOriginalAreaKeyPolicy areaKeys;
        private readonly IEverestLoggerProcessEnvironment diagnostics;
        private readonly IOriginalEngineIdentityEnvironment engineIdentity;
        private readonly IOriginalPlatformStatisticsEnvironment statistics;

        public EverestSaveRuntimePolicy(IOriginalSaveCompletionEnvironment environment,
            IOriginalAreaSourceTable registry, IOriginalGameSaveContext context, IOriginalAreaKeyPolicy areaKeys,
            IEverestLoggerProcessEnvironment diagnostics,
            IOriginalEngineIdentityEnvironment engineIdentity,
            IEverestSaveModulesEnvironment saveModules,
            IOriginalPlatformStatisticsEnvironment statistics)
        {
            this.environment = environment;
            this.registry = registry;
            this.context = context;
            this.areaKeys = areaKeys;
            this.diagnostics = diagnostics;
            this.engineIdentity = engineIdentity;
            this.statistics = statistics;
            this.saveModules = saveModules;
        }

        public OriginalLevelSetStats GetLevelSetStatsFor(OriginalSaveDataState actualSave, string name)
        {
            return (OriginalLevelSetStats)actualSave.LevelSets.Find(value => value.Name == name);
        }

        public int TotalHeartGemsInVanilla(OriginalSaveDataState actualSave)
        {
            return GetLevelSetStatsFor(actualSave, "Celeste")
                .AreasIncludingCeleste.Sum(area => area.Modes.Count(mode => mode is { HeartGem: true }));
        }

        public int TotalHeartGems(OriginalSaveDataState actualSave)
        {
            var areas = GetLevelSetStats(actualSave).AreasIncludingCeleste;
            if (areas == null) throw new ArgumentNullException("source");
            var total = 0;
            foreach (var area in areas)
            {
                var modes = area.Modes;
                if (modes == null) throw new ArgumentNullException("source");
                var count = 0;
                foreach (var mode in modes)
                    if (mode is { HeartGem: true })
                        count = checked(count + 1);
                total = checked(total + count);
            }

            return total;
        }

        public int TotalCassettes(OriginalSaveDataState actualSave)
        {
            var count = 0;
            var areas = GetAreasSafe(actualSave);
            var set = GetLevelSetStats(actualSave);
            var maxArea = unchecked(set.AreaOffset + set.MaxArea);
            for (var i = 0; i <= maxArea; i++)
                if (areas[i].Cassette && !IsInterlude(registry.Areas[i]))
                    count = unchecked(count + 1);

            return count;
        }

        public List<ChapterAreaProgress> GetAreasSafe(OriginalSaveDataState actualSave)
        {
            if (actualSave.CachedAreasSafe == null)
            {
                diagnostics.Logger.Log(EverestLogLevel.Verbose, "SaveData", "Recomputing SaveData.Areas_Safe");
                var result = new List<ChapterAreaProgress>(actualSave.Areas);
                foreach (var set in actualSave.LevelSets)
                    result.AddRange(set.Areas);
                actualSave.CachedAreasSafe = result;
            }

            return actualSave.CachedAreasSafe;
        }

        public void SetAreasSafe(OriginalSaveDataState actualSave, List<ChapterAreaProgress> value)
        {
            actualSave.CachedAreasSafe = null;
            actualSave.CachedLevelSetStats = null;
            var progress = actualSave;
            if (progress.LevelSets == null && value.Count == 0)
            {
                progress.Areas = value;
                return;
            }

            var offset = 0;
            progress.Areas = value.GetRange(offset, progress.Areas.Count);
            offset = unchecked(offset + progress.Areas.Count);
            foreach (var set in progress.LevelSets)
            {
                set.Areas = value.GetRange(offset, set.Areas.Count);
                offset = unchecked(offset + set.Areas.Count);
            }
        }

        public OriginalLevelSetStats GetLevelSetStats(OriginalSaveDataState actualSave)
        {
            var name = LastAreaLevelSet(actualSave) ?? "Celeste";
            if (actualSave.CachedLevelSetStats == null
                || actualSave.CachedLevelSetStatsLevelSet != name)
            {
                actualSave.CachedLevelSetStats = ComputeLevelSetStats(actualSave);
                actualSave.CachedLevelSetStatsLevelSet = name;
            }

            return actualSave.CachedLevelSetStats;
        }

        private OriginalLevelSetStats ComputeLevelSetStats(OriginalSaveDataState actualSave)
        {
            diagnostics.Logger.Log(EverestLogLevel.Verbose, "SaveData", "Recomputing SaveData.LevelSetStats");
            var name = LastAreaLevelSet(actualSave) ?? "Celeste";
            var set = (OriginalLevelSetStats)actualSave.LevelSets.Find(value => value.Name == name);
            if (set == null)
            {
                set = new() { SaveData = actualSave, Name = name };
                if (name == "Celeste") actualSave.UnlockedAreas = 0;
                else set.UnlockedAreas = 0;
                actualSave.LevelSets.Add(set);
                actualSave.CachedAreasSafe = null;
            }

            if (name != "Celeste" && set.AreaOffset == -1)
            {
                // Source LastArea_Safe = AreaKey.Default, not a repaired metadata lookup.
                actualSave.LastAreaSafe = areaKeys.Default;
                return GetLevelSetStats(actualSave);
            }

            return set;
        }

        private string LastAreaLevelSet(OriginalSaveDataState actualSave)
        {
            return areaKeys.GetLevelSet(actualSave.LastAreaSafe);
        }

        public bool IsInterlude(IOriginalAreaData area)
        {
            return area.Interlude || (context.CurrentSave != null
                                      && GetLevelSetStats(context.CurrentSave).Name != area.LevelSet);
        }

        // Exact LevelSetStats.ComputeBounds; actual AfterInitialize must own publication.
        public void ComputeBounds(OriginalLevelSetStats set)
        {
            var offset = -1;
            for (var i = 0; i < registry.Areas.Count; i++)
                if (registry.Areas[i].LevelSet == set.Name)
                {
                    offset = i;
                    break;
                }

            set.AreaOffset = offset;
            var playable = 0;
            foreach (var area in registry.Areas)
                if (area.LevelSet == set.Name && string.IsNullOrEmpty(((EverestArea)area).Metadata?.Parent))
                    playable = checked(playable + 1);
            var maxArea = unchecked(playable - 1);
            set.MaxArea = environment.EventMode ? Math.Min(maxArea, unchecked(set.AreaOffset + 2)) : maxArea;
        }

        public void CompleteAfterInitialize(OriginalSaveDataState actualSave)
        {
            // Original installed normal tail: keep the cached levelset-name string.
            actualSave.CachedAreasSafe = null;
            actualSave.CachedLevelSetStats = null;
        }
    }
}
