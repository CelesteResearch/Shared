using System.Collections.Generic;
using Celeste.Game.Save.Data;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public OriginalSaveDataState CreateSave()
        {
            var save = new OriginalSaveDataState(this);
            save.Name = "Madeline";
            save.Assists = FileAssists.Default;
            save.Flags = [];
            SetPoemSafe(save, []);
            SetAreasSafe(save, []);
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
