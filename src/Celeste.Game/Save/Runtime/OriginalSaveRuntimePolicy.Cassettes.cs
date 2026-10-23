using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Data;
using Celeste.Game.Platform.Statistics;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public void RegisterCassette(OriginalSaveDataState actualSave, OriginalAreaKey area)
        {
            actualSave.Areas[area.ID].Cassette = true;
            statistics.Statistics.Achievements.Register(OriginalAchievement.CASS);
        }
    }
}
