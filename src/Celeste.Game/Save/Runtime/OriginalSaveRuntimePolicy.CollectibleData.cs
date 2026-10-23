using System.Collections.Generic;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public int GetTotalStrawberriesSafe(OriginalSaveDataState save) => save.TotalStrawberries;
        public void SetTotalStrawberriesSafe(OriginalSaveDataState save, int value) => save.TotalStrawberries = value;
        public List<string> GetPoemSafe(OriginalSaveDataState save) => save.Poem;
        public void SetPoemSafe(OriginalSaveDataState save, List<string> value) => save.Poem = value;

        public bool RegisterPoemEntry(OriginalSaveDataState save, string id)
        {
            id = id.ToLower();
            if (GetPoemSafe(save).Contains(id)) return false;
            GetPoemSafe(save).Add(id);
            return true;
        }
    }
}
