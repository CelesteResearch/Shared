using System.Collections.Generic;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public OriginalSaveDataState CreateSave()
        {
            var save = new OriginalSaveDataState(this);
            save.Name = "Madeline";
            save.Assists = FileAssists.Default;
            save.Flags = new HashSet<string>();
            SetPoemSafe(save, new List<string>());
            SetAreasSafe(save, new List<ChapterAreaProgress>());
            return save;
        }

        public void SetPoemSafe(OriginalSaveDataState save, List<string> value)
        {
            if (save.LevelSets == null || GetLevelSet(save) == "Celeste")
                save.Poem = value;
            else
                GetLevelSetStats(save).Poem = value;
        }
    }
}
