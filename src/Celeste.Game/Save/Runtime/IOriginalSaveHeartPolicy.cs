using Celeste.Game.Save.Data;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveHeartPolicy
    {
        void RegisterHeartGem(OriginalSaveDataState save, OriginalAreaKey area);
    }
}
