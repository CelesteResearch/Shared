using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCassettePolicy
    {
        void RegisterCassette(OriginalSaveDataState actualSave, OriginalAreaKey area);
    }
}
