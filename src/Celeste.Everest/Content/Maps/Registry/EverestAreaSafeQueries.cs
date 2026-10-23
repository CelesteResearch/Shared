using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Content.Maps.Registry
{
    public static class EverestAreaSafeQueries
    {
        public static bool GetInterlude(ISourceEngineContext engine, IOriginalAreaData area)
        {
            if (!area.Interlude)
            {
                if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null)
                    return ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSet(
                        ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave) != area.LevelSet;
                return false;
            }

            return true;
        }

        public static bool GetIsFinal(ISourceEngineContext engine, IOriginalAreaData area)
        {
            if (area.IsFinal)
            {
                if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null)
                    return ((IOriginalSaveLevelSetEnvironment)engine).SaveLevelSets.GetLevelSet(
                        ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave) == area.LevelSet;
                return false;
            }

            return false;
        }
    }
}
