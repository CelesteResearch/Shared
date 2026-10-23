#pragma once
#include "DepthStencilAttachment.h"
#include <vector>
namespace Celeste::Graphics::Vulkan
{
    class DepthStencilRecording final
    {
        struct State
        {
            DepthStencilAttachment* image;
            VkImageLayout layout;
            VkPipelineStageFlags stage;
            VkAccessFlags access;
        };
        VkCommandBuffer commands;
        std::vector<State> states;
        State& Find(DepthStencilAttachment&) noexcept;

      public:
        DepthStencilRecording(VkCommandBuffer, DepthStencilAttachment* const*, size_t count);
        void Validate(const DepthStencilAttachment&) const;
        void Transition(DepthStencilAttachment&, VkImageLayout, VkPipelineStageFlags, VkAccessFlags) noexcept;
        // Caller validates requested aspects during preparation, before any vkCmd.
        void Clear(DepthStencilAttachment&, float depth, uint32_t stencil, VkImageAspectFlags) noexcept;
        void Commit() noexcept;
    };
}
