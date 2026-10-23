using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public void AddTime(OriginalSaveDataState save, OriginalAreaKey area, long ticks)
        {
            OriginalSaveTimeSource.AddTime(save, area, ticks, this);
        }
    }
}
