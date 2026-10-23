#pragma once
#include "ResourceContext.h"
#include "DepthStencilRecording.h"
namespace Celeste::Graphics::Vulkan
{
    struct SpriteDrawArguments
    {
        VkBuffer vertices = VK_NULL_HANDLE;
        VkDeviceSize vertexOffset = 0;
        const VkBuffer* vertexBuffers = nullptr;
        const VkDeviceSize* vertexOffsets = nullptr;
        uint32_t vertexBindingCount = 0;
        VkBuffer indices = VK_NULL_HANDLE;
        VkIndexType indexType = VK_INDEX_TYPE_UINT16;
        uint32_t count = 0, first = 0, instances = 1;
        int32_t baseVertex = 0;
        VkViewport viewport{};
        VkRect2D scissor{};
        float blendConstants[4]{};
        const uint32_t* dynamicOffsets = nullptr;
        uint32_t dynamicOffsetCount = 0;
        DepthStencilRecording* depthRecording = nullptr;
        uint32_t stencilReference = 0;
        float depthBiasConstant = 0, depthBiasSlope = 0;
    };
}
