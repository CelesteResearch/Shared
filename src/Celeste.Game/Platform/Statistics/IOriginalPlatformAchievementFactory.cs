namespace Celeste.Game.Platform.Statistics
{
    public interface IOriginalPlatformAchievementFactory
    {
        OriginalPlatformAchievementProcess Create(IOriginalPlatformStatisticsOutput output,
            OriginalPlatformStatisticsProcess statistics);
    }
}
