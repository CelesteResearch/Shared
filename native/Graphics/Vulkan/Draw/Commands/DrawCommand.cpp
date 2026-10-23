#include "DrawCommand.h"
#include "VulkanDrawContext.h"
#include "VulkanDrawState.h"
#include "SourceVulkanConversions.h"
#include "SourceVulkanDepthStencil.h"
#include "mojoshader.h"
#include <stdexcept>
#include <algorithm>
namespace Celeste::Graphics::Vulkan
{
    static int Usage(SourceVertexElementUsage value)
    {
        switch (value)
        {
        case SourceVertexElementUsage_Position:
            return MOJOSHADER_USAGE_POSITION;
        case SourceVertexElementUsage_Color:
            return MOJOSHADER_USAGE_COLOR;
        case SourceVertexElementUsage_TextureCoordinate:
            return MOJOSHADER_USAGE_TEXCOORD;
        case SourceVertexElementUsage_Normal:
            return MOJOSHADER_USAGE_NORMAL;
        case SourceVertexElementUsage_Binormal:
            return MOJOSHADER_USAGE_BINORMAL;
        case SourceVertexElementUsage_Tangent:
            return MOJOSHADER_USAGE_TANGENT;
        case SourceVertexElementUsage_BlendIndices:
            return MOJOSHADER_USAGE_BLENDINDICES;
        case SourceVertexElementUsage_BlendWeight:
            return MOJOSHADER_USAGE_BLENDWEIGHT;
        case SourceVertexElementUsage_Depth:
            return MOJOSHADER_USAGE_DEPTH;
        case SourceVertexElementUsage_Fog:
            return MOJOSHADER_USAGE_FOG;
        case SourceVertexElementUsage_PointSize:
            return MOJOSHADER_USAGE_POINTSIZE;
        case SourceVertexElementUsage_Sample:
            return MOJOSHADER_USAGE_SAMPLE;
        case SourceVertexElementUsage_TessellateFactor:
            return MOJOSHADER_USAGE_TESSFACTOR;
        default:
            throw std::invalid_argument("Unknown source vertex semantic");
        }
    }
    static bool SameBindings(const DrawLogicalState& a, const DrawLogicalState& b)
    {
        if (&a == &b)
            return true;
        if (a.target != b.target || a.targetLevel != b.targetLevel || a.targetLayer != b.targetLayer ||
            a.depthAttachment != b.depthAttachment || a.stride != b.stride || a.elements.size() != b.elements.size() ||
            a.raster.cullMode != b.raster.cullMode || a.raster.fillMode != b.raster.fillMode ||
            a.blend.multiSampleMask != b.blend.multiSampleMask)
            return false;
        if (a.streams.size() != b.streams.size() || a.elementBindings != b.elementBindings)
            return false;
        for (size_t i = 0; i < a.streams.size(); ++i)
            if (a.streams[i].stride != b.streams[i].stride ||
                a.streams[i].instanceFrequency != b.streams[i].instanceFrequency)
                return false;
        if (a.colorTargetCount != b.colorTargetCount)
            return false;
        for (uint32_t i = 0; i + 1 < a.colorTargetCount; ++i)
        {
            const auto& p = a.additionalTargets[i];
            const auto& q = b.additionalTargets[i];
            if (p.image != q.image || p.level != q.level || p.layer != q.layer)
                return false;
        }
        if (a.blend.colorWriteEnable1 != b.blend.colorWriteEnable1 ||
            a.blend.colorWriteEnable2 != b.blend.colorWriteEnable2 ||
            a.blend.colorWriteEnable3 != b.blend.colorWriteEnable3)
            return false;
        const auto& da = a.depth;
        const auto& db = b.depth;
        if (da.depthBufferEnable != db.depthBufferEnable || da.depthBufferWriteEnable != db.depthBufferWriteEnable ||
            da.depthBufferFunction != db.depthBufferFunction || da.stencilEnable != db.stencilEnable ||
            da.stencilMask != db.stencilMask || da.stencilWriteMask != db.stencilWriteMask ||
            da.twoSidedStencilMode != db.twoSidedStencilMode || da.stencilFail != db.stencilFail ||
            da.stencilDepthBufferFail != db.stencilDepthBufferFail || da.stencilPass != db.stencilPass ||
            da.stencilFunction != db.stencilFunction || da.ccwStencilFail != db.ccwStencilFail ||
            da.ccwStencilDepthBufferFail != db.ccwStencilDepthBufferFail || da.ccwStencilPass != db.ccwStencilPass ||
            da.ccwStencilFunction != db.ccwStencilFunction)
            return false;
        const auto& x = a.blend;
        const auto& y = b.blend;
        if (x.colorSourceBlend != y.colorSourceBlend || x.colorDestinationBlend != y.colorDestinationBlend ||
            x.colorBlendFunction != y.colorBlendFunction || x.alphaSourceBlend != y.alphaSourceBlend ||
            x.alphaDestinationBlend != y.alphaDestinationBlend || x.alphaBlendFunction != y.alphaBlendFunction ||
            x.colorWriteEnable != y.colorWriteEnable)
            return false;
        for (size_t i = 0; i < a.elements.size(); ++i)
        {
            const auto& p = a.elements[i];
            const auto& q = b.elements[i];
            if (p.offset != q.offset || p.vertexElementFormat != q.vertexElementFormat ||
                p.vertexElementUsage != q.vertexElementUsage || p.usageIndex != q.usageIndex)
                return false;
        }
        for (int stage = 0; stage < 2; ++stage)
            for (int slot = 0; slot < 16; ++slot)
            {
                const auto& p = a.samplers[stage][slot];
                const auto& q = b.samplers[stage][slot];
                if (p.texture != q.texture)
                    return false;
                if (!p.texture)
                    continue;
                const auto& u = p.state;
                const auto& v = q.state;
                if (u.filter != v.filter || u.addressU != v.addressU || u.addressV != v.addressV ||
                    u.addressW != v.addressW || u.mipMapLevelOfDetailBias != v.mipMapLevelOfDetailBias ||
                    u.maxAnisotropy != v.maxAnisotropy || u.maxMipLevel != v.maxMipLevel)
                    return false;
            }
        return true;
    }
    void DrawCommand::Prepare(CelesteGraphicsPacket& packet, void* data)
    {
        auto& command = *static_cast<DrawCommand*>(data);
        auto& state = packet.Resource<VulkanDrawState>(command.state);
        const auto& logical = packet.Resource<DrawLogicalState>(command.logical);
        auto& context = packet.Owner().Draws();
        const auto& effect = state.effects[command.effect];
        state.PrepareUniforms(context);
        auto& attributes = context.vertexScratch;
        attributes.clear();
        attributes.reserve(logical.elements.size());
        for (const auto& element : logical.elements)
            attributes.push_back({Usage(element.vertexElementUsage), element.vertexElementFormat, element.usageIndex});
        const auto program = context.programs.Get(effect, attributes);
        const auto topology = ConvertTopology(command.topology);
        for (const auto& binding : state.bindings)
            if (binding.program == program.get() && binding.topology == topology &&
                SameBindings(*binding.logical, logical))
            {
                command.pipeline = packet.Retain(binding.pipeline);
                return;
            }
        SpritePipelineInfo info{};
        const auto vertex = program->Binary(true), pixel = program->Binary(false);
        info.vertex = {vertex.words, vertex.byteCount, vertex.entryPoint};
        info.pixel = {pixel.words, pixel.byteCount, pixel.entryPoint};
        info.polygonMode =
            logical.raster.fillMode == SourceFillMode_WireFrame ? VK_POLYGON_MODE_LINE : VK_POLYGON_MODE_FILL;
        info.sampleMask = static_cast<uint32_t>(logical.blend.multiSampleMask);
        for (uint32_t slot = 0; slot < logical.streams.size(); ++slot)
            info.vertexBindings.push_back({slot, logical.streams[slot].stride,
                                           logical.streams[slot].instanceFrequency ? VK_VERTEX_INPUT_RATE_INSTANCE
                                                                                   : VK_VERTEX_INPUT_RATE_VERTEX});
        info.vertexStride = logical.stride;
        info.topology = topology;
        info.dynamicConstants = true;
        info.blend = ConvertBlend(logical.blend);
        info.colorTargetCount = logical.colorTargetCount;
        info.additionalTargets = logical.additionalTargets;
        const SourceColorWriteChannels masks[] = {logical.blend.colorWriteEnable1, logical.blend.colorWriteEnable2,
                                                  logical.blend.colorWriteEnable3};
        for (uint32_t i = 0; i + 1 < info.colorTargetCount; ++i)
        {
            auto blend = logical.blend;
            blend.colorWriteEnable = masks[i];
            info.additionalBlends[i] = ConvertBlend(blend);
        }
        info.targetLevel = logical.targetLevel;
        info.targetLayer = logical.targetLayer;
        info.depthAttachment = logical.depthAttachment;
        info.depthState = ConvertDepthStencil(logical.depth);
        // With the negative viewport, D3D CCW remains the front-face definition.
        if (logical.raster.cullMode == SourceCullMode_CullClockwiseFace)
            info.cullMode = VK_CULL_MODE_BACK_BIT;
        else if (logical.raster.cullMode == SourceCullMode_CullCounterClockwiseFace)
            info.cullMode = VK_CULL_MODE_FRONT_BIT;
        for (size_t i = 0; i < logical.elements.size(); ++i)
        {
            const auto& element = logical.elements[i];
            const auto location = program->VertexLocation(attributes[i].usage, element.usageIndex);
            if (location >= 0)
            {
                const VkFormat format = ConvertVertexFormat(element.vertexElementFormat);
                const uint32_t portability = context.resources->native.portabilityFeatures;
                if ((portability & CelesteVulkanPortabilitySubset) &&
                    !(portability & CelesteVulkanPortabilityVertexAttributeAccessBeyondStride))
                {
                    static constexpr uint32_t sizes[] = {4, 8, 12, 16, 4, 4, 4, 8, 4, 8, 4, 8};
                    const uint64_t end =
                        uint64_t(static_cast<uint32_t>(element.offset)) + sizes[element.vertexElementFormat];
                    if (end > logical.streams[logical.elementBindings[i]].stride)
                        throw std::invalid_argument(
                            "Vertex access beyond its stride was not enabled on this portability device");
                }
                info.attributes.push_back({static_cast<uint32_t>(location), logical.elementBindings[i], format,
                                           static_cast<uint32_t>(element.offset)});
            }
        }
        if (info.attributes.size() > context.deviceLimits.maxVertexInputAttributes)
            throw std::invalid_argument("Vertex attribute count exceeds device limit");
        for (int stage = 0; stage < 2; ++stage)
        {
            const auto& description = effect.shaders[stage]->description;
            const auto* samplers = static_cast<const MOJOSHADER_sampler*>(description.samplers);
            for (int i = 0; i < description.samplerCountParsed; ++i)
            {
                const int slot = samplers[i].index;
                if (slot < 0 || slot >= 16)
                    throw std::invalid_argument("Unsupported Vulkan sampled image slot");
                const auto& source = logical.samplers[stage][slot];
                const auto& texture = source.texture ? source.texture : context.nullTextures.Get(samplers[i].type);
                const auto dimension = texture->info.dimension;
                if (samplers[i].type != MOJOSHADER_SAMPLER_2D && samplers[i].type != MOJOSHADER_SAMPLER_VOLUME &&
                    samplers[i].type != MOJOSHADER_SAMPLER_CUBE)
                    throw std::invalid_argument("Unsupported shader sampler dimension");
                if ((samplers[i].type == MOJOSHADER_SAMPLER_2D && dimension != CelesteGraphicsTexture2D) ||
                    (samplers[i].type == MOJOSHADER_SAMPLER_VOLUME && dimension != CelesteGraphicsTexture3D) ||
                    (samplers[i].type == MOJOSHADER_SAMPLER_CUBE && dimension != CelesteGraphicsTextureCube))
                    throw std::invalid_argument("Sampled texture dimension differs from shader declaration");
                auto sampler = ConvertSampler(source.state);
                if (sampler.anisotropyEnable)
                {
                    if (!context.resources->native.enabledFeatures.samplerAnisotropy)
                        throw std::invalid_argument("Sampler anisotropy was not enabled on this device");
                    sampler.maxAnisotropy =
                        std::clamp(sampler.maxAnisotropy, 1.0f, context.deviceLimits.maxSamplerAnisotropy);
                }
                const uint32_t portability = context.resources->native.portabilityFeatures;
                if (sampler.mipLodBias != 0.0f && (portability & CelesteVulkanPortabilitySubset) &&
                    !(portability & CelesteVulkanPortabilitySamplerMipLodBias))
                    throw std::invalid_argument("Sampler LOD bias was not enabled on this portability device");
                sampler.mipLodBias = std::clamp(sampler.mipLodBias, -context.deviceLimits.maxSamplerLodBias,
                                                context.deviceLimits.maxSamplerLodBias);
                info.sampledImages[stage].push_back({static_cast<uint32_t>(slot), texture, sampler});
            }
            if (effect.constantSizes[stage])
                info.constants[stage] = {state.uniformPage->buffer, 0, effect.constantSizes[stage]};
        }
        auto pipeline = context.pipelines.Bind(logical.target, info);
        state.bindings.push_back({&logical, program.get(), topology, pipeline});
        command.pipeline = packet.Retain(std::move(pipeline));
    }
    void DrawCommand::Record(CelesteGraphicsPacket& packet, const void* data,
                             VulkanPacketRecordContext& recording) noexcept
    {
        const auto& command = *static_cast<const DrawCommand*>(data);
        const auto& logical = packet.Resource<DrawLogicalState>(command.logical);
        const auto& effect = packet.Resource<VulkanDrawState>(command.state).effects[command.effect];
        uint32_t offsets[2]{};
        uint32_t count = 0;
        for (int stage = 0; stage < 2; ++stage)
            if (effect.constantSizes[stage])
                offsets[count++] = effect.constantOffsets[stage];
        SpriteDrawArguments arguments;
        arguments.vertexBuffers = logical.vertexBuffers.data();
        arguments.vertexOffsets = logical.vertexOffsets.data();
        arguments.vertexBindingCount = static_cast<uint32_t>(logical.vertexBuffers.size());
        if (command.indexBuffer != UINT32_MAX)
            arguments.indices = packet.Resource<TransferBuffer>(command.indexBuffer).buffer;
        arguments.indexType = command.indexType;
        arguments.count = command.count;
        arguments.first = command.first;
        arguments.instances = command.instances;
        arguments.baseVertex = command.baseVertex;
        arguments.viewport = {static_cast<float>(logical.viewport.x),
                              static_cast<float>(logical.viewport.y + logical.viewport.height),
                              static_cast<float>(logical.viewport.width),
                              -static_cast<float>(logical.viewport.height),
                              logical.viewport.minDepth,
                              logical.viewport.maxDepth};
        const auto extent = logical.target->MipExtent(logical.targetLevel);
        const int64_t left =
            logical.raster.scissorTestEnable ? std::clamp<int64_t>(logical.scissor.x, 0, extent.width) : 0;
        const int64_t top =
            logical.raster.scissorTestEnable ? std::clamp<int64_t>(logical.scissor.y, 0, extent.height) : 0;
        const int64_t right = logical.raster.scissorTestEnable
                                  ? std::clamp<int64_t>(static_cast<int64_t>(logical.scissor.x) + logical.scissor.width,
                                                        left, extent.width)
                                  : extent.width;
        const int64_t bottom =
            logical.raster.scissorTestEnable
                ? std::clamp<int64_t>(static_cast<int64_t>(logical.scissor.y) + logical.scissor.height, top,
                                      extent.height)
                : extent.height;
        arguments.scissor = {{static_cast<int32_t>(left), static_cast<int32_t>(top)},
                             {static_cast<uint32_t>(right - left), static_cast<uint32_t>(bottom - top)}};
        for (int c = 0; c < 4; ++c)
            arguments.blendConstants[c] = static_cast<float>((logical.blend.blendFactor >> (8 * c)) & 255u) / 255;
        arguments.dynamicOffsets = offsets;
        arguments.dynamicOffsetCount = count;
        const float depthScale = logical.depthAttachment ? logical.depthAttachment->depthBiasScale : 0.0f;
        arguments.depthBiasConstant = logical.raster.depthBias * depthScale;
        arguments.depthBiasSlope = logical.raster.slopeScaleDepthBias;
        arguments.depthRecording = &recording.depth;
        arguments.stencilReference = static_cast<uint32_t>(logical.depth.referenceStencil);
        packet.Resource<SpritePipeline>(command.pipeline).Record(recording.images, arguments);
    }
}
