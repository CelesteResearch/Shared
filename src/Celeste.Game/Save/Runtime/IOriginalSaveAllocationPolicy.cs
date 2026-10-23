using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveAllocationPolicy
    {
        OriginalSaveDataState CreateSave();
    }
}
