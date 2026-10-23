#pragma once
#include "CelesteGraphicsSourceTypes.h"
#include "ResourceContext.h"
namespace Celeste::Graphics::Vulkan
{
    VkPipelineColorBlendAttachmentState ConvertBlend(const SourceNativeBlendState& value);
    VkSamplerCreateInfo ConvertSampler(const SourceNativeSamplerState& value);
    VkFormat ConvertVertexFormat(SourceVertexElementFormat value);
    VkPrimitiveTopology ConvertTopology(SourcePrimitiveType value);
    uint32_t PrimitiveVertices(SourcePrimitiveType type, int32_t primitiveCount);
}
