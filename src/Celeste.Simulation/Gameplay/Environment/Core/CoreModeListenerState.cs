using System;
using Celeste.Core.Components;

namespace Celeste.Simulation.Gameplay.Environment.Core
{
    public class CoreModeListenerState : SourceComponentState
    {
        public Action<RoomCoreMode> OnChange;
        public CoreModeListenerState(Action<RoomCoreMode> onChange) : base(false, false) => OnChange = onChange;
    }
}
