#pragma once
#include "CelesteGraphicsVulkan.h"
#include <cstddef>
namespace Celeste::Graphics::Vulkan
{
    struct ResourceContext final
    {
        CelesteVulkanNativeDevice native;
        VkPhysicalDeviceMemoryProperties memory{};
#define RESOURCE_PROC(name) PFN_vk##name name = nullptr;
        RESOURCE_PROC(CreateImage)
        RESOURCE_PROC(DestroyImage)
        RESOURCE_PROC(GetImageMemoryRequirements)
        RESOURCE_PROC(AllocateMemory)
        RESOURCE_PROC(FreeMemory)
        RESOURCE_PROC(BindImageMemory)
        RESOURCE_PROC(CreateImageView)
        RESOURCE_PROC(DestroyImageView)
        RESOURCE_PROC(CreateBuffer)
        RESOURCE_PROC(DestroyBuffer)
        RESOURCE_PROC(GetBufferMemoryRequirements)
        RESOURCE_PROC(BindBufferMemory)
        RESOURCE_PROC(MapMemory)
        RESOURCE_PROC(UnmapMemory)
        RESOURCE_PROC(FlushMappedMemoryRanges)
        RESOURCE_PROC(InvalidateMappedMemoryRanges)
        RESOURCE_PROC(CmdPipelineBarrier)
        RESOURCE_PROC(CmdCopyBufferToImage)
        RESOURCE_PROC(CmdResolveImage)
        RESOURCE_PROC(CmdBlitImage)
        RESOURCE_PROC(CmdCopyImage)
        RESOURCE_PROC(CmdCopyBuffer)
        RESOURCE_PROC(CmdCopyImageToBuffer)
        RESOURCE_PROC(CmdClearColorImage)
#undef RESOURCE_PROC
        explicit ResourceContext(const CelesteVulkanNativeDevice& device);
        uint32_t MemoryType(uint32_t bits, VkMemoryPropertyFlags required) const;
    };

}
