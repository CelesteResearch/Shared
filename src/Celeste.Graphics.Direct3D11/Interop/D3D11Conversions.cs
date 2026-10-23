using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Interop
{
    internal static class D3D11Conversions
    {
        private static readonly uint[] TextureFormat =
        {
            28, 85, 86, 115, 71, 74, 77, 51, 31, 24, 35, 11, 65, 41, 16, 2, 54, 34, 10, 10, 87, 29, 78, 98, 99, 61, 56
        };

        private static readonly uint[] DepthFormat = { 0, 55, 45, 45 };
        private static readonly uint[] VertexAttribFormat = { 41, 16, 6, 2, 28, 30, 38, 14, 37, 13, 34, 10 };
        private static readonly uint[] IndexType = { 57, 42 };
        private static readonly uint[] BlendMode = { 2, 1, 3, 4, 5, 6, 9, 10, 7, 8, 14, 15, 11 };
        private static readonly uint[] BlendModeAlpha = { 2, 1, 5, 6, 5, 6, 7, 8, 7, 8, 14, 15, 11 };
        private static readonly uint[] BlendOperation = { 1, 2, 3, 4, 5 };
        private static readonly uint[] CompareFunc = { 8, 1, 2, 4, 3, 7, 5, 6 };
        private static readonly uint[] StencilOp = { 1, 2, 3, 7, 8, 4, 5, 6 };
        private static readonly uint[] FillMode = { 3, 2 };
        private static readonly uint[] CullMode = { 1, 3, 2 };
        private static readonly uint[] Wrap = { 1, 3, 2 };
        private static readonly uint[] Filter = { 21, 0, 85, 20, 1, 17, 16, 5, 4 };
        private static readonly uint[] Primitive = { 4, 5, 2, 3, 1 };
        internal static uint SurfaceFormat(SourceSurfaceFormat value) => TextureFormat[(int)value];
        internal static uint DepthSurfaceFormat(SourceDepthFormat value) => DepthFormat[(int)value];
        internal static uint VertexFormat(int value) => VertexAttribFormat[value];
        internal static uint IndexFormat(int value) => IndexType[value];
        internal static uint Topology(int value) => Primitive[value];

        internal static D3D11BlendDesc Blend(ref SourceNativeBlendState state)
        {
            var result = new D3D11BlendDesc();
            result.Target0.BlendEnable = state.colorSourceBlend == SourceBlendFactor.One &&
                                         state.colorDestinationBlend == SourceBlendFactor.Zero &&
                                         state.alphaSourceBlend == SourceBlendFactor.One &&
                                         state.alphaDestinationBlend == SourceBlendFactor.Zero
                ? 0
                : 1;
            if (result.Target0.BlendEnable != 0)
            {
                result.Target0.SourceBlend = BlendMode[(int)state.colorSourceBlend];
                result.Target0.DestinationBlend = BlendMode[(int)state.colorDestinationBlend];
                result.Target0.BlendOperation = BlendOperation[(int)state.colorBlendFunction];
                result.Target0.SourceAlphaBlend = BlendModeAlpha[(int)state.alphaSourceBlend];
                result.Target0.DestinationAlphaBlend = BlendModeAlpha[(int)state.alphaDestinationBlend];
                result.Target0.AlphaBlendOperation = BlendOperation[(int)state.alphaBlendFunction];
            }

            result.Target1 = result.Target2 = result.Target3 = result.Target0;
            result.Target0.WriteMask = (byte)state.colorWriteEnable;
            result.Target1.WriteMask = (byte)state.colorWriteEnable1;
            result.Target2.WriteMask = (byte)state.colorWriteEnable2;
            result.Target3.WriteMask = (byte)state.colorWriteEnable3;
            return result;
        }

        internal static D3D11DepthStencilDesc DepthStencil(ref SourceNativeDepthStencilState state)
        {
            var result = new D3D11DepthStencilDesc();
            result.DepthEnable = state.depthBufferEnable;
            result.DepthWriteMask = state.depthBufferEnable != 0 && state.depthBufferWriteEnable != 0 ? 1u : 0u;
            result.DepthFunction = CompareFunc[(int)state.depthBufferFunction];
            result.StencilEnable = state.stencilEnable;
            result.StencilReadMask = unchecked((byte)state.stencilMask);
            result.StencilWriteMask = unchecked((byte)state.stencilWriteMask);
            result.FrontFace = new D3D11StencilOperationDesc
            {
                StencilFailOperation = StencilOp[(int)state.stencilFail],
                DepthFailOperation = StencilOp[(int)state.stencilDepthBufferFail],
                PassOperation = StencilOp[(int)state.stencilPass], Function = CompareFunc[(int)state.stencilFunction]
            };
            result.BackFace = state.twoSidedStencilMode != 0
                ? new D3D11StencilOperationDesc
                {
                    StencilFailOperation = StencilOp[(int)state.ccwStencilFail],
                    DepthFailOperation = StencilOp[(int)state.ccwStencilDepthBufferFail],
                    PassOperation = StencilOp[(int)state.ccwStencilPass],
                    Function = CompareFunc[(int)state.ccwStencilFunction]
                }
                : result.FrontFace;
            return result;
        }

        // FNA3D_Driver.h Texture_GetFormatSize / Texture_GetBlockSize; physical format metadata only.
        internal static readonly uint[] TextureBytesPerBlock =
            { 4, 2, 2, 2, 8, 16, 16, 2, 4, 4, 4, 8, 1, 4, 8, 16, 2, 4, 8, 8, 4, 4, 16, 16, 16 };

        internal static readonly uint[] TextureBlockExtent =
            { 1, 1, 1, 1, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 4 };

        private static readonly float[] DepthBiasScale = { 0f, 65535f, 16777215f, 16777215f };

        internal static D3D11RasterizerDesc Rasterizer(ref SourceNativeRasterizerState state,
            SourceDepthFormat actualDepthFormat)
        {
            float depthScale = DepthBiasScale[(int)actualDepthFormat];
            return new D3D11RasterizerDesc
            {
                FillMode = FillMode[(int)state.fillMode], CullMode = CullMode[(int)state.cullMode],
                FrontCounterClockwise = 1, DepthBias = unchecked((int)(state.depthBias * depthScale)),
                DepthBiasClamp = float.MaxValue,
                SlopeScaledDepthBias = state.slopeScaleDepthBias, DepthClipEnable = 1,
                ScissorEnable = state.scissorTestEnable,
                MultisampleEnable = state.multiSampleAntiAlias, AntialiasedLineEnable = 0
            };
        }

        internal static D3D11SamplerDesc Sampler(ref SourceNativeSamplerState state)
        {
            return new D3D11SamplerDesc
            {
                Filter = Filter[(int)state.filter], AddressU = Wrap[(int)state.addressU],
                AddressV = Wrap[(int)state.addressV], AddressW = Wrap[(int)state.addressW],
                MipBias = state.mipMapLevelOfDetailBias,
                MaxAnisotropy = unchecked((uint)state.maxAnisotropy), ComparisonFunction = 1,
                Border0 = 1f, Border1 = 1f, Border2 = 1f, Border3 = 1f, MinLOD = state.maxMipLevel,
                MaxLOD = float.MaxValue
            };
        }
    }
}
