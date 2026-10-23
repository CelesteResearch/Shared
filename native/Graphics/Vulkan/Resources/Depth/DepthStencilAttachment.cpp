#include "DepthStencilAttachment.h"
#include <stdexcept>
#include <string>
namespace Celeste::Graphics::Vulkan
{
    static void Check(VkResult result, const char* operation)
    {
        if (result != VK_SUCCESS)
            throw std::runtime_error(std::string(operation) + ": " + std::to_string(result));
    }
    DepthStencilAttachment::DepthStencilAttachment(std::shared_ptr<ResourceContext> resourceContext, uint32_t width,
                                                   uint32_t height, SourceDepthFormat depth, int32_t sampleCount)
        : owner(std::move(resourceContext)),
          context(owner ? *owner : throw std::invalid_argument("Missing resource context")), extent{width, height}
    {
        if (!width || !height)
            throw std::invalid_argument("Empty depth extent");
        switch (depth)
        {
        case SourceDepthFormat_Depth16:
            format = VK_FORMAT_D16_UNORM;
            break;
        case SourceDepthFormat_Depth24:
            format = VK_FORMAT_X8_D24_UNORM_PACK32;
            break;
        case SourceDepthFormat_Depth24Stencil8:
            format = VK_FORMAT_D24_UNORM_S8_UINT;
            break;
        default:
            throw std::invalid_argument("Depth attachment requires a depth format");
        }
        aspect = VK_IMAGE_ASPECT_DEPTH_BIT;
        if (depth == SourceDepthFormat_Depth24Stencil8)
            aspect |= VK_IMAGE_ASPECT_STENCIL_BIT;
        const uint32_t count = sampleCount == 0 ? 1 : static_cast<uint32_t>(sampleCount);
        if (count > 64 || !count || (count & (count - 1)))
            throw std::invalid_argument("Invalid depth sample count");
        samples = static_cast<VkSampleCountFlagBits>(count);
        auto query = reinterpret_cast<PFN_vkGetPhysicalDeviceImageFormatProperties>(
            context.native.getInstanceProcAddr(context.native.instance, "vkGetPhysicalDeviceImageFormatProperties"));
        clearDepthStencil = reinterpret_cast<PFN_vkCmdClearDepthStencilImage>(
            context.native.getDeviceProcAddr(context.native.device, "vkCmdClearDepthStencilImage"));
        if (!query || !clearDepthStencil)
            throw std::runtime_error("Missing depth Vulkan entry point");
        const VkImageUsageFlags usage = VK_IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT | VK_IMAGE_USAGE_TRANSFER_DST_BIT;
        VkImageFormatProperties properties{};
        VkResult result = query(context.native.physicalDevice, format, VK_IMAGE_TYPE_2D, VK_IMAGE_TILING_OPTIMAL, usage,
                                0, &properties);
        if (result == VK_ERROR_FORMAT_NOT_SUPPORTED)
        {
            // FNA's Vulkan backend uses floating-point depth when the requested UNorm format is unavailable.
            format = depth == SourceDepthFormat_Depth24Stencil8 ? VK_FORMAT_D32_SFLOAT_S8_UINT : VK_FORMAT_D32_SFLOAT;
            result = query(context.native.physicalDevice, format, VK_IMAGE_TYPE_2D, VK_IMAGE_TILING_OPTIMAL, usage, 0,
                           &properties);
        }
        Check(result, "Query depth format");
        depthBiasScale = format == VK_FORMAT_D16_UNORM                                              ? 65535.0f
                         : format == VK_FORMAT_D32_SFLOAT || format == VK_FORMAT_D32_SFLOAT_S8_UINT ? 8388607.0f
                                                                                                    : 16777215.0f;
        if (width > properties.maxExtent.width || height > properties.maxExtent.height ||
            !(properties.sampleCounts & samples))
            throw std::invalid_argument("Unsupported depth extent or sample count");
        VkImageCreateInfo info{VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO};
        info.imageType = VK_IMAGE_TYPE_2D;
        info.format = format;
        info.extent = {width, height, 1};
        info.mipLevels = 1;
        info.arrayLayers = 1;
        info.samples = samples;
        info.tiling = VK_IMAGE_TILING_OPTIMAL;
        info.usage = usage;
        info.sharingMode = VK_SHARING_MODE_EXCLUSIVE;
        Check(context.CreateImage(context.native.device, &info, nullptr, &image), "Create depth image");
        try
        {
            VkMemoryRequirements requirements{};
            context.GetImageMemoryRequirements(context.native.device, image, &requirements);
            VkMemoryAllocateInfo allocation{VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO};
            allocation.allocationSize = requirements.size;
            allocation.memoryTypeIndex =
                context.MemoryType(requirements.memoryTypeBits, VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT);
            Check(context.AllocateMemory(context.native.device, &allocation, nullptr, &memory),
                  "Allocate depth memory");
            Check(context.BindImageMemory(context.native.device, image, memory, 0), "Bind depth memory");
            VkImageViewCreateInfo viewInfo{VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO};
            viewInfo.image = image;
            viewInfo.viewType = VK_IMAGE_VIEW_TYPE_2D;
            viewInfo.format = format;
            viewInfo.subresourceRange = {aspect, 0, 1, 0, 1};
            Check(context.CreateImageView(context.native.device, &viewInfo, nullptr, &view), "Create depth view");
        }
        catch (...)
        {
            context.DestroyImage(context.native.device, image, nullptr);
            if (memory)
                context.FreeMemory(context.native.device, memory, nullptr);
            throw;
        }
    }
    DepthStencilAttachment::~DepthStencilAttachment()
    {
        context.DestroyImageView(context.native.device, view, nullptr);
        context.DestroyImage(context.native.device, image, nullptr);
        context.FreeMemory(context.native.device, memory, nullptr);
    }
}
