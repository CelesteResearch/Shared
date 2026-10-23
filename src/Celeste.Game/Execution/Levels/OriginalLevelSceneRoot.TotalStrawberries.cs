using System;
using Celeste.Game.Presentation.Hud.Strawberries;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool TimerHidden;
        public TotalStrawberriesDisplayState StrawberriesDisplay => strawberriesDisplay;

        public void ConstructSourceTotalStrawberriesDisplay()
        {
            if (strawberriesDisplay != null)
                throw new InvalidOperationException("The actual Level strawberries display is already constructed.");
            strawberriesDisplay = new TotalStrawberriesDisplayState(EngineContext);
            Scheduler.QueueSourceEntity(strawberriesDisplay);
        }
    }
}
