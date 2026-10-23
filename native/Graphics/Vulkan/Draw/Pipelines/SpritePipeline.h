#pragma once
#include "ImageRecording.h"
#include "SpritePipelineInfo.h"
#include "SpritePipelineObjects.h"
#include "SpriteDrawArguments.h"
#include <array>
#include <vector>

namespace Celeste::Graphics::Vulkan
{
    // Immutable prepared draw state. Resources and this object must survive GPU retirement.
    // Owns descriptors, samplers, shaders, render pass, framebuffer and pipeline.
    // Retains images/context. Constant/vertex/index buffers remain borrowed. Requires Vulkan 1.1.
    class SpritePipeline final
    {
      public:
        SpritePipeline(std::shared_ptr<ResourceContext> context, std::shared_ptr<TextureImage> target,
                       const SpritePipelineInfo& info, std::shared_ptr<SpritePipelineObjects> cachedObjects = {});
        ~SpritePipeline();
        SpritePipeline(const SpritePipeline&) = delete;
        SpritePipeline& operator=(const SpritePipeline&) = delete;
        // Validate every image before any commands are emitted to the host recording.
        void PrepareRecording(const ImageRecording& recording, const DepthStencilRecording* depth = nullptr) const;
        const std::shared_ptr<SpritePipelineObjects>& Objects() const noexcept
        {
            return objects;
        }
        // Requires PrepareRecording on this unchanged transaction, valid buffers/ranges,
        // and an active command buffer outside a render pass. No allocations.
        void Record(ImageRecording& recording, VkBuffer vertices, VkBuffer indices, uint32_t indexCount,
                    VkIndexType indexType = VK_INDEX_TYPE_UINT16, const uint32_t* dynamicOffsets = nullptr,
                    uint32_t dynamicOffsetCount = 0, DepthStencilRecording* depth = nullptr) noexcept;
        void Record(ImageRecording& recording, const SpriteDrawArguments& arguments) noexcept;

      private:
        std::shared_ptr<SpritePipelineObjects> objects;
        std::shared_ptr<ResourceContext> contextOwner;
        std::shared_ptr<TextureImage> targetOwner;
        ResourceContext& context;
        TextureImage& target;
        uint32_t targetLevel, targetLayer;
        uint32_t colorTargetCount = 1;
        std::array<ColorTargetBinding, 3> additionalTargets{};
        VkExtent2D targetExtent;
        std::shared_ptr<DepthStencilAttachment> depthAttachment;
        std::array<std::vector<SampledImageBinding>, 2> images;
        std::array<VkShaderModule, 2> shaders{};
        std::array<VkDescriptorSetLayout, 4> setLayouts{};
        std::array<VkDescriptorSet, 4> sets{};
        std::vector<VkSampler> samplers;
        VkDescriptorPool pool = VK_NULL_HANDLE;
        VkPipelineLayout layout = VK_NULL_HANDLE;
        VkRenderPass renderPass = VK_NULL_HANDLE;
        VkFramebuffer framebuffer = VK_NULL_HANDLE;
        VkPipeline pipeline = VK_NULL_HANDLE;
#define PIPELINE_PROC(name) PFN_vk##name name = nullptr;
        PIPELINE_PROC(CreateShaderModule)
        PIPELINE_PROC(DestroyShaderModule)
        PIPELINE_PROC(CreateDescriptorSetLayout)
        PIPELINE_PROC(DestroyDescriptorSetLayout)
        PIPELINE_PROC(CreateDescriptorPool)
        PIPELINE_PROC(DestroyDescriptorPool)
        PIPELINE_PROC(AllocateDescriptorSets)
        PIPELINE_PROC(UpdateDescriptorSets)
        PIPELINE_PROC(CreateSampler)
        PIPELINE_PROC(DestroySampler)
        PIPELINE_PROC(CreatePipelineLayout)
        PIPELINE_PROC(DestroyPipelineLayout)
        PIPELINE_PROC(CreateRenderPass)
        PIPELINE_PROC(DestroyRenderPass)
        PIPELINE_PROC(CreateFramebuffer)
        PIPELINE_PROC(DestroyFramebuffer)
        PIPELINE_PROC(CreateGraphicsPipelines)
        PIPELINE_PROC(DestroyPipeline)
        PIPELINE_PROC(CmdBeginRenderPass)
        PIPELINE_PROC(CmdEndRenderPass)
        PIPELINE_PROC(CmdBindPipeline)
        PIPELINE_PROC(CmdBindDescriptorSets)
        PIPELINE_PROC(CmdBindVertexBuffers)
        PIPELINE_PROC(CmdBindIndexBuffer)
        PIPELINE_PROC(CmdDrawIndexed)
        PIPELINE_PROC(CmdSetViewport)
        PIPELINE_PROC(CmdSetScissor)
        PIPELINE_PROC(CmdSetBlendConstants)
        PIPELINE_PROC(CmdDraw)
        PIPELINE_PROC(CmdSetStencilReference)
        PIPELINE_PROC(CmdSetDepthBias)
#undef PIPELINE_PROC
        void Release() noexcept;
    };
}
