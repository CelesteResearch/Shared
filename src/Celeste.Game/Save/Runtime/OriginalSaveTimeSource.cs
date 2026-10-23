using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public static class OriginalSaveTimeSource
    {
        public static void AddTime(OriginalSaveDataState save, OriginalAreaKey area, long ticks,
            IOriginalSaveCounterQueries counters)
        {
            save.Time = unchecked(save.Time + ticks);
            var mode = counters.GetAreasSafe(save)[area.ID].Modes[area.Mode];
            mode.TimePlayed = unchecked(mode.TimePlayed + ticks);
        }
    }
}
