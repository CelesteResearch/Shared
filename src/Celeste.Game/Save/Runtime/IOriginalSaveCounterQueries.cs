using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCounterQueries
    {
        int TotalHeartGems(OriginalSaveDataState actualSave);
        int TotalHeartGemsInVanilla(OriginalSaveDataState actualSave);
        int TotalCassettes(OriginalSaveDataState actualSave);

        System.Collections.Generic.List<Celeste.Simulation.Save.Progress.ChapterAreaProgress> GetAreasSafe(
            OriginalSaveDataState actualSave);
    }
}
