using System.Collections.Generic;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public List<string> GetPoemSafe(OriginalSaveDataState save)
            => GetLevelSet(save) == "Celeste" ? save.Poem : GetLevelSetStats(save).Poem;

        public bool RegisterPoemEntry(OriginalSaveDataState save, string id)
        {
            id = id.ToLower();
            if (GetPoemSafe(save).Contains(id)) return false;
            GetPoemSafe(save).Add(id);
            return true;
        }
    }
}
