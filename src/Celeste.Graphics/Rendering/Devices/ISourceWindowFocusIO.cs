using System;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceWindowFocusIO
    {
        Action<IntPtr> SdlRaiseWindow { get; }
        bool SetForegroundWindow(IntPtr handle);
    }
}
