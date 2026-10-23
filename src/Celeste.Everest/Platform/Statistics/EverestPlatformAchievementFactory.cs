using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Platform.Statistics;

namespace Celeste.Everest.Platform.Statistics
{
    public sealed class EverestPlatformAchievementFactory : IOriginalPlatformAchievementFactory
    {
        private readonly ISourceEngineContext engine;

        public EverestPlatformAchievementFactory(ISourceEngineContext engine) =>
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));

        public OriginalPlatformAchievementProcess Create(IOriginalPlatformStatisticsOutput output,
            OriginalPlatformStatisticsProcess statistics)
            => new EverestPlatformAchievementProcess(output, statistics, engine);
    }
}
