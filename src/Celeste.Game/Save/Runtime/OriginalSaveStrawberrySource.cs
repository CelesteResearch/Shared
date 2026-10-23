using Celeste.Core.Maps;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public static class OriginalSaveStrawberrySource
    {
        public static void Add(OriginalSaveDataState save, int area, int mode, MapEntityId id,
            bool golden, IFileSaveStatistics statistics, IOriginalSaveCounterQueries counters,
            IOriginalSaveCollectibleTotalsPolicy totals)
        {
            var areaModeStats = counters.GetAreasSafe(save)[area].Modes[mode];
            if (!areaModeStats.Strawberries.Contains(id))
            {
                areaModeStats.Strawberries.Add(id);
                areaModeStats.TotalStrawberries = unchecked(areaModeStats.TotalStrawberries + 1);
                totals.SetTotalStrawberriesSafe(save, unchecked(totals.GetTotalStrawberriesSafe(save) + 1));
                if (golden) save.TotalGoldenStrawberries = unchecked(save.TotalGoldenStrawberries + 1);
                if (totals.GetTotalStrawberriesSafe(save) >= 30) statistics.RegisterAchievement("STRB1");
                if (totals.GetTotalStrawberriesSafe(save) >= 80) statistics.RegisterAchievement("STRB2");
                if (totals.GetTotalStrawberriesSafe(save) >= 175) statistics.RegisterAchievement("STRB3");
                statistics.SetStadiaBerriesIfLarger(totals.GetTotalStrawberriesSafe(save));
            }

            statistics.Increment(golden ? FileStatistic.GoldenBerries : FileStatistic.Berries);
        }
    }
}
