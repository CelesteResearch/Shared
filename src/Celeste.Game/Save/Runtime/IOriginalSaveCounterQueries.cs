using System.Collections.Generic;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCounterQueries
    {
        int TotalHeartGems(OriginalSaveDataState actualSave);
        int TotalHeartGemsInVanilla(OriginalSaveDataState actualSave);
        int TotalCassettes(OriginalSaveDataState actualSave);

        List<ChapterAreaProgress> GetAreasSafe(
            OriginalSaveDataState actualSave);
    }
}
