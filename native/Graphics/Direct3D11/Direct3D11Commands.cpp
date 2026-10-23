#include "Direct3D11Commands.h"
#include "Direct3D11ImmutableStateCache.h"
#include "Direct3D11SamplerReplay.h"
#include <cstring>
#include <array>
#include <string>

struct Direct3D11PhysicalVertexBindings
{
    std::vector<std::shared_ptr<ID3D11Buffer>> buffers;
    std::vector<ID3D11Buffer*> rawBuffers;
    std::vector<uint32_t> strides, offsets;
    std::vector<D3D11_INPUT_ELEMENT_DESC> elements;
    std::vector<std::string> semantics;
    uint64_t hash;
    Direct3D11PhysicalVertexBindings() = default;
    // Main-thread clones copy immutable bindings only, never render-thread cache state.
    Direct3D11PhysicalVertexBindings(const Direct3D11PhysicalVertexBindings& other)
        : buffers(other.buffers), rawBuffers(other.rawBuffers), strides(other.strides), offsets(other.offsets),
          elements(other.elements), semantics(other.semantics), hash(other.hash)
    {
    }
    // Render-thread cache only. Weak ownership cannot extend a shader past device shutdown.
    MOJOSHADER_d3d11Shader* layoutVertex = nullptr;
    uint64_t layoutGeneration = 0, layoutHash = 0;
    std::weak_ptr<ID3D11InputLayout> resolvedLayout;
};

