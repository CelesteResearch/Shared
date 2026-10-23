#include "Direct3D12StateApi.h"
#include "Direct3D12DrawContext.h"
#include "CelesteGraphicsPacket.h"
#include "CelesteGraphicsTexture.h"
#include "CelesteGraphicsBuffer.h"
#include "CelesteGraphicsRenderbuffer.h"
#include <stdexcept>
#include <limits>
namespace Celeste::Graphics::Direct3D12
{
    namespace
    {
        Direct3D12DrawState& State(CelesteGraphicsPacket* p)
        {
            if (!p)
                throw std::invalid_argument("Packet is null");
            return GetDrawState(*p);
        }
        template <class T> const T& Required(const T* p)
        {
            if (!p)
                throw std::invalid_argument("State argument is null");
            return *p;
        }
    } // namespace
    void SetViewport(CelesteGraphicsPacket* p, const SourceCameraViewport* value)
    {
        State(p).viewport = Required(value);
    }
    void SetScissorRect(CelesteGraphicsPacket* p, const CelesteGraphicsRect* value)
    {
        State(p).scissor = Required(value);
    }
    void SetBlendState(CelesteGraphicsPacket* p, const SourceNativeBlendState* value)
    {
        State(p).blend = Required(value);
    }
    void SetDepthStencilState(CelesteGraphicsPacket* p, const SourceNativeDepthStencilState* value)
    {
        State(p).depthState = Required(value);
    }
    void SetRasterizerState(CelesteGraphicsPacket* p, const SourceNativeRasterizerState* value)
    {
        State(p).raster = Required(value);
    }
    void SetBlendFactor(CelesteGraphicsPacket* p, uint32_t value)
    {
        State(p).blend.blendFactor = value;
    }
    void SetSampleMask(CelesteGraphicsPacket* p, int32_t value)
    {
        State(p).blend.multiSampleMask = value;
    }
    void SetStencilReference(CelesteGraphicsPacket* p, int32_t value)
    {
        State(p).depthState.referenceStencil = value;
    }
    void GetBlendFactor(CelesteGraphicsDevice* d, uint32_t* value)
    {
        if (!d || !value)
            throw std::invalid_argument("Null blend query");
        *value = GetReadableDrawState(*d)->blend.blendFactor;
    }
    void GetSampleMask(CelesteGraphicsDevice* d, int32_t* value)
    {
        if (!d || !value)
            throw std::invalid_argument("Null sample query");
        *value = GetReadableDrawState(*d)->blend.multiSampleMask;
    }
    void GetStencilReference(CelesteGraphicsDevice* d, int32_t* value)
    {
        if (!d || !value)
            throw std::invalid_argument("Null stencil query");
        *value = GetReadableDrawState(*d)->depthState.referenceStencil;
    }
    void SetSampler(CelesteGraphicsPacket* p, uint32_t slot, uint8_t vertex, CelesteGraphicsTexture* texture,
                    const SourceNativeSamplerState* value)
    {
        auto& state = State(p);
        if (slot >= 16)
            throw std::invalid_argument("Sampler slot outside Source stage");
        if (texture && texture->device != &p->Owner())
            throw std::invalid_argument("Sampler texture belongs to another device");
        auto& target = state.samplers[(vertex ? 16 : 0) + slot];
        target.state = Required(value);
        target.texture = texture ? texture->image : nullptr;
    }
    void SetRenderTargets(CelesteGraphicsPacket* p, const SourceNativeRenderTargetBinding* bindings, int32_t count,
                          CelesteGraphicsRenderbuffer* depth, SourceDepthFormat format, uint8_t)
    {
        auto& state = State(p);
        if (count < 0 || count > 4 || (count && !bindings))
            throw std::invalid_argument("Invalid Source render targets");
        if (depth && (depth->device != &p->Owner() || !depth->depth))
            throw std::invalid_argument("Invalid depth target owner or kind");
        std::vector<Direct3D12TargetBinding> targets;
        targets.reserve(count);
        for (int32_t i = 0; i < count; ++i)
        {
            auto* texture = static_cast<CelesteGraphicsTexture*>(bindings[i].texture);
            auto* color = static_cast<CelesteGraphicsRenderbuffer*>(bindings[i].colorBuffer);
            if (!texture || texture->device != &p->Owner() ||
                (color && (color->device != &p->Owner() || !color->color)))
                throw std::invalid_argument("Invalid color target owner or kind");
            auto image = color ? color->color : texture->image;
            if (bindings[i].type > 1)
                throw std::invalid_argument("Invalid render target dimension tag");
            const uint32_t requestedLayer = bindings[i].type == 1 ? static_cast<uint32_t>(bindings[i].data2) : 0;
            texture->image->Subresource(0, requestedLayer);
            // MSAA color storage is a 2D renderbuffer; the cube face belongs to its resolve destination.
            const uint32_t layer = image->info.dimension == CelesteGraphicsTextureCube ? requestedLayer : 0;
            image->Subresource(0, layer);
            targets.push_back({std::move(image), layer});
        }
        state.usesBackbuffer = count == 0;
        state.targets = std::move(targets);
        state.depth = depth ? depth->depth : nullptr;
        state.depthFormat = format;
    }
    void SetVertexBindings(CelesteGraphicsPacket* p, const SourceNativeVertexBufferBinding* values, int32_t count,
                           uint8_t, int32_t)
    {
        auto& state = State(p);
        if (count < 0 || count > 32 || (count && !values))
            throw std::invalid_argument("Invalid vertex bindings");
        std::vector<Direct3D12VertexBinding> result;
        result.reserve(count);
        for (int32_t i = 0; i < count; ++i)
        {
            const auto& source = values[i];
            const auto& decl = source.vertexDeclaration;
            auto* handle = static_cast<CelesteGraphicsBuffer*>(source.vertexBuffer);
            if (!handle || handle->device != &p->Owner() || handle->index || decl.vertexStride < 0 ||
                decl.elementCount < 0 || (decl.elementCount && !decl.elements) || source.vertexOffset < 0 ||
                source.instanceFrequency < 0)
                throw std::invalid_argument("Invalid vertex buffer or declaration");
            const auto offset = uint64_t(source.vertexOffset) * uint32_t(decl.vertexStride);
            if (offset > handle->buffer->description.Width || offset > UINT32_MAX)
                throw std::out_of_range("Vertex buffer offset exceeds resource");
            Direct3D12VertexBinding target;
            target.buffer = handle->buffer;
            target.stride = decl.vertexStride;
            target.offset = static_cast<uint32_t>(offset);
            target.frequency = source.instanceFrequency;
            if (decl.elementCount)
                target.elements.assign(decl.elements, decl.elements + decl.elementCount);
            result.push_back(std::move(target));
        }
        auto input = std::make_shared<InputLayout>(ConvertInputLayout(values, count));
        state.vertices = std::move(result);
        state.input = std::move(input);
    }
} // namespace Celeste::Graphics::Direct3D12
