#pragma once
#include "ResourceContext.h"
#include "TextureFormat.h"
#include "TextureSubresourceState.h"
#include "CelesteGraphicsBackend.h"
#include <memory>
#include <vector>
namespace Celeste::Graphics::Vulkan
{
    class TextureImage final
    {
        std::shared_ptr<ResourceContext> owner;

      public:
        ResourceContext& context;
        CelesteGraphicsTextureInfo info;
        TextureFormat format;
        VkFormatFeatureFlags formatFeatures = 0;
        VkImage image = VK_NULL_HANDLE;
        VkImageView view = VK_NULL_HANDLE;
        VkDeviceMemory memory = VK_NULL_HANDLE;
        VkExtent2D extent;
        uint32_t layers;
        VkSampleCountFlagBits samples;
        std::vector<TextureSubresourceState> states;
        std::vector<VkImageView> attachments;
        TextureImage(std::shared_ptr<ResourceContext> context, const CelesteGraphicsTextureInfo& info,
                     VkSampleCountFlagBits samples = VK_SAMPLE_COUNT_1_BIT);
        ~TextureImage();
        TextureImage(const TextureImage&) = delete;
        TextureImage& operator=(const TextureImage&) = delete;
        VkExtent3D MipExtent(uint32_t level) const;
        uint32_t StateIndex(uint32_t level, uint32_t layer) const;
        VkBufferImageCopy Region(const CelesteGraphicsTextureRegion& region) const;
        uint64_t SourceByteSize(const VkBufferImageCopy& region) const;
        uint64_t ByteSize(const VkBufferImageCopy& region) const;
    };
}
