using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public void RegisterHeartGem(OriginalSaveDataState save, OriginalAreaKey area)
        {
            OriginalSaveHeartSource.RegisterHeartGem(save, area, this, statistics);
        }
    }
}
