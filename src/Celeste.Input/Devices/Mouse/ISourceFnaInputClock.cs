using System;

namespace Celeste.Input.Devices.Mouse
{
    public interface ISourceFnaInputClock
    {
        DateTime Now { get; }
        int TickCount { get; }
    }
}
