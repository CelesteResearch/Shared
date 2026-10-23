using System;
using Celeste.Graphics.Direct3D11.Interop;

namespace Celeste.Graphics.Direct3D11.Submission
{
    public static unsafe class Direct3D11FrameOutput
    {
        public static void Configure(IntPtr device, int width, int height)
        {
            Direct3D11GraphicsBindings.RequireSuccess(Direct3D11GraphicsBindings.SourceGpuConfigureFrameOutput(device,
                checked((uint)width), checked((uint)height)));
        }

        public static int ReadRgba(IntPtr device, byte[] rgba)
        {
            if (rgba == null) throw new ArgumentNullException(nameof(rgba));
            fixed (byte* destination = rgba)
            {
                Direct3D11GraphicsBindings.RequireSuccess(Direct3D11GraphicsBindings.SourceGpuReadFrameRgba(device,
                    (IntPtr)destination, checked((uint)rgba.Length), out uint written));
                return checked((int)written);
            }
        }
    }
}
