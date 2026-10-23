using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11DepthStencilViewDesc
    {
        public uint Format;
        public uint Dimension;
        public uint Flags;
        public uint Union0;
        public uint Union1;
        public uint Union2;
    }
}
