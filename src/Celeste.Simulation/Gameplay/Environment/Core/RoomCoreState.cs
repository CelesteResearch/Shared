using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Gameplay.Environment.Core
{
    public sealed class RoomCoreState
    {
        public RoomCoreMode Mode { get; private set; }
        private readonly IRoomCoreModeChangeEffects beforeListeners;
        public readonly List<Action<RoomCoreMode>> Listeners = new List<Action<RoomCoreMode>>();

        public RoomCoreState(IRoomCoreModeChangeEffects beforeListeners = null)
        {
            this.beforeListeners = beforeListeners;
        }

        public void SetMode(RoomCoreMode mode)
        {
            if (Mode == mode) return;
            Mode = mode;
            beforeListeners?.OnCoreModeChanged(mode);
            foreach (var listener in Listeners) listener?.Invoke(mode);
        }
    }
}
