#include "SourceVulkanDepthStencil.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    static VkCompareOp Compare(SourceCompareFunction value)
    {
        switch (value)
        {
        case SourceCompareFunction_Always:
            return VK_COMPARE_OP_ALWAYS;
        case SourceCompareFunction_Never:
            return VK_COMPARE_OP_NEVER;
        case SourceCompareFunction_Less:
            return VK_COMPARE_OP_LESS;
        case SourceCompareFunction_LessEqual:
            return VK_COMPARE_OP_LESS_OR_EQUAL;
        case SourceCompareFunction_Equal:
            return VK_COMPARE_OP_EQUAL;
        case SourceCompareFunction_GreaterEqual:
            return VK_COMPARE_OP_GREATER_OR_EQUAL;
        case SourceCompareFunction_Greater:
            return VK_COMPARE_OP_GREATER;
        case SourceCompareFunction_NotEqual:
            return VK_COMPARE_OP_NOT_EQUAL;
        default:
            throw std::invalid_argument("Unknown source comparison function");
        }
    }
    static VkStencilOp Operation(SourceStencilOperation value)
    {
        switch (value)
        {
        case SourceStencilOperation_Keep:
            return VK_STENCIL_OP_KEEP;
        case SourceStencilOperation_Zero:
            return VK_STENCIL_OP_ZERO;
        case SourceStencilOperation_Replace:
            return VK_STENCIL_OP_REPLACE;
        case SourceStencilOperation_Increment:
            return VK_STENCIL_OP_INCREMENT_AND_WRAP;
        case SourceStencilOperation_Decrement:
            return VK_STENCIL_OP_DECREMENT_AND_WRAP;
        case SourceStencilOperation_IncrementSaturation:
            return VK_STENCIL_OP_INCREMENT_AND_CLAMP;
        case SourceStencilOperation_DecrementSaturation:
            return VK_STENCIL_OP_DECREMENT_AND_CLAMP;
        case SourceStencilOperation_Invert:
            return VK_STENCIL_OP_INVERT;
        default:
            throw std::invalid_argument("Unknown source stencil operation");
        }
    }
    VkPipelineDepthStencilStateCreateInfo ConvertDepthStencil(const SourceNativeDepthStencilState& value)
    {
        VkPipelineDepthStencilStateCreateInfo result{VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO};
        result.depthTestEnable = value.depthBufferEnable;
        result.depthWriteEnable = value.depthBufferWriteEnable;
        result.depthCompareOp = Compare(value.depthBufferFunction);
        result.stencilTestEnable = value.stencilEnable;
        result.front.failOp = Operation(value.stencilFail);
        result.front.passOp = Operation(value.stencilPass);
        result.front.depthFailOp = Operation(value.stencilDepthBufferFail);
        result.front.compareOp = Compare(value.stencilFunction);
        result.front.compareMask = static_cast<uint32_t>(value.stencilMask);
        result.front.writeMask = static_cast<uint32_t>(value.stencilWriteMask);
        result.front.reference = static_cast<uint32_t>(value.referenceStencil);
        result.back = result.front;
        if (value.twoSidedStencilMode)
        {
            result.back.failOp = Operation(value.ccwStencilFail);
            result.back.passOp = Operation(value.ccwStencilPass);
            result.back.depthFailOp = Operation(value.ccwStencilDepthBufferFail);
            result.back.compareOp = Compare(value.ccwStencilFunction);
        }
        // Match FNA D3D11: front uses primary operations, back uses CCW operations.
        // The negative viewport already preserves the verified Source facing/cull mapping.
        return result;
    }
}
