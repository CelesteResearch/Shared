using Celeste.Game.Execution.Areas;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public static class OriginalSaveHeartSource
    {
        public static void RegisterHeartGem(OriginalSaveDataState save, OriginalAreaKey area,
            IOriginalSaveCounterQueries counters, IOriginalPlatformStatisticsEnvironment statistics)
        {
            counters.GetAreasSafe(save)[area.ID].Modes[area.Mode].HeartGem = true;
            if (area.Mode == 0)
            {
                if (area.ID == 1)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.HEART1);
                else if (area.ID == 2)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.HEART2);
                else if (area.ID == 3)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.HEART3);
                else if (area.ID == 4)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.HEART4);
                else if (area.ID == 5)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.HEART5);
                else if (area.ID == 6)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.HEART6);
                else if (area.ID == 7)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.HEART7);
                else if (area.ID == 9) statistics.Statistics.Achievements.Register(OriginalAchievement.HEART8);
            }
            else if (area.Mode == 1)
            {
                if (area.ID == 1)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.BSIDE1);
                else if (area.ID == 2)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.BSIDE2);
                else if (area.ID == 3)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.BSIDE3);
                else if (area.ID == 4)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.BSIDE4);
                else if (area.ID == 5)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.BSIDE5);
                else if (area.ID == 6)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.BSIDE6);
                else if (area.ID == 7)
                    statistics.Statistics.Achievements.Register(OriginalAchievement.BSIDE7);
                else if (area.ID == 9) statistics.Statistics.Achievements.Register(OriginalAchievement.BSIDE8);
            }

            statistics.Statistics.SetStadiaHeartsIfLarger(counters.TotalHeartGems(save));
        }
    }
}
