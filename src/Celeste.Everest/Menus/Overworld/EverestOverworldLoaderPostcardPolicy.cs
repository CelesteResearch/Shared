using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Menus.Overworld
{
    public sealed class EverestOverworldLoaderPostcardPolicy : IOriginalOverworldLoaderPostcardPolicy
    {
        public int GetVariantHeartCount(OriginalSaveDataState save, ISourceEngineContext engine)
        {
            return ((IOriginalSaveCounterEnvironment)engine).SaveCounters.TotalHeartGemsInVanilla(save);
        }

        public bool ShouldShowCSide(ChapterCompletionSession session, ISourceEngineContext engine)
        {
            return session.UnlockedCSide && ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetMaxAreaMode(
                ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSetStats(
                    ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave)) >= 2;
        }
    }
}
