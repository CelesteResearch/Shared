using System;
using Celeste.Game.Presentation.Hud.Speedrun;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public SpeedrunTimerState SpeedrunTimer { get; private set; }

        public void ConstructSourceSpeedrunTimer()
        {
            if (SpeedrunTimer != null)
                throw new InvalidOperationException("The actual Level speedrun timer is already constructed.");
            SpeedrunTimer = new SpeedrunTimerState(EngineContext);
            Scheduler.QueueSourceEntity(SpeedrunTimer);
        }
    }
}
