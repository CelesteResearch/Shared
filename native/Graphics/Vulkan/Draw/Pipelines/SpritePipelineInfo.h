#pragma once
#include "ShaderBinary.h"
#include "SampledImageBinding.h"
#include "DepthStencilAttachment.h"
#include "ColorTargetBinding.h"
#include <array>
#include <vector>
namespace Celeste::Graphics::Vulkan
{
    struct SpritePipelineInfo
    {
        ShaderBinary vertex, pixel;
        uint32_t vertexStride;
        std::vector<VkVertexInputBindingDescription> vertexBindings;
        std::vector<VkVertexInputAttributeDescription> attributes;
        std::array<std::vector<SampledImageBinding>, 2> sampledImages;
        std::array<VkDescriptorBufferInfo, 2> constants;
        VkPipelineColorBlendAttachmentState blend;
        uint32_t colorTargetCount = 1;
        std::array<ColorTargetBinding, 3> additionalTargets{};
        std::array<VkPipelineColorBlendAttachmentState, 3> additionalBlends{};
        bool dynamicConstants = false;
        VkPrimitiveTopology topology = VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST;
        VkPolygonMode polygonMode = VK_POLYGON_MODE_FILL;
        uint32_t sampleMask = UINT32_MAX;
        VkCullModeFlags cullMode = VK_CULL_MODE_NONE;
        uint32_t targetLevel = 0, targetLayer = 0;
        std::shared_ptr<DepthStencilAttachment> depthAttachment;
        VkPipelineDepthStencilStateCreateInfo depthState{VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO};
    };
}
