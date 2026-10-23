using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11Box
    {
        public uint Left;
        public uint Top;
        public uint Front;
        public uint Right;
        public uint Bottom;
        public uint Back;
    }
}
