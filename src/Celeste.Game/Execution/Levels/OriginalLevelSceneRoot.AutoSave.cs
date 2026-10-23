using System.Collections;
using Celeste.Core.Scheduling;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private SimulationCoroutine saving;

        public void AutoSave()
        {
            if (saving == null)
                saving = new(EngineContext, SavingRoutine());
        }

        public bool IsAutoSaving()
        {
            return saving != null;
        }

        private IEnumerator SavingRoutine()
        {
            ((IOriginalUserIOEnvironment)EngineContext).UserIO.SaveHandler(true, false);
            while (((IOriginalUserIOEnvironment)EngineContext).UserIO.Saving)
                yield return null;
            saving = null;
        }

        private void UpdateSourceSaving()
        {
            if (saving != null)
                saving.Update();
        }
    }
}
