using Celeste.Core.Rendering.Resources;

namespace Celeste.Core.Rendering.States
{
    public class SourceDepthStencilState : SourceGraphicsResource
    {
        public static readonly SourceDepthStencilState Default = new SourceDepthStencilState(
            "DepthStencilState.Default",
            depthBufferEnable: true, depthBufferWriteEnable: true);

        public static readonly SourceDepthStencilState DepthRead =
            new SourceDepthStencilState("DepthStencilState.DepthRead", depthBufferEnable: true,
                depthBufferWriteEnable: false);

        public static readonly SourceDepthStencilState None = new SourceDepthStencilState("DepthStencilState.None",
            depthBufferEnable: false, depthBufferWriteEnable: false);

        private SourceNativeDepthStencilState state;

        public ref SourceNativeDepthStencilState NativeState => ref state;

        public bool DepthBufferEnable
        {
            get { return state.depthBufferEnable == 1; }
            set { state.depthBufferEnable = (value ? ((byte)1) : ((byte)0)); }
        }

        public bool DepthBufferWriteEnable
        {
            get { return state.depthBufferWriteEnable == 1; }
            set { state.depthBufferWriteEnable = (value ? ((byte)1) : ((byte)0)); }
        }

        public SourceStencilOperation CounterClockwiseStencilDepthBufferFail
        {
            get { return state.ccwStencilDepthBufferFail; }
            set { state.ccwStencilDepthBufferFail = value; }
        }

        public SourceStencilOperation CounterClockwiseStencilFail
        {
            get { return state.ccwStencilFail; }
            set { state.ccwStencilFail = value; }
        }

        public SourceCompareFunction CounterClockwiseStencilFunction
        {
            get { return state.ccwStencilFunction; }
            set { state.ccwStencilFunction = value; }
        }

        public SourceStencilOperation CounterClockwiseStencilPass
        {
            get { return state.ccwStencilPass; }
            set { state.ccwStencilPass = value; }
        }

        public SourceCompareFunction DepthBufferFunction
        {
            get { return state.depthBufferFunction; }
            set { state.depthBufferFunction = value; }
        }

        public int ReferenceStencil
        {
            get { return state.referenceStencil; }
            set { state.referenceStencil = value; }
        }

        public SourceStencilOperation StencilDepthBufferFail
        {
            get { return state.stencilDepthBufferFail; }
            set { state.stencilDepthBufferFail = value; }
        }

        public bool StencilEnable
        {
            get { return state.stencilEnable == 1; }
            set { state.stencilEnable = (value ? ((byte)1) : ((byte)0)); }
        }

        public SourceStencilOperation StencilFail
        {
            get { return state.stencilFail; }
            set { state.stencilFail = value; }
        }

        public SourceCompareFunction StencilFunction
        {
            get { return state.stencilFunction; }
            set { state.stencilFunction = value; }
        }

        public int StencilMask
        {
            get { return state.stencilMask; }
            set { state.stencilMask = value; }
        }

        public SourceStencilOperation StencilPass
        {
            get { return state.stencilPass; }
            set { state.stencilPass = value; }
        }

        public int StencilWriteMask
        {
            get { return state.stencilWriteMask; }
            set { state.stencilWriteMask = value; }
        }

        public bool TwoSidedStencilMode
        {
            get { return state.twoSidedStencilMode == 1; }
            set { state.twoSidedStencilMode = (value ? ((byte)1) : ((byte)0)); }
        }

        protected internal override bool IsHarmlessToLeakInstance => true;

        public SourceDepthStencilState()
        {
            DepthBufferEnable = true;
            DepthBufferWriteEnable = true;
            DepthBufferFunction = SourceCompareFunction.LessEqual;
            StencilEnable = false;
            StencilFunction = SourceCompareFunction.Always;
            StencilPass = SourceStencilOperation.Keep;
            StencilFail = SourceStencilOperation.Keep;
            StencilDepthBufferFail = SourceStencilOperation.Keep;
            TwoSidedStencilMode = false;
            CounterClockwiseStencilFunction = SourceCompareFunction.Always;
            CounterClockwiseStencilFail = SourceStencilOperation.Keep;
            CounterClockwiseStencilPass = SourceStencilOperation.Keep;
            CounterClockwiseStencilDepthBufferFail = SourceStencilOperation.Keep;
            StencilMask = int.MaxValue;
            StencilWriteMask = int.MaxValue;
            ReferenceStencil = 0;
        }

        private SourceDepthStencilState(string name, bool depthBufferEnable, bool depthBufferWriteEnable)
            : this()
        {
            Name = name;
            DepthBufferEnable = depthBufferEnable;
            DepthBufferWriteEnable = depthBufferWriteEnable;
        }
    }
}
