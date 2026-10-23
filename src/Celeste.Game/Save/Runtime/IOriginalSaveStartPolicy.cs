using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveStartPolicy
    {
        void Start(OriginalSaveDataState data, int slot, IOriginalSaveInitializationServices services);
    }
}
