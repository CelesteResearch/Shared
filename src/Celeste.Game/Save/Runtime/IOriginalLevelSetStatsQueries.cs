using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalLevelSetStatsQueries
    {
        int GetCompletionPercent(OriginalLevelSetStats stats);
        int GetTotalGoldenStrawberries(OriginalLevelSetStats stats);
        int GetMaxStrawberries(OriginalLevelSetStats stats);
        int GetMaxStrawberriesIncludingUntracked(OriginalLevelSetStats stats);
        int GetMaxGoldenStrawberries(OriginalLevelSetStats stats);
        int GetMaxCassettes(OriginalLevelSetStats stats);
        int GetTotalHeartGems(OriginalLevelSetStats stats);
        int GetMaxHeartGems(OriginalLevelSetStats stats);
        int GetMaxHeartGemsExcludingCSides(OriginalLevelSetStats stats);
        int GetMaxCompletions(OriginalLevelSetStats stats);
        int GetTotalCassettes(OriginalLevelSetStats stats);
        int GetTotalCompletions(OriginalLevelSetStats stats);
        int GetLevelSetUnlockedModes(OriginalLevelSetStats stats);
        int GetMaxAreaMode(OriginalLevelSetStats stats);
        void ComputeBounds(OriginalLevelSetStats stats);
    }
}
