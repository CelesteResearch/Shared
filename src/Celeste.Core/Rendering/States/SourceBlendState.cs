using Celeste.Core.Rendering.Resources;

namespace Celeste.Core.Rendering.States
{
    public class SourceBlendState : SourceGraphicsResource
    {
        public static readonly SourceBlendState Additive = new("BlendState.Additive", SourceBlendFactor.SourceAlpha,
            SourceBlendFactor.SourceAlpha, SourceBlendFactor.One, SourceBlendFactor.One);

        public static readonly SourceBlendState AlphaBlend = new("BlendState.AlphaBlend", SourceBlendFactor.One,
            SourceBlendFactor.One, SourceBlendFactor.InverseSourceAlpha, SourceBlendFactor.InverseSourceAlpha);

        public static readonly SourceBlendState NonPremultiplied = new("BlendState.NonPremultiplied",
            SourceBlendFactor.SourceAlpha, SourceBlendFactor.SourceAlpha, SourceBlendFactor.InverseSourceAlpha,
            SourceBlendFactor.InverseSourceAlpha);

        public static readonly SourceBlendState Opaque = new("BlendState.Opaque", SourceBlendFactor.One,
            SourceBlendFactor.One, SourceBlendFactor.Zero, SourceBlendFactor.Zero);

        private SourceNativeBlendState _state;
        public ref SourceNativeBlendState NativeState => ref _state;

        public SourceBlendFunction AlphaBlendFunction
        {
            get => _state.alphaBlendFunction;
            set => _state.alphaBlendFunction = value;
        }

        public SourceBlendFactor AlphaDestinationBlend
        {
            get => _state.alphaDestinationBlend;
            set => _state.alphaDestinationBlend = value;
        }

        public SourceBlendFactor AlphaSourceBlend
        {
            get => _state.alphaSourceBlend;
            set => _state.alphaSourceBlend = value;
        }

        public SourceBlendFunction ColorBlendFunction
        {
            get => _state.colorBlendFunction;
            set => _state.colorBlendFunction = value;
        }

        public SourceBlendFactor ColorDestinationBlend
        {
            get => _state.colorDestinationBlend;
            set => _state.colorDestinationBlend = value;
        }

        public SourceBlendFactor ColorSourceBlend
        {
            get => _state.colorSourceBlend;
            set => _state.colorSourceBlend = value;
        }

        public SourceColorWriteChannels ColorWriteChannels
        {
            get => _state.colorWriteEnable;
            set => _state.colorWriteEnable = value;
        }

        public SourceColorWriteChannels ColorWriteChannels1
        {
            get => _state.colorWriteEnable1;
            set => _state.colorWriteEnable1 = value;
        }

        public SourceColorWriteChannels ColorWriteChannels2
        {
            get => _state.colorWriteEnable2;
            set => _state.colorWriteEnable2 = value;
        }

        public SourceColorWriteChannels ColorWriteChannels3
        {
            get => _state.colorWriteEnable3;
            set => _state.colorWriteEnable3 = value;
        }

        public uint PackedBlendFactor
        {
            get => _state.blendFactor;
            set => _state.blendFactor = value;
        }

        public int MultiSampleMask
        {
            get => _state.multiSampleMask;
            set => _state.multiSampleMask = value;
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
            SourceBlendFactor colorDestBlend, SourceBlendFactor alphaDestBlend) : this()
        {
            Name = name;
            ColorSourceBlend = colorSourceBlend;
            AlphaSourceBlend = alphaSourceBlend;
            ColorDestinationBlend = colorDestBlend;
            AlphaDestinationBlend = alphaDestBlend;
        }
    }
}
