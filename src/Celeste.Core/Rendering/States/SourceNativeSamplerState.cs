using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.States
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativeSamplerState
    {
        public SourceTextureFilter filter;

        public SourceTextureAddressMode addressU;

        public SourceTextureAddressMode addressV;

        public SourceTextureAddressMode addressW;

        public float mipMapLevelOfDetailBias;

        public int maxAnisotropy;

        public int maxMipLevel;
    }
}
