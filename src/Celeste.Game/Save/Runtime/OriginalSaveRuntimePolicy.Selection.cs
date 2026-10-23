using Celeste.Game.Save.Data;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public Celeste.Simulation.Runtime.Session.ChapterCompletionSession GetCurrentSessionSafe(
            OriginalSaveDataState save)
            => save.CurrentSession;

        public void SetCurrentSessionSafe(OriginalSaveDataState save,
            Celeste.Simulation.Runtime.Session.ChapterCompletionSession session)
            => save.CurrentSession = session;

        public Celeste.Game.Execution.Areas.OriginalAreaKey GetLastAreaSafe(OriginalSaveDataState save)
            => save.LastArea;

        // The original source has no installed file-slot level-set selection tail.
        public void SelectNewGameLevelSet(string levelSet)
        {
        }

        public ref OriginalAreaKey GetLastAreaReference(OriginalSaveDataState save) => ref save.LastArea;

        public void SetLastAreaSafe(OriginalSaveDataState save, Celeste.Game.Execution.Areas.OriginalAreaKey area)
            => save.LastArea = area;
    }
}
