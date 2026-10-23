#include "DrawLogicalState.h"
namespace Celeste::Graphics::Vulkan
{
    DrawLogicalState::DrawLogicalState()
    {
        blend.colorSourceBlend = blend.alphaSourceBlend = SourceBlendFactor_One;
        blend.colorDestinationBlend = blend.alphaDestinationBlend = SourceBlendFactor_Zero;
        blend.colorWriteEnable = blend.colorWriteEnable1 = blend.colorWriteEnable2 = blend.colorWriteEnable3 =
            SourceColorWriteChannels_All;
        blend.blendFactor = UINT32_MAX;
        blend.multiSampleMask = -1;
        depth.depthBufferEnable = depth.depthBufferWriteEnable = 1;
        depth.depthBufferFunction = SourceCompareFunction_LessEqual;
        depth.stencilMask = depth.stencilWriteMask = -1;
        depth.stencilFunction = depth.ccwStencilFunction = SourceCompareFunction_Always;
        raster.fillMode = SourceFillMode_Solid;
        raster.cullMode = SourceCullMode_CullCounterClockwiseFace;
        raster.multiSampleAntiAlias = 1;
        viewport.maxDepth = 1;
        for (auto& stage : samplers)
            for (auto& sampler : stage)
            {
                sampler.state.filter = SourceTextureFilter_Linear;
                sampler.state.addressU = sampler.state.addressV = sampler.state.addressW =
                    SourceTextureAddressMode_Wrap;
                sampler.state.maxAnisotropy = 4;
            }
    }
}
