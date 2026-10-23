using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11VertexBinding
    {
        public IntPtr Buffer;
        public uint Stride;
        public uint Offset;
    }
}
