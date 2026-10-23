using Celeste.Game.Execution.Areas;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Data
{
    public sealed partial class OriginalSaveDataState
    {
        [IgnoreDataMember] public bool HasModdedSaveData;
        [IgnoreDataMember] public int FileSlot;
        [IgnoreDataMember] public bool DoNotSave;
        [IgnoreDataMember] public OriginalAreaKey LastAreaSafe;
        [IgnoreDataMember] public Celeste.Simulation.Runtime.Session.ChapterCompletionSession CurrentSessionSafe;
        [IgnoreDataMember] public OriginalLevelSetStats CachedLevelSetStats;
        [IgnoreDataMember] public string CachedLevelSetStatsLevelSet;
        [IgnoreDataMember] public List<ChapterAreaProgress> CachedAreasSafe;
    }
}
