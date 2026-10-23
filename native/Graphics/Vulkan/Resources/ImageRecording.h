#pragma once
#include "TextureImage.h"
#include "TransferBuffer.h"
#include <initializer_list>
#include <vector>
namespace Celeste::Graphics::Vulkan
{
    class ImageRecording final
    {
        struct State
        {
            TextureImage* image;
            uint32_t level, layer;
            TextureSubresourceState value;
        };
        VkCommandBuffer commands;
        std::vector<State> states;
        State& Find(TextureImage& image, uint32_t level, uint32_t layer);
        void Restore(TextureImage& image, uint32_t level, uint32_t layer, TextureSubresourceState state);

      public:
        ImageRecording(VkCommandBuffer commands, std::initializer_list<TextureImage*> images);
        ImageRecording(VkCommandBuffer commands, TextureImage* const* images, size_t count);
        ImageRecording(const ImageRecording&) = delete;
        ImageRecording& operator=(const ImageRecording&) = delete;
        VkCommandBuffer Commands() const noexcept
        {
            return commands;
        }
        void Validate(TextureImage& image) const;
        void Commit() noexcept;
        void Transition(TextureImage& image, VkImageLayout layout, VkPipelineStageFlags stage, VkAccessFlags access);
        void Transition(TextureImage& image, uint32_t level, uint32_t layer, VkImageLayout layout,
                        VkPipelineStageFlags stage, VkAccessFlags access);
        void Upload(TextureImage& image, const TransferBuffer& source, const VkBufferImageCopy& region);
        void Readback(TextureImage& image, const TransferBuffer& destination, const VkBufferImageCopy& region);
        void Copy(TextureImage& source, TextureImage& destination);
        void Resolve(TextureImage& source, TextureImage& destination, uint32_t level, uint32_t layer);
        void GenerateMipmaps(TextureImage& image);
        void Clear(TextureImage& image, const VkClearColorValue& color, uint32_t level = 0, uint32_t layer = 0);
    };
}
