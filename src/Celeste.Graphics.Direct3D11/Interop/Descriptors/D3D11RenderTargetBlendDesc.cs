using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11RenderTargetBlendDesc
    {
        public int BlendEnable;
        public uint SourceBlend;
        public uint DestinationBlend;
        public uint BlendOperation;
        public uint SourceAlphaBlend;
        public uint DestinationAlphaBlend;
        public uint AlphaBlendOperation;
        public byte WriteMask;
    }
}
