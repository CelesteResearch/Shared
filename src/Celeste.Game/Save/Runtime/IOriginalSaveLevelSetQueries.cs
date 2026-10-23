using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveLevelSetQueries
    {
        string GetLevelSet(OriginalSaveDataState save);
        OriginalLevelSetStats GetLevelSetStats(OriginalSaveDataState save);
        OriginalLevelSetStats GetLevelSetStatsFor(OriginalSaveDataState actualSave, string name);
        int GetMaxAreaMode(OriginalLevelSetStats actualLevelSet);
    }
}
