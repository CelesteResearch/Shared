using Celeste.Input.Runtime;
using System;

namespace Celeste.Graphics.Rendering.Devices
{
    public sealed class SourceHostWindowPlatform : ISourceGameWindowPlatform
    {
        private readonly ISourceHostWindowIO device;
        private readonly ISourceWindowInputMetrics input;

        public SourceHostWindowPlatform(ISourceHostWindowIO device, ISourceWindowInputMetrics input)
        {
            this.device = device;
            this.input = input;
        }

        public SourceGameWindow CreateWindow() => new SourceHostGameWindow(device);

        public void DisposeWindow(SourceGameWindow window)
        {
            if (input.MouseWindowHandle == window.Handle) input.MouseWindowHandle = IntPtr.Zero;
            if (input.TouchWindowHandle == window.Handle) input.TouchWindowHandle = IntPtr.Zero;
        }

        public bool SupportsOrientationChanges() => false;

        public void ScaleForWindow(IntPtr handle, bool invert, ref int width, ref int height)
        {
            device.GetWindowSize(out int w2, out int h2);
            device.GetDrawableSize(out int w3, out int h3);
            if (w2 != 0 && h2 != 0 && w3 != 0 && h3 != 0 && (w2 != w3 || h2 != h3))
            {
                if (invert)
                {
                    width = (int)((float)width * ((float)w3 / (float)w2));
                    height = (int)((float)height * ((float)h3 / (float)h2));
                }
                else
                {
                    width = (int)((float)width / ((float)w3 / (float)w2));
                    height = (int)((float)height / ((float)h3 / (float)h2));
                }
            }
        }
    }
}
