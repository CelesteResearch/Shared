using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11DepthStencilDesc
    {
        public int DepthEnable;
        public uint DepthWriteMask;
        public uint DepthFunction;
        public int StencilEnable;
        public byte StencilReadMask;
        public byte StencilWriteMask;
        public D3D11StencilOperationDesc FrontFace;
        public D3D11StencilOperationDesc BackFace;
    }
}
