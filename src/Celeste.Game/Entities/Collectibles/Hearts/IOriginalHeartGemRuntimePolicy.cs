using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Save.Data;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public interface IOriginalHeartGemRuntimePolicy
    {
        bool InstalledDialogs { get; }
        bool InstalledFakeHeartColor { get; }
        void BeforeCollectRoutine(OriginalLevelSceneRoot level, RoomPlayerSession player, bool isFake);
        bool IsCompleteArea(OriginalLevelSceneRoot level, bool isFake, bool originalValue);
        int TotalHeartsForAchievement(ISourceEngineContext engine, OriginalSaveDataState save);
    }
}
