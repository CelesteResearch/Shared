using Celeste.Core.Rendering.Resources;

namespace Celeste.Core.Rendering.States
{
    public class SourceRasterizerState : SourceGraphicsResource
    {
        public static readonly SourceRasterizerState CullClockwise =
            new("RasterizerState.CullClockwise", SourceCullMode.CullClockwiseFace);

        public static readonly SourceRasterizerState CullCounterClockwise =
            new("RasterizerState.CullCounterClockwise", SourceCullMode.CullCounterClockwiseFace);

        public static readonly SourceRasterizerState CullNone = new("RasterizerState.CullNone", SourceCullMode.None);
        private SourceNativeRasterizerState _state;
        public ref SourceNativeRasterizerState NativeState => ref _state;

        public SourceCullMode CullMode
        {
            get => _state.cullMode;
            set => _state.cullMode = value;
        }

        public float DepthBias
        {
            get => _state.depthBias;
            set => _state.depthBias = value;
        }

        public SourceFillMode FillMode
        {
            get => _state.fillMode;
            set => _state.fillMode = value;
        }

        public bool MultiSampleAntiAlias
        {
            get => _state.multiSampleAntiAlias == 1;
            set => _state.multiSampleAntiAlias = value ? (byte)1 : (byte)0;
        }

        public bool ScissorTestEnable
        {
            get => _state.scissorTestEnable == 1;
            set => _state.scissorTestEnable = value ? (byte)1 : (byte)0;
        }

        public float SlopeScaleDepthBias
        {
            get => _state.slopeScaleDepthBias;
            set => _state.slopeScaleDepthBias = value;
        }

        protected internal override bool IsHarmlessToLeakInstance => true;

        public SourceRasterizerState()
        {
            CullMode = SourceCullMode.CullCounterClockwiseFace;
            FillMode = SourceFillMode.Solid;
            DepthBias = 0f;
            MultiSampleAntiAlias = true;
            ScissorTestEnable = false;
            SlopeScaleDepthBias = 0f;
        }

        private SourceRasterizerState(string name, SourceCullMode cullMode) : this()
        {
            Name = name;
            CullMode = cullMode;
        }
    }
}
