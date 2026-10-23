#include "ImageRecording.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    ImageRecording::ImageRecording(VkCommandBuffer commands, std::initializer_list<TextureImage*> images)
        : ImageRecording(commands, images.begin(), images.size())
    {
    }
    ImageRecording::ImageRecording(VkCommandBuffer buffer, TextureImage* const* images, size_t count) : commands(buffer)
    {
        if (!buffer || (count && !images))
            throw std::invalid_argument("Invalid image recording");
        size_t size = 0;
        for (size_t index = 0; index < count; ++index)
        {
            if (!images[index])
                throw std::invalid_argument("Missing recording image");
            size += images[index]->states.size();
        }
        states.reserve(size);
        for (size_t index = 0; index < count; ++index)
        {
            auto& image = *images[index];
            bool duplicate = false;
            for (const auto& state : states)
                if (state.image == &image)
                {
                    duplicate = true;
                    break;
                }
            if (duplicate)
                continue;
            for (uint32_t layer = 0; layer < image.layers; ++layer)
                for (uint32_t level = 0; level < image.info.levels; ++level)
                    states.push_back({&image, level, layer, image.states[image.StateIndex(level, layer)]});
        }
    }
    ImageRecording::State& ImageRecording::Find(TextureImage& image, uint32_t level, uint32_t layer)
    {
        for (auto& state : states)
            if (state.image == &image && state.level == level && state.layer == layer)
                return state;
        throw std::invalid_argument("Texture subresource not registered for recording");
    }
    void ImageRecording::Validate(TextureImage& image) const
    {
        for (const auto& state : states)
            if (state.image == &image)
                return;
        throw std::invalid_argument("Texture not registered for recording");
    }
    void ImageRecording::Commit() noexcept
    {
        for (const auto& state : states)
            state.image->states[state.layer * state.image->info.levels + state.level] = state.value;
        states.clear();
    }
    void ImageRecording::Transition(TextureImage& image, VkImageLayout layout, VkPipelineStageFlags stage,
                                    VkAccessFlags access)
    {
        for (uint32_t layer = 0; layer < image.layers; ++layer)
            for (uint32_t level = 0; level < image.info.levels; ++level)
                Transition(image, level, layer, layout, stage, access);
    }
    void ImageRecording::Transition(TextureImage& image, uint32_t level, uint32_t layer, VkImageLayout layout,
                                    VkPipelineStageFlags stage, VkAccessFlags access)
    {
        auto& state = Find(image, level, layer).value;
        constexpr VkAccessFlags writes = VK_ACCESS_SHADER_WRITE_BIT | VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT |
                                         VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT | VK_ACCESS_TRANSFER_WRITE_BIT |
                                         VK_ACCESS_HOST_WRITE_BIT | VK_ACCESS_MEMORY_WRITE_BIT;
        if (state.layout == layout && !(state.access & writes) && !(access & writes))
        {
            state.stage |= stage;
            state.access |= access;
            return;
        }
        VkImageMemoryBarrier barrier{VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER};
        barrier.srcAccessMask = state.access;
        barrier.dstAccessMask = access;
        barrier.oldLayout = state.layout;
        barrier.newLayout = layout;
        barrier.srcQueueFamilyIndex = VK_QUEUE_FAMILY_IGNORED;
        barrier.dstQueueFamilyIndex = VK_QUEUE_FAMILY_IGNORED;
        barrier.image = image.image;
        barrier.subresourceRange = {VK_IMAGE_ASPECT_COLOR_BIT, level, 1, layer, 1};
        image.context.CmdPipelineBarrier(commands, state.stage, stage, 0, 0, nullptr, 0, nullptr, 1, &barrier);
        state = {layout, stage, access};
    }
    void ImageRecording::Restore(TextureImage& image, uint32_t level, uint32_t layer, TextureSubresourceState state)
    {
        if (state.layout == VK_IMAGE_LAYOUT_UNDEFINED)
            state = {VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                     VK_PIPELINE_STAGE_VERTEX_SHADER_BIT | VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT,
                     VK_ACCESS_SHADER_READ_BIT};
        Transition(image, level, layer, state.layout, state.stage, state.access);
    }
    static void ValidateRegion(TextureImage& image, const TransferBuffer& buffer, const VkBufferImageCopy& region)
    {
        if (image.samples != VK_SAMPLE_COUNT_1_BIT || &image.context != &buffer.context || region.bufferOffset ||
            region.bufferRowLength || region.bufferImageHeight ||
            region.imageSubresource.aspectMask != VK_IMAGE_ASPECT_COLOR_BIT ||
            region.imageSubresource.layerCount != 1 || region.imageOffset.x < 0 || region.imageOffset.y < 0 ||
            region.imageOffset.z < 0 || image.ByteSize(region) > buffer.size)
            throw std::invalid_argument("Invalid texture transfer region/buffer");
        const CelesteGraphicsTextureRegion source{
            region.imageSubresource.mipLevel, region.imageSubresource.baseArrayLayer,
            uint32_t(region.imageOffset.x),   uint32_t(region.imageOffset.y),
            uint32_t(region.imageOffset.z),   region.imageExtent.width,
            region.imageExtent.height,        region.imageExtent.depth};
        image.Region(source);
    }
    void ImageRecording::Upload(TextureImage& image, const TransferBuffer& source, const VkBufferImageCopy& region)
    {
        ValidateRegion(image, source, region);
        const uint32_t level = region.imageSubresource.mipLevel, layer = region.imageSubresource.baseArrayLayer;
        Transition(image, level, layer, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                   VK_ACCESS_TRANSFER_WRITE_BIT);
        image.context.CmdCopyBufferToImage(commands, source.buffer, image.image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL,
                                           1, &region);
        Transition(image, level, layer, VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                   VK_PIPELINE_STAGE_VERTEX_SHADER_BIT | VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT,
                   VK_ACCESS_SHADER_READ_BIT);
    }
    void ImageRecording::Readback(TextureImage& image, const TransferBuffer& destination,
                                  const VkBufferImageCopy& region)
    {
        ValidateRegion(image, destination, region);
        const uint32_t level = region.imageSubresource.mipLevel, layer = region.imageSubresource.baseArrayLayer;
        const auto previous = Find(image, level, layer).value;
        Transition(image, level, layer, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                   VK_ACCESS_TRANSFER_READ_BIT);
        image.context.CmdCopyImageToBuffer(commands, image.image, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL,
                                           destination.buffer, 1, &region);
        VkBufferMemoryBarrier barrier{VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER};
        barrier.srcAccessMask = VK_ACCESS_TRANSFER_WRITE_BIT;
        barrier.dstAccessMask = VK_ACCESS_HOST_READ_BIT;
        barrier.srcQueueFamilyIndex = VK_QUEUE_FAMILY_IGNORED;
        barrier.dstQueueFamilyIndex = VK_QUEUE_FAMILY_IGNORED;
        barrier.buffer = destination.buffer;
        barrier.size = VK_WHOLE_SIZE;
        image.context.CmdPipelineBarrier(commands, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_PIPELINE_STAGE_HOST_BIT, 0, 0,
                                         nullptr, 1, &barrier, 0, nullptr);
        Restore(image, level, layer, previous);
    }
    void ImageRecording::Copy(TextureImage& source, TextureImage& destination)
    {
        Validate(source);
        Validate(destination);
        if (&source == &destination || &source.context != &destination.context ||
            source.info.dimension != destination.info.dimension || source.samples != destination.samples ||
            source.info.sourceFormat != destination.info.sourceFormat || source.info.width != destination.info.width ||
            source.info.height != destination.info.height || source.info.depth != destination.info.depth ||
            source.info.levels != destination.info.levels)
            throw std::invalid_argument("Texture copy requires matching distinct resources");
        for (uint32_t layer = 0; layer < source.layers; ++layer)
            for (uint32_t level = 0; level < source.info.levels; ++level)
            {
                const auto previous = Find(source, level, layer).value;
                Transition(source, level, layer, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                           VK_ACCESS_TRANSFER_READ_BIT);
                Transition(destination, level, layer, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL,
                           VK_PIPELINE_STAGE_TRANSFER_BIT, VK_ACCESS_TRANSFER_WRITE_BIT);
                VkImageCopy region{};
                region.srcSubresource = {VK_IMAGE_ASPECT_COLOR_BIT, level, layer, 1};
                region.dstSubresource = region.srcSubresource;
                region.extent = source.MipExtent(level);
                source.context.CmdCopyImage(commands, source.image, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL,
                                            destination.image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &region);
                Restore(source, level, layer, previous);
                Transition(destination, level, layer, VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                           VK_PIPELINE_STAGE_VERTEX_SHADER_BIT | VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT,
                           VK_ACCESS_SHADER_READ_BIT);
            }
    }
    void ImageRecording::Resolve(TextureImage& source, TextureImage& destination, uint32_t level, uint32_t layer)
    {
        Validate(source);
        Validate(destination);
        const auto extent = destination.MipExtent(level);
        destination.StateIndex(level, layer);
        if (destination.samples != VK_SAMPLE_COUNT_1_BIT || &source.context != &destination.context ||
            source.format.native != destination.format.native || source.extent.width != extent.width ||
            source.extent.height != extent.height || extent.depth != 1)
            throw std::invalid_argument("Invalid multisample resolve source/destination");
        const auto previous = Find(source, 0, 0).value;
        Transition(source, 0, 0, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                   VK_ACCESS_TRANSFER_READ_BIT);
        Transition(destination, level, layer, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                   VK_ACCESS_TRANSFER_WRITE_BIT);
        VkImageResolve region{};
        region.srcSubresource = {VK_IMAGE_ASPECT_COLOR_BIT, 0, 0, 1};
        region.dstSubresource = {VK_IMAGE_ASPECT_COLOR_BIT, level, layer, 1};
        region.extent = extent;
        if (source.samples == VK_SAMPLE_COUNT_1_BIT)
        {
            VkImageCopy copy{};
            copy.srcSubresource = region.srcSubresource;
            copy.dstSubresource = region.dstSubresource;
            copy.extent = region.extent;
            source.context.CmdCopyImage(commands, source.image, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, destination.image,
                                        VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &copy);
        }
        else
            source.context.CmdResolveImage(commands, source.image, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL,
                                           destination.image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &region);
        if (previous.layout == VK_IMAGE_LAYOUT_UNDEFINED)
            Transition(source, 0, 0, VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                       VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT,
                       VK_ACCESS_COLOR_ATTACHMENT_READ_BIT | VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT);
        else
            Restore(source, 0, 0, previous);
        Transition(destination, level, layer, VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                   VK_PIPELINE_STAGE_VERTEX_SHADER_BIT | VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT,
                   VK_ACCESS_SHADER_READ_BIT);
    }
    void ImageRecording::GenerateMipmaps(TextureImage& image)
    {
        Validate(image);
        const VkFormatFeatureFlags required = VK_FORMAT_FEATURE_BLIT_SRC_BIT | VK_FORMAT_FEATURE_BLIT_DST_BIT |
                                              VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_LINEAR_BIT;
        if (image.samples != VK_SAMPLE_COUNT_1_BIT || (image.formatFeatures & required) != required)
            throw std::invalid_argument("Texture format does not support linear mipmap generation");
        for (uint32_t layer = 0; layer < image.layers; ++layer)
            for (uint32_t level = 1; level < image.info.levels; ++level)
            {
                Transition(image, level - 1, layer, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL,
                           VK_PIPELINE_STAGE_TRANSFER_BIT, VK_ACCESS_TRANSFER_READ_BIT);
                Transition(image, level, layer, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                           VK_ACCESS_TRANSFER_WRITE_BIT);
                const auto from = image.MipExtent(level - 1), to = image.MipExtent(level);
                VkImageBlit region{};
                region.srcSubresource = {VK_IMAGE_ASPECT_COLOR_BIT, level - 1, layer, 1};
                region.dstSubresource = {VK_IMAGE_ASPECT_COLOR_BIT, level, layer, 1};
                region.srcOffsets[1] = {int32_t(from.width), int32_t(from.height), int32_t(from.depth)};
                region.dstOffsets[1] = {int32_t(to.width), int32_t(to.height), int32_t(to.depth)};
                image.context.CmdBlitImage(commands, image.image, VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL, image.image,
                                           VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, 1, &region, VK_FILTER_LINEAR);
                Transition(image, level - 1, layer, VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                           VK_PIPELINE_STAGE_VERTEX_SHADER_BIT | VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT,
                           VK_ACCESS_SHADER_READ_BIT);
                Transition(image, level, layer, VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                           VK_PIPELINE_STAGE_VERTEX_SHADER_BIT | VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT,
                           VK_ACCESS_SHADER_READ_BIT);
            }
    }
    void ImageRecording::Clear(TextureImage& image, const VkClearColorValue& color, uint32_t level, uint32_t layer)
    {
        if (image.format.Compressed())
            throw std::invalid_argument("Compressed images do not support color clear");
        Transition(image, level, layer, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                   VK_ACCESS_TRANSFER_WRITE_BIT);
        VkImageSubresourceRange range{VK_IMAGE_ASPECT_COLOR_BIT, level, 1, layer, 1};
        image.context.CmdClearColorImage(commands, image.image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, &color, 1,
                                         &range);
        if (image.samples == VK_SAMPLE_COUNT_1_BIT)
            Transition(image, level, layer, VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL,
                       VK_PIPELINE_STAGE_VERTEX_SHADER_BIT | VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT,
                       VK_ACCESS_SHADER_READ_BIT);
        else
            Transition(image, level, layer, VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL,
                       VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT,
                       VK_ACCESS_COLOR_ATTACHMENT_READ_BIT | VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT);
    }
}
