#include "TextureImage.h"
#include <algorithm>
#include <stdexcept>
#include <string>
namespace Celeste::Graphics::Vulkan
{
    static void Check(VkResult result, const char* operation)
    {
        if (result != VK_SUCCESS)
            throw std::runtime_error(std::string(operation) + ": " + std::to_string(result));
    }
    TextureImage::TextureImage(std::shared_ptr<ResourceContext> resourceContext,
                               const CelesteGraphicsTextureInfo& descriptor, VkSampleCountFlagBits sampleCount)
        : owner(std::move(resourceContext)),
          context(owner ? *owner : throw std::invalid_argument("Missing resource context")), info(descriptor),
          format(TextureFormat::FromSource(info.sourceFormat)), extent{info.width, info.height},
          layers(info.dimension == CelesteGraphicsTextureCube ? 6 : 1), samples(sampleCount)
    {
        if (info.dimension > CelesteGraphicsTextureCube || !info.width || !info.height || !info.depth || !info.levels ||
            info.renderTarget > 1)
            throw std::invalid_argument("Invalid texture dimensions");
        if (info.dimension != CelesteGraphicsTexture3D && info.depth != 1)
            throw std::invalid_argument("2D/cube depth must equal one");
        if (info.dimension == CelesteGraphicsTextureCube && info.width != info.height)
            throw std::invalid_argument("Cube faces must be square");
        if (info.dimension == CelesteGraphicsTexture3D && info.renderTarget)
            throw std::invalid_argument("Source 3D render targets are not part of the source IO contract");
        const uint32_t portability = context.native.portabilityFeatures;
        if (info.sourceFormat == SourceSurfaceFormat_Alpha8 && (portability & CelesteVulkanPortabilitySubset) &&
            !(portability & CelesteVulkanPortabilityImageViewSwizzle))
            throw std::runtime_error(
                "Alpha8 textures require enabled Vulkan image-view swizzles; enable MoltenVK full image-view swizzles");
        if (format.Compressed() && !context.native.enabledFeatures.textureCompressionBC)
            throw std::runtime_error("BC texture compression was not enabled on this Vulkan device");
        if (!samples || uint32_t(samples) > 64 || (uint32_t(samples) & (uint32_t(samples) - 1)))
            throw std::invalid_argument("Invalid Vulkan sample count");
        if (samples != VK_SAMPLE_COUNT_1_BIT &&
            (info.dimension != CelesteGraphicsTexture2D || info.levels != 1 || !info.renderTarget))
            throw std::invalid_argument("Multisample attachments require 2D, one mip and render-target usage");
        uint32_t maxLevels = 1;
        for (uint32_t size = std::max({info.width, info.height, info.depth}); size > 1; size >>= 1)
            ++maxLevels;
        if (info.levels > maxLevels)
            throw std::invalid_argument("Texture mip count exceeds its extent");
        const VkImageType type = info.dimension == CelesteGraphicsTexture3D ? VK_IMAGE_TYPE_3D : VK_IMAGE_TYPE_2D;
        const VkImageCreateFlags flags =
            info.dimension == CelesteGraphicsTextureCube ? VK_IMAGE_CREATE_CUBE_COMPATIBLE_BIT : 0;
        const VkImageUsageFlags usage = (samples == VK_SAMPLE_COUNT_1_BIT ? VK_IMAGE_USAGE_SAMPLED_BIT : 0) |
                                        VK_IMAGE_USAGE_TRANSFER_SRC_BIT | VK_IMAGE_USAGE_TRANSFER_DST_BIT |
                                        (info.renderTarget ? VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT : 0);
        auto query = reinterpret_cast<PFN_vkGetPhysicalDeviceImageFormatProperties>(
            context.native.getInstanceProcAddr(context.native.instance, "vkGetPhysicalDeviceImageFormatProperties"));
        if (!query)
            throw std::runtime_error("Missing vkGetPhysicalDeviceImageFormatProperties");
        auto queryFeatures = reinterpret_cast<PFN_vkGetPhysicalDeviceFormatProperties>(
            context.native.getInstanceProcAddr(context.native.instance, "vkGetPhysicalDeviceFormatProperties"));
        if (!queryFeatures)
            throw std::runtime_error("Missing vkGetPhysicalDeviceFormatProperties");
        VkFormatProperties features{};
        queryFeatures(context.native.physicalDevice, format.native, &features);
        formatFeatures = features.optimalTilingFeatures;
        VkImageFormatProperties supported{};
        Check(query(context.native.physicalDevice, format.native, type, VK_IMAGE_TILING_OPTIMAL, usage, flags,
                    &supported),
              "Image format/dimension/usage not supported");
        if (info.width > supported.maxExtent.width || info.height > supported.maxExtent.height ||
            info.depth > supported.maxExtent.depth || info.levels > supported.maxMipLevels ||
            layers > supported.maxArrayLayers || !(supported.sampleCounts & samples))
            throw std::invalid_argument("Texture exceeds physical device image limits");
        states.resize(size_t(layers) * info.levels);
        if (info.renderTarget)
            attachments.resize(states.size());
        VkImageCreateInfo create{VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO};
        create.flags = flags;
        create.imageType = type;
        create.format = format.native;
        create.extent = {info.width, info.height, info.depth};
        create.mipLevels = info.levels;
        create.arrayLayers = layers;
        create.samples = samples;
        create.tiling = VK_IMAGE_TILING_OPTIMAL;
        create.usage = usage;
        create.sharingMode = VK_SHARING_MODE_EXCLUSIVE;
        Check(context.CreateImage(context.native.device, &create, nullptr, &image), "CreateImage");
        try
        {
            VkMemoryRequirements requirements{};
            context.GetImageMemoryRequirements(context.native.device, image, &requirements);
            VkMemoryAllocateInfo allocation{VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO};
            allocation.allocationSize = requirements.size;
            allocation.memoryTypeIndex =
                context.MemoryType(requirements.memoryTypeBits, VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT);
            Check(context.AllocateMemory(context.native.device, &allocation, nullptr, &memory), "AllocateMemory");
            Check(context.BindImageMemory(context.native.device, image, memory, 0), "BindImageMemory");
            VkImageViewCreateInfo viewInfo{VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO};
            viewInfo.image = image;
            viewInfo.format = format.native;
            viewInfo.components = format.swizzle;
            viewInfo.viewType = info.dimension == CelesteGraphicsTexture3D     ? VK_IMAGE_VIEW_TYPE_3D
                                : info.dimension == CelesteGraphicsTextureCube ? VK_IMAGE_VIEW_TYPE_CUBE
                                                                               : VK_IMAGE_VIEW_TYPE_2D;
            viewInfo.subresourceRange = {VK_IMAGE_ASPECT_COLOR_BIT, 0, info.levels, 0, layers};
            Check(context.CreateImageView(context.native.device, &viewInfo, nullptr, &view),
                  "Create sampled image view");
            viewInfo.viewType = VK_IMAGE_VIEW_TYPE_2D;
            viewInfo.components = {};
            viewInfo.subresourceRange.levelCount = 1;
            viewInfo.subresourceRange.layerCount = 1;
            for (uint32_t layer = 0; layer < layers && info.renderTarget; ++layer)
                for (uint32_t level = 0; level < info.levels; ++level)
                {
                    viewInfo.subresourceRange.baseMipLevel = level;
                    viewInfo.subresourceRange.baseArrayLayer = layer;
                    Check(context.CreateImageView(context.native.device, &viewInfo, nullptr,
                                                  &attachments[StateIndex(level, layer)]),
                          "Create attachment image view");
                }
        }
        catch (...)
        {
            for (auto attachment : attachments)
                if (attachment)
                    context.DestroyImageView(context.native.device, attachment, nullptr);
            if (view)
                context.DestroyImageView(context.native.device, view, nullptr);
            context.DestroyImage(context.native.device, image, nullptr);
            if (memory)
                context.FreeMemory(context.native.device, memory, nullptr);
            throw;
        }
    }
    TextureImage::~TextureImage()
    {
        for (auto attachment : attachments)
            context.DestroyImageView(context.native.device, attachment, nullptr);
        context.DestroyImageView(context.native.device, view, nullptr);
        context.DestroyImage(context.native.device, image, nullptr);
        context.FreeMemory(context.native.device, memory, nullptr);
    }
    VkExtent3D TextureImage::MipExtent(uint32_t level) const
    {
        if (level >= info.levels)
            throw std::out_of_range("Texture mip level");
        return {std::max(1u, info.width >> level), std::max(1u, info.height >> level),
                std::max(1u, info.depth >> level)};
    }
    uint32_t TextureImage::StateIndex(uint32_t level, uint32_t layer) const
    {
        if (level >= info.levels || layer >= layers)
            throw std::out_of_range("Texture subresource");
        return layer * info.levels + level;
    }
    VkBufferImageCopy TextureImage::Region(const CelesteGraphicsTextureRegion& region) const
    {
        StateIndex(region.level, region.layer);
        const auto mip = MipExtent(region.level);
        if (!region.width || !region.height || !region.depth || uint64_t(region.x) + region.width > mip.width ||
            uint64_t(region.y) + region.height > mip.height || uint64_t(region.z) + region.depth > mip.depth)
            throw std::out_of_range("Texture region");
        if (region.x % format.blockWidth || region.y % format.blockHeight ||
            (region.width % format.blockWidth && region.x + region.width != mip.width) ||
            (region.height % format.blockHeight && region.y + region.height != mip.height))
            throw std::invalid_argument("Compressed texture region must align to blocks or the mip edge");
        VkBufferImageCopy result{};
        result.imageSubresource = {VK_IMAGE_ASPECT_COLOR_BIT, region.level, region.layer, 1};
        result.imageOffset = {int32_t(region.x), int32_t(region.y), int32_t(region.z)};
        result.imageExtent = {region.width, region.height, region.depth};
        return result;
    }
    uint64_t TextureImage::ByteSize(const VkBufferImageCopy& region) const
    {
        return format.StorageByteSize(region.imageExtent.width, region.imageExtent.height, region.imageExtent.depth);
    }
    uint64_t TextureImage::SourceByteSize(const VkBufferImageCopy& region) const
    {
        return format.ByteSize(region.imageExtent.width, region.imageExtent.height, region.imageExtent.depth);
    }
}
