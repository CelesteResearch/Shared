using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.States
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativeRasterizerState
    {
        public SourceFillMode fillMode;

        public SourceCullMode cullMode;

        public float depthBias;

        public float slopeScaleDepthBias;

        public byte scissorTestEnable;

        public byte multiSampleAntiAlias;
    }
}
