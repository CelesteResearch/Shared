using Celeste.Game.Execution.Areas;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Save.Data;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public void RegisterCassette(OriginalSaveDataState actualSave, OriginalAreaKey area)
        {
            GetAreasSafe(actualSave)[area.ID].Cassette = true;
            statistics.Statistics.Achievements.Register(OriginalAchievement.CASS);
        }
    }
}
