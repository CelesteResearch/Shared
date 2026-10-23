using Celeste.Core.Rendering.Resources;

namespace Celeste.Core.Rendering.States
{
    public class SourceRasterizerState : SourceGraphicsResource
    {
        public static readonly SourceRasterizerState CullClockwise =
            new SourceRasterizerState("RasterizerState.CullClockwise", SourceCullMode.CullClockwiseFace);

        public static readonly SourceRasterizerState CullCounterClockwise =
            new SourceRasterizerState("RasterizerState.CullCounterClockwise", SourceCullMode.CullCounterClockwiseFace);

        public static readonly SourceRasterizerState CullNone =
            new SourceRasterizerState("RasterizerState.CullNone", SourceCullMode.None);

        private SourceNativeRasterizerState state;

        public ref SourceNativeRasterizerState NativeState => ref state;

        public SourceCullMode CullMode
        {
            get { return state.cullMode; }
            set { state.cullMode = value; }
        }

        public float DepthBias
        {
            get { return state.depthBias; }
            set { state.depthBias = value; }
        }

        public SourceFillMode FillMode
        {
            get { return state.fillMode; }
            set { state.fillMode = value; }
        }

        public bool MultiSampleAntiAlias
        {
            get { return state.multiSampleAntiAlias == 1; }
            set { state.multiSampleAntiAlias = (value ? ((byte)1) : ((byte)0)); }
        }

        public bool ScissorTestEnable
        {
            get { return state.scissorTestEnable == 1; }
            set { state.scissorTestEnable = (value ? ((byte)1) : ((byte)0)); }
        }

        public float SlopeScaleDepthBias
        {
            get { return state.slopeScaleDepthBias; }
            set { state.slopeScaleDepthBias = value; }
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

        private SourceRasterizerState(string name, SourceCullMode cullMode)
            : this()
        {
            Name = name;
            CullMode = cullMode;
        }
    }
}
