#include "ResourceContext.h"
#include <cstring>
#include <stdexcept>
#include <string>
namespace Celeste::Graphics::Vulkan
{
    static void Check(VkResult result, const char* operation)
    {
        if (result != VK_SUCCESS)
            throw std::runtime_error(std::string(operation) + ": " + std::to_string(result));
    }
    ResourceContext::ResourceContext(const CelesteVulkanNativeDevice& device) : native(device)
    {
        if (!native.device || !native.physicalDevice || !native.getDeviceProcAddr || !native.getInstanceProcAddr)
            throw std::invalid_argument("Incomplete Vulkan device");
#define LOAD(name) name = reinterpret_cast<PFN_vk##name>(native.getDeviceProcAddr(native.device, "vk" #name)); if (!name) throw std::runtime_error("Missing vk" #name);
        LOAD(CreateImage)
        LOAD(DestroyImage)
        LOAD(GetImageMemoryRequirements)
        LOAD(AllocateMemory)
        LOAD(FreeMemory)
        LOAD(BindImageMemory)
        LOAD(CreateImageView)
        LOAD(DestroyImageView)
        LOAD(CreateBuffer)
        LOAD(DestroyBuffer)
        LOAD(GetBufferMemoryRequirements)
        LOAD(BindBufferMemory)
        LOAD(MapMemory)
        LOAD(UnmapMemory)
        LOAD(FlushMappedMemoryRanges)
        LOAD(InvalidateMappedMemoryRanges)
        LOAD(CmdPipelineBarrier)
        LOAD(CmdCopyBufferToImage)
        LOAD(CmdResolveImage)
        LOAD(CmdBlitImage)
        LOAD(CmdCopyImage)
        LOAD(CmdCopyBuffer)
        LOAD(CmdCopyImageToBuffer)
        LOAD(CmdClearColorImage)
#undef LOAD
        auto properties = reinterpret_cast<PFN_vkGetPhysicalDeviceMemoryProperties>(
            native.getInstanceProcAddr(native.instance, "vkGetPhysicalDeviceMemoryProperties"));
        if (!properties)
            throw std::runtime_error("Missing vkGetPhysicalDeviceMemoryProperties");
        properties(native.physicalDevice, &memory);
    }
    uint32_t ResourceContext::MemoryType(uint32_t bits, VkMemoryPropertyFlags required) const
    {
        for (uint32_t i = 0; i < memory.memoryTypeCount; ++i)
            if ((bits & (1u << i)) && (memory.memoryTypes[i].propertyFlags & required) == required)
                return i;
        throw std::runtime_error("No compatible Vulkan memory type");
    }
}
