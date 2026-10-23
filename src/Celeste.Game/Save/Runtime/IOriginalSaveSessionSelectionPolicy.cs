using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveSessionSelectionPolicy
    {
        Celeste.Simulation.Runtime.Session.ChapterCompletionSession GetCurrentSessionSafe(
            OriginalSaveDataState actualSave);

        void SetCurrentSessionSafe(OriginalSaveDataState actualSave,
            Celeste.Simulation.Runtime.Session.ChapterCompletionSession session);

        Celeste.Game.Execution.Areas.OriginalAreaKey GetLastAreaSafe(OriginalSaveDataState actualSave);
        void SelectNewGameLevelSet(string levelSet);
        ref Celeste.Game.Execution.Areas.OriginalAreaKey GetLastAreaReference(OriginalSaveDataState actualSave);
        void SetLastAreaSafe(OriginalSaveDataState actualSave, Celeste.Game.Execution.Areas.OriginalAreaKey area);
    }
}
