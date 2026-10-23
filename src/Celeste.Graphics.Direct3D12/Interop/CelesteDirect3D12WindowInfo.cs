using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D12.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CelesteDirect3D12WindowInfo
    {
        public IntPtr window;
        public uint width;
        public uint height;
        public uint interval;
    }
}
