using Celeste.Core.Rendering.Resources;

namespace Celeste.Core.Rendering.States
{
    public class SourceBlendState : SourceGraphicsResource
    {
        public static readonly SourceBlendState Additive = new SourceBlendState("BlendState.Additive",
            SourceBlendFactor.SourceAlpha, SourceBlendFactor.SourceAlpha, SourceBlendFactor.One, SourceBlendFactor.One);

        public static readonly SourceBlendState AlphaBlend = new SourceBlendState("BlendState.AlphaBlend",
            SourceBlendFactor.One, SourceBlendFactor.One, SourceBlendFactor.InverseSourceAlpha,
            SourceBlendFactor.InverseSourceAlpha);

        public static readonly SourceBlendState NonPremultiplied = new SourceBlendState("BlendState.NonPremultiplied",
            SourceBlendFactor.SourceAlpha, SourceBlendFactor.SourceAlpha, SourceBlendFactor.InverseSourceAlpha,
            SourceBlendFactor.InverseSourceAlpha);

        public static readonly SourceBlendState Opaque = new SourceBlendState("BlendState.Opaque",
            SourceBlendFactor.One,
            SourceBlendFactor.One, SourceBlendFactor.Zero, SourceBlendFactor.Zero);

        private SourceNativeBlendState state;

        public ref SourceNativeBlendState NativeState => ref state;

        public SourceBlendFunction AlphaBlendFunction
        {
            get { return state.alphaBlendFunction; }
            set { state.alphaBlendFunction = value; }
        }

        public SourceBlendFactor AlphaDestinationBlend
        {
            get { return state.alphaDestinationBlend; }
            set { state.alphaDestinationBlend = value; }
        }

        public SourceBlendFactor AlphaSourceBlend
        {
            get { return state.alphaSourceBlend; }
            set { state.alphaSourceBlend = value; }
        }

        public SourceBlendFunction ColorBlendFunction
        {
            get { return state.colorBlendFunction; }
            set { state.colorBlendFunction = value; }
        }

        public SourceBlendFactor ColorDestinationBlend
        {
            get { return state.colorDestinationBlend; }
            set { state.colorDestinationBlend = value; }
        }

        public SourceBlendFactor ColorSourceBlend
        {
            get { return state.colorSourceBlend; }
            set { state.colorSourceBlend = value; }
        }

        public SourceColorWriteChannels ColorWriteChannels
        {
            get { return state.colorWriteEnable; }
            set { state.colorWriteEnable = value; }
        }

        public SourceColorWriteChannels ColorWriteChannels1
        {
            get { return state.colorWriteEnable1; }
            set { state.colorWriteEnable1 = value; }
        }

        public SourceColorWriteChannels ColorWriteChannels2
        {
            get { return state.colorWriteEnable2; }
            set { state.colorWriteEnable2 = value; }
        }

        public SourceColorWriteChannels ColorWriteChannels3
        {
            get { return state.colorWriteEnable3; }
            set { state.colorWriteEnable3 = value; }
        }

        public uint PackedBlendFactor
        {
            get { return state.blendFactor; }
            set { state.blendFactor = value; }
        }

        public int MultiSampleMask
        {
            get { return state.multiSampleMask; }
            set { state.multiSampleMask = value; }
        }

        protected internal override bool IsHarmlessToLeakInstance => true;

        public SourceBlendState()
        {
            AlphaBlendFunction = SourceBlendFunction.Add;
            AlphaDestinationBlend = SourceBlendFactor.Zero;
            AlphaSourceBlend = SourceBlendFactor.One;
            ColorBlendFunction = SourceBlendFunction.Add;
            ColorDestinationBlend = SourceBlendFactor.Zero;
            ColorSourceBlend = SourceBlendFactor.One;
            ColorWriteChannels = SourceColorWriteChannels.All;
            ColorWriteChannels1 = SourceColorWriteChannels.All;
            ColorWriteChannels2 = SourceColorWriteChannels.All;
            ColorWriteChannels3 = SourceColorWriteChannels.All;
            PackedBlendFactor = uint.MaxValue;
            MultiSampleMask = -1;
        }

        private SourceBlendState(string name, SourceBlendFactor colorSourceBlend, SourceBlendFactor alphaSourceBlend,
            SourceBlendFactor colorDestBlend, SourceBlendFactor alphaDestBlend)
            : this()
        {
            Name = name;
            ColorSourceBlend = colorSourceBlend;
            AlphaSourceBlend = alphaSourceBlend;
            ColorDestinationBlend = colorDestBlend;
            AlphaDestinationBlend = alphaDestBlend;
        }
    }
}
