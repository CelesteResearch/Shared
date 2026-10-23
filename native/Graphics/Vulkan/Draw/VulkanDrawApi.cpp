#include "VulkanDrawApi.h"
#include "InitializeNullTextureCommand.h"
#include "mojoshader.h"
#include "VulkanColorRenderbufferApi.h"
#include "VulkanDrawContext.h"
#include "VulkanDrawState.h"
#include "DrawCommand.h"
#include "ClearCommand.h"
#include "SourceVulkanConversions.h"
#include "CelesteGraphicsPacket.h"
#include "CelesteGraphicsTexture.h"
#include "CelesteGraphicsBuffer.h"
#include "CelesteGraphicsRenderbuffer.h"
#include "SourceVulkanDepthStencil.h"
#include <stdexcept>
#include <cstring>
namespace Celeste::Graphics::Vulkan
{
    static DrawLogicalState& Edit(CelesteGraphicsPacket* packet)
    {
        if (!packet)
            throw std::invalid_argument("Missing draw packet");
        packet->RequireOpen();
        return packet->DrawState().Edit(packet->Owner().Draws());
    }
    template <class T> static const T& Required(const T* value)
    {
        if (!value)
            throw std::invalid_argument("Missing source state");
        return *value;
    }
    void SetViewport(CelesteGraphicsPacket* packet, const SourceCameraViewport* value)
    {
        const auto& source = Required(value);
        if (source.width <= 0 || source.height <= 0)
            throw std::invalid_argument("Vulkan viewport requires positive extent");
        Edit(packet).viewport = source;
    }
    void SetScissorRect(CelesteGraphicsPacket* packet, const CelesteGraphicsRect* value)
    {
        const auto& source = Required(value);
        if (source.width < 0 || source.height < 0)
            throw std::invalid_argument("Invalid source scissor rectangle");
        Edit(packet).scissor = source;
    }
    void SetBlendState(CelesteGraphicsPacket* packet, const SourceNativeBlendState* value)
    {
        ConvertBlend(Required(value));
        Edit(packet).blend = *value;
    }
    void SetDepthStencilState(CelesteGraphicsPacket* packet, const SourceNativeDepthStencilState* value)
    {
        ConvertDepthStencil(Required(value));
        Edit(packet).depth = *value;
    }
    void SetRasterizerState(CelesteGraphicsPacket* packet, const SourceNativeRasterizerState* value)
    {
        Edit(packet).raster = Required(value);
    }
    void SetSampler(CelesteGraphicsPacket* packet, uint32_t slot, uint8_t vertex, CelesteGraphicsTexture* texture,
                    const SourceNativeSamplerState* value)
    {
        if (slot >= 16)
            throw std::invalid_argument("Source sampler slot exceeds 16");
        if (texture && texture->device != &packet->Owner())
            throw std::invalid_argument("Sampler belongs to another device");
        ConvertSampler(Required(value));
        auto& sampler = Edit(packet).samplers[vertex ? 0 : 1][slot];
        sampler.texture = texture ? texture->image : nullptr;
        sampler.state = *value;
    }
    void SetBlendFactor(CelesteGraphicsPacket* packet, uint32_t value)
    {
        Edit(packet).blend.blendFactor = value;
    }
    void SetSampleMask(CelesteGraphicsPacket* packet, int32_t value)
    {
        Edit(packet).blend.multiSampleMask = value;
    }
    void SetStencilReference(CelesteGraphicsPacket* packet, int32_t value)
    {
        Edit(packet).depth.referenceStencil = value;
    }
    void GetBlendFactor(CelesteGraphicsDevice* device, uint32_t* result)
    {
        if (!device || !result)
            throw std::invalid_argument("Missing blend query");
        *result = device->Draws().logical->blend.blendFactor;
    }
    void GetSampleMask(CelesteGraphicsDevice* device, int32_t* result)
    {
        if (!device || !result)
            throw std::invalid_argument("Missing mask query");
        *result = device->Draws().logical->blend.multiSampleMask;
    }
    void GetStencilReference(CelesteGraphicsDevice* device, int32_t* result)
    {
        if (!device || !result)
            throw std::invalid_argument("Missing stencil query");
        *result = device->Draws().logical->depth.referenceStencil;
    }
    void ConfigureBackbuffer(CelesteGraphicsPacket* packet, const SourceNativePresentationParameters* value)
    {
        const auto& source = Required(value);
        if (source.backBufferWidth <= 0 || source.backBufferHeight <= 0 || source.multiSampleCount < 0)
            throw std::invalid_argument("Invalid backbuffer request");
        auto& logical = Edit(packet);
        auto& context = packet->Owner().Draws();
        if (!context.backbuffer || context.backbuffer->info.width != static_cast<uint32_t>(source.backBufferWidth) ||
            context.backbuffer->info.height != static_cast<uint32_t>(source.backBufferHeight) ||
            context.backbuffer->info.sourceFormat != source.backBufferFormat)
        {
            CelesteGraphicsTextureInfo info{source.backBufferFormat,
                                            CelesteGraphicsTexture2D,
                                            static_cast<uint32_t>(source.backBufferWidth),
                                            static_cast<uint32_t>(source.backBufferHeight),
                                            1,
                                            1,
                                            1};
            context.backbuffer = std::make_shared<TextureImage>(context.resources, info);
        }
        const auto samples = static_cast<VkSampleCountFlagBits>(source.multiSampleCount ? source.multiSampleCount : 1);
        if (samples == VK_SAMPLE_COUNT_1_BIT)
            context.backbufferColor = context.backbuffer;
        else if (!context.backbufferColor || context.backbufferColor->samples != samples ||
                 context.backbufferColor->extent.width != context.backbuffer->extent.width ||
                 context.backbufferColor->extent.height != context.backbuffer->extent.height ||
                 context.backbufferColor->info.sourceFormat != source.backBufferFormat)
            context.backbufferColor =
                std::make_shared<TextureImage>(context.resources, context.backbuffer->info, samples);
        if (source.depthStencilFormat == SourceDepthFormat_None)
            context.backbufferDepth.reset();
        else if (!context.backbufferDepth ||
                 context.backbufferDepth->extent.width != static_cast<uint32_t>(source.backBufferWidth) ||
                 context.backbufferDepth->extent.height != static_cast<uint32_t>(source.backBufferHeight) ||
                 context.backbufferDepthFormat != source.depthStencilFormat ||
                 context.backbufferDepth->samples != samples)
            context.backbufferDepth = std::make_shared<DepthStencilAttachment>(
                context.resources, source.backBufferWidth, source.backBufferHeight, source.depthStencilFormat,
                source.multiSampleCount);
        context.backbufferDepthFormat = source.depthStencilFormat;
        logical.colorTargetCount = 1;
        logical.additionalTargets = {};
        logical.target = context.backbufferColor;
        logical.targetLevel = logical.targetLayer = 0;
        logical.depthAttachment = context.backbufferDepth;
        logical.viewport = {0, 0, source.backBufferWidth, source.backBufferHeight, 0, 1};
        logical.scissor = {0, 0, source.backBufferWidth, source.backBufferHeight};
    }
    void ResolveBackbuffer(CelesteGraphicsPacket* packet)
    {
        if (!packet)
            throw std::invalid_argument("Missing resolve packet");
        packet->RequireOpen();
        auto& context = packet->Owner().Draws();
        if (!context.backbufferColor || context.backbufferColor == context.backbuffer)
            return;
        CelesteGraphicsTexture texture{&packet->Owner(), context.backbuffer, context.backbuffer->info};
        CelesteGraphicsRenderbuffer color{&packet->Owner(), nullptr, context.backbufferColor};
        SourceNativeRenderTargetBinding binding{};
        binding.texture = &texture;
        binding.colorBuffer = &color;
        binding.levelCount = 1;
        binding.multiSampleCount = static_cast<int32_t>(context.backbufferColor->samples);
        ResolveTarget(packet, &binding);
    }
    void GetBackbufferInfo(CelesteGraphicsDevice* device, CelesteGraphicsBackbufferInfo* result)
    {
        if (!device || !result)
            throw std::invalid_argument("Missing backbuffer query");
        const auto& context = device->Draws();
        const auto& image = context.backbuffer;
        if (!image)
            throw std::logic_error("Backbuffer has not been configured");
        *result = {static_cast<int32_t>(image->extent.width), static_cast<int32_t>(image->extent.height),
                   image->info.sourceFormat, context.backbufferDepthFormat,
                   context.backbufferColor->samples == VK_SAMPLE_COUNT_1_BIT
                       ? 0
                       : static_cast<int32_t>(context.backbufferColor->samples)};
    }
    void SetRenderTargets(CelesteGraphicsPacket* packet, const SourceNativeRenderTargetBinding* targets, int32_t count,
                          CelesteGraphicsRenderbuffer* depth, SourceDepthFormat format, uint8_t)
    {
        if (count < 0 || count > 4)
            throw std::invalid_argument("Source supports at most four color attachments");
        if (!packet)
            throw std::invalid_argument("Missing target packet");
        if (depth && (depth->device != &packet->Owner() || !depth->depth))
            throw std::invalid_argument("Invalid depth attachment");
        auto& context = packet->Owner().Draws();
        std::array<ColorTargetBinding, 4> colors{};
        auto depthAttachment = count ? (depth ? depth->depth : nullptr) : context.backbufferDepth;
        if (!count)
            colors[0] = {context.backbufferColor, 0, 0};
        else
        {
            if (!targets)
                throw std::invalid_argument("Missing target bindings");
            if (depth && format == SourceDepthFormat_None)
                throw std::invalid_argument("A bound depth attachment requires its source format");
            for (int32_t i = 0; i < count; ++i)
            {
                const auto& source = targets[i];
                auto& color = colors[i];
                const auto* texture = static_cast<CelesteGraphicsTexture*>(source.texture);
                if (source.type > 1 || !texture || texture->device != &packet->Owner() || !texture->info.renderTarget)
                    throw std::invalid_argument("Invalid render target texture");
                color.image = texture->image;
                if (source.type == 1)
                {
                    if (texture->info.dimension != CelesteGraphicsTextureCube || source.data2 < 0 || source.data2 >= 6)
                        throw std::invalid_argument("Invalid cube target face");
                    color.layer = source.data2;
                }
                else if (texture->info.dimension != CelesteGraphicsTexture2D)
                    throw std::invalid_argument("A 2D target binding requires a 2D texture");
                if (source.colorBuffer)
                {
                    const auto* buffer = static_cast<CelesteGraphicsRenderbuffer*>(source.colorBuffer);
                    if (buffer->device != &packet->Owner() || !buffer->color)
                        throw std::invalid_argument("Invalid color renderbuffer");
                    if (buffer->color->info.sourceFormat != texture->info.sourceFormat ||
                        buffer->color->extent.width != texture->info.width ||
                        buffer->color->extent.height != texture->info.height ||
                        static_cast<uint32_t>(buffer->color->samples) !=
                            static_cast<uint32_t>(source.multiSampleCount ? source.multiSampleCount : 1))
                        throw std::invalid_argument("Color renderbuffer differs from resolve binding");
                    color.image = buffer->color;
                    color.layer = 0;
                }
                else if (source.multiSampleCount > 1)
                    throw std::invalid_argument("A multisampled target requires its color renderbuffer");
                if (color.image->extent.width != colors[0].image->extent.width ||
                    color.image->extent.height != colors[0].image->extent.height ||
                    color.image->samples != colors[0].image->samples)
                    throw std::invalid_argument("Color attachment extent or samples differ");
                for (int32_t j = 0; j < i; ++j)
                    if (color.image == colors[j].image && color.layer == colors[j].layer)
                        throw std::invalid_argument("Duplicate color attachment subresource");
            }
        }
        if (!colors[0].image)
            throw std::logic_error("Missing source render target");
        auto& logical = Edit(packet);
        logical.target = colors[0].image;
        logical.targetLevel = 0;
        logical.targetLayer = colors[0].layer;
        logical.colorTargetCount = count ? count : 1;
        logical.additionalTargets = {};
        logical.depthAttachment = std::move(depthAttachment);
        for (uint32_t i = 1; i < logical.colorTargetCount; ++i)
            logical.additionalTargets[i - 1] = std::move(colors[i]);
        if (!logical.viewport.width || !logical.viewport.height)
            logical.viewport = {0,
                                0,
                                static_cast<int32_t>(logical.target->extent.width),
                                static_cast<int32_t>(logical.target->extent.height),
                                0,
                                1};
    }
    void Clear(CelesteGraphicsPacket* packet, SourceClearOptions options, const float* rgba, float depth,
               int32_t stencil)
    {
        if (options & ~(SourceClearOptions_Target | SourceClearOptions_DepthBuffer | SourceClearOptions_Stencil))
            throw std::invalid_argument("Unknown clear flags");
        auto& logical = Edit(packet);
        ClearCommand command{};
        command.image = UINT32_MAX;
        if (options & SourceClearOptions_Target)
        {
            if (!logical.target || !rgba)
                throw std::logic_error("Color clear requires a target and color");
            command.image = packet->Retain(logical.target);
            std::memcpy(command.value.float32, rgba, 16);
            command.level = logical.targetLevel;
            command.layer = logical.targetLayer;
            packet->RegisterImage(*logical.target);
            for (uint32_t i = 0; i + 1 < logical.colorTargetCount; ++i)
            {
                const auto& target = logical.additionalTargets[i];
                ClearCommand extra{};
                extra.image = packet->Retain(target.image);
                extra.level = target.level;
                extra.layer = target.layer;
                std::memcpy(extra.value.float32, rgba, 16);
                packet->RegisterImage(*target.image);
                packet->AddCommand(extra, nullptr, ClearCommand::Record);
            }
        }
        if (logical.depthAttachment)
        {
            VkImageAspectFlags aspects = 0;
            if (options & SourceClearOptions_DepthBuffer)
                aspects |= VK_IMAGE_ASPECT_DEPTH_BIT;
            if (options & SourceClearOptions_Stencil)
                aspects |= VK_IMAGE_ASPECT_STENCIL_BIT;
            command.depthAspects = aspects & logical.depthAttachment->aspect;
            if (command.depthAspects)
            {
                command.depth = packet->Retain(logical.depthAttachment);
                command.depthValue = depth;
                command.stencilValue = static_cast<uint32_t>(stencil);
                packet->RegisterDepth(*logical.depthAttachment);
            }
        }
        if (command.image != UINT32_MAX || command.depth != UINT32_MAX)
            packet->AddCommand(command, nullptr, ClearCommand::Record);
    }
    void SetVertexBindings(CelesteGraphicsPacket* packet, const SourceNativeVertexBufferBinding* bindings,
                           int32_t count, uint8_t, int32_t)
    {
        if (!packet || count < 0 || (count && !bindings))
            throw std::invalid_argument("Missing source vertex bindings");
        const auto& limits = packet->Owner().Draws().deviceLimits;
        if (static_cast<uint32_t>(count) > limits.maxVertexInputBindings)
            throw std::invalid_argument("Vertex stream count exceeds device limit");
        auto& logical = Edit(packet);
        logical.streams.clear();
        logical.vertexBuffers.clear();
        logical.vertexOffsets.clear();
        logical.elements.clear();
        logical.elementBindings.clear();
        logical.streams.reserve(count);
        logical.vertexBuffers.reserve(count);
        logical.vertexOffsets.reserve(count);
        bool used[16][16]{};
        for (int32_t slot = 0; slot < count; ++slot)
        {
            const auto& source = bindings[slot];
            auto* buffer = static_cast<CelesteGraphicsBuffer*>(source.vertexBuffer);
            if (!buffer || buffer->device != &packet->Owner() || buffer->index || source.vertexOffset < 0 ||
                source.vertexDeclaration.vertexStride <= 0 || source.vertexDeclaration.elementCount < 0 ||
                (source.vertexDeclaration.elementCount && !source.vertexDeclaration.elements))
                throw std::invalid_argument("Invalid source vertex stream");
            if (source.instanceFrequency < 0 || source.instanceFrequency > 1)
                throw std::invalid_argument(
                    "Instance divisor above one requires an explicitly enabled vertex attribute divisor extension");
            if (static_cast<uint32_t>(source.vertexDeclaration.vertexStride) > limits.maxVertexInputBindingStride)
                throw std::invalid_argument("Vertex stride exceeds device limit");
            const auto offset = static_cast<VkDeviceSize>(source.vertexOffset) * source.vertexDeclaration.vertexStride;
            if (offset > buffer->buffer->size)
                throw std::out_of_range("Vertex stream offset exceeds buffer");
            logical.streams.push_back({buffer->buffer, static_cast<uint32_t>(source.vertexDeclaration.vertexStride),
                                       static_cast<uint32_t>(source.instanceFrequency), offset});
            logical.vertexBuffers.push_back(buffer->buffer->buffer);
            logical.vertexOffsets.push_back(offset);
            for (int32_t i = 0; i < source.vertexDeclaration.elementCount; ++i)
            {
                auto element = source.vertexDeclaration.elements[i];
                if (element.vertexElementUsage < 0 || element.vertexElementUsage >= 16 || element.usageIndex < 0 ||
                    element.usageIndex >= 16 || element.offset < 0 ||
                    static_cast<uint32_t>(element.offset) > limits.maxVertexInputAttributeOffset)
                    throw std::invalid_argument("Invalid source vertex element");
                auto& usage = used[element.vertexElementUsage];
                if (usage[element.usageIndex])
                {
                    int replacement = 0;
                    while (replacement < 16 && usage[replacement])
                        ++replacement;
                    if (replacement == 16)
                        throw std::invalid_argument("Source vertex semantic slots exhausted");
                    element.usageIndex = replacement;
                }
                usage[element.usageIndex] = true;
                logical.elements.push_back(element);
                logical.elementBindings.push_back(static_cast<uint32_t>(slot));
            }
        }
        logical.vertices = count ? logical.streams[0].buffer : nullptr;
        logical.stride = count ? logical.streams[0].stride : 0;
        logical.vertexOffset = count ? logical.streams[0].offset : 0;
    }
    void ApplyEffect(CelesteGraphicsPacket* packet, void* effect, uint32_t pass, void* changes)
    {
        if (!packet)
            throw std::invalid_argument("Missing effect packet");
        packet->RequireOpen();
        auto& state = packet->DrawState();
        auto& context = packet->Owner().Draws();
        state.effects.push_back(context.effects.Apply(effect, pass, changes, *state.constants));
        context.lastEffect = state.effects.back();
        context.lastConstants = state.constants;
    }
    static DrawCommand Capture(CelesteGraphicsPacket* packet, SourcePrimitiveType topology, int32_t primitiveCount)
    {
        if (!packet)
            throw std::invalid_argument("Missing draw packet");
        packet->RequireOpen();
        auto& state = packet->DrawState();
        const auto& logical = *state.logical;
        if (!logical.target || !logical.vertices || state.effects.empty())
            throw std::logic_error("Draw requires target, vertex binding and applied effect");
        if (logical.raster.fillMode != SourceFillMode_Solid && logical.raster.fillMode != SourceFillMode_WireFrame)
            throw std::invalid_argument("Unknown source fill mode");
        if (logical.raster.cullMode < SourceCullMode_None ||
            logical.raster.cullMode > SourceCullMode_CullCounterClockwiseFace)
            throw std::invalid_argument("Unknown cull mode");
        if (logical.viewport.width <= 0 || logical.viewport.height <= 0)
            throw std::invalid_argument("Missing viewport");
        auto& context = packet->Owner().Draws();
        const auto& effect = state.effects.back();
        for (int stage = 0; stage < 2; ++stage)
        {
            const auto& shader = effect.shaders[stage]->description;
            const auto* samplers = static_cast<const MOJOSHADER_sampler*>(shader.samplers);
            for (int i = 0; i < shader.samplerCountParsed; ++i)
            {
                const auto& sampler = samplers[i];
                if (sampler.index < 0 || sampler.index >= 16)
                    throw std::invalid_argument("Unsupported Vulkan sampled image slot");
                if (logical.samplers[stage][sampler.index].texture)
                    continue;
                const auto dimension = NullTextureCache::Dimension(sampler.type);
                const auto& image = context.nullTextures.Get(sampler.type);
                packet->RegisterImage(*image);
                if (!state.nullInitializationQueued[dimension] && image->states[0].layout == VK_IMAGE_LAYOUT_UNDEFINED)
                {
                    packet->AddCommand(InitializeNullTextureCommand{packet->Retain(image)}, nullptr,
                                       InitializeNullTextureCommand::Record);
                    state.nullInitializationQueued[dimension] = true;
                }
            }
        }
        DrawCommand command{};
        command.state = packet->Retain(packet->drawState);
        command.logical = packet->Retain(state.logical);
        command.effect = static_cast<uint32_t>(state.effects.size() - 1);
        command.topology = topology;
        command.count = PrimitiveVertices(topology, primitiveCount);
        command.instances = 1;
        packet->RegisterImage(*logical.target);
        for (uint32_t i = 0; i + 1 < logical.colorTargetCount; ++i)
            packet->RegisterImage(*logical.additionalTargets[i].image);
        if (logical.depthAttachment)
            packet->RegisterDepth(*logical.depthAttachment);
        for (const auto& stage : logical.samplers)
            for (const auto& binding : stage)
                if (binding.texture)
                    packet->RegisterImage(*binding.texture);
        return command;
    }
    void Draw(CelesteGraphicsPacket* packet, SourcePrimitiveType topology, int32_t start, int32_t primitiveCount)
    {
        if (start < 0)
            throw std::invalid_argument("Negative start vertex");
        auto command = Capture(packet, topology, primitiveCount);
        command.first = start;
        packet->AddCommand(command, DrawCommand::Prepare, DrawCommand::Record);
    }
    void DrawIndexed(CelesteGraphicsPacket* packet, SourcePrimitiveType topology, int32_t baseVertex, int32_t, int32_t,
                     int32_t startIndex, int32_t primitiveCount, int32_t instances, CelesteGraphicsBuffer* indices,
                     SourceIndexElementSize size)
    {
        if (!indices || indices->device != &packet->Owner() || !indices->index || startIndex < 0 || instances < 1 ||
            (size != SourceIndexElementSize_SixteenBits && size != SourceIndexElementSize_ThirtyTwoBits))
            throw std::invalid_argument("Invalid indexed draw arguments");
        auto command = Capture(packet, topology, primitiveCount);
        command.first = startIndex;
        command.baseVertex = baseVertex;
        command.instances = instances;
        command.indexType = size == SourceIndexElementSize_SixteenBits ? VK_INDEX_TYPE_UINT16 : VK_INDEX_TYPE_UINT32;
        const uint64_t end =
            (static_cast<uint64_t>(startIndex) + command.count) * (size == SourceIndexElementSize_SixteenBits ? 2 : 4);
        if (end > indices->buffer->size)
            throw std::out_of_range("Indexed draw exceeds index buffer");
        command.indexBuffer = packet->Retain(indices->buffer);
        packet->AddCommand(command, DrawCommand::Prepare, DrawCommand::Record);
    }
}
