using Celeste.Game.Save.Data;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveTimePolicy
    {
        void AddTime(OriginalSaveDataState save, OriginalAreaKey area, long ticks);
    }
}
