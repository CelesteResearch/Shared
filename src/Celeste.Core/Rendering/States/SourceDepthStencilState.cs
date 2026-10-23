using Celeste.Core.Rendering.Resources;

namespace Celeste.Core.Rendering.States
{
    public class SourceDepthStencilState : SourceGraphicsResource
    {
        public static readonly SourceDepthStencilState Default = new("DepthStencilState.Default", true, true);
        public static readonly SourceDepthStencilState DepthRead = new("DepthStencilState.DepthRead", true, false);
        public static readonly SourceDepthStencilState None = new("DepthStencilState.None", false, false);
        private SourceNativeDepthStencilState _state;
        public ref SourceNativeDepthStencilState NativeState => ref _state;

        public bool DepthBufferEnable
        {
            get => _state.depthBufferEnable == 1;
            set => _state.depthBufferEnable = value ? (byte)1 : (byte)0;
        }

        public bool DepthBufferWriteEnable
        {
            get => _state.depthBufferWriteEnable == 1;
            set => _state.depthBufferWriteEnable = value ? (byte)1 : (byte)0;
        }

        public SourceStencilOperation CounterClockwiseStencilDepthBufferFail
        {
            get => _state.ccwStencilDepthBufferFail;
            set => _state.ccwStencilDepthBufferFail = value;
        }

        public SourceStencilOperation CounterClockwiseStencilFail
        {
            get => _state.ccwStencilFail;
            set => _state.ccwStencilFail = value;
        }

        public SourceCompareFunction CounterClockwiseStencilFunction
        {
            get => _state.ccwStencilFunction;
            set => _state.ccwStencilFunction = value;
        }

        public SourceStencilOperation CounterClockwiseStencilPass
        {
            get => _state.ccwStencilPass;
            set => _state.ccwStencilPass = value;
        }

        public SourceCompareFunction DepthBufferFunction
        {
            get => _state.depthBufferFunction;
            set => _state.depthBufferFunction = value;
        }

        public int ReferenceStencil
        {
            get => _state.referenceStencil;
            set => _state.referenceStencil = value;
        }

        public SourceStencilOperation StencilDepthBufferFail
        {
            get => _state.stencilDepthBufferFail;
            set => _state.stencilDepthBufferFail = value;
        }

        public bool StencilEnable
        {
            get => _state.stencilEnable == 1;
            set => _state.stencilEnable = value ? (byte)1 : (byte)0;
        }

        public SourceStencilOperation StencilFail
        {
            get => _state.stencilFail;
            set => _state.stencilFail = value;
        }

        public SourceCompareFunction StencilFunction
        {
            get => _state.stencilFunction;
            set => _state.stencilFunction = value;
        }

        public int StencilMask
        {
            get => _state.stencilMask;
            set => _state.stencilMask = value;
        }

        public SourceStencilOperation StencilPass
        {
            get => _state.stencilPass;
            set => _state.stencilPass = value;
        }

        public int StencilWriteMask
        {
            get => _state.stencilWriteMask;
            set => _state.stencilWriteMask = value;
        }

        public bool TwoSidedStencilMode
        {
            get => _state.twoSidedStencilMode == 1;
            set => _state.twoSidedStencilMode = value ? (byte)1 : (byte)0;
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

        private SourceDepthStencilState(string name, bool depthBufferEnable, bool depthBufferWriteEnable) : this()
        {
            Name = name;
            DepthBufferEnable = depthBufferEnable;
            DepthBufferWriteEnable = depthBufferWriteEnable;
        }
    }
}
