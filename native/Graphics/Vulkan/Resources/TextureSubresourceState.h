#pragma once
#include <vulkan/vulkan_core.h>
namespace Celeste::Graphics::Vulkan
{
    struct TextureSubresourceState final
    {
        VkImageLayout layout = VK_IMAGE_LAYOUT_UNDEFINED;
        VkPipelineStageFlags stage = VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
        VkAccessFlags access = 0;
    };
}
