using Celeste.Core.Display;
using System.Numerics;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Effects
{
    public class SourcePipelineCache
    {
        private ISourceEffectDevice device;

        public SourceBlendFunction AlphaBlendFunction;

        public SourceBlendFactor AlphaDestinationBlend;

        public SourceBlendFactor AlphaSourceBlend;

        public SourceBlendFunction ColorBlendFunction;

        public SourceBlendFactor ColorDestinationBlend;

        public SourceBlendFactor ColorSourceBlend;

        public SourceColorWriteChannels ColorWriteChannels;

        public SourceColorWriteChannels ColorWriteChannels1;

        public SourceColorWriteChannels ColorWriteChannels2;

        public SourceColorWriteChannels ColorWriteChannels3;

        public PackedColor BlendFactor;

        public int MultiSampleMask;

        public bool SeparateAlphaBlend;

        private Dictionary<SourceStateHash, SourceBlendState> blendCache =
            new Dictionary<SourceStateHash, SourceBlendState>();

        public bool DepthBufferEnable;

        public bool DepthBufferWriteEnable;

        public SourceCompareFunction DepthBufferFunction;

        public bool StencilEnable;

        public SourceCompareFunction StencilFunction;

        public SourceStencilOperation StencilPass;

        public SourceStencilOperation StencilFail;

        public SourceStencilOperation StencilDepthBufferFail;

        public bool TwoSidedStencilMode;

        public SourceCompareFunction CCWStencilFunction;

        public SourceStencilOperation CCWStencilFail;

        public SourceStencilOperation CCWStencilPass;

        public SourceStencilOperation CCWStencilDepthBufferFail;

        public int StencilMask;

        public int StencilWriteMask;

        public int ReferenceStencil;

        private Dictionary<SourceStateHash, SourceDepthStencilState> depthStencilCache =
            new Dictionary<SourceStateHash, SourceDepthStencilState>();

        public SourceCullMode CullMode;

        public SourceFillMode FillMode;

        public float DepthBias;

        public bool MultiSampleAntiAlias;

        public bool ScissorTestEnable;

        public float SlopeScaleDepthBias;

        private Dictionary<SourceStateHash, SourceRasterizerState> rasterizerCache =
            new Dictionary<SourceStateHash, SourceRasterizerState>();

        public SourceTextureAddressMode AddressU;

        public SourceTextureAddressMode AddressV;

        public SourceTextureAddressMode AddressW;

        public int MaxAnisotropy;

        public int MaxMipLevel;

        public float MipMapLODBias;

        public SourceTextureFilter Filter;

        private Dictionary<SourceStateHash, SourceSamplerState> samplerCache =
            new Dictionary<SourceStateHash, SourceSamplerState>();

        private const ulong HASH_FACTOR = 39uL;

        public SourcePipelineCache(ISourceEffectDevice graphicsDevice)
        {
            device = graphicsDevice;
        }

        private static SourceStateHash GetBlendHash(SourceBlendFunction alphaBlendFunc,
            SourceBlendFactor alphaDestBlend,
            SourceBlendFactor alphaSrcBlend, SourceBlendFunction colorBlendFunc, SourceBlendFactor colorDestBlend,
            SourceBlendFactor colorSrcBlend, SourceColorWriteChannels channels, SourceColorWriteChannels channels1,
            SourceColorWriteChannels channels2, SourceColorWriteChannels channels3, PackedColor blendFactor,
            int multisampleMask)
        {
            int num = ((int)alphaBlendFunc << 4) | (int)colorBlendFunc;
            int num2 = ((int)alphaDestBlend << 28) | ((int)alphaSrcBlend << 24) | ((int)colorDestBlend << 20) |
                       ((int)colorSrcBlend << 16) | ((int)channels << 12) | ((int)channels1 << 8) |
                       ((int)channels2 << 4) |
                       (int)channels3;
#pragma warning disable CS0675 // Preserve the source signed bitwise hash expression.
            return new SourceStateHash((ulong)(((long)num << 32) | num2),
                (ulong)(((long)multisampleMask << 32) | blendFactor.PackedValue));
#pragma warning restore CS0675
        }

        public static SourceStateHash GetBlendHash(SourceBlendState state)
        {
            return GetBlendHash(state.AlphaBlendFunction, state.AlphaDestinationBlend, state.AlphaSourceBlend,
                state.ColorBlendFunction, state.ColorDestinationBlend, state.ColorSourceBlend, state.ColorWriteChannels,
                state.ColorWriteChannels1, state.ColorWriteChannels2, state.ColorWriteChannels3,
                new PackedColor { PackedValue = state.PackedBlendFactor }, state.MultiSampleMask);
        }

        public void BeginApplyBlend()
        {
            SourceBlendState blendState = device.BlendState;
            AlphaBlendFunction = blendState.AlphaBlendFunction;
            AlphaDestinationBlend = blendState.AlphaDestinationBlend;
            AlphaSourceBlend = blendState.AlphaSourceBlend;
            ColorBlendFunction = blendState.ColorBlendFunction;
            ColorDestinationBlend = blendState.ColorDestinationBlend;
            ColorSourceBlend = blendState.ColorSourceBlend;
            ColorWriteChannels = blendState.ColorWriteChannels;
            ColorWriteChannels1 = blendState.ColorWriteChannels1;
            ColorWriteChannels2 = blendState.ColorWriteChannels2;
            ColorWriteChannels3 = blendState.ColorWriteChannels3;
            BlendFactor = new PackedColor { PackedValue = blendState.PackedBlendFactor };
            MultiSampleMask = blendState.MultiSampleMask;
            SeparateAlphaBlend = ColorBlendFunction != AlphaBlendFunction ||
                                 ColorDestinationBlend != AlphaDestinationBlend;
        }

        public void EndApplyBlend()
        {
            SourceStateHash blendHash = GetBlendHash(AlphaBlendFunction, AlphaDestinationBlend, AlphaSourceBlend,
                ColorBlendFunction, ColorDestinationBlend, ColorSourceBlend, ColorWriteChannels, ColorWriteChannels1,
                ColorWriteChannels2, ColorWriteChannels3, BlendFactor, MultiSampleMask);
            if (!blendCache.TryGetValue(blendHash, out var value))
            {
                value = new SourceBlendState();
                value.AlphaBlendFunction = AlphaBlendFunction;
                value.AlphaDestinationBlend = AlphaDestinationBlend;
                value.AlphaSourceBlend = AlphaSourceBlend;
                value.ColorBlendFunction = ColorBlendFunction;
                value.ColorDestinationBlend = ColorDestinationBlend;
                value.ColorSourceBlend = ColorSourceBlend;
                value.ColorWriteChannels = ColorWriteChannels;
                value.ColorWriteChannels1 = ColorWriteChannels1;
                value.ColorWriteChannels2 = ColorWriteChannels2;
                value.ColorWriteChannels3 = ColorWriteChannels3;
                value.PackedBlendFactor = BlendFactor.PackedValue;
                value.MultiSampleMask = MultiSampleMask;
                blendCache.Add(blendHash, value);
            }

            device.BlendState = value;
        }

        private static SourceStateHash GetDepthStencilHash(bool depthBufferEnable, bool depthWriteEnable,
            SourceCompareFunction depthFunc, bool stencilEnable, SourceCompareFunction stencilFunc,
            SourceStencilOperation stencilPass, SourceStencilOperation stencilFail,
            SourceStencilOperation stencilDepthFail,
            bool twoSidedStencil, SourceCompareFunction ccwStencilFunc, SourceStencilOperation ccwStencilPass,
            SourceStencilOperation ccwStencilFail, SourceStencilOperation ccwStencilDepthFail, int stencilMask,
            int stencilWriteMask, int referenceStencil)
        {
            bool num = depthBufferEnable;
            int num2 = (depthWriteEnable ? 1 : 0);
            int num3 = (stencilEnable ? 1 : 0);
            int num4 = (twoSidedStencil ? 1 : 0);
            int num5 = (int)(((num ? 1u : 0u) << 30) | (uint)(num2 << 29) | (uint)(num3 << 28) | (uint)(num4 << 27) |
                             (uint)((int)depthFunc << 24) | (uint)((int)stencilFunc << 21) |
                             (uint)((int)ccwStencilFunc << 18) | (uint)((int)stencilPass << 15) |
                             (uint)((int)stencilFail << 12) | (uint)((int)stencilDepthFail << 9) |
                             (uint)((int)ccwStencilFail << 6) | (uint)((int)ccwStencilPass << 3)) |
                       (int)ccwStencilDepthFail;
#pragma warning disable CS0675 // Preserve the source signed bitwise hash expression.
            return new SourceStateHash((ulong)(((long)stencilMask << 32) | num5),
                (ulong)(((long)referenceStencil << 32) | stencilWriteMask));
#pragma warning restore CS0675
        }

        public static SourceStateHash GetDepthStencilHash(SourceDepthStencilState state)
        {
            return GetDepthStencilHash(state.DepthBufferEnable, state.DepthBufferWriteEnable, state.DepthBufferFunction,
                state.StencilEnable, state.StencilFunction, state.StencilPass, state.StencilFail,
                state.StencilDepthBufferFail, state.TwoSidedStencilMode, state.CounterClockwiseStencilFunction,
                state.CounterClockwiseStencilPass, state.CounterClockwiseStencilFail,
                state.CounterClockwiseStencilDepthBufferFail, state.StencilMask, state.StencilWriteMask,
                state.ReferenceStencil);
        }

        public void BeginApplyDepthStencil()
        {
            SourceDepthStencilState depthStencilState = device.DepthStencilState;
            DepthBufferEnable = depthStencilState.DepthBufferEnable;
            DepthBufferWriteEnable = depthStencilState.DepthBufferWriteEnable;
            DepthBufferFunction = depthStencilState.DepthBufferFunction;
            StencilEnable = depthStencilState.StencilEnable;
            StencilFunction = depthStencilState.StencilFunction;
            StencilPass = depthStencilState.StencilPass;
            StencilFail = depthStencilState.StencilFail;
            StencilDepthBufferFail = depthStencilState.StencilDepthBufferFail;
            TwoSidedStencilMode = depthStencilState.TwoSidedStencilMode;
            CCWStencilFunction = depthStencilState.CounterClockwiseStencilFunction;
            CCWStencilFail = depthStencilState.CounterClockwiseStencilFail;
            CCWStencilPass = depthStencilState.CounterClockwiseStencilPass;
            CCWStencilDepthBufferFail = depthStencilState.CounterClockwiseStencilDepthBufferFail;
            StencilMask = depthStencilState.StencilMask;
            StencilWriteMask = depthStencilState.StencilWriteMask;
            ReferenceStencil = depthStencilState.ReferenceStencil;
        }

        public void EndApplyDepthStencil()
        {
            SourceStateHash depthStencilHash = GetDepthStencilHash(DepthBufferEnable, DepthBufferWriteEnable,
                DepthBufferFunction, StencilEnable, StencilFunction, StencilPass, StencilFail, StencilDepthBufferFail,
                TwoSidedStencilMode, CCWStencilFunction, CCWStencilPass, CCWStencilFail, CCWStencilDepthBufferFail,
                StencilMask, StencilWriteMask, ReferenceStencil);
            if (!depthStencilCache.TryGetValue(depthStencilHash, out var value))
            {
                value = new SourceDepthStencilState();
                value.DepthBufferEnable = DepthBufferEnable;
                value.DepthBufferWriteEnable = DepthBufferWriteEnable;
                value.DepthBufferFunction = DepthBufferFunction;
                value.StencilEnable = StencilEnable;
                value.StencilFunction = StencilFunction;
                value.StencilPass = StencilPass;
                value.StencilFail = StencilFail;
                value.StencilDepthBufferFail = StencilDepthBufferFail;
                value.TwoSidedStencilMode = TwoSidedStencilMode;
                value.CounterClockwiseStencilFunction = CCWStencilFunction;
                value.CounterClockwiseStencilFail = CCWStencilFail;
                value.CounterClockwiseStencilPass = CCWStencilPass;
                value.CounterClockwiseStencilDepthBufferFail = CCWStencilDepthBufferFail;
                value.StencilMask = StencilMask;
                value.StencilWriteMask = StencilWriteMask;
                value.ReferenceStencil = ReferenceStencil;
                depthStencilCache.Add(depthStencilHash, value);
            }

            device.DepthStencilState = value;
        }

        private static SourceStateHash GetRasterizerHash(SourceCullMode cullMode, SourceFillMode fillMode,
            float depthBias,
            bool msaa, bool scissor, float slopeScaleDepthBias)
        {
            bool num = msaa;
            int num2 = (scissor ? 1 : 0);
            return new SourceStateHash(
                (ulong)(int)(((num ? 1u : 0u) << 4) | (uint)(num2 << 3) | (uint)((int)cullMode << 1) | (uint)fillMode),
                (FloatToULong(slopeScaleDepthBias) << 32) | FloatToULong(depthBias));
        }

        public static SourceStateHash GetRasterizerHash(SourceRasterizerState state)
        {
            return GetRasterizerHash(state.CullMode, state.FillMode, state.DepthBias, state.MultiSampleAntiAlias,
                state.ScissorTestEnable, state.SlopeScaleDepthBias);
        }

        public void BeginApplyRasterizer()
        {
            SourceRasterizerState rasterizerState = device.RasterizerState;
            CullMode = rasterizerState.CullMode;
            FillMode = rasterizerState.FillMode;
            DepthBias = rasterizerState.DepthBias;
            MultiSampleAntiAlias = rasterizerState.MultiSampleAntiAlias;
            ScissorTestEnable = rasterizerState.ScissorTestEnable;
            SlopeScaleDepthBias = rasterizerState.SlopeScaleDepthBias;
        }

        public void EndApplyRasterizer()
        {
            SourceStateHash rasterizerHash = GetRasterizerHash(CullMode, FillMode, DepthBias, MultiSampleAntiAlias,
                ScissorTestEnable, SlopeScaleDepthBias);
            if (!rasterizerCache.TryGetValue(rasterizerHash, out var value))
            {
                value = new SourceRasterizerState();
                value.CullMode = CullMode;
                value.FillMode = FillMode;
                value.DepthBias = DepthBias;
                value.MultiSampleAntiAlias = MultiSampleAntiAlias;
                value.ScissorTestEnable = ScissorTestEnable;
                value.SlopeScaleDepthBias = SlopeScaleDepthBias;
                rasterizerCache.Add(rasterizerHash, value);
            }

            device.RasterizerState = value;
        }

        private static SourceStateHash GetSamplerHash(SourceTextureAddressMode addressU,
            SourceTextureAddressMode addressV,
            SourceTextureAddressMode addressW, int maxAnisotropy, int maxMipLevel, float mipLODBias,
            SourceTextureFilter filter)
        {
            int num = ((int)filter << 6) | ((int)addressU << 4) | ((int)addressV << 2) | (int)addressW;
#pragma warning disable CS0675 // Preserve the source signed bitwise hash expression.
            return new SourceStateHash((ulong)(((long)maxAnisotropy << 32) | num),
                (FloatToULong(mipLODBias) << 32) | (ulong)maxMipLevel);
#pragma warning restore CS0675
        }

        public static SourceStateHash GetSamplerHash(SourceSamplerState state)
        {
            return GetSamplerHash(state.AddressU, state.AddressV, state.AddressW, state.MaxAnisotropy,
                state.MaxMipLevel,
                state.MipMapLevelOfDetailBias, state.Filter);
        }

        public void BeginApplySampler(SourceSamplerStateCollection samplers, int register)
        {
            SourceSamplerState samplerState = samplers[register];
            AddressU = samplerState.AddressU;
            AddressV = samplerState.AddressV;
            AddressW = samplerState.AddressW;
            MaxAnisotropy = samplerState.MaxAnisotropy;
            MaxMipLevel = samplerState.MaxMipLevel;
            MipMapLODBias = samplerState.MipMapLevelOfDetailBias;
            Filter = samplerState.Filter;
        }

        public void EndApplySampler(SourceSamplerStateCollection samplers, int register)
        {
            SourceStateHash samplerHash = GetSamplerHash(AddressU, AddressV, AddressW, MaxAnisotropy, MaxMipLevel,
                MipMapLODBias, Filter);
            if (!samplerCache.TryGetValue(samplerHash, out var value))
            {
                value = new SourceSamplerState();
                value.Filter = Filter;
                value.AddressU = AddressU;
                value.AddressV = AddressV;
                value.AddressW = AddressW;
                value.MaxAnisotropy = MaxAnisotropy;
                value.MaxMipLevel = MaxMipLevel;
                value.MipMapLevelOfDetailBias = MipMapLODBias;
                samplerCache.Add(samplerHash, value);
            }

            samplers[register] = value;
        }

        public static ulong GetVertexDeclarationHash(SourceVertexDeclaration declaration, ulong vertexShader)
        {
            ulong num = vertexShader;
            for (int i = 0; i < declaration.elements.Length; i++)
            {
                num = num * 39 + (ulong)declaration.elements[i].GetHashCode();
            }

            return num * 39 + (ulong)declaration.VertexStride;
        }

        public static ulong GetVertexBindingHash(SourceVertexBufferBinding[] bindings, int numBindings,
            ulong vertexShader)
        {
            ulong num = vertexShader;
            for (int i = 0; i < numBindings; i++)
            {
                SourceVertexBufferBinding vertexBufferBinding = bindings[i];
                num = num * 39 + (ulong)vertexBufferBinding.InstanceFrequency;
                num = num * 39 +
                      GetVertexDeclarationHash(vertexBufferBinding.VertexBuffer.VertexDeclaration, vertexShader);
            }

            return num;
        }

        private unsafe static ulong FloatToULong(float f)
        {
            return *(uint*)(&f);
        }
    }
}
