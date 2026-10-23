using System.Linq;
using Celeste.Game.Save.Data;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public Celeste.Simulation.Runtime.Session.ChapterCompletionSession GetCurrentSessionSafe(
            OriginalSaveDataState save)
            => save.CurrentSessionSafe;

        public void SetCurrentSessionSafe(OriginalSaveDataState save,
            Celeste.Simulation.Runtime.Session.ChapterCompletionSession session)
            => save.CurrentSessionSafe = session;

        public OriginalAreaKey GetLastAreaSafe(OriginalSaveDataState save) => save.LastAreaSafe;

        public void SelectNewGameLevelSet(string levelSet)
        {
            if (levelSet != null && levelSet != "Celeste")
            {
                var save = context.CurrentSave;
                var first = registry.Areas.FirstOrDefault(area => area.LevelSet == levelSet);
                save.LastAreaSafe = first == null ? areaKeys.Default : areaKeys.ToKey(first);
            }
        }

        public ref OriginalAreaKey GetLastAreaReference(OriginalSaveDataState save) => ref save.LastAreaSafe;
        public void SetLastAreaSafe(OriginalSaveDataState save, OriginalAreaKey area) => save.LastAreaSafe = area;
    }
}
