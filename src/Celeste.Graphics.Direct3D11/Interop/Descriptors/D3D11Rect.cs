using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
