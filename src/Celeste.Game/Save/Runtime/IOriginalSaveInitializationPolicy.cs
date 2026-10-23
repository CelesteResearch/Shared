using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveInitializationPolicy
    {
        string GetFilename(int slot);
        void AfterInitialize(OriginalSaveDataState save, IOriginalSaveInitializationServices services);
    }
}
