using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public void RegisterHeartGem(OriginalSaveDataState save, OriginalAreaKey area)
            => OriginalSaveHeartSource.RegisterHeartGem(save, area, this, statistics);
    }
}
