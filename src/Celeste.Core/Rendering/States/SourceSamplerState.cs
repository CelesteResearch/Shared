using Celeste.Core.Rendering.Resources;

namespace Celeste.Core.Rendering.States
{
    public class SourceSamplerState : SourceGraphicsResource
    {
        public static readonly SourceSamplerState AnisotropicClamp = new SourceSamplerState(
            "SamplerState.AnisotropicClamp",
            SourceTextureFilter.Anisotropic, SourceTextureAddressMode.Clamp, SourceTextureAddressMode.Clamp,
            SourceTextureAddressMode.Clamp);

        public static readonly SourceSamplerState AnisotropicWrap = new SourceSamplerState(
            "SamplerState.AnisotropicWrap",
            SourceTextureFilter.Anisotropic, SourceTextureAddressMode.Wrap, SourceTextureAddressMode.Wrap,
            SourceTextureAddressMode.Wrap);

        public static readonly SourceSamplerState LinearClamp = new SourceSamplerState("SamplerState.LinearClamp",
            SourceTextureFilter.Linear, SourceTextureAddressMode.Clamp, SourceTextureAddressMode.Clamp,
            SourceTextureAddressMode.Clamp);

        public static readonly SourceSamplerState LinearWrap = new SourceSamplerState("SamplerState.LinearWrap",
            SourceTextureFilter.Linear, SourceTextureAddressMode.Wrap, SourceTextureAddressMode.Wrap,
            SourceTextureAddressMode.Wrap);

        public static readonly SourceSamplerState PointClamp = new SourceSamplerState("SamplerState.PointClamp",
            SourceTextureFilter.Point, SourceTextureAddressMode.Clamp, SourceTextureAddressMode.Clamp,
            SourceTextureAddressMode.Clamp);

        public static readonly SourceSamplerState PointWrap = new SourceSamplerState("SamplerState.PointWrap",
            SourceTextureFilter.Point, SourceTextureAddressMode.Wrap, SourceTextureAddressMode.Wrap,
            SourceTextureAddressMode.Wrap);

        private SourceNativeSamplerState state;

        public ref SourceNativeSamplerState NativeState => ref state;

        public SourceTextureAddressMode AddressU
        {
            get { return state.addressU; }
            set { state.addressU = value; }
        }

        public SourceTextureAddressMode AddressV
        {
            get { return state.addressV; }
            set { state.addressV = value; }
        }

        public SourceTextureAddressMode AddressW
        {
            get { return state.addressW; }
            set { state.addressW = value; }
        }

        public SourceTextureFilter Filter
        {
            get { return state.filter; }
            set { state.filter = value; }
        }

        public int MaxAnisotropy
        {
            get { return state.maxAnisotropy; }
            set { state.maxAnisotropy = value; }
        }

        public int MaxMipLevel
        {
            get { return state.maxMipLevel; }
            set { state.maxMipLevel = value; }
        }

        public float MipMapLevelOfDetailBias
        {
            get { return state.mipMapLevelOfDetailBias; }
            set { state.mipMapLevelOfDetailBias = value; }
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
            SourceTextureAddressMode addressV, SourceTextureAddressMode addressW)
            : this()
        {
            Name = name;
            Filter = filter;
            AddressU = addressU;
            AddressV = addressV;
            AddressW = addressW;
        }
    }
}
