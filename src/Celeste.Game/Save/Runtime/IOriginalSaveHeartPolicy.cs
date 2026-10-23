using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveHeartPolicy
    {
        void RegisterHeartGem(OriginalSaveDataState save, OriginalAreaKey area);
    }
}
