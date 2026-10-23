#pragma once
#include "ResourceContext.h"
#include <memory>
namespace Celeste::Graphics::Vulkan
{
    class DepthStencilAttachment final
    {
        std::shared_ptr<ResourceContext> owner;

      public:
        ResourceContext& context;
        VkImage image = VK_NULL_HANDLE;
        VkImageView view = VK_NULL_HANDLE;
        VkDeviceMemory memory = VK_NULL_HANDLE;
        VkFormat format;
        float depthBiasScale;
        VkExtent2D extent;
        VkSampleCountFlagBits samples;
        VkImageAspectFlags aspect;
        VkImageLayout layout = VK_IMAGE_LAYOUT_UNDEFINED;
        VkPipelineStageFlags stage = VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
        VkAccessFlags access = 0;
        PFN_vkCmdClearDepthStencilImage clearDepthStencil;
        DepthStencilAttachment(std::shared_ptr<ResourceContext>, uint32_t width, uint32_t height, SourceDepthFormat,
                               int32_t sampleCount);
        ~DepthStencilAttachment();
        DepthStencilAttachment(const DepthStencilAttachment&) = delete;
        DepthStencilAttachment& operator=(const DepthStencilAttachment&) = delete;
    };
}
