using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSavePoemPolicy
    {
        System.Collections.Generic.List<string> GetPoemSafe(OriginalSaveDataState save);
        void SetPoemSafe(OriginalSaveDataState save, System.Collections.Generic.List<string> value);
        bool RegisterPoemEntry(OriginalSaveDataState save, string id);
    }
}
