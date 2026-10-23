using System;
using Celeste.Core.Campaigns;
using Celeste.Core.Maps;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public sealed class OriginalGameSaveContext : IOriginalGameSaveContext
    {
        private IOriginalSaveCompletionPolicy completionPolicy;
        private IOriginalStrawberrySavePolicy strawberryPolicy;
        private IFileSaveStatistics statistics;
        private IOriginalSaveCounterQueries counterQueries;

        public OriginalSaveDataState CurrentSave { get; private set; }

        public void PublishCurrentSave(OriginalSaveDataState currentSave)
        {
            CurrentSave = currentSave;
        }

        public void BindCompletionPolicy(IOriginalSaveCompletionPolicy policy)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));
            if (completionPolicy != null)
                throw new InvalidOperationException("The completion policy is already bound.");
            completionPolicy = policy;
        }

        public void BindCounterQueries(IOriginalSaveCounterQueries actualQueries)
        {
            if (actualQueries == null) throw new ArgumentNullException(nameof(actualQueries));
            if (counterQueries != null)
                throw new InvalidOperationException("The save counter queries are already bound.");
            counterQueries = actualQueries;
        }

        public void AddDeath(CampaignAreaKey area)
        {
            var save = CurrentSave;
            save.TotalDeaths = unchecked(save.TotalDeaths + 1);
            var queries = counterQueries ??
                          throw new InvalidOperationException("The save counter queries are not initialized.");
            var mode = queries.GetAreasSafe(save)[area.ID].Modes[area.Mode];
            mode.Deaths = unchecked(mode.Deaths + 1);
            var actualStatistics = statistics ??
                                   throw new InvalidOperationException("The save statistics are not initialized.");
            actualStatistics.Increment(FileStatistic.Deaths);
            actualStatistics.IncrementStadiaDeaths();
        }

        public bool HasCheckpoint(CampaignAreaKey area, string level)
        {
            var queries = counterQueries ??
                          throw new InvalidOperationException("The save counter queries are not initialized.");
            return queries.GetAreasSafe(CurrentSave)[area.ID].Modes[area.Mode].Checkpoints.Contains(level);
        }

        public bool SetCheckpoint(CampaignAreaKey area, string level)
        {
            var queries = counterQueries ??
                          throw new InvalidOperationException("The save counter queries are not initialized.");
            var mode = queries.GetAreasSafe(CurrentSave)[area.ID].Modes[area.Mode];
            if (!mode.Checkpoints.Contains(level))
            {
                mode.Checkpoints.Add(level);
                return true;
            }

            return false;
        }

        public void RegisterCompletion(ChapterCompletionSession session)
        {
            var policy = completionPolicy ??
                         throw new InvalidOperationException("The completion policy is not initialized.");
            policy.RegisterCompletion(CurrentSave, session);
        }

        public void BindStrawberryPolicy(IOriginalStrawberrySavePolicy policy,
            IFileSaveStatistics actualStatistics)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));
            if (actualStatistics == null) throw new ArgumentNullException(nameof(actualStatistics));
            if (strawberryPolicy != null)
                throw new InvalidOperationException("The save process policy is already bound.");
            statistics = actualStatistics;
            strawberryPolicy = policy;
        }

        private IOriginalStrawberrySavePolicy StrawberryPolicy => strawberryPolicy ??
                                                                  throw new InvalidOperationException(
                                                                      "The save process policy is not initialized.");

        public void AddStrawberry(MapEntityId id, bool golden)
        {
            var save = CurrentSave;
            var session = ((IOriginalSaveSessionSelectionPolicy)counterQueries).GetCurrentSessionSafe(save);
            var area = session.AreaID;
            var mode = session.Mode;
            StrawberryPolicy.Add(save, area, mode, id, golden, statistics);
        }

        public bool CheckStrawberry(MapEntityId id)
        {
            var save = CurrentSave;
            var session = ((IOriginalSaveSessionSelectionPolicy)counterQueries).GetCurrentSessionSafe(save);
            var area = session.AreaID;
            var mode = session.Mode;
            return StrawberryPolicy.Check(save, area, mode, id);
        }
    }
}
