using Celeste.Core.Display;
using System;
using Celeste.Core.Geometry;
using Celeste.Core.Framework.Services;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGraphicsManagerPlatform
    {
        bool SupportsOrientationChanges();
        void ScaleForWindow(IntPtr handle, bool invert, ref int width, ref int height);
    }
}
