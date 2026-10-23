using System;
using Celeste.Game.Presentation.Hud.Statistics;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public GameplayStatsState GameplayStats { get; private set; }

        public void ConstructSourceGameplayStats()
        {
            if (GameplayStats != null)
                throw new InvalidOperationException("The actual Level GameplayStats is already constructed.");
            GameplayStats = new GameplayStatsState(EngineContext);
            Scheduler.QueueSourceEntity(GameplayStats);
        }
    }
}
