using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Direct3D11.Interop.Descriptors
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct D3D11Texture2DDesc
    {
        public uint Width;
        public uint Height;
        public uint MipLevels;
        public uint ArraySize;
        public uint Format;
        public D3D11SampleDesc Sample;
        public uint Usage;
        public uint BindFlags;
        public uint CPUAccessFlags;
        public uint MiscFlags;
    }
}
