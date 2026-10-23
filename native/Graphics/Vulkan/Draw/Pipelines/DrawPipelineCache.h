#pragma once
#include "SpritePipeline.h"
#include <unordered_map>

namespace Celeste::Graphics::Vulkan
{
    class DrawPipelineCache final
    {
        struct Hash
        {
            size_t operator()(const std::vector<uint64_t>& values) const noexcept;
        };
        std::shared_ptr<ResourceContext> context;
        std::unordered_map<std::vector<uint64_t>, std::shared_ptr<SpritePipelineObjects>, Hash> pipelines;
        std::vector<uint64_t> key;

      public:
        explicit DrawPipelineCache(std::shared_ptr<ResourceContext> owner) : context(std::move(owner))
        {
        }
        std::shared_ptr<SpritePipeline> Bind(std::shared_ptr<TextureImage> target, const SpritePipelineInfo& info);
    };
}
