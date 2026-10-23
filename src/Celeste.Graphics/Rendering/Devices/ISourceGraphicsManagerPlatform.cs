using System;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGraphicsManagerPlatform
    {
        bool SupportsOrientationChanges();
        void ScaleForWindow(IntPtr handle, bool invert, ref int width, ref int height);
    }
}
