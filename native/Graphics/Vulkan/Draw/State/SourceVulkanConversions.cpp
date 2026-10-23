#include "SourceVulkanConversions.h"
#include <stdexcept>
#include <limits>
namespace Celeste::Graphics::Vulkan
{
    static VkBlendFactor BlendFactor(SourceBlendFactor value, bool alpha)
    {
        switch (value)
        {
        case SourceBlendFactor_One:
            return VK_BLEND_FACTOR_ONE;
        case SourceBlendFactor_Zero:
            return VK_BLEND_FACTOR_ZERO;
        case SourceBlendFactor_SourceColor:
            return alpha ? VK_BLEND_FACTOR_SRC_ALPHA : VK_BLEND_FACTOR_SRC_COLOR;
        case SourceBlendFactor_InverseSourceColor:
            return alpha ? VK_BLEND_FACTOR_ONE_MINUS_SRC_ALPHA : VK_BLEND_FACTOR_ONE_MINUS_SRC_COLOR;
        case SourceBlendFactor_SourceAlpha:
            return VK_BLEND_FACTOR_SRC_ALPHA;
        case SourceBlendFactor_InverseSourceAlpha:
            return VK_BLEND_FACTOR_ONE_MINUS_SRC_ALPHA;
        case SourceBlendFactor_DestinationColor:
            return alpha ? VK_BLEND_FACTOR_DST_ALPHA : VK_BLEND_FACTOR_DST_COLOR;
        case SourceBlendFactor_InverseDestinationColor:
            return alpha ? VK_BLEND_FACTOR_ONE_MINUS_DST_ALPHA : VK_BLEND_FACTOR_ONE_MINUS_DST_COLOR;
        case SourceBlendFactor_DestinationAlpha:
            return VK_BLEND_FACTOR_DST_ALPHA;
        case SourceBlendFactor_InverseDestinationAlpha:
            return VK_BLEND_FACTOR_ONE_MINUS_DST_ALPHA;
        case SourceBlendFactor_BlendFactor:
            return alpha ? VK_BLEND_FACTOR_CONSTANT_ALPHA : VK_BLEND_FACTOR_CONSTANT_COLOR;
        case SourceBlendFactor_InverseBlendFactor:
            return alpha ? VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_ALPHA : VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_COLOR;
        case SourceBlendFactor_SourceAlphaSaturation:
            return VK_BLEND_FACTOR_SRC_ALPHA_SATURATE;
        default:
            throw std::invalid_argument("Unknown source blend factor");
        }
    }
    static VkBlendOp BlendOperation(SourceBlendFunction value)
    {
        switch (value)
        {
        case SourceBlendFunction_Add:
            return VK_BLEND_OP_ADD;
        case SourceBlendFunction_Subtract:
            return VK_BLEND_OP_SUBTRACT;
        case SourceBlendFunction_ReverseSubtract:
            return VK_BLEND_OP_REVERSE_SUBTRACT;
        case SourceBlendFunction_Min:
            return VK_BLEND_OP_MIN;
        case SourceBlendFunction_Max:
            return VK_BLEND_OP_MAX;
        default:
            throw std::invalid_argument("Unknown source blend operation");
        }
    }
    VkPipelineColorBlendAttachmentState ConvertBlend(const SourceNativeBlendState& value)
    {
        VkPipelineColorBlendAttachmentState result{};
        result.blendEnable = !(
            value.colorSourceBlend == SourceBlendFactor_One && value.colorDestinationBlend == SourceBlendFactor_Zero &&
            value.alphaSourceBlend == SourceBlendFactor_One && value.alphaDestinationBlend == SourceBlendFactor_Zero &&
            value.colorBlendFunction == SourceBlendFunction_Add && value.alphaBlendFunction == SourceBlendFunction_Add);
        result.srcColorBlendFactor = BlendFactor(value.colorSourceBlend, false);
        result.dstColorBlendFactor = BlendFactor(value.colorDestinationBlend, false);
        result.colorBlendOp = BlendOperation(value.colorBlendFunction);
        result.srcAlphaBlendFactor = BlendFactor(value.alphaSourceBlend, true);
        result.dstAlphaBlendFactor = BlendFactor(value.alphaDestinationBlend, true);
        result.alphaBlendOp = BlendOperation(value.alphaBlendFunction);
        result.colorWriteMask = value.colorWriteEnable;
        return result;
    }
    static VkSamplerAddressMode Address(SourceTextureAddressMode value)
    {
        switch (value)
        {
        case SourceTextureAddressMode_Wrap:
            return VK_SAMPLER_ADDRESS_MODE_REPEAT;
        case SourceTextureAddressMode_Clamp:
            return VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_EDGE;
        case SourceTextureAddressMode_Mirror:
            return VK_SAMPLER_ADDRESS_MODE_MIRRORED_REPEAT;
        default:
            throw std::invalid_argument("Unknown source sampler address mode");
        }
    }
    VkSamplerCreateInfo ConvertSampler(const SourceNativeSamplerState& value)
    {
        VkSamplerCreateInfo result{VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO};
        switch (value.filter)
        {
        case SourceTextureFilter_Anisotropic:
            result.minFilter = result.magFilter = VK_FILTER_LINEAR;
            result.mipmapMode = VK_SAMPLER_MIPMAP_MODE_LINEAR;
            result.anisotropyEnable = VK_TRUE;
            result.maxAnisotropy = static_cast<float>(value.maxAnisotropy);
            break;
        case SourceTextureFilter_Linear:
            result.minFilter = result.magFilter = VK_FILTER_LINEAR;
            result.mipmapMode = VK_SAMPLER_MIPMAP_MODE_LINEAR;
            break;
        case SourceTextureFilter_Point:
            result.minFilter = result.magFilter = VK_FILTER_NEAREST;
            result.mipmapMode = VK_SAMPLER_MIPMAP_MODE_NEAREST;
            break;
        case SourceTextureFilter_LinearMipPoint:
            result.minFilter = result.magFilter = VK_FILTER_LINEAR;
            result.mipmapMode = VK_SAMPLER_MIPMAP_MODE_NEAREST;
            break;
        case SourceTextureFilter_PointMipLinear:
            result.minFilter = result.magFilter = VK_FILTER_NEAREST;
            result.mipmapMode = VK_SAMPLER_MIPMAP_MODE_LINEAR;
            break;
        case SourceTextureFilter_MinLinearMagPointMipLinear:
        case SourceTextureFilter_MinLinearMagPointMipPoint:
            result.minFilter = VK_FILTER_LINEAR;
            result.magFilter = VK_FILTER_NEAREST;
            result.mipmapMode = value.filter == SourceTextureFilter_MinLinearMagPointMipLinear
                                    ? VK_SAMPLER_MIPMAP_MODE_LINEAR
                                    : VK_SAMPLER_MIPMAP_MODE_NEAREST;
            break;
        case SourceTextureFilter_MinPointMagLinearMipLinear:
        case SourceTextureFilter_MinPointMagLinearMipPoint:
            result.minFilter = VK_FILTER_NEAREST;
            result.magFilter = VK_FILTER_LINEAR;
            result.mipmapMode = value.filter == SourceTextureFilter_MinPointMagLinearMipLinear
                                    ? VK_SAMPLER_MIPMAP_MODE_LINEAR
                                    : VK_SAMPLER_MIPMAP_MODE_NEAREST;
            break;
        default:
            throw std::invalid_argument("Unknown source sampler filter");
        }
        result.addressModeU = Address(value.addressU);
        result.addressModeV = Address(value.addressV);
        result.addressModeW = Address(value.addressW);
        result.mipLodBias = value.mipMapLevelOfDetailBias;
        result.minLod = static_cast<float>(value.maxMipLevel);
        result.maxLod = VK_LOD_CLAMP_NONE;
        return result;
    }
    VkFormat ConvertVertexFormat(SourceVertexElementFormat value)
    {
        switch (value)
        {
        case SourceVertexElementFormat_Single:
            return VK_FORMAT_R32_SFLOAT;
        case SourceVertexElementFormat_Vector2:
            return VK_FORMAT_R32G32_SFLOAT;
        case SourceVertexElementFormat_Vector3:
            return VK_FORMAT_R32G32B32_SFLOAT;
        case SourceVertexElementFormat_Vector4:
            return VK_FORMAT_R32G32B32A32_SFLOAT;
        case SourceVertexElementFormat_Color:
            return VK_FORMAT_R8G8B8A8_UNORM;
        case SourceVertexElementFormat_Byte4:
            return VK_FORMAT_R8G8B8A8_UINT;
        case SourceVertexElementFormat_Short2:
            return VK_FORMAT_R16G16_SINT;
        case SourceVertexElementFormat_Short4:
            return VK_FORMAT_R16G16B16A16_SINT;
        case SourceVertexElementFormat_NormalizedShort2:
            return VK_FORMAT_R16G16_SNORM;
        case SourceVertexElementFormat_NormalizedShort4:
            return VK_FORMAT_R16G16B16A16_SNORM;
        case SourceVertexElementFormat_HalfVector2:
            return VK_FORMAT_R16G16_SFLOAT;
        case SourceVertexElementFormat_HalfVector4:
            return VK_FORMAT_R16G16B16A16_SFLOAT;
        default:
            throw std::invalid_argument("Unknown source vertex format");
        }
    }
    VkPrimitiveTopology ConvertTopology(SourcePrimitiveType value)
    {
        switch (value)
        {
        case SourcePrimitiveType_TriangleList:
            return VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST;
        case SourcePrimitiveType_TriangleStrip:
            return VK_PRIMITIVE_TOPOLOGY_TRIANGLE_STRIP;
        case SourcePrimitiveType_LineList:
            return VK_PRIMITIVE_TOPOLOGY_LINE_LIST;
        case SourcePrimitiveType_LineStrip:
            return VK_PRIMITIVE_TOPOLOGY_LINE_STRIP;
        case SourcePrimitiveType_PointListEXT:
            return VK_PRIMITIVE_TOPOLOGY_POINT_LIST;
        default:
            throw std::invalid_argument("Unknown source primitive type");
        }
    }
    uint32_t PrimitiveVertices(SourcePrimitiveType type, int32_t count)
    {
        if (count < 0)
            throw std::invalid_argument("Negative primitive count");
        uint64_t value = count;
        switch (type)
        {
        case SourcePrimitiveType_TriangleList:
            value *= 3;
            break;
        case SourcePrimitiveType_TriangleStrip:
            if (count)
                value += 2;
            break;
        case SourcePrimitiveType_LineList:
            value *= 2;
            break;
        case SourcePrimitiveType_LineStrip:
            if (count)
                value += 1;
            break;
        case SourcePrimitiveType_PointListEXT:
            break;
        default:
            throw std::invalid_argument("Unknown primitive type");
        }
        if (value > std::numeric_limits<uint32_t>::max())
            throw std::overflow_error("Primitive count exceeds native range");
        return static_cast<uint32_t>(value);
    }
}
