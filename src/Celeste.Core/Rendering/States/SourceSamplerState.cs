using Celeste.Core.Rendering.Resources;

namespace Celeste.Core.Rendering.States
{
    public class SourceSamplerState : SourceGraphicsResource
    {
        public static readonly SourceSamplerState AnisotropicClamp = new("SamplerState.AnisotropicClamp",
            SourceTextureFilter.Anisotropic, SourceTextureAddressMode.Clamp, SourceTextureAddressMode.Clamp,
            SourceTextureAddressMode.Clamp);

        public static readonly SourceSamplerState AnisotropicWrap = new("SamplerState.AnisotropicWrap",
            SourceTextureFilter.Anisotropic, SourceTextureAddressMode.Wrap, SourceTextureAddressMode.Wrap,
            SourceTextureAddressMode.Wrap);

        public static readonly SourceSamplerState LinearClamp = new("SamplerState.LinearClamp",
            SourceTextureFilter.Linear, SourceTextureAddressMode.Clamp, SourceTextureAddressMode.Clamp,
            SourceTextureAddressMode.Clamp);

        public static readonly SourceSamplerState LinearWrap = new("SamplerState.LinearWrap",
            SourceTextureFilter.Linear, SourceTextureAddressMode.Wrap, SourceTextureAddressMode.Wrap,
            SourceTextureAddressMode.Wrap);

        public static readonly SourceSamplerState PointClamp = new("SamplerState.PointClamp", SourceTextureFilter.Point,
            SourceTextureAddressMode.Clamp, SourceTextureAddressMode.Clamp, SourceTextureAddressMode.Clamp);

        public static readonly SourceSamplerState PointWrap = new("SamplerState.PointWrap", SourceTextureFilter.Point,
            SourceTextureAddressMode.Wrap, SourceTextureAddressMode.Wrap, SourceTextureAddressMode.Wrap);

        private SourceNativeSamplerState _state;
        public ref SourceNativeSamplerState NativeState => ref _state;

        public SourceTextureAddressMode AddressU
        {
            get => _state.addressU;
            set => _state.addressU = value;
        }

        public SourceTextureAddressMode AddressV
        {
            get => _state.addressV;
            set => _state.addressV = value;
        }

        public SourceTextureAddressMode AddressW
        {
            get => _state.addressW;
            set => _state.addressW = value;
        }

        public SourceTextureFilter Filter
        {
            get => _state.filter;
            set => _state.filter = value;
        }

        public int MaxAnisotropy
        {
            get => _state.maxAnisotropy;
            set => _state.maxAnisotropy = value;
        }

        public int MaxMipLevel
        {
            get => _state.maxMipLevel;
            set => _state.maxMipLevel = value;
        }

        public float MipMapLevelOfDetailBias
        {
            get => _state.mipMapLevelOfDetailBias;
            set => _state.mipMapLevelOfDetailBias = value;
        }

        protected internal override bool IsHarmlessToLeakInstance => true;

        public SourceSamplerState()
        {
            Filter = SourceTextureFilter.Linear;
            AddressU = SourceTextureAddressMode.Wrap;
            AddressV = SourceTextureAddressMode.Wrap;
            AddressW = SourceTextureAddressMode.Wrap;
            MaxAnisotropy = 4;
            MaxMipLevel = 0;
            MipMapLevelOfDetailBias = 0f;
        }

        private SourceSamplerState(string name, SourceTextureFilter filter, SourceTextureAddressMode addressU,
            SourceTextureAddressMode addressV, SourceTextureAddressMode addressW) : this()
        {
            Name = name;
            Filter = filter;
            AddressU = addressU;
            AddressV = addressV;
            AddressW = addressW;
        }
    }
}
