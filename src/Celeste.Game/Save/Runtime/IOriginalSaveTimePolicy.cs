using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveTimePolicy
    {
        void AddTime(OriginalSaveDataState save, OriginalAreaKey area, long ticks);
    }
}
