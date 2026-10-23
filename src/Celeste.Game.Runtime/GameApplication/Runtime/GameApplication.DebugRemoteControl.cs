using System;
using Celeste.Everest.Runtime.Startup;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestDebugRemoteControlEnvironment,
        IEverestDebugRemoteControlPhysicalEnvironment
    {
        private EverestDebugRemoteControlProcess sourceDebugRemoteControl;

        public EverestDebugRemoteControlProcess DebugRC => sourceDebugRemoteControl ??
                                                           throw new InvalidOperationException(
                                                               "The actual source debug remote control is not constructed.");

        SourceGameWindow IEverestDebugRemoteControlPhysicalEnvironment.Window => ActualGame.Window;

        ISourceWindowFocusIO IEverestDebugRemoteControlPhysicalEnvironment.WindowFocus =>
            (ISourceWindowFocusIO)PhysicalIO.WindowFocus;

        internal void ConstructSourceDebugRemoteControl()
        {
            if (sourceDebugRemoteControl != null)
                throw new InvalidOperationException("The actual source debug remote control is already constructed.");
            sourceDebugRemoteControl = new(this);
        }
    }
}
