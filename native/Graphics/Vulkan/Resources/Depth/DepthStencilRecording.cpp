#include "DepthStencilRecording.h"
#include <exception>
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    DepthStencilRecording::DepthStencilRecording(VkCommandBuffer commandBuffer, DepthStencilAttachment* const* images,
                                                 size_t count)
        : commands(commandBuffer)
    {
        states.reserve(count);
        for (size_t i = 0; i < count; ++i)
        {
            if (!images[i])
                throw std::invalid_argument("Null depth recording attachment");
            bool found = false;
            for (const auto& state : states)
                if (state.image == images[i])
                {
                    found = true;
                    break;
                }
            if (!found)
                states.push_back({images[i], images[i]->layout, images[i]->stage, images[i]->access});
        }
    }
    void DepthStencilRecording::Validate(const DepthStencilAttachment& image) const
    {
        for (const auto& state : states)
            if (state.image == &image)
                return;
        throw std::invalid_argument("Depth attachment not registered before recording");
    }
    DepthStencilRecording::State& DepthStencilRecording::Find(DepthStencilAttachment& image) noexcept
    {
        for (auto& state : states)
            if (state.image == &image)
                return state;
        std::terminate(); // Internal preparation invariant, never a recoverable record failure.
    }
    void DepthStencilRecording::Transition(DepthStencilAttachment& image, VkImageLayout layout,
                                           VkPipelineStageFlags stage, VkAccessFlags access) noexcept
    {
        auto& state = Find(image);
        VkImageMemoryBarrier barrier{VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER};
        barrier.srcAccessMask = state.access;
        barrier.dstAccessMask = access;
        barrier.oldLayout = state.layout;
        barrier.newLayout = layout;
        barrier.srcQueueFamilyIndex = barrier.dstQueueFamilyIndex = VK_QUEUE_FAMILY_IGNORED;
        barrier.image = image.image;
        barrier.subresourceRange = {image.aspect, 0, 1, 0, 1};
        image.context.CmdPipelineBarrier(commands, state.stage, stage, 0, 0, nullptr, 0, nullptr, 1, &barrier);
        state.layout = layout;
        state.stage = stage;
        state.access = access;
    }
    void DepthStencilRecording::Clear(DepthStencilAttachment& image, float depth, uint32_t stencil,
                                      VkImageAspectFlags aspects) noexcept
    {
        Transition(image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, VK_PIPELINE_STAGE_TRANSFER_BIT,
                   VK_ACCESS_TRANSFER_WRITE_BIT);
        VkClearDepthStencilValue value{depth, stencil};
        VkImageSubresourceRange range{aspects, 0, 1, 0, 1};
        image.clearDepthStencil(commands, image.image, VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL, &value, 1, &range);
    }
    void DepthStencilRecording::Commit() noexcept
    {
        for (const auto& state : states)
        {
            state.image->layout = state.layout;
            state.image->stage = state.stage;
            state.image->access = state.access;
        }
    }
}
