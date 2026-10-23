using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public void AddTime(OriginalSaveDataState save, OriginalAreaKey area, long ticks)
        {
            OriginalSaveTimeSource.AddTime(save, area, ticks, this);
        }
    }
}
