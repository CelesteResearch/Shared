using System.Collections.Generic;
using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Data
{
// Actual ModSaveData payload. Loaded lists transfer by reference at CopyToCelesteSaveData.
    public sealed class OriginalModSaveData
    {
        public List<ChapterLevelSetStats> LevelSets = [];
        public List<ChapterLevelSetStats> LevelSetRecycleBin = [];
        public OriginalAreaKey LastAreaSafe;
        public ChapterCompletionSession CurrentSessionSafe;

        public OriginalModSaveData()
        {
        }

        public OriginalModSaveData(OriginalSaveDataState save)
        {
            LevelSets = save.LevelSets;
            LevelSetRecycleBin = save.LevelSetRecycleBin;
            LastAreaSafe = save.LastAreaSafe;
            CurrentSessionSafe = save.CurrentSessionSafe;
        }
    }
}
