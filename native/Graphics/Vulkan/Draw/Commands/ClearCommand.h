#pragma once
#include "CelesteGraphicsPacket.h"
namespace Celeste::Graphics::Vulkan
{
    struct ClearCommand
    {
        uint32_t image;
        VkClearColorValue value;
        uint32_t level = 0, layer = 0, depth = UINT32_MAX;
        float depthValue = 1;
        uint32_t stencilValue = 0;
        VkImageAspectFlags depthAspects = 0;
        static void Record(CelesteGraphicsPacket&, const void*, VulkanPacketRecordContext&) noexcept;
    };
}
