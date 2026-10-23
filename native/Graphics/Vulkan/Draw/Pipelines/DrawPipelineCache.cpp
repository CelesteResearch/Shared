#include "DrawPipelineCache.h"

namespace Celeste::Graphics::Vulkan
{
    size_t DrawPipelineCache::Hash::operator()(const std::vector<uint64_t>& values) const noexcept
    {
        size_t result = 0;
        for (auto value : values)
            result ^= std::hash<uint64_t>{}(value) + 0x9e3779b9u + (result << 6) + (result >> 2);
        return result;
    }
    std::shared_ptr<SpritePipeline> DrawPipelineCache::Bind(std::shared_ptr<TextureImage> target,
                                                            const SpritePipelineInfo& info)
    {
        key.clear();
        key.push_back(reinterpret_cast<uintptr_t>(info.vertex.words));
        key.push_back(reinterpret_cast<uintptr_t>(info.pixel.words));
        key.push_back(info.vertexBindings.size());
        for (const auto& stream : info.vertexBindings)
        {
            key.push_back(stream.binding);
            key.push_back(stream.stride);
            key.push_back(stream.inputRate);
        }
        key.push_back(info.vertexStride);
        key.push_back(info.attributes.size());
        for (const auto& attribute : info.attributes)
        {
            key.push_back(attribute.location);
            key.push_back(attribute.binding);
            key.push_back(attribute.format);
            key.push_back(attribute.offset);
        }
        for (int stage = 0; stage < 2; ++stage)
        {
            key.push_back(info.sampledImages[stage].size());
            for (const auto& image : info.sampledImages[stage])
                key.push_back(image.slot);
            key.push_back(info.constants[stage].buffer ? 1 : 0);
        }
        key.push_back(info.polygonMode);
        key.push_back(info.sampleMask);
        key.push_back(info.dynamicConstants);
        key.push_back(info.topology);
        key.push_back(info.cullMode);
        key.push_back(target->samples);
        key.push_back(target->format.native);
        key.push_back(info.depthAttachment ? info.depthAttachment->format : VK_FORMAT_UNDEFINED);
        const auto& depth = info.depthState;
        key.push_back(depth.depthTestEnable);
        key.push_back(depth.depthWriteEnable);
        key.push_back(depth.depthCompareOp);
        key.push_back(depth.stencilTestEnable);
        for (const auto* face : {&depth.front, &depth.back})
        {
            key.push_back(face->failOp);
            key.push_back(face->passOp);
            key.push_back(face->depthFailOp);
            key.push_back(face->compareOp);
            key.push_back(face->compareMask);
            key.push_back(face->writeMask);
        }
        const auto& blend = info.blend;
        key.push_back(blend.blendEnable);
        key.push_back(blend.srcColorBlendFactor);
        key.push_back(blend.dstColorBlendFactor);
        key.push_back(blend.colorBlendOp);
        key.push_back(blend.srcAlphaBlendFactor);
        key.push_back(blend.dstAlphaBlendFactor);
        key.push_back(blend.alphaBlendOp);
        key.push_back(blend.colorWriteMask);
        key.push_back(info.colorTargetCount);
        for (uint32_t i = 0; i + 1 < info.colorTargetCount; ++i)
        {
            key.push_back(info.additionalTargets[i].image->format.native);
            const auto& extra = info.additionalBlends[i];
            key.push_back(extra.blendEnable);
            key.push_back(extra.srcColorBlendFactor);
            key.push_back(extra.dstColorBlendFactor);
            key.push_back(extra.colorBlendOp);
            key.push_back(extra.srcAlphaBlendFactor);
            key.push_back(extra.dstAlphaBlendFactor);
            key.push_back(extra.alphaBlendOp);
            key.push_back(extra.colorWriteMask);
        }
        auto found = pipelines.find(key);
        auto result = std::make_shared<SpritePipeline>(context, std::move(target), info,
                                                       found == pipelines.end() ? nullptr : found->second);
        if (found == pipelines.end())
            pipelines.emplace(key, result->Objects());
        return result;
    }
}
