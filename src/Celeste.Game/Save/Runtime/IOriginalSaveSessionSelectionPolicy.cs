using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveSessionSelectionPolicy
    {
        ChapterCompletionSession GetCurrentSessionSafe(
            OriginalSaveDataState actualSave);

        void SetCurrentSessionSafe(OriginalSaveDataState actualSave,
            ChapterCompletionSession session);

        OriginalAreaKey GetLastAreaSafe(OriginalSaveDataState actualSave);
        void SelectNewGameLevelSet(string levelSet);
        ref OriginalAreaKey GetLastAreaReference(OriginalSaveDataState actualSave);
        void SetLastAreaSafe(OriginalSaveDataState actualSave, OriginalAreaKey area);
    }
}
