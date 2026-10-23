using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11StencilOperationDesc
    {
        public uint StencilFailOperation;
        public uint DepthFailOperation;
        public uint PassOperation;
        public uint Function;
    }
}
