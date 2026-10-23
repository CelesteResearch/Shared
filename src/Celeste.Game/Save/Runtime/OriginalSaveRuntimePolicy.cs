using System;
using System.Collections.Generic;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy : IOriginalSaveCheckpointQueries,
        IOriginalAreaInterludePolicy,
        IOriginalSaveDebugPolicy, IOriginalSaveTimePolicy, IOriginalStrawberrySavePolicy, IOriginalSaveHeartPolicy,
        IOriginalSaveCollectibleTotalsPolicy, IOriginalSavePoemPolicy, IOriginalSaveCompletionPolicy,
        IOriginalSaveCassettePolicy, IOriginalSaveDeletionPolicy, IOriginalSaveSessionStartPolicy,
        IOriginalSaveAllocationPolicy, IOriginalSaveStartPolicy, IOriginalSavePreparationPolicy,
        IOriginalAreaStatsPolicy,
        IOriginalSaveCounterQueries, IOriginalSaveSessionSelectionPolicy, IOriginalSaveProgressionPolicy,
        IOriginalSaveInitializationPolicy
    {
        private readonly IOriginalSaveCompletionEnvironment environment;
        private readonly IOriginalAreaSourceTable areas;
        private readonly IOriginalGameSaveContext context;
        private readonly IOriginalEngineIdentityEnvironment engineIdentity;
        private readonly IOriginalPlatformStatisticsEnvironment statistics;

        public OriginalSaveRuntimePolicy(IOriginalSaveCompletionEnvironment actualEnvironment,
            IOriginalAreaSourceTable actualAreas, IOriginalGameSaveContext context,
            IOriginalEngineIdentityEnvironment engineIdentity,
            IOriginalPlatformStatisticsEnvironment statistics)
        {
            environment = actualEnvironment ?? throw new ArgumentNullException(nameof(actualEnvironment));
            areas = actualAreas ?? throw new ArgumentNullException(nameof(actualAreas));
            this.context = context;
            this.engineIdentity = engineIdentity;
            this.statistics = statistics;
        }

        public bool IsInterlude(IOriginalAreaData actualArea)
        {
            return actualArea.Interlude;
        }

        public int TotalHeartGemsInVanilla(OriginalSaveDataState actualSave)
        {
            return TotalHeartGems(actualSave);
        }

        public int TotalHeartGems(OriginalSaveDataState actualSave)
        {
            var count = 0;
            foreach (var area in actualSave.Areas)
                for (var i = 0; i < area.Modes.Length; i++)
                    if (area.Modes[i] != null && area.Modes[i].HeartGem)
                        count = unchecked(count + 1);

            return count;
        }

        public int TotalCassettes(OriginalSaveDataState actualSave)
        {
            var count = 0;
            for (var i = 0; i <= (environment.EventMode ? 2 : areas.Areas.Count - 1); i++)
                if (!areas.Areas[i].Interlude && actualSave.Areas[i].Cassette)
                    count = unchecked(count + 1);

            return count;
        }

        public List<ChapterAreaProgress> GetAreasSafe(
            OriginalSaveDataState actualSave)
        {
            return actualSave.Areas;
        }
    }
}
