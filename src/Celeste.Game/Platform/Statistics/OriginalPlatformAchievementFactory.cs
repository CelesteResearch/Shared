namespace Celeste.Game.Platform.Statistics
{
    public sealed class OriginalPlatformAchievementFactory : IOriginalPlatformAchievementFactory
    {
        public static readonly OriginalPlatformAchievementFactory Shared = new();

        private OriginalPlatformAchievementFactory()
        {
        }

        public OriginalPlatformAchievementProcess Create(IOriginalPlatformStatisticsOutput output,
            OriginalPlatformStatisticsProcess statistics)
            => new OriginalPlatformAchievementProcess(output, statistics);
    }
}
