using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public void RegisterHeartGem(OriginalSaveDataState save, OriginalAreaKey area)
            => OriginalSaveHeartSource.RegisterHeartGem(save, area, this, statistics);
    }
}
