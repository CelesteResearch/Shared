using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Runtime;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication :
        IOriginalSaveProgressionEnvironment,
        IOriginalSaveSessionSelectionEnvironment,
        IOriginalSaveLevelSetEnvironment,
        IOriginalAreaStatsEnvironment,
        IOriginalSavePreparationEnvironment,
        IOriginalSaveAllocationEnvironment,
        IOriginalSaveStartEnvironment,
        IOriginalSaveSessionStartEnvironment,
        IOriginalSaveCollectibleTotalsEnvironment,
        IOriginalSaveHeartEnvironment,
        IOriginalSavePoemEnvironment,
        IOriginalSaveCassetteEnvironment,
        IOriginalSaveTimeEnvironment,
        IOriginalSaveDebugEnvironment,
        IOriginalSaveDeletionEnvironment,
        IEverestSaveModuleStateEnvironment,
        IInstalledLevelSetStatsEnvironment,
        IEverestRestartSaveEnvironment
    {
        public IInstalledLevelSetStatsQueries LevelSetStatsQueries => (IInstalledLevelSetStatsQueries)SaveCounters;
        public IEverestSaveModuleState SaveModuleState => (IEverestSaveModuleState)SaveCounters;
        public IOriginalSaveCassettePolicy SaveCassette => (IOriginalSaveCassettePolicy)SaveCounters;
        public IOriginalSaveDeletionPolicy SaveDeletion => (IOriginalSaveDeletionPolicy)SaveCounters;
        public IOriginalSaveDeletionServices SaveDeletionServices => UserIOStorage;
        public IOriginalSaveDebugPolicy SaveDebug => (IOriginalSaveDebugPolicy)SaveCounters;

        public IOriginalSaveCollectibleTotalsPolicy SaveCollectibleTotals =>
            (IOriginalSaveCollectibleTotalsPolicy)SaveCounters;

        public IOriginalSaveHeartPolicy SaveHearts => (IOriginalSaveHeartPolicy)SaveCounters;
        public IOriginalSavePoemPolicy SavePoem => (IOriginalSavePoemPolicy)SaveCounters;
        public IOriginalSavePreparationPolicy SavePreparation => (IOriginalSavePreparationPolicy)SaveCounters;
        public IOriginalSaveSessionStartPolicy SaveSessionStart => (IOriginalSaveSessionStartPolicy)SaveCounters;
        public IOriginalSaveStartPolicy SaveStart => (IOriginalSaveStartPolicy)SaveCounters;
        public IOriginalSaveTimePolicy SaveTime => (IOriginalSaveTimePolicy)SaveCounters;
        public IOriginalSaveLevelSetQueries SaveLevelSets => (IOriginalSaveLevelSetQueries)SaveCounters;
        public IOriginalSaveProgressionPolicy SaveProgression => (IOriginalSaveProgressionPolicy)SaveCounters;

        public IOriginalSaveSessionSelectionPolicy SaveSessionSelection =>
            (IOriginalSaveSessionSelectionPolicy)SaveCounters;
    }
}
