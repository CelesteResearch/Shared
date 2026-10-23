#pragma once
#include "ResourceContext.h"
#include <array>
#include <memory>

namespace Celeste::Graphics::Vulkan
{
    // Device-local immutable PSO. Does not retain textures, framebuffers or upload pages.
    struct SpritePipelineObjects final
    {
        std::shared_ptr<ResourceContext> context;
        std::array<VkShaderModule, 2> shaders{};
        std::array<VkDescriptorSetLayout, 4> setLayouts{};
        VkPipelineLayout layout = VK_NULL_HANDLE;
        VkRenderPass renderPass = VK_NULL_HANDLE;
        VkPipeline pipeline = VK_NULL_HANDLE;
        explicit SpritePipelineObjects(std::shared_ptr<ResourceContext> owner) : context(std::move(owner))
        {
        }
        ~SpritePipelineObjects();
        SpritePipelineObjects(const SpritePipelineObjects&) = delete;
        SpritePipelineObjects& operator=(const SpritePipelineObjects&) = delete;
    };
}
