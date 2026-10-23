using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Devices
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativeDisplayMode
    {
        public uint format;
        public int w;
        public int h;
        public int refresh_rate;
        public IntPtr driverdata;
    }
}
