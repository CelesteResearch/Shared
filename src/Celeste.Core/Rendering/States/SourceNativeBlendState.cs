using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.States
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativeBlendState
    {
        public SourceBlendFactor colorSourceBlend;

        public SourceBlendFactor colorDestinationBlend;

        public SourceBlendFunction colorBlendFunction;

        public SourceBlendFactor alphaSourceBlend;

        public SourceBlendFactor alphaDestinationBlend;

        public SourceBlendFunction alphaBlendFunction;

        public SourceColorWriteChannels colorWriteEnable;

        public SourceColorWriteChannels colorWriteEnable1;

        public SourceColorWriteChannels colorWriteEnable2;

        public SourceColorWriteChannels colorWriteEnable3;

        public uint blendFactor;

        public int multiSampleMask;
    }
}
