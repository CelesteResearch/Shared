using Celeste.Game.Gameplay.Platforms.Cassette;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void StartSourceCassetteManager()
        {
            var managers = Scheduler.Entities.GetTrackedEntities("Celeste.CassetteBlockManager");
            if (managers.Count > 0)
                ((OriginalCassetteBlockManagerState)managers[0]).OnLevelStart();
        }
    }
}
