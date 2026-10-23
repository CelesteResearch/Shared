#include "Direct3D12DrawApi.h"
#include "Direct3D12DrawArena.h"
#include "Direct3D12ConsumedInputs.h"
#include "Direct3D12DrawPayload.h"
#include "Direct3D12PreparedDraw.h"
#include "Direct3D12DrawContext.h"
#include "Direct3D12Sampler.h"
#include "Direct3D12EffectSnapshot.h"
#include "Direct3D12EffectShaderLease.h"
#include "Direct3D12EffectProgram.h"
#include "Direct3D12Effects.h"
#include "CelesteGraphicsPacket.h"
#include "CelesteGraphicsBuffer.h"
#include "RootParameter.h"
#include <mojoshader.h>
#include <algorithm>
#include <cstring>
#include <stdexcept>
using namespace Celeste::Graphics::Direct3D12;
namespace
{
    uint32_t ElementCount(SourcePrimitiveType primitive, int32_t count)
    {
        if (count < 0)
            throw std::invalid_argument("Negative primitive count");
        if (count == 0)
            return 0;
        uint64_t result;
        switch (primitive)
        {
        case SourcePrimitiveType_TriangleList:
            result = uint64_t(count) * 3;
            break;
        case SourcePrimitiveType_TriangleStrip:
            result = uint64_t(count) + 2;
            break;
        case SourcePrimitiveType_LineList:
            result = uint64_t(count) * 2;
            break;
        case SourcePrimitiveType_LineStrip:
            result = uint64_t(count) + 1;
            break;
        case SourcePrimitiveType_PointListEXT:
            result = count;
            break;
        default:
            throw std::invalid_argument("Invalid primitive topology");
        }
        if (result > UINT32_MAX)
            throw std::overflow_error("Draw count exceeds D3D range");
        return static_cast<uint32_t>(result);
    }
    Direct3D12ConsumedInputs UsedInputs(const InputLayout& layout, const MOJOSHADER_parseData& shader)
    {
        static constexpr const char* names[] = {"POSITION", "BLENDWEIGHT", "BLENDINDICES", "NORMAL",        "PSIZE",
                                                "TEXCOORD", "TANGENT",     "BINORMAL",     "TESSFACTOR",    "POSITIONT",
                                                "COLOR",    "FOG",         "SV_DEPTH",     "SV_SampleIndex"};
        Direct3D12ConsumedInputs used;
        if (shader.attribute_count < 0 || static_cast<size_t>(shader.attribute_count) > used.elements.size())
            throw std::invalid_argument("Shader input count exceeds D3D12 input registers");
        for (int32_t i = 0; i < shader.attribute_count; ++i)
        {
            const auto& attribute = shader.attributes[i];
            if (static_cast<unsigned>(attribute.usage) >= std::size(names))
                throw std::runtime_error("Unsupported vertex attribute semantic");
            const auto found = std::find_if(layout.elements.begin(), layout.elements.end(), [&](const auto& element) {
                return element.SemanticIndex == static_cast<UINT>(attribute.index) &&
                       !std::strcmp(element.SemanticName, names[attribute.usage]);
            });
            if (found == layout.elements.end())
                throw std::runtime_error("Vertex declaration does not provide a consumed shader attribute");
            used.elements[used.count++] = *found;
        }
        return used;
    }
    void PrepareDraw(CelesteGraphicsPacket& packet, void* data)
    {
        auto& command = *static_cast<Direct3D12DrawPayload*>(data);
        const auto& state = packet.Resource<Direct3D12DrawState>(command.stateIndex);
        if (!state.effect || !state.effect->shaders[0] || !state.effect->shaders[1])
            throw std::logic_error("Draw requires applied vertex and pixel shaders");
        BindingRequirements required{32, 32, 4, 1, 0};
        for (const auto& constants : state.effect->constants)
            required.uniformBytes += (std::max<size_t>(1, constants.size()) + 255) & ~size_t(255);
        auto& arena = GetDrawArena(packet);
        command.preparedIndex = arena.AddDraw();
        auto& result = arena.draws[command.preparedIndex];
        result.bindings = GetBindingBatch(packet, required);
        PrepareTargets(packet, state, result.bindings, result.targets);
        const auto& layout = *state.input;
        const auto& parsed = *static_cast<const MOJOSHADER_parseData*>(state.effect->shaders[0]->description.parsed);
        auto used = UsedInputs(layout, parsed);
        auto shaders = PrepareShadersForLayout(*state.effect, used.elements.data(), used.count);
        const auto depthFormat = state.usesBackbuffer ? state.presentation.depthStencilFormat : state.depthFormat;
        auto pipelineState = ConvertPipelineState(state.blend, state.depthState, state.raster, depthFormat);
        result.pipeline =
            GetDrawContext(packet.Owner())
                .pipelines.Acquire(static_cast<uint64_t>(reinterpret_cast<uintptr_t>(shaders.get())), shaders->shaders,
                                   pipelineState, layout, result.targets.formats, command.primitive);
        result.dynamic = ConvertDynamicState(state.blend, state.depthState, state.raster);
        const auto& v = state.viewport;
        result.viewport = {static_cast<float>(v.x),
                           static_cast<float>(v.y),
                           static_cast<float>(v.width),
                           static_cast<float>(v.height),
                           v.minDepth,
                           v.maxDepth};
        D3D12_RECT rect{state.scissor.x, state.scissor.y, state.scissor.x + state.scissor.width,
                        state.scissor.y + state.scissor.height};
        result.scissor = ResolveScissor(result.dynamic, rect, result.targets.width, result.targets.height);
        result.views = result.bindings->AllocateViews(32);
        result.samplers = result.bindings->AllocateSamplers(32);
        for (uint32_t stage = 0; stage < 2; ++stage)
        {
            const auto& constants = state.effect->constants[stage];
            static const uint32_t zero = 0;
            result.constants[stage] = result.bindings->UploadUniform(
                constants.empty() ? static_cast<const void*>(&zero) : constants.data(),
                static_cast<uint32_t>(constants.empty() ? sizeof(zero) : constants.size()));
            for (uint32_t slot = 0; slot < 16; ++slot)
            {
                const auto index = stage * 16 + slot;
                const auto& binding = state.samplers[(stage == 0 ? 16 : 0) + slot];
                const auto type = state.effect->shaders[stage]->samplerTypes[slot];
                auto texture = type >= 0 ? binding.texture : nullptr;
                if (texture)
                    for (uint32_t target = 0; target < result.targets.count; ++target)
                        if (texture == result.targets.colors[target].image)
                            texture.reset();
                if (texture)
                {
                    texture->CreateShaderView(result.views.Cpu(index));
                    packet.RegisterResource(texture);
                    result.sampled[result.sampledCount++] = std::move(texture);
                }
                else
                {
                    D3D12_SHADER_RESOURCE_VIEW_DESC view{};
                    view.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
                    view.Shader4ComponentMapping = D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING;
                    if (type == 1)
                    {
                        view.ViewDimension = D3D12_SRV_DIMENSION_TEXTURECUBE;
                        view.TextureCube.MipLevels = 1;
                    }
                    else if (type == 2)
                    {
                        view.ViewDimension = D3D12_SRV_DIMENSION_TEXTURE3D;
                        view.Texture3D.MipLevels = 1;
                    }
                    else
                    {
                        view.ViewDimension = D3D12_SRV_DIMENSION_TEXTURE2D;
                        view.Texture2D.MipLevels = 1;
                    }
                    packet.Owner().context->device->CreateShaderResourceView(nullptr, &view, result.views.Cpu(index));
                }
                auto sampler = ConvertSampler(binding.state);
                packet.Owner().context->device->CreateSampler(&sampler, result.samplers.Cpu(index));
            }
        }

        for (const auto& binding : state.vertices)
        {
            if (binding.buffer->description.Width - binding.offset > UINT32_MAX)
                throw std::overflow_error("Vertex buffer exceeds D3D view range");
            result.vertices[result.vertexCount] = {
                binding.buffer->resource->GetGPUVirtualAddress() + binding.offset,
                static_cast<UINT>(binding.buffer->description.Width - binding.offset), binding.stride};
            result.vertexResources[result.vertexCount++] = binding.buffer;
            packet.RegisterResource(binding.buffer);
        }
        if (command.indexResource != UINT32_MAX)
        {
            auto index = std::static_pointer_cast<BufferResource>(packet.storage->resources[command.indexResource]);
            const uint64_t bytes = command.indexSize == SourceIndexElementSize_SixteenBits ? 2u : 4u;
            if ((uint64_t(command.start) + command.count) * bytes > index->description.Width ||
                index->description.Width > UINT32_MAX)
                throw std::out_of_range("Indexed draw exceeds index buffer");
            result.indexResource = index;
            result.index = {index->resource->GetGPUVirtualAddress(), static_cast<UINT>(index->description.Width),
                            bytes == 2 ? DXGI_FORMAT_R16_UINT : DXGI_FORMAT_R32_UINT};
            packet.RegisterResource(index);
        }
    }
    void RecordDraw(CelesteGraphicsPacket& packet, const void* data, Direct3D12PacketRecordContext& context) noexcept
    {
        const auto& command = *static_cast<const Direct3D12DrawPayload*>(data);
        const auto& draw = packet.drawArena->draws[command.preparedIndex];
        auto* list = context.lease.List();
        for (uint32_t i = 0; i < draw.sampledCount; ++i)
            context.states.TransitionAll(*draw.sampled[i], D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE |
                                                               D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE);
        for (uint32_t i = 0; i < draw.vertexCount; ++i)
            context.states.TransitionAll(*draw.vertexResources[i], D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER);
        if (draw.indexResource)
            context.states.TransitionAll(*draw.indexResource, D3D12_RESOURCE_STATE_INDEX_BUFFER);
        BindTargets(draw.targets, context);
        draw.bindings->BindHeaps(list);
        list->SetGraphicsRootSignature(draw.pipeline->root.Get());
        list->SetPipelineState(draw.pipeline->pipeline.Get());
        list->IASetPrimitiveTopology(draw.pipeline->topology);
        list->RSSetViewports(1, &draw.viewport);
        list->RSSetScissorRects(1, &draw.scissor);
        list->OMSetBlendFactor(draw.dynamic.blendFactor.data());
        list->OMSetStencilRef(draw.dynamic.stencilReference);
        list->SetGraphicsRootConstantBufferView(static_cast<UINT>(RootParameter::VertexConstants), draw.constants[0]);
        list->SetGraphicsRootConstantBufferView(static_cast<UINT>(RootParameter::PixelConstants), draw.constants[1]);
        auto pixelViews = draw.views.gpu;
        pixelViews.ptr += 16ull * draw.views.increment;
        auto pixelSamplers = draw.samplers.gpu;
        pixelSamplers.ptr += 16ull * draw.samplers.increment;
        list->SetGraphicsRootDescriptorTable(static_cast<UINT>(RootParameter::VertexTextures), draw.views.gpu);
        list->SetGraphicsRootDescriptorTable(static_cast<UINT>(RootParameter::PixelTextures), pixelViews);
        list->SetGraphicsRootDescriptorTable(static_cast<UINT>(RootParameter::VertexSamplers), draw.samplers.gpu);
        list->SetGraphicsRootDescriptorTable(static_cast<UINT>(RootParameter::PixelSamplers), pixelSamplers);
        list->IASetVertexBuffers(0, draw.vertexCount, draw.vertices.data());
        if (draw.indexResource)
        {
            list->IASetIndexBuffer(&draw.index);
            list->DrawIndexedInstanced(command.count, command.instances, command.start, command.baseVertex, 0);
        }
        else
            list->DrawInstanced(command.count, command.instances, command.start, 0);
    }
    void AddDraw(CelesteGraphicsPacket& packet, Direct3D12DrawPayload command)
    {
        command.stateIndex = packet.Retain(GetDrawSnapshot(packet));
        packet.AddCommand(command, PrepareDraw, RecordDraw);
    }
} // namespace
namespace Celeste::Graphics::Direct3D12
{
    void Draw(CelesteGraphicsPacket* packet, SourcePrimitiveType primitive, int32_t startVertex, int32_t primitiveCount)
    {
        if (!packet || startVertex < 0)
            throw std::invalid_argument("Invalid draw arguments");
        packet->RequireOpen();
        Direct3D12DrawPayload command;
        command.primitive = primitive;
        command.count = ElementCount(primitive, primitiveCount);
        command.start = startVertex;
        if (command.count)
            AddDraw(*packet, command);
    }
    void DrawIndexed(CelesteGraphicsPacket* packet, SourcePrimitiveType primitive, int32_t baseVertex, int32_t, int32_t,
                     int32_t startIndex, int32_t primitiveCount, int32_t instanceCount, CelesteGraphicsBuffer* indices,
                     SourceIndexElementSize indexSize)
    {
        if (!packet || !indices || indices->device != &packet->Owner() || !indices->index || startIndex < 0 ||
            instanceCount < 0 ||
            (indexSize != SourceIndexElementSize_SixteenBits && indexSize != SourceIndexElementSize_ThirtyTwoBits))
            throw std::invalid_argument("Invalid indexed draw arguments");
        packet->RequireOpen();
        Direct3D12DrawPayload command;
        command.primitive = primitive;
        command.count = ElementCount(primitive, primitiveCount);
        command.start = startIndex;
        command.instances = instanceCount;
        command.baseVertex = baseVertex;
        command.indexSize = indexSize;
        if (command.count && command.instances)
        {
            command.indexResource = packet->Retain(indices->buffer);
            AddDraw(*packet, command);
        }
    }
} // namespace Celeste::Graphics::Direct3D12
