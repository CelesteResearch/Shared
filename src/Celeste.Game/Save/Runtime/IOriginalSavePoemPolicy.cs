using System.Collections.Generic;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSavePoemPolicy
    {
        List<string> GetPoemSafe(OriginalSaveDataState save);
        void SetPoemSafe(OriginalSaveDataState save, List<string> value);
        bool RegisterPoemEntry(OriginalSaveDataState save, string id);
    }
}
