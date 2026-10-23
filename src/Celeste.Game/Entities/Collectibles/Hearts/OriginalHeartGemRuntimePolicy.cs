using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public sealed class OriginalHeartGemRuntimePolicy : IOriginalHeartGemRuntimePolicy
    {
        public bool InstalledDialogs => false;
        public bool InstalledFakeHeartColor => false;

        public void BeforeCollectRoutine(OriginalLevelSceneRoot level, RoomPlayerSession player, bool isFake)
        {
        }

        public bool IsCompleteArea(OriginalLevelSceneRoot level, bool isFake, bool originalValue) => originalValue;

        public int TotalHeartsForAchievement(ISourceEngineContext engine, OriginalSaveDataState save)
            => ((IOriginalSaveCounterEnvironment)engine).SaveCounters.TotalHeartGems(save);
    }
}
