#pragma once
#include "DrawLogicalState.h"
#include "NullTextureCache.h"
#include "EffectSnapshotCache.h"
#include "EffectProgramCache.h"
#include "UniformBufferPool.h"
#include "DrawPipelineCache.h"
struct CelesteGraphicsDevice;
class VulkanDrawContext final
{
  public:
    std::shared_ptr<Celeste::Graphics::Vulkan::ResourceContext> resources;
    std::shared_ptr<Celeste::Graphics::Vulkan::DrawLogicalState> logical;
    std::shared_ptr<Celeste::Graphics::Vulkan::TextureImage> backbuffer, backbufferColor;
    std::shared_ptr<Celeste::Graphics::Vulkan::DepthStencilAttachment> backbufferDepth;
    SourceDepthFormat backbufferDepthFormat = SourceDepthFormat_None;
    Celeste::Graphics::Vulkan::EffectSnapshotCache effects;
    Celeste::Graphics::Vulkan::EffectProgramCache programs;
    Celeste::Graphics::Vulkan::UniformBufferPool uniforms;
    Celeste::Graphics::Vulkan::DrawPipelineCache pipelines;
    Celeste::Graphics::Vulkan::NullTextureCache nullTextures;
    uint32_t uniformAlignment;
    VkPhysicalDeviceLimits deviceLimits{};
    Celeste::Graphics::Vulkan::EffectSnapshot lastEffect;
    std::shared_ptr<Celeste::Graphics::Vulkan::EffectConstantStorage> lastConstants;
    std::vector<CelesteSpirvVertexAttribute> vertexScratch;
    explicit VulkanDrawContext(CelesteGraphicsDevice& device);
};
