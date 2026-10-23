using System;
using Celeste.Game.Presentation.Hud.Strawberries;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public bool TimerHidden;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public TotalStrawberriesDisplayState StrawberriesDisplay => strawberriesDisplay;

        public void ConstructSourceTotalStrawberriesDisplay()
        {
            if (StrawberriesDisplay != null)
                throw new InvalidOperationException("The actual Level strawberries display is already constructed.");
            strawberriesDisplay = new(EngineContext);
            Scheduler.QueueSourceEntity(StrawberriesDisplay);
        }
    }
}
