using System;
using Celeste.Input.Runtime;

namespace Celeste.Graphics.Rendering.Devices
{
    public sealed class SourceHostWindowPlatform(ISourceHostWindowIO device, ISourceWindowInputMetrics input)
        : ISourceGameWindowPlatform
    {
        private readonly ISourceHostWindowIO device = device;
        private readonly ISourceWindowInputMetrics input = input;

        public SourceGameWindow CreateWindow()
        {
            return new SourceHostGameWindow(device);
        }

        public void DisposeWindow(SourceGameWindow window)
        {
            if (input.MouseWindowHandle == window.Handle)
                input.MouseWindowHandle = IntPtr.Zero;
            if (input.TouchWindowHandle == window.Handle)
                input.TouchWindowHandle = IntPtr.Zero;
        }

        public bool SupportsOrientationChanges()
        {
            return false;
        }

        public void ScaleForWindow(IntPtr handle, bool invert, ref int width, ref int height)
        {
            device.GetWindowSize(out var w2, out var h2);
            device.GetDrawableSize(out var w3, out var h3);
            if (w2 != 0 && h2 != 0 && w3 != 0 && h3 != 0 && (w2 != w3 || h2 != h3))
            {
                if (invert)
                {
                    width = (int)(width * (w3 / (float)w2));
                    height = (int)(height * (h3 / (float)h2));
                }
                else
                {
                    width = (int)(width / (w3 / (float)w2));
                    height = (int)(height / (h3 / (float)h2));
                }
            }
        }
    }
}
