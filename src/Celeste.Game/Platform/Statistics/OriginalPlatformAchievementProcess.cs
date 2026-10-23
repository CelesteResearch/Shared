#nullable enable annotations
using System;

namespace Celeste.Game.Platform.Statistics
{
    public class OriginalPlatformAchievementProcess
    {
        private readonly IOriginalPlatformStatisticsOutput? output;
        private readonly OriginalPlatformStatisticsProcess statistics;

        protected internal OriginalPlatformAchievementProcess(IOriginalPlatformStatisticsOutput? output,
            OriginalPlatformStatisticsProcess statistics)
        {
            this.output = output;
            this.statistics = statistics ?? throw new ArgumentNullException(nameof(statistics));
        }

        public string ID(OriginalAchievement achievement)
        {
            return achievement.ToString();
        }

        public bool Has(OriginalAchievement achievement)
        {
            return output != null && output.GetAchievement(ID(achievement), out var achieved) && achieved;
        }

        public virtual void Register(OriginalAchievement achievement)
        {
            if (output != null && !Has(achievement))
            {
                output.SetAchievement(ID(achievement));
                statistics.Store();
            }
        }
    }
}
