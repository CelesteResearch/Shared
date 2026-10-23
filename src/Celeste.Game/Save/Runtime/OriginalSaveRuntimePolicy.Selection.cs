using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public ChapterCompletionSession GetCurrentSessionSafe(
            OriginalSaveDataState save)
        {
            return save.CurrentSession;
        }

        public void SetCurrentSessionSafe(OriginalSaveDataState save,
            ChapterCompletionSession session)
        {
            save.CurrentSession = session;
        }

        public OriginalAreaKey GetLastAreaSafe(OriginalSaveDataState save)
        {
            return save.LastArea;
        }

        // The original source has no installed file-slot level-set selection tail.
        public void SelectNewGameLevelSet(string levelSet)
        {
        }

        public ref OriginalAreaKey GetLastAreaReference(OriginalSaveDataState save)
        {
            return ref save.LastArea;
        }

        public void SetLastAreaSafe(OriginalSaveDataState save, OriginalAreaKey area)
        {
            save.LastArea = area;
        }
    }
}
