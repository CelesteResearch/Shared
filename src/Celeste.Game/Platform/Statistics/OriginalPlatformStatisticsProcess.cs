#nullable enable annotations
using System;
using System.Collections.Generic;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Platform.Statistics
{
    public sealed class OriginalPlatformStatisticsProcess : IFileSaveStatistics
    {
        private readonly IOriginalPlatformStatisticsOutput? output;
        private readonly IOriginalGameTextEnvironment textEnvironment;
        private readonly Dictionary<OriginalStatistic, string> statToString = new();
        private bool ready;
        public OriginalPlatformAchievementProcess Achievements { get; }

        public OriginalPlatformStatisticsProcess(IOriginalPlatformStatisticsOutput? output,
            IOriginalGameTextEnvironment textEnvironment,
            IOriginalPlatformAchievementFactory achievements)
        {
            this.output = output;
            this.textEnvironment = textEnvironment ?? throw new ArgumentNullException(nameof(textEnvironment));
            Achievements = (achievements ?? throw new ArgumentNullException(nameof(achievements))).Create(output, this);
        }

        public void MakeRequest()
        {
            ready = output?.RequestCurrentStats() ?? false;
            output?.RequestGlobalStats(0);
        }

        public void MakeStadiaRequest()
        {
        }

        public bool Has()
        {
            return ready;
        }

        public void Increment(OriginalStatistic statistic, int increment = 1)
        {
            if (ready)
            {
                string name = null;
                if (!statToString.TryGetValue(statistic, out name))
                    statToString.Add(statistic, name = statistic.ToString());
                if (output.GetStat(name, out var current))
                    output.SetStat(name, unchecked(current + increment));
            }
        }

        public int Local(OriginalStatistic statistic)
        {
            var value = 0;
            if (ready)
            {
                string name = null;
                if (!statToString.TryGetValue(statistic, out name))
                    statToString.Add(statistic, name = statistic.ToString());
                output.GetStat(name, out value);
            }

            return value;
        }

        public long Global(OriginalStatistic statistic)
        {
            long value = 0;
            if (ready)
            {
                string name = null;
                if (!statToString.TryGetValue(statistic, out name))
                    statToString.Add(statistic, name = statistic.ToString());
                output.GetGlobalStat(name, out value);
            }

            return value;
        }

        public void Store()
        {
            if (ready) output.StoreStats();
        }

        public string Name(OriginalStatistic statistic)
        {
            return textEnvironment.Text.Dialog.Clean("STAT_" + statistic);
        }

        void IFileSaveStatistics.Increment(FileStatistic statistic)
        {
            Increment(statistic switch
            {
                FileStatistic.Deaths => OriginalStatistic.DEATHS,
                FileStatistic.Berries => OriginalStatistic.BERRIES,
                FileStatistic.GoldenBerries => OriginalStatistic.GOLDBERRIES,
                _ => throw new ArgumentOutOfRangeException(nameof(statistic)),
            });
        }

        void IFileSaveStatistics.RegisterAchievement(string achievement)
        {
            Achievements.Register((OriginalAchievement)Enum.Parse(typeof(OriginalAchievement), achievement));
        }

        // In the referenced Steam build, StatsForStadia.Increment and SetIfLarger are empty.
        // These preserve that source implementation; a Stadia port needs its own actual provider.
        public void SetStadiaHeartsIfLarger(int count)
        {
        }

        void IFileSaveStatistics.IncrementStadiaDeaths()
        {
        }

        void IFileSaveStatistics.SetStadiaBerriesIfLarger(int count)
        {
        }
    }
}
