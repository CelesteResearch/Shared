#include "SourcePipelineState.h"
#include <cmath>
#include <limits>
#include <stdexcept>

namespace Celeste::Graphics::Direct3D12
{
    namespace
    {
        template <typename T, size_t N> T Lookup(const T (&values)[N], int32_t index, const char* what)
        {
            if (index < 0 || static_cast<size_t>(index) >= N)
                throw std::invalid_argument(what);
            return values[index];
        }
        D3D12_BLEND Blend(SourceBlendFactor value, bool alpha)
        {
            static constexpr D3D12_BLEND rgb[] = {D3D12_BLEND_ONE,          D3D12_BLEND_ZERO,
                                                  D3D12_BLEND_SRC_COLOR,    D3D12_BLEND_INV_SRC_COLOR,
                                                  D3D12_BLEND_SRC_ALPHA,    D3D12_BLEND_INV_SRC_ALPHA,
                                                  D3D12_BLEND_DEST_COLOR,   D3D12_BLEND_INV_DEST_COLOR,
                                                  D3D12_BLEND_DEST_ALPHA,   D3D12_BLEND_INV_DEST_ALPHA,
                                                  D3D12_BLEND_BLEND_FACTOR, D3D12_BLEND_INV_BLEND_FACTOR,
                                                  D3D12_BLEND_SRC_ALPHA_SAT};
            static constexpr D3D12_BLEND a[] = {D3D12_BLEND_ONE,          D3D12_BLEND_ZERO,
                                                D3D12_BLEND_SRC_ALPHA,    D3D12_BLEND_INV_SRC_ALPHA,
                                                D3D12_BLEND_SRC_ALPHA,    D3D12_BLEND_INV_SRC_ALPHA,
                                                D3D12_BLEND_DEST_ALPHA,   D3D12_BLEND_INV_DEST_ALPHA,
                                                D3D12_BLEND_DEST_ALPHA,   D3D12_BLEND_INV_DEST_ALPHA,
                                                D3D12_BLEND_BLEND_FACTOR, D3D12_BLEND_INV_BLEND_FACTOR,
                                                D3D12_BLEND_SRC_ALPHA_SAT};
            return alpha ? Lookup(a, value, "Invalid alpha blend factor")
                         : Lookup(rgb, value, "Invalid color blend factor");
        }
        D3D12_BLEND_OP BlendOp(SourceBlendFunction value)
        {
            static constexpr D3D12_BLEND_OP values[] = {D3D12_BLEND_OP_ADD, D3D12_BLEND_OP_SUBTRACT,
                                                        D3D12_BLEND_OP_REV_SUBTRACT, D3D12_BLEND_OP_MIN,
                                                        D3D12_BLEND_OP_MAX};
            return Lookup(values, value, "Invalid blend operation");
        }
        D3D12_COMPARISON_FUNC Compare(SourceCompareFunction value)
        {
            static constexpr D3D12_COMPARISON_FUNC values[] = {
                D3D12_COMPARISON_FUNC_ALWAYS,     D3D12_COMPARISON_FUNC_NEVER,    D3D12_COMPARISON_FUNC_LESS,
                D3D12_COMPARISON_FUNC_LESS_EQUAL, D3D12_COMPARISON_FUNC_EQUAL,    D3D12_COMPARISON_FUNC_GREATER_EQUAL,
                D3D12_COMPARISON_FUNC_GREATER,    D3D12_COMPARISON_FUNC_NOT_EQUAL};
            return Lookup(values, value, "Invalid comparison function");
        }
        D3D12_STENCIL_OP Stencil(SourceStencilOperation value)
        {
            static constexpr D3D12_STENCIL_OP values[] = {
                D3D12_STENCIL_OP_KEEP, D3D12_STENCIL_OP_ZERO,     D3D12_STENCIL_OP_REPLACE,  D3D12_STENCIL_OP_INCR,
                D3D12_STENCIL_OP_DECR, D3D12_STENCIL_OP_INCR_SAT, D3D12_STENCIL_OP_DECR_SAT, D3D12_STENCIL_OP_INVERT};
            return Lookup(values, value, "Invalid stencil operation");
        }
        D3D12_DEPTH_STENCILOP_DESC Face(SourceStencilOperation fail, SourceStencilOperation depthFail,
                                        SourceStencilOperation pass, SourceCompareFunction compare)
        {
            return {Stencil(fail), Stencil(depthFail), Stencil(pass), Compare(compare)};
        }
    } // namespace
    PipelineState ConvertPipelineState(const SourceNativeBlendState& blend, const SourceNativeDepthStencilState& depth,
                                       const SourceNativeRasterizerState& raster, SourceDepthFormat actualDepthFormat)
    {
        PipelineState result{};
        result.blend.IndependentBlendEnable = TRUE;
        D3D12_RENDER_TARGET_BLEND_DESC target{};
        target.BlendEnable = !(
            blend.colorSourceBlend == SourceBlendFactor_One && blend.colorDestinationBlend == SourceBlendFactor_Zero &&
            blend.alphaSourceBlend == SourceBlendFactor_One && blend.alphaDestinationBlend == SourceBlendFactor_Zero);
        target.SrcBlend = Blend(blend.colorSourceBlend, false);
        target.DestBlend = Blend(blend.colorDestinationBlend, false);
        target.BlendOp = BlendOp(blend.colorBlendFunction);
        target.SrcBlendAlpha = Blend(blend.alphaSourceBlend, true);
        target.DestBlendAlpha = Blend(blend.alphaDestinationBlend, true);
        target.BlendOpAlpha = BlendOp(blend.alphaBlendFunction);
        target.LogicOp = D3D12_LOGIC_OP_NOOP;
        const int masks[] = {blend.colorWriteEnable, blend.colorWriteEnable1, blend.colorWriteEnable2,
                             blend.colorWriteEnable3};
        for (size_t i = 0; i < 8; ++i)
        {
            result.blend.RenderTarget[i] = target;
            result.blend.RenderTarget[i].RenderTargetWriteMask = static_cast<UINT8>(i < 4 ? masks[i] : 0);
        }
        result.sampleMask = static_cast<uint32_t>(blend.multiSampleMask);
        result.depth.DepthEnable = depth.depthBufferEnable != 0;
        result.depth.DepthWriteMask = depth.depthBufferEnable && depth.depthBufferWriteEnable
                                          ? D3D12_DEPTH_WRITE_MASK_ALL
                                          : D3D12_DEPTH_WRITE_MASK_ZERO;
        result.depth.DepthFunc = Compare(depth.depthBufferFunction);
        result.depth.StencilEnable = depth.stencilEnable != 0;
        result.depth.StencilReadMask = static_cast<UINT8>(depth.stencilMask);
        result.depth.StencilWriteMask = static_cast<UINT8>(depth.stencilWriteMask);
        result.depth.FrontFace =
            Face(depth.stencilFail, depth.stencilDepthBufferFail, depth.stencilPass, depth.stencilFunction);
        result.depth.BackFace = depth.twoSidedStencilMode ? Face(depth.ccwStencilFail, depth.ccwStencilDepthBufferFail,
                                                                 depth.ccwStencilPass, depth.ccwStencilFunction)
                                                          : result.depth.FrontFace;
        static constexpr D3D12_FILL_MODE fill[] = {D3D12_FILL_MODE_SOLID, D3D12_FILL_MODE_WIREFRAME};
        static constexpr D3D12_CULL_MODE cull[] = {D3D12_CULL_MODE_NONE, D3D12_CULL_MODE_BACK, D3D12_CULL_MODE_FRONT};
        static constexpr float depthScale[] = {0.0f, 65535.0f, 16777215.0f, 16777215.0f};
        result.rasterizer.FillMode = Lookup(fill, raster.fillMode, "Invalid fill mode");
        result.rasterizer.CullMode = Lookup(cull, raster.cullMode, "Invalid cull mode");
        result.rasterizer.FrontCounterClockwise = TRUE;
        const float bias = raster.depthBias * Lookup(depthScale, actualDepthFormat, "Invalid depth format");
        // CLR unchecked float-to-int and x86 cvttss2si return INT_MIN outside the signed range.
        result.rasterizer.DepthBias = (!std::isfinite(bias) || bias >= 2147483648.0f || bias < -2147483648.0f)
                                          ? std::numeric_limits<int32_t>::min()
                                          : static_cast<int32_t>(bias);
        result.rasterizer.DepthBiasClamp = std::numeric_limits<float>::max();
        result.rasterizer.SlopeScaledDepthBias = raster.slopeScaleDepthBias;
        result.rasterizer.DepthClipEnable = TRUE;
        result.rasterizer.MultisampleEnable = raster.multiSampleAntiAlias != 0;
        result.rasterizer.ConservativeRaster = D3D12_CONSERVATIVE_RASTERIZATION_MODE_OFF;
        return result;
    }
    DynamicState ConvertDynamicState(const SourceNativeBlendState& blend, const SourceNativeDepthStencilState& depth,
                                     const SourceNativeRasterizerState& raster)
    {
        DynamicState state{};
        for (uint32_t i = 0; i < 4; ++i)
            state.blendFactor[i] = static_cast<float>((blend.blendFactor >> (8 * i)) & 255u) / 255.0f;
        state.stencilReference = static_cast<uint32_t>(depth.referenceStencil);
        state.scissorEnabled = raster.scissorTestEnable != 0;
        return state;
    }
    D3D12_PRIMITIVE_TOPOLOGY ConvertTopology(SourcePrimitiveType type)
    {
        static constexpr D3D12_PRIMITIVE_TOPOLOGY values[] = {
            D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST, D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP, D3D_PRIMITIVE_TOPOLOGY_LINELIST,
            D3D_PRIMITIVE_TOPOLOGY_LINESTRIP, D3D_PRIMITIVE_TOPOLOGY_POINTLIST};
        return Lookup(values, type, "Invalid primitive topology");
    }
    D3D12_PRIMITIVE_TOPOLOGY_TYPE ConvertTopologyType(SourcePrimitiveType type)
    {
        static constexpr D3D12_PRIMITIVE_TOPOLOGY_TYPE values[] = {
            D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE, D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE,
            D3D12_PRIMITIVE_TOPOLOGY_TYPE_LINE, D3D12_PRIMITIVE_TOPOLOGY_TYPE_LINE,
            D3D12_PRIMITIVE_TOPOLOGY_TYPE_POINT};
        return Lookup(values, type, "Invalid primitive topology type");
    }
    D3D12_RECT ResolveScissor(const DynamicState& state, D3D12_RECT requested, int32_t width, int32_t height)
    {
        return state.scissorEnabled ? requested : D3D12_RECT{0, 0, width, height};
    }
} // namespace Celeste::Graphics::Direct3D12
