using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.States
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SourceNativeDepthStencilState
    {
        public byte depthBufferEnable;

        public byte depthBufferWriteEnable;

        public SourceCompareFunction depthBufferFunction;

        public byte stencilEnable;

        public int stencilMask;

        public int stencilWriteMask;

        public byte twoSidedStencilMode;

        public SourceStencilOperation stencilFail;

        public SourceStencilOperation stencilDepthBufferFail;

        public SourceStencilOperation stencilPass;

        public SourceCompareFunction stencilFunction;

        public SourceStencilOperation ccwStencilFail;

        public SourceStencilOperation ccwStencilDepthBufferFail;

        public SourceStencilOperation ccwStencilPass;

        public SourceCompareFunction ccwStencilFunction;

        public int referenceStencil;
    }
}
