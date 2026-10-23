using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveStartSourceHooksEnvironment
    {
        void AfterSourceSaveStart(OriginalSaveDataState actualSave);
    }
}
