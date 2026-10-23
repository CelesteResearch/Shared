using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public void RegisterHeartGem(OriginalSaveDataState save, OriginalAreaKey area)
        {
            OriginalSaveHeartSource.RegisterHeartGem(save, area, this, statistics);
        }
    }
}