template <class T> static std::shared_ptr<T> Retain(T* object)
{
    if (object)
        object->AddRef();
    return std::shared_ptr<T>(object, [](T* value) {
        if (value)
            value->Release();
    });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateBuffer(Direct3D11Device* device, const D3D11_BUFFER_DESC* description,
                                                    const void* bytes, ID3D11Buffer** result)
{
    if (!SourceRequireDevice(device) || !description || !result)
        return 0;
    D3D11_SUBRESOURCE_DATA data = {};
    data.pSysMem = bytes;
    HRESULT status = device->device->CreateBuffer(description, bytes ? &data : nullptr, result);
    if (FAILED(status))
    {
        SourceSetError("D3D11 CreateBuffer failed");
        return 0;
    }
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateTexture2D(Direct3D11Device* device,
                                                       const D3D11_TEXTURE2D_DESC* description,
                                                       ID3D11Texture2D** result)
{
    if (!SourceRequireDevice(device) || !description || !result)
        return 0;
    HRESULT status = device->device->CreateTexture2D(description, nullptr, result);
    if (FAILED(status))
    {
        SourceSetError("D3D11 CreateTexture2D failed");
        return 0;
    }
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateRenderTargetView(Direct3D11Device* device, ID3D11Resource* texture,
                                                              const D3D11_RENDER_TARGET_VIEW_DESC* description,
                                                              ID3D11RenderTargetView** result)
{
    if (!SourceRequireDevice(device))
        return 0;
    HRESULT status = device->device->CreateRenderTargetView(texture, description, result);
    if (FAILED(status))
    {
        SourceSetError("D3D11 CreateRenderTargetView failed");
        return 0;
    }
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateShaderResourceView(Direct3D11Device* device, ID3D11Resource* texture,
                                                                const D3D11_SHADER_RESOURCE_VIEW_DESC* description,
                                                                ID3D11ShaderResourceView** result)
{
    if (!SourceRequireDevice(device))
        return 0;
    HRESULT status = device->device->CreateShaderResourceView(texture, description, result);
    if (FAILED(status))
    {
        SourceSetError("D3D11 CreateShaderResourceView failed");
        return 0;
    }
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordBufferWrite(Direct3D11Device* device, ID3D11Buffer* buffer,
                                                         const void* bytes, uint32_t count, uint32_t offset,
                                                         D3D11_MAP mapping)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto retained = Retain(buffer);
    auto copy = std::make_shared<std::vector<uint8_t>>(static_cast<const uint8_t*>(bytes),
                                                       static_cast<const uint8_t*>(bytes) + count);
    return SourceAppendPhysical(device, [device, retained, copy, offset, mapping]() {
        if (mapping == D3D11_MAP_WRITE_DISCARD || mapping == D3D11_MAP_WRITE_NO_OVERWRITE)
        {
            D3D11_MAPPED_SUBRESOURCE mapped = {};
            HRESULT status = device->context->Map(retained.get(), 0, mapping, 0, &mapped);
            if (FAILED(status))
            {
                SourceSetError("D3D11 buffer Map failed");
                return;
            }
            std::memcpy(static_cast<uint8_t*>(mapped.pData) + offset, copy->data(), copy->size());
            device->context->Unmap(retained.get(), 0);
        }
        else
        {
            D3D11_BOX box = {offset, 0, 0, offset + static_cast<UINT>(copy->size()), 1, 1};
            device->context->UpdateSubresource(retained.get(), 0, &box, copy->data(), 0, 0);
        }
    });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordTextureWrite(Direct3D11Device* device, ID3D11Resource* texture,
                                                          uint32_t subresource, const D3D11_BOX* box, const void* bytes,
                                                          uint32_t count, uint32_t rowPitch, uint32_t depthPitch)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto retained = Retain(texture);
    auto copy = std::make_shared<std::vector<uint8_t>>(static_cast<const uint8_t*>(bytes),
                                                       static_cast<const uint8_t*>(bytes) + count);
    bool bounded = box != nullptr;
    D3D11_BOX copiedBox = bounded ? *box : D3D11_BOX{};
    return SourceAppendPhysical(
        device, [device, retained, copy, subresource, bounded, copiedBox, rowPitch, depthPitch]() {
            device->context->UpdateSubresource(retained.get(), subresource, bounded ? &copiedBox : nullptr,
                                               copy->data(), rowPitch, depthPitch);
        });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordVertexBufferWrite(Direct3D11Device* device, ID3D11Buffer* buffer,
                                                               uint32_t offset, const void* bytes,
                                                               uint32_t elementCount, uint32_t elementSize,
                                                               uint32_t vertexStride, D3D11_MAP mapping)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto retained = Retain(buffer);
    auto start = static_cast<const uint8_t*>(bytes);
    auto copy = std::make_shared<std::vector<uint8_t>>(start, start + static_cast<size_t>(elementCount) * elementSize);
    return SourceAppendPhysical(
        device, [device, retained, copy, offset, elementCount, elementSize, vertexStride, mapping]() {
            if (mapping == D3D11_MAP_WRITE_DISCARD || mapping == D3D11_MAP_WRITE_NO_OVERWRITE)
            {
                D3D11_MAPPED_SUBRESOURCE mapped = {};
                if (FAILED(device->context->Map(retained.get(), 0, mapping, 0, &mapped)))
                {
                    SourceSetError("D3D11 strided vertex buffer Map failed");
                    return;
                }
                auto target = static_cast<uint8_t*>(mapped.pData) + offset;
                if (elementSize == vertexStride)
                {
                    if (!copy->empty())
                        std::memcpy(target, copy->data(), copy->size());
                }
                else
                {
                    for (uint32_t i = 0; i < elementCount; ++i)
                        std::memcpy(target + static_cast<size_t>(i) * vertexStride,
                                    copy->data() + static_cast<size_t>(i) * elementSize, elementSize);
                }
                device->context->Unmap(retained.get(), 0);
            }
            else if (elementSize == vertexStride)
            {
                if (elementCount)
                {
                    D3D11_BOX box = {offset, 0, 0, offset + elementCount * elementSize, 1, 1};
                    device->context->UpdateSubresource(retained.get(), 0, &box, copy->data(), 0, 0);
                }
            }
            else
            {
                // Update only each source element; intervening vertex fields retain
                // their previous bytes, rather than being zero-filled on the host.
                for (uint32_t i = 0; i < elementCount; ++i)
                {
                    UINT begin = offset + i * vertexStride;
                    D3D11_BOX box = {begin, 0, 0, begin + elementSize, 1, 1};
                    device->context->UpdateSubresource(retained.get(), 0, &box,
                                                       copy->data() + static_cast<size_t>(i) * elementSize, 0, 0);
                }
            }
        });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordViewport(Direct3D11Device* device, const D3D11_VIEWPORT* viewport)
{
    if (!SourceRequireDevice(device) || !viewport)
        return 0;
    auto copied = *viewport;
    return SourceAppendPhysical(device, [device, copied]() { device->context->RSSetViewports(1, &copied); });
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordScissor(Direct3D11Device* device, const D3D11_RECT* rectangle)
{
    if (!SourceRequireDevice(device) || !rectangle)
        return 0;
    auto copied = *rectangle;
    return SourceAppendPhysical(device, [device, copied]() { device->context->RSSetScissorRects(1, &copied); });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordBlend(Direct3D11Device* device, const D3D11_BLEND_DESC* description,
                                                   const float* factor, uint32_t mask)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto retained = SourceBorrowBlendState(device, description);
    if (!retained)
        return 0;
    std::array<float, 4> copy;
    std::memcpy(copy.data(), factor, sizeof(float) * 4);
    return SourceAppendPhysical(device, [device, retained, copy, mask]() {
        device->context->OMSetBlendState(retained.get(), copy.data(), mask);
    });
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordDepthStencil(Direct3D11Device* device,
                                                          const D3D11_DEPTH_STENCIL_DESC* description, uint32_t stencil)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto retained = SourceBorrowDepthStencilState(device, description);
    if (!retained)
        return 0;
    return SourceAppendPhysical(
        device, [device, retained, stencil]() { device->context->OMSetDepthStencilState(retained.get(), stencil); });
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordRasterizer(Direct3D11Device* device,
                                                        const D3D11_RASTERIZER_DESC* description)
{
    if (!SourceRequirePhysicalScope(device) || !SourceRequireDevice(device))
        return 0;
    auto retained = SourceBorrowRasterizerState(device, description);
    if (!retained)
        return 0;
    return SourceAppendPhysicalRasterizer(device, std::move(retained));
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSampler(Direct3D11Device* device, uint32_t index,
                                                     ID3D11ShaderResourceView* texture,
                                                     const D3D11_SAMPLER_DESC* description, int vertex)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto sampler = SourceBorrowSamplerState(device, description, "D3D11 CreateSamplerState failed");
    if (!sampler)
        return 0;
    auto resource = Retain(texture);
    return SourceAppendPhysical(device, [device, index, sampler, resource, vertex]() {
        auto state = sampler.get();
        auto view = resource.get();
        if (vertex)
        {
            device->context->VSSetSamplers(index, 1, &state);
            device->context->VSSetShaderResources(index, 1, &view);
        }
        else
        {
            device->context->PSSetSamplers(index, 1, &state);
            device->context->PSSetShaderResources(index, 1, &view);
        }
    });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordTargets(Direct3D11Device* device, ID3D11RenderTargetView* const* targets,
                                                     uint32_t count, ID3D11DepthStencilView* depth)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto views = std::make_shared<std::vector<std::shared_ptr<ID3D11RenderTargetView>>>();
    for (uint32_t i = 0; i < count; ++i)
        views->push_back(Retain(targets[i]));
    auto depthView = Retain(depth);
    return SourceAppendPhysical(device, [device, views, depthView]() {
        std::vector<ID3D11RenderTargetView*> raw;
        raw.reserve(views->size());
        for (const auto& view : *views)
            raw.push_back(view.get());
        device->context->OMSetRenderTargets(static_cast<UINT>(raw.size()), raw.data(), depthView.get());
    });
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordClearTarget(Direct3D11Device* device, ID3D11RenderTargetView* target,
                                                         const float* color)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto retained = Retain(target);
    std::array<float, 4> copied;
    std::memcpy(copied.data(), color, sizeof(float) * 4);
    return SourceAppendPhysical(device, [device, retained, copied]() {
        device->context->ClearRenderTargetView(retained.get(), copied.data());
    });
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordClearDepth(Direct3D11Device* device, ID3D11DepthStencilView* target,
                                                        uint32_t flags, float depth, uint8_t stencil)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto retained = Retain(target);
    return SourceAppendPhysical(device, [device, retained, flags, depth, stencil]() {
        device->context->ClearDepthStencilView(retained.get(), flags, depth, stencil);
    });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordVertexBuffer(Direct3D11Device* device, uint32_t slot, ID3D11Buffer* buffer,
                                                          uint32_t stride, uint32_t offset)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto retained = Retain(buffer);
    if (!SourceAppendPhysical(device, [device, slot, retained, stride, offset]() {
            auto buffer = retained.get();
            device->context->IASetVertexBuffers(slot, 1, &buffer, &stride, &offset);
        }))
        return 0;
    SourceInvalidatePhysicalInputBindings(device, true, false);
    return 1;
}
template <class T> struct Direct3D11PhysicalComLease
{
    T* object;
    explicit Direct3D11PhysicalComLease(T* value) : object(value)
    {
        if (object)
            object->AddRef();
    }
    Direct3D11PhysicalComLease(const Direct3D11PhysicalComLease& other) : Direct3D11PhysicalComLease(other.object)
    {
    }
    Direct3D11PhysicalComLease(Direct3D11PhysicalComLease&& other) noexcept : object(other.object)
    {
        other.object = nullptr;
    }
    ~Direct3D11PhysicalComLease()
    {
        if (object)
            object->Release();
    }
    T* get() const noexcept
    {
        return object;
    }
};
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordIndexBuffer(Direct3D11Device* device, ID3D11Buffer* buffer,
                                                         DXGI_FORMAT format, uint32_t offset)
{
    if (!SourceRequireDevice(device))
        return 0;
    Direct3D11PhysicalComLease<ID3D11Buffer> retained(buffer);
    auto packet = SourceCurrentPhysicalPacket();
    if (packet)
    {
        std::lock_guard<std::recursive_mutex> lock(packet->device->physicalLock);
        if (packet->device == device && packet->hasIndexBinding && packet->lastIndexBuffer == buffer &&
            packet->lastIndexFormat == format && packet->lastIndexOffset == offset)
            return SourceCanAppendPhysicalPacketLocked(device) ? 1 : 0;
        if (!SourceAppendPhysical(device, [device, retained = std::move(retained), format, offset]() {
                device->context->IASetIndexBuffer(retained.get(), format, offset);
            }))
            return 0;
        if (packet->device == device)
        {
            packet->lastIndexBuffer = buffer;
            packet->lastIndexFormat = format;
            packet->lastIndexOffset = offset;
            packet->hasIndexBinding = true;
        }
        else
            packet->hasIndexBinding = false;
        return 1;
    }
    return SourceAppendPhysical(device, [device, retained = std::move(retained), format, offset]() {
        device->context->IASetIndexBuffer(retained.get(), format, offset);
    });
}

// Arguments are resolved by SourceGraphicsDevice. Conversion retains its exact
// declaration and shader pair; there is no alternate CPU colored mesh.
struct Direct3D11DrawShaderLease
{
    Direct3D11Device* device;
    MOJOSHADER_d3d11Shader* vertex;
    MOJOSHADER_d3d11Shader* pixel;
    Direct3D11DrawShaderLease(Direct3D11Device* d, MOJOSHADER_d3d11Shader* v, MOJOSHADER_d3d11Shader* p)
        : device(d), vertex(v), pixel(p)
    {
        MOJOSHADER_d3d11ShaderAddRef(vertex);
        MOJOSHADER_d3d11ShaderAddRef(pixel);
    }
    Direct3D11DrawShaderLease(const Direct3D11DrawShaderLease& other)
        : Direct3D11DrawShaderLease(other.device, other.vertex, other.pixel)
    {
    }
    Direct3D11DrawShaderLease(Direct3D11DrawShaderLease&& other) noexcept
        : device(other.device), vertex(other.vertex), pixel(other.pixel)
    {
        other.device = nullptr;
    }
    ~Direct3D11DrawShaderLease()
    {
        if (device && device->shaders)
        {
            MOJOSHADER_d3d11DeleteShader(device->shaders, vertex);
            MOJOSHADER_d3d11DeleteShader(device->shaders, pixel);
        }
    }
};
struct Direct3D11DrawInput
{
    D3D11_INPUT_ELEMENT_DESC description;
    std::string semantic;
};
struct Direct3D11DrawReplay
{
    std::shared_ptr<std::vector<Direct3D11DrawInput>> inputs;
    std::shared_ptr<Direct3D11PhysicalVertexBindings> inputOwner, bindingSnapshot;
    uint32_t elementCount;
    uint64_t inputHash;
    Direct3D11DrawShaderLease shaders;
    Direct3D11DrawReplay(Direct3D11Device* device, std::shared_ptr<std::vector<Direct3D11DrawInput>>&& i,
                         const std::shared_ptr<Direct3D11PhysicalVertexBindings>& owner,
                         const std::shared_ptr<Direct3D11PhysicalVertexBindings>& binding, uint32_t n, uint64_t hash,
                         MOJOSHADER_d3d11Shader* vertex, MOJOSHADER_d3d11Shader* pixel)
        : inputs(std::move(i)), inputOwner(owner), bindingSnapshot(binding), elementCount(n), inputHash(hash),
          shaders(device, vertex, pixel)
    {
    }
};
static bool SourceCaptureDrawReplay(Direct3D11Device* device, const D3D11_INPUT_ELEMENT_DESC* elements,
                                    uint32_t elementCount, uint64_t inputHash,
                                    const std::shared_ptr<Direct3D11PhysicalVertexBindings>& inputOwner,
                                    std::optional<Direct3D11DrawReplay>& result,
                                    const Direct3D11DrawReplay* reusable = nullptr)
{
    if (!SourceRequirePhysicalScope(device) || !SourceRequireDevice(device))
        return false;
    std::shared_ptr<std::vector<Direct3D11DrawInput>> inputs;
    if (!inputOwner)
    {
        inputs = std::make_shared<std::vector<Direct3D11DrawInput>>();
        inputs->reserve(elementCount);
        for (uint32_t i = 0; i < elementCount; ++i)
            inputs->push_back({elements[i], elements[i].SemanticName});
    }
    MOJOSHADER_d3d11Shader *vertex, *pixel;
    MOJOSHADER_d3d11GetBoundShaders(device->shaders, &vertex, &pixel);
    if (!vertex || !pixel)
    {
        SourceSetError("Draw has no actual vertex/pixel shader pair");
        return false;
    }
    auto bindingSnapshot = device->vertexBindings;
    if (reusable && inputOwner && reusable->inputOwner == inputOwner && reusable->bindingSnapshot == bindingSnapshot &&
        reusable->elementCount == elementCount && reusable->inputHash == inputHash &&
        reusable->shaders.vertex == vertex && reusable->shaders.pixel == pixel)
    {
        result.reset();
        return true;
    }
    result.emplace(device, std::move(inputs), inputOwner, bindingSnapshot, elementCount, inputHash, vertex, pixel);
    return true;
}
static void SourceReplayDraw(Direct3D11Device* device, const Direct3D11DrawReplay& snapshot,
                             D3D11_PRIMITIVE_TOPOLOGY topology, uint32_t count, uint32_t start, int32_t baseVertex,
                             uint32_t instances, int indexed)
{
    const auto& inputs = snapshot.inputs;
    const auto& inputOwner = snapshot.inputOwner;
    const auto& bindingSnapshot = snapshot.bindingSnapshot;
    auto elementCount = snapshot.elementCount;
    auto inputHash = snapshot.inputHash;
    auto vertex = snapshot.shaders.vertex;
    auto pixel = snapshot.shaders.pixel;
    MOJOSHADER_d3d11Shader *oldVertex, *oldPixel;
    MOJOSHADER_d3d11GetBoundShaders(device->shaders, &oldVertex, &oldPixel);
    MOJOSHADER_d3d11BindShaders(device->shaders, vertex, pixel);
    bool cacheEligible = inputOwner && inputOwner == bindingSnapshot;
    std::shared_ptr<ID3D11InputLayout> resolved;
    if (cacheEligible && inputOwner->layoutVertex == vertex && inputOwner->layoutGeneration == device->generation &&
        inputOwner->layoutHash == inputHash)
        resolved = inputOwner->resolvedLayout.lock();
    if (!resolved)
    {
        std::vector<D3D11_INPUT_ELEMENT_DESC> descriptions;
        descriptions.reserve(elementCount);
        // FNA3D's actual usage collision and Mojo attribute-location sequence.
        // Descriptors supplied by managed IO are format/slot/offset conversions;
        // only this same physical shader backend decides which inputs are used.
        static const char* names[] = {"POSITION", "COLOR",          "TEXCOORD",    "NORMAL",   "BINORMAL",
                                      "TANGENT",  "BLENDINDICES",   "BLENDWEIGHT", "SV_DEPTH", "FOG",
                                      "PSIZE",    "SV_SampleIndex", "TESSFACTOR"};
        static const MOJOSHADER_usage usages[] = {
            MOJOSHADER_USAGE_POSITION,     MOJOSHADER_USAGE_COLOR,       MOJOSHADER_USAGE_TEXCOORD,
            MOJOSHADER_USAGE_NORMAL,       MOJOSHADER_USAGE_BINORMAL,    MOJOSHADER_USAGE_TANGENT,
            MOJOSHADER_USAGE_BLENDINDICES, MOJOSHADER_USAGE_BLENDWEIGHT, MOJOSHADER_USAGE_POSITION,
            MOJOSHADER_USAGE_FOG,          MOJOSHADER_USAGE_POINTSIZE,   MOJOSHADER_USAGE_SAMPLE,
            MOJOSHADER_USAGE_TESSFACTOR};
        bool used[13][16] = {};
        std::array<D3D11_INPUT_ELEMENT_DESC, 208> ordered = {};
        uint32_t active = 0;
        for (uint32_t inputIndex = 0; inputIndex < elementCount; ++inputIndex)
        {
            auto description = inputOwner ? inputOwner->elements[inputIndex] : (*inputs)[inputIndex].description;
            const char* semantic = inputOwner ? description.SemanticName : (*inputs)[inputIndex].semantic.c_str();
            int usage = -1;
            for (int i = 0; i < 13; ++i)
                if (std::strcmp(semantic, names[i]) == 0)
                {
                    usage = i;
                    break;
                }
            if (usage < 0 || description.SemanticIndex >= 16)
            {
                SourceBackendLogError("Unrecognized VertexElementUsage!");
                MOJOSHADER_d3d11BindShaders(device->shaders, oldVertex, oldPixel);
                return;
            }
            uint32_t index = description.SemanticIndex;
            if (used[usage][index])
            {
                int available = -1;
                for (int i = 0; i < 16; ++i)
                    if (!used[usage][i])
                    {
                        available = i;
                        break;
                    }
                if (available < 0)
                {
                    SourceBackendLogError("Vertex usage collision!");
                    MOJOSHADER_d3d11BindShaders(device->shaders, oldVertex, oldPixel);
                    return;
                }
                index = static_cast<uint32_t>(available);
            }
            used[usage][index] = true;
            if (usage == 8)
            {
                SourceBackendLogError("Unrecognized VertexElementUsage!");
                cacheEligible = false;
            }
            int location = MOJOSHADER_d3d11GetVertexAttribLocation(vertex, usages[usage], index);
            if (location == -1)
                continue;
            description.SemanticName = names[usage];
            description.SemanticIndex = index;
            ordered[location] = description;
            ++active;
        }
        descriptions.assign(ordered.begin(), ordered.begin() + active);
        // Serialize every layout field, not descriptor pointers/padding or a hash alone.
        std::string key;
        auto append = [&](const auto& value) { key.append(reinterpret_cast<const char*>(&value), sizeof(value)); };
        auto shaderIdentity = reinterpret_cast<uintptr_t>(vertex);
        append(shaderIdentity);
        append(inputHash);
        auto descriptorCount = static_cast<uint32_t>(descriptions.size());
        append(descriptorCount);
        for (const auto& element : descriptions)
        {
            key.append(element.SemanticName);
            key.push_back('\0');
            append(element.SemanticIndex);
            append(element.Format);
            append(element.InputSlot);
            append(element.AlignedByteOffset);
            append(element.InputSlotClass);
            append(element.InstanceDataStepRate);
        }
        auto streamCount = bindingSnapshot ? static_cast<uint32_t>(bindingSnapshot->strides.size()) : 0u;
        append(streamCount);
        if (bindingSnapshot)
            for (uint32_t i = 0; i < streamCount; ++i)
            {
                append(bindingSnapshot->strides[i]);
            }
        auto cached = device->inputLayouts.find(key);
        if (cached == device->inputLayouts.end())
        {
            void* bytecode;
            int bytecodeLength;
            if (MOJOSHADER_d3d11CompileVertexShader(device->shaders, inputHash, descriptions.data(),
                                                    static_cast<int>(descriptions.size()), &bytecode, &bytecodeLength))
            {
                SourceSetError(MOJOSHADER_d3d11GetError(device->shaders));
                MOJOSHADER_d3d11BindShaders(device->shaders, oldVertex, oldPixel);
                return;
            }
            ID3D11InputLayout* created = nullptr;
            HRESULT status =
                device->device->CreateInputLayout(descriptions.data(), static_cast<UINT>(descriptions.size()), bytecode,
                                                  static_cast<SIZE_T>(bytecodeLength), &created);
            if (FAILED(status))
            {
                SourceSetError("D3D11 CreateInputLayout failed");
                MOJOSHADER_d3d11BindShaders(device->shaders, oldVertex, oldPixel);
                return;
            }
            auto layout =
                std::shared_ptr<ID3D11InputLayout>(created, [](ID3D11InputLayout* value) { value->Release(); });
            MOJOSHADER_d3d11ShaderAddRef(vertex);
            auto shader = std::shared_ptr<void>(
                vertex, [device, vertex](void*) { MOJOSHADER_d3d11DeleteShader(device->shaders, vertex); });
            cached = device->inputLayouts.emplace(std::move(key), std::make_pair(std::move(layout), std::move(shader)))
                         .first;
        }
        resolved = cached->second.first;
    }
    auto layout = resolved.get();
    if (MOJOSHADER_d3d11ProgramReady(device->shaders, inputHash))
    {
        SourceSetError(MOJOSHADER_d3d11GetError(device->shaders));
        MOJOSHADER_d3d11BindShaders(device->shaders, oldVertex, oldPixel);
        return;
    }
    if (cacheEligible)
    {
        inputOwner->layoutVertex = vertex;
        inputOwner->layoutGeneration = device->generation;
        inputOwner->layoutHash = inputHash;
        inputOwner->resolvedLayout = resolved;
    }
    device->context->IASetInputLayout(layout);
    device->context->IASetPrimitiveTopology(topology);
    if (indexed)
    {
        if (instances > 1)
            device->context->DrawIndexedInstanced(count, instances, start, baseVertex, 0);
        else
            device->context->DrawIndexed(count, start, baseVertex);
    }
    else
    {
        if (instances > 1)
            device->context->DrawInstanced(count, instances, start, 0);
        else
            device->context->Draw(count, start);
    }
    MOJOSHADER_d3d11BindShaders(device->shaders, oldVertex, oldPixel);
}
static int SourceRecordDraw(Direct3D11Device* device, const D3D11_INPUT_ELEMENT_DESC* elements, uint32_t elementCount,
                            uint64_t inputHash, D3D11_PRIMITIVE_TOPOLOGY topology, uint32_t count, uint32_t start,
                            int32_t baseVertex, uint32_t instances, int indexed,
                            const std::shared_ptr<Direct3D11PhysicalVertexBindings>& inputOwner,
                            bool physicalLockHeld = false)
{
    std::optional<Direct3D11DrawReplay> snapshot;
    if (!SourceCaptureDrawReplay(device, elements, elementCount, inputHash, inputOwner, snapshot))
        return 0;
    auto write = [device, snapshot = std::move(*snapshot), topology, count, start, baseVertex, instances, indexed]() {
        SourceReplayDraw(device, snapshot, topology, count, start, baseVertex, instances, indexed);
    };
    if (physicalLockHeld)
        return SourceAppendPhysicalDeviceLocked(device, std::move(write));
    return SourceAppendPhysical(device, std::move(write));
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordDraw(Direct3D11Device* device, const D3D11_INPUT_ELEMENT_DESC* elements,
                                                  uint32_t elementCount, uint64_t inputHash,
                                                  D3D11_PRIMITIVE_TOPOLOGY topology, uint32_t count, uint32_t start,
                                                  int32_t baseVertex, uint32_t instances, int indexed)
{
    return SourceRecordDraw(device, elements, elementCount, inputHash, topology, count, start, baseVertex, instances,
                            indexed, {});
}

SOURCE_GPU_EXPORT void __cdecl SourceGpuReleaseResource(IUnknown* resource)
{
    if (resource)
        resource->Release();
}

static int SourceAppendVertexBindings(Direct3D11Device* device,
                                      const std::shared_ptr<Direct3D11PhysicalVertexBindings>& snapshot)
{
    auto packet = SourceCurrentPhysicalPacket();
    if (packet && packet->device == device && packet->lastVertexBindings == snapshot.get())
        return SourceCanAppendPhysicalPacketLocked(device) ? 1 : 0;
    if (!SourceAppendPhysicalDeviceLocked(device, [device, snapshot]() {
            device->context->IASetVertexBuffers(0, static_cast<UINT>(snapshot->rawBuffers.size()),
                                                snapshot->rawBuffers.data(), snapshot->strides.data(),
                                                snapshot->offsets.data());
        }))
        return 0;
    SourceInvalidatePhysicalInputBindings(device, true, false);
    if (packet && packet->device == device)
        packet->lastVertexBindings = snapshot.get();
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuSetVertexBindings(Direct3D11Device* device,
                                                         const SourceGpuVertexBinding* bindings, uint32_t bindingCount,
                                                         const D3D11_INPUT_ELEMENT_DESC* elements,
                                                         uint32_t elementCount, uint64_t hash)
{
    if (!SourceRequirePhysicalScope(device) || !SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto snapshot = std::make_shared<Direct3D11PhysicalVertexBindings>();
    snapshot->hash = hash;
    snapshot->semantics.reserve(elementCount);
    snapshot->elements.reserve(elementCount);
    for (uint32_t i = 0; i < bindingCount; ++i)
    {
        snapshot->buffers.push_back(Retain(bindings[i].buffer));
        snapshot->rawBuffers.push_back(bindings[i].buffer);
        snapshot->strides.push_back(bindings[i].stride);
        snapshot->offsets.push_back(bindings[i].offset);
    }
    for (uint32_t i = 0; i < elementCount; ++i)
    {
        snapshot->semantics.emplace_back(elements[i].SemanticName);
        snapshot->elements.push_back(elements[i]);
        snapshot->elements.back().SemanticName = snapshot->semantics.back().c_str();
    }
    if (!SourceAppendVertexBindings(device, snapshot))
        return 0;
    device->vertexBindings = snapshot;
    return 1;
}

// A source unchanged-binding call reuses its immutable declaration, but still
// records IA bindings: prior packets may have been discarded or the host may draw.
SOURCE_GPU_EXPORT int __cdecl SourceGpuTryReuseVertexBindings(Direct3D11Device* device, uint32_t* ownsScope,
                                                              uint32_t* reused)
{
    if (!ownsScope || !reused)
        return 0;
    *ownsScope = 0;
    *reused = 0;
    if (!SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto snapshot = device->vertexBindings;
    if (!snapshot)
        return 1;
    if (!SourceBorrowOrBeginPhysicalPacketLocked(device, ownsScope))
        return 0;
    if (!SourceAppendVertexBindings(device, snapshot))
        return 0;
    *reused = 1;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordBoundDraw(Direct3D11Device* device, D3D11_PRIMITIVE_TOPOLOGY topology,
                                                       uint32_t count, uint32_t start, int32_t baseVertex,
                                                       uint32_t instances, int indexed)
{
    if (!SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto bindings = device->vertexBindings;
    if (!bindings)
    {
        SourceSetError("Draw requires actual physical vertex bindings");
        return 0;
    }
    return SourceRecordDraw(device, bindings->elements.data(), static_cast<uint32_t>(bindings->elements.size()),
                            bindings->hash, topology, count, start, baseVertex, instances, indexed, bindings, true);
}

static std::array<float, 4> BlendFloats(uint32_t packed)
{
    return {static_cast<float>(packed & 255) / 255.0f, static_cast<float>((packed >> 8) & 255) / 255.0f,
            static_cast<float>((packed >> 16) & 255) / 255.0f, static_cast<float>((packed >> 24) & 255) / 255.0f};
}
SOURCE_GPU_EXPORT uint32_t __cdecl SourceGpuGetBlendFactor(Direct3D11Device* device)
{
    return device->physicalBlendFactor;
}
SOURCE_GPU_EXPORT int32_t __cdecl SourceGpuGetSampleMask(Direct3D11Device* device)
{
    return device->physicalSampleMask;
}
SOURCE_GPU_EXPORT int32_t __cdecl SourceGpuGetStencilReference(Direct3D11Device* device)
{
    return device->physicalStencilReference;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordBlendFactor(Direct3D11Device* device, uint32_t packed)
{
    if (!SourceRequireDevice(device))
        return 0;
    if (device->physicalBlendFactor == packed)
        return 1;
    auto factor = BlendFloats(packed);
    auto mask = device->physicalSampleMask;
    if (!SourceAppendPhysical(device, [device, factor, mask]() {
            ID3D11BlendState* state = nullptr;
            float previous[4];
            UINT previousMask;
            device->context->OMGetBlendState(&state, previous, &previousMask);
            device->context->OMSetBlendState(state, factor.data(), static_cast<UINT>(mask));
            if (state)
                state->Release();
        }))
        return 0;
    device->physicalBlendFactor = packed;
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSampleMask(Direct3D11Device* device, int32_t mask)
{
    if (!SourceRequireDevice(device))
        return 0;
    if (device->physicalSampleMask == mask)
        return 1;
    auto factor = BlendFloats(device->physicalBlendFactor);
    if (!SourceAppendPhysical(device, [device, factor, mask]() {
            ID3D11BlendState* state = nullptr;
            float previous[4];
            UINT previousMask;
            device->context->OMGetBlendState(&state, previous, &previousMask);
            device->context->OMSetBlendState(state, factor.data(), static_cast<UINT>(mask));
            if (state)
                state->Release();
        }))
        return 0;
    device->physicalSampleMask = mask;
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordStencilReference(Direct3D11Device* device, int32_t reference)
{
    if (!SourceRequireDevice(device))
        return 0;
    if (device->physicalStencilReference == reference)
        return 1;
    if (!SourceAppendPhysical(device, [device, reference]() {
            ID3D11DepthStencilState* state = nullptr;
            UINT previous;
            device->context->OMGetDepthStencilState(&state, &previous);
            device->context->OMSetDepthStencilState(state, static_cast<UINT>(reference));
            if (state)
                state->Release();
        }))
        return 0;
    device->physicalStencilReference = reference;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceBlend(Direct3D11Device* device, const D3D11_BLEND_DESC* description,
                                                         uint32_t packed, int32_t mask)
{
    auto factor = BlendFloats(packed);
    if (!SourceGpuRecordBlend(device, description, factor.data(), static_cast<uint32_t>(mask)))
        return 0;
    device->physicalBlendFactor = packed;
    device->physicalSampleMask = mask;
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceDepthStencil(Direct3D11Device* device,
                                                                const D3D11_DEPTH_STENCIL_DESC* description,
                                                                int32_t reference)
{
    if (!SourceGpuRecordDepthStencil(device, description, static_cast<uint32_t>(reference)))
        return 0;
    device->physicalStencilReference = reference;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuDisposeVertexBuffer(Direct3D11Device* device, ID3D11Buffer* buffer)
{
    if (!buffer)
        return 1;
    if (!device)
    {
        buffer->Release();
        return 1;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!device->device || !device->context)
    {
        buffer->Release();
        return 1;
    }
    auto retained = Retain(buffer);
    if (!SourceAppendPhysical(device, [device, retained]() {
            ID3D11Buffer* bound[32] = {};
            UINT strides[32] = {}, offsets[32] = {};
            device->context->IAGetVertexBuffers(0, 32, bound, strides, offsets);
            for (UINT slot = 0; slot < 32; ++slot)
            {
                if (bound[slot] == retained.get())
                {
                    ID3D11Buffer* empty = nullptr;
                    UINT zero = 0;
                    device->context->IASetVertexBuffers(slot, 1, &empty, &zero, &zero);
                }
                if (bound[slot])
                    bound[slot]->Release();
            }
        }))
        return 0;
    SourceInvalidatePhysicalInputBindings(device, true, false);
    if (device->vertexBindings)
    {
        auto bindings = std::make_shared<Direct3D11PhysicalVertexBindings>(*device->vertexBindings);
        for (size_t i = 0; i < bindings->elements.size(); ++i)
            bindings->elements[i].SemanticName = bindings->semantics[i].c_str();
        for (size_t i = 0; i < bindings->buffers.size(); ++i)
            if (bindings->buffers[i].get() == buffer)
            {
                bindings->buffers[i].reset();
                bindings->rawBuffers[i] = nullptr;
                bindings->strides[i] = 0;
                bindings->offsets[i] = 0;
            }
        device->vertexBindings = bindings;
    }
    buffer->Release();
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuDisposeIndexBuffer(Direct3D11Device* device, ID3D11Buffer* buffer)
{
    if (!buffer)
        return 1;
    if (!device)
    {
        buffer->Release();
        return 1;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!device->device || !device->context)
    {
        buffer->Release();
        return 1;
    }
    auto retained = Retain(buffer);
    if (!SourceAppendPhysical(device, [device, retained]() {
            ID3D11Buffer* bound = nullptr;
            DXGI_FORMAT format;
            UINT offset;
            device->context->IAGetIndexBuffer(&bound, &format, &offset);
            if (bound == retained.get())
                device->context->IASetIndexBuffer(nullptr, DXGI_FORMAT_R16_UINT, 0);
            if (bound)
                bound->Release();
        }))
        return 0;
    SourceInvalidatePhysicalInputBindings(device, false, true);
    buffer->Release();
    return 1;
}

// Pinned FNA3D_PipelineCache.c HashVertexBufferBindings. The hash is computed
// from the original declarations before shader usage/location filtering.
SOURCE_GPU_EXPORT uint32_t __cdecl SourceGpuHashSourceVertexBindings(const SourceGpuRawVertexBufferBinding* bindings,
                                                                     int32_t count)
{
    uint32_t hash = static_cast<uint32_t>(count);
    for (int32_t i = 0; i < count; ++i)
    {
        const auto& declaration = bindings[i].declaration;
        for (int32_t j = 0; j < declaration.count; ++j)
        {
            const auto& element = declaration.elements[j];
            // Preserve the original packed 32-bit bit pattern and wraparound.
            uint32_t packed = (static_cast<uint32_t>(element.offset) << 12) |
                              (static_cast<uint32_t>(element.format) << 8) |
                              (static_cast<uint32_t>(element.usage) << 4) | static_cast<uint32_t>(element.index);
            hash = hash * 37u + packed;
        }
        hash = hash * 37u + static_cast<uint32_t>(declaration.stride);
        hash = hash * 37u + static_cast<uint32_t>(bindings[i].instanceFrequency);
    }
    return hash;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceBoundDraw(Direct3D11Device* device, int32_t primitiveType,
                                                             int32_t primitiveCount, uint32_t start, int32_t baseVertex,
                                                             uint32_t instances, int32_t indexed)
{
    D3D11_PRIMITIVE_TOPOLOGY topology = D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED;
    uint32_t count = 0;
    switch (primitiveType)
    {
    case 0:
        topology = D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST;
        count = static_cast<uint32_t>(primitiveCount) * 3u;
        break;
    case 1:
        topology = D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP;
        count = static_cast<uint32_t>(primitiveCount) + 2u;
        break;
    case 2:
        topology = D3D11_PRIMITIVE_TOPOLOGY_LINELIST;
        count = static_cast<uint32_t>(primitiveCount) * 2u;
        break;
    case 3:
        topology = D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP;
        count = static_cast<uint32_t>(primitiveCount) + 1u;
        break;
    case 4:
        topology = D3D11_PRIMITIVE_TOPOLOGY_POINTLIST;
        count = static_cast<uint32_t>(primitiveCount);
        break;
    default:
        SourceBackendLogError("Unrecognized primitive type!");
        break;
    }
    // No zero-count early return: original submission still applies state/input.
    return SourceGpuRecordBoundDraw(device, topology, count, start, baseVertex, instances, indexed);
}

SOURCE_GPU_EXPORT Direct3D11PhysicalPacket* __cdecl SourceGpuGetSpriteGroupPacket(Direct3D11Device* device)
{
    if (!device)
        return nullptr;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto packet = SourceCurrentPhysicalPacket();
    // Capability probing does not create scopes or overwrite the caller's native error.
    return packet && packet->device == device && packet->generation == device->generation && device->device &&
                   device->context && device->shaders
               ? packet
               : nullptr;
}
struct Direct3D11CompactSpriteReplay
{
    struct Group
    {
        std::optional<Direct3D11SourceSamplerReplay> sampler;
        std::shared_ptr<Direct3D11DrawReplay> draw;
        uint32_t count = 0;
        int32_t baseVertex = 0;
        explicit Group(Direct3D11SourceSamplerReplay&& value) : sampler(std::move(value))
        {
        }
        Group() = default;
    };
    std::vector<Group> groups;
    std::shared_ptr<Direct3D11DrawReplay> common;
    void Replay(Direct3D11Device* device) const
    {
        for (const auto& group : groups)
        {
            if (group.sampler)
                SourceReplaySourceSampler(device, *group.sampler);
            if (group.draw)
                SourceReplayDraw(device, *group.draw, D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST, group.count, 0,
                                 group.baseVertex, 1, 1);
        }
    }
};
static int SourceRecordCompactSpriteDraw(Direct3D11Device* device, const SourceGpuSpriteTextureGroup& group,
                                         int32_t baseSprite, int32_t groupCapacity,
                                         std::shared_ptr<Direct3D11CompactSpriteReplay>& replay)
{
    // Same SourceGpuRecordBoundDraw validation stage, under the bulk's held device lock.
    if (!SourceRequireDevice(device))
        return 0;
    auto bindings = device->vertexBindings;
    if (!bindings)
    {
        SourceSetError("Draw requires actual physical vertex bindings");
        return 0;
    }
    std::optional<Direct3D11DrawReplay> snapshot;
    if (!SourceCaptureDrawReplay(device, bindings->elements.data(), static_cast<uint32_t>(bindings->elements.size()),
                                 bindings->hash, bindings, snapshot, replay ? replay->common.get() : nullptr))
        return 0;
    auto state = snapshot ? std::make_shared<Direct3D11DrawReplay>(std::move(*snapshot)) : replay->common;
    if (!replay)
    {
        auto first = std::make_shared<Direct3D11CompactSpriteReplay>();
        first->groups.reserve(static_cast<size_t>(groupCapacity));
        first->common = state;
        first->groups.emplace_back();
        auto& accepted = first->groups.back();
        accepted.draw = state;
        accepted.count = static_cast<uint32_t>(group.spriteCount * 2) * 3u;
        accepted.baseVertex = (baseSprite + group.firstSprite) * 4;
        if (!SourceAppendPhysicalDeviceLocked(device, [device, first]() { first->Replay(device); }))
            return 0;
        replay = std::move(first);
        return 1;
    }
    // Preserve append qualification even though this write joins the one existing command.
    if (!SourceCanAppendPhysicalPacketLocked(device))
        return 0;
    auto& accepted = replay->groups.back();
    accepted.draw = std::move(state);
    accepted.count = static_cast<uint32_t>(group.spriteCount * 2) * 3u;
    accepted.baseVertex = (baseSprite + group.firstSprite) * 4;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSpriteGroups(
    Direct3D11Device* device, Direct3D11PhysicalPacket* expectedPacket, const SourceGpuSpriteTextureGroup* groups,
    int32_t groupCount, int32_t baseSprite, ID3D11Buffer* indices, DXGI_FORMAT indexFormat,
    const D3D11_RASTERIZER_DESC* rasterizer, const D3D11_SAMPLER_DESC* sampler, SourceGpuSpriteGroupProgress* progress)
{
    if (!progress)
        return 0;
    progress->attemptedGroup = 0;
    progress->samplerConsumed = 1;
    progress->writeScopeCount = 0;
    if (!SourceRequirePhysicalScope(device) || !SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (SourceCurrentPhysicalPacket() != expectedPacket || !SourceCanAppendPhysicalPacketLocked(device))
        return 0;
    if (!groups || groupCount < 2 || groupCount > 2048 || !rasterizer || !sampler)
    {
        SourceSetError("Actual sprite texture groups are required");
        return 0;
    }
    std::shared_ptr<Direct3D11CompactSpriteReplay> replay;
    for (int32_t i = 0; i < groupCount; i++)
    {
        progress->attemptedGroup = i;
        progress->samplerConsumed = i == 0 ? 1 : 0;
        if (i != 0)
        {
            ++progress->writeScopeCount;
            // First managed ApplyState already recorded this rasterizer. This locked
            // bulk only appends sampler/draw writes, neither changes cached IA/RS.
            if (!SourceRequirePhysicalScope(device) || !SourceRequireDevice(device) ||
                !SourceCanAppendPhysicalPacketLocked(device))
                return 0;
            progress->samplerConsumed = 1;
            ++progress->writeScopeCount;
            auto captured = SourceCaptureSourceSampler(device, 0, groups[i].texture, sampler, 0);
            if (!captured)
                return 0;
            // Match SourceAppendPhysical's scope checks at this original sampler stage.
            if (!SourceRequirePhysicalScope(device) || !SourceCanAppendPhysicalPacketLocked(device))
                return 0;
            replay->groups.emplace_back(std::move(*captured));
            ++progress->writeScopeCount;
            if (!SourceRequireDevice(device) || !SourceCanAppendPhysicalPacketLocked(device))
                return 0;
        }
        ++progress->writeScopeCount;
        if (i == 0)
        {
            if (!SourceGpuRecordIndexBuffer(device, indices, indexFormat, 0))
                return 0;
        }
        else if (!SourceRequireDevice(device) || !SourceCanAppendPhysicalPacketLocked(device))
            return 0;
        if (!SourceRecordCompactSpriteDraw(device, groups[i], baseSprite, groupCount, replay))
            return 0;
    }
    return 1;
}
