#include "Direct3D11ImmutableStateCache.h"
#include "Direct3D11Resources.h"
#include "Direct3D11Transport.h"
#include "Direct3D11SamplerReplay.h"
#include <cstring>
#include <memory>
#include <algorithm>
#include <array>

struct Direct3D11HostBackbuffer
{
    ID3D11RenderTargetView* color = nullptr;
    ID3D11DepthStencilView* depth = nullptr;
    uint32_t width = 0, height = 0, samples = 0;
    DXGI_FORMAT format = DXGI_FORMAT_UNKNOWN;
    int32_t depthFormat = 0;
    ~Direct3D11HostBackbuffer()
    {
        if (color)
            color->Release();
        if (depth)
            depth->Release();
    }
};
struct SourceGpuRenderTargetBindings
{
    std::vector<std::shared_ptr<SourceGpuRenderbuffer>> colors;
    std::shared_ptr<SourceGpuRenderbuffer> depth;
};

void SourceCaptureHostBackbuffer(Direct3D11Device* device)
{
    if (device->ownsPhysicalDevice)
        return;
    auto target = std::make_shared<Direct3D11HostBackbuffer>();
    // The engine explicitly binds its actual host output immediately before
    // issuing this event. This does not create or discover another swap chain.
    device->context->OMGetRenderTargets(1, &target->color, &target->depth);
    if (target->color)
    {
        ID3D11Resource* resource = nullptr;
        target->color->GetResource(&resource);
        ID3D11Texture2D* texture = nullptr;
        HRESULT status = resource->QueryInterface(__uuidof(ID3D11Texture2D), reinterpret_cast<void**>(&texture));
        resource->Release();
        if (SUCCEEDED(status))
        {
            D3D11_TEXTURE2D_DESC desc;
            texture->GetDesc(&desc);
            texture->Release();
            target->width = desc.Width;
            target->height = desc.Height;
            target->format = desc.Format;
            target->samples = desc.SampleDesc.Count;
        }
    }
    if (target->depth)
    {
        D3D11_DEPTH_STENCIL_VIEW_DESC desc;
        target->depth->GetDesc(&desc);
        if (desc.Format == DXGI_FORMAT_D16_UNORM)
            target->depthFormat = 1;
        else if (desc.Format == DXGI_FORMAT_D24_UNORM_S8_UINT)
            target->depthFormat = 3;
        else if (desc.Format == DXGI_FORMAT_D32_FLOAT)
            target->depthFormat = 2;
    }
    device->hostBackbuffer = target;
}

void SourceGetActualHostOutput(Direct3D11Device* device, ID3D11RenderTargetView** color, uint32_t* width,
                               uint32_t* height)
{
    auto host = device->hostBackbuffer;
    *color = host ? host->color : nullptr;
    *width = host ? host->width : 0;
    *height = host ? host->height : 0;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuGetBackbufferDescription(Direct3D11Device* device, uint32_t* width,
                                                                uint32_t* height, DXGI_FORMAT* format,
                                                                uint32_t* samples, int32_t* depthFormat)
{
    if (!SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (device->sourceBackbuffer)
        return SourceGetActualBackbuffer(device, width, height, format, samples, depthFormat);
    auto target = device->hostBackbuffer;
    if (!target || !target->color)
    {
        SourceSetError("Actual host output has not been bound and captured by a render event");
        return 0;
    }
    *width = target->width;
    *height = target->height;
    *format = target->format;
    *samples = target->samples;
    *depthFormat = target->depthFormat;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordBackbufferTargets(Direct3D11Device* device)
{
    if (device->sourceBackbuffer)
        return SourceBindActualBackbuffer(device);
    if (!SourceRequireDevice(device))
        return 0;
    if (!SourceAppendPhysical(device, [device]() {
            auto target = device->hostBackbuffer;
            if (!target || !target->color)
            {
                SourceSetError("Borrowed host output must be explicitly bound before the render event");
                return;
            }
            device->context->OMSetRenderTargets(1, &target->color, target->depth);
        }))
        return 0;
    auto target = device->hostBackbuffer;
    device->physicalTargets.reset();
    device->physicalDepthFormat = target ? target->depthFormat : 0;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordClearBackbuffer(Direct3D11Device* device, const float* color,
                                                             uint32_t clearColor, uint32_t clearDepth,
                                                             uint32_t clearStencil, float depth, uint8_t stencil)
{
    if (!SourceRequireDevice(device))
        return 0;
    if (device->sourceBackbuffer)
        return SourceClearActualBackbuffer(device, color, clearColor, clearDepth, clearStencil, depth, stencil);
    std::array<float, 4> values = {};
    if (color)
        std::memcpy(values.data(), color, sizeof(values));
    return SourceAppendPhysical(device, [device, values, clearColor, clearDepth, clearStencil, depth, stencil]() {
        auto target = device->hostBackbuffer;
        if (!target || !target->color)
        {
            SourceSetError("Borrowed host output has not been captured");
            return;
        }
        if (clearColor)
            device->context->ClearRenderTargetView(target->color, values.data());
        UINT flags = (clearDepth ? D3D11_CLEAR_DEPTH : 0) | (clearStencil ? D3D11_CLEAR_STENCIL : 0);
        if (flags && target->depth)
            device->context->ClearDepthStencilView(target->depth, flags, depth, stencil);
    });
}

static std::shared_ptr<SourceGpuTexture> RetainTexture(SourceGpuTexture* texture)
{
    texture->references.fetch_add(1, std::memory_order_relaxed);
    return std::shared_ptr<SourceGpuTexture>(texture, [](SourceGpuTexture* value) {
        if (value->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
            delete value;
    });
}
static bool ValidTexture(SourceGpuTexture* texture, Direct3D11Device* expected = nullptr)
{
    if (texture && expected && texture->device != expected)
    {
        SourceSetError("Texture belongs to another device context");
        return false;
    }
    if (!texture || texture->generation != texture->device->generation)
    {
        SourceSetError("Texture belongs to a disposed device generation");
        return false;
    }
    return SourceRequireDevice(texture->device);
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateTexture(Direct3D11Device* device, DXGI_FORMAT format, uint32_t width,
                                                     uint32_t height, uint32_t depth, uint32_t levels,
                                                     uint32_t arraySize, D3D11_RESOURCE_DIMENSION dimension,
                                                     uint32_t renderTarget, uint32_t bytesPerBlock, uint32_t blockWidth,
                                                     uint32_t blockHeight, SourceGpuTexture** result)
{
    if (!result || !SourceRequireDevice(device))
        return 0;
    *result = nullptr;
    if (!bytesPerBlock || !blockWidth || !blockHeight)
    {
        SourceSetError("Physical format block layout is required");
        return 0;
    }
    auto texture = std::make_unique<SourceGpuTexture>(device);
    texture->format = format;
    texture->width = width;
    texture->height = height;
    texture->depth = depth;
    texture->levels = levels;
    texture->arraySize = arraySize;
    texture->bytesPerBlock = bytesPerBlock;
    texture->blockWidth = blockWidth;
    texture->blockHeight = blockHeight;
    texture->dimension = dimension;
    HRESULT status;
    if (dimension == D3D11_RESOURCE_DIMENSION_TEXTURE3D)
    {
        D3D11_TEXTURE3D_DESC desc = {
            width, height, depth, levels, format, D3D11_USAGE_DEFAULT, D3D11_BIND_SHADER_RESOURCE, 0, 0};
        ID3D11Texture3D* resource = nullptr;
        status = device->device->CreateTexture3D(&desc, nullptr, &resource);
        texture->resource = resource;
    }
    else
    {
        D3D11_TEXTURE2D_DESC desc = {};
        desc.Width = width;
        desc.Height = height;
        desc.MipLevels = levels;
        desc.ArraySize = arraySize;
        desc.Format = format;
        desc.SampleDesc.Count = 1;
        desc.Usage = D3D11_USAGE_DEFAULT;
        desc.BindFlags = D3D11_BIND_SHADER_RESOURCE;
        if (renderTarget)
            desc.BindFlags |= D3D11_BIND_RENDER_TARGET;
        if (arraySize == 6)
            desc.MiscFlags = D3D11_RESOURCE_MISC_TEXTURECUBE;
        if (renderTarget && levels > 1)
            desc.MiscFlags |= D3D11_RESOURCE_MISC_GENERATE_MIPS;
        ID3D11Texture2D* resource = nullptr;
        status = device->device->CreateTexture2D(&desc, nullptr, &resource);
        texture->resource = resource;
    }
    if (FAILED(status))
    {
        SourceSetError("D3D11 texture creation failed");
        return 0;
    }
    status = device->device->CreateShaderResourceView(texture->resource, nullptr, &texture->view);
    if (FAILED(status))
    {
        SourceSetError("D3D11 texture SRV creation failed");
        return 0;
    }
    if (renderTarget && dimension == D3D11_RESOURCE_DIMENSION_TEXTURE2D)
    {
        texture->colorViews.resize(arraySize, nullptr);
        for (uint32_t slice = 0; slice < arraySize; ++slice)
        {
            D3D11_RENDER_TARGET_VIEW_DESC desc = {};
            desc.Format = format;
            if (arraySize > 1)
            {
                desc.ViewDimension = D3D11_RTV_DIMENSION_TEXTURE2DARRAY;
                desc.Texture2DArray.FirstArraySlice = slice;
                desc.Texture2DArray.ArraySize = 1;
            }
            else
                desc.ViewDimension = D3D11_RTV_DIMENSION_TEXTURE2D;
            if (FAILED(device->device->CreateRenderTargetView(texture->resource, &desc, &texture->colorViews[slice])))
            {
                SourceSetError("D3D11 actual texture RTV creation failed");
                return 0;
            }
        }
    }
    *result = texture.release();
    return 1;
}

SOURCE_GPU_EXPORT void __cdecl SourceGpuDisposeTexture(SourceGpuTexture* texture)
{
    if (texture && texture->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
        delete texture;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordTextureData(SourceGpuTexture* texture, uint32_t level, uint32_t slice,
                                                         uint32_t x, uint32_t y, uint32_t z, uint32_t width,
                                                         uint32_t height, uint32_t depth, const void* bytes,
                                                         uint32_t length)
{
    if (!ValidTexture(texture))
        return 0;
    auto retained = RetainTexture(texture);
    auto data = static_cast<const uint8_t*>(bytes);
    auto copy = std::make_shared<std::vector<uint8_t>>(data, data + length);
    uint32_t rowPitch = ((width + texture->blockWidth - 1) / texture->blockWidth) * texture->bytesPerBlock;
    uint32_t depthPitch = ((height + texture->blockHeight - 1) / texture->blockHeight) * rowPitch;
    D3D11_BOX box = {x, y, z, x + width, y + height, z + depth};
    uint32_t subresource = D3D11CalcSubresource(level, slice, texture->levels);
    return SourceAppendPhysical(texture->device, [retained, copy, box, subresource, rowPitch, depthPitch]() {
        retained->device->context->UpdateSubresource(retained->resource, subresource, &box, copy->data(), rowPitch,
                                                     depthPitch);
    });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordTextureCopy(SourceGpuTexture* source, SourceGpuTexture* destination)
{
    if (!ValidTexture(source) || !ValidTexture(destination))
        return 0;
    if (source->device != destination->device || source->resource == destination->resource ||
        source->dimension != D3D11_RESOURCE_DIMENSION_TEXTURE2D ||
        destination->dimension != D3D11_RESOURCE_DIMENSION_TEXTURE2D || source->width != destination->width ||
        source->height != destination->height || source->levels != destination->levels ||
        source->arraySize != destination->arraySize || source->format != destination->format)
    {
        SourceSetError("Texture copy requires distinct matching Texture2D resources on one device");
        return 0;
    }
    auto packet = SourceCurrentPhysicalPacket();
    if (packet && packet->device != source->device)
    {
        SourceSetError("Cannot record texture copy for another physical device");
        return 0;
    }
    auto retainedSource = RetainTexture(source);
    auto retainedDestination = RetainTexture(destination);
    return SourceAppendPhysical(source->device, [retainedSource, retainedDestination]() {
        auto context = retainedSource->device->context;
        ID3D11RenderTargetView* targets[D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT] = {};
        ID3D11DepthStencilView* depth = nullptr;
        context->OMGetRenderTargets(D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT, targets, &depth);
        context->OMSetRenderTargets(0, nullptr, nullptr);
        context->CopyResource(retainedDestination->resource, retainedSource->resource);
        context->OMSetRenderTargets(D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT, targets, depth);
        for (auto target : targets)
            if (target)
                target->Release();
        if (depth)
            depth->Release();
    });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordTextureBinding(Direct3D11Device* device, uint32_t slot,
                                                            uint32_t vertexStage, SourceGpuTexture* texture)
{
    if (!SourceRequireDevice(device) || (texture && !ValidTexture(texture, device)))
        return 0;
    Direct3D11TextureLease retained(texture);
    return SourceAppendPhysical(device, [device, slot, vertexStage, retained = std::move(retained)]() {
        auto view = retained ? retained->view : nullptr;
        if (vertexStage)
            device->context->VSSetShaderResources(slot, 1, &view);
        else
            device->context->PSSetShaderResources(slot, 1, &view);
    });
}

std::optional<Direct3D11SourceSamplerReplay> SourceCaptureSourceSampler(Direct3D11Device* device, uint32_t slot,
                                                                        SourceGpuTexture* texture,
                                                                        const D3D11_SAMPLER_DESC* description,
                                                                        uint32_t vertexStage)
{
    if (!SourceRequireDevice(device) || (texture && !ValidTexture(texture, device)))
        return {};
    Direct3D11TextureLease retained(texture);
    auto sampler = SourceBorrowSamplerState(device, description, "D3D11 source sampler creation failed");
    if (!sampler)
        return {};
    return Direct3D11SourceSamplerReplay(slot, vertexStage, std::move(retained), std::move(sampler));
}
void SourceReplaySourceSampler(Direct3D11Device* device, const Direct3D11SourceSamplerReplay& snapshot)
{
    auto state = snapshot.sampler.get();
    auto view = snapshot.retained ? snapshot.retained->view : nullptr;
    if (snapshot.vertexStage)
    {
        device->context->VSSetShaderResources(snapshot.slot, 1, &view);
        device->context->VSSetSamplers(snapshot.slot, 1, &state);
    }
    else
    {
        device->context->PSSetShaderResources(snapshot.slot, 1, &view);
        device->context->PSSetSamplers(snapshot.slot, 1, &state);
    }
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceSampler(Direct3D11Device* device, uint32_t slot,
                                                           SourceGpuTexture* texture,
                                                           const D3D11_SAMPLER_DESC* description, uint32_t vertexStage)
{
    auto snapshot = SourceCaptureSourceSampler(device, slot, texture, description, vertexStage);
    if (!snapshot)
        return 0;
    return SourceAppendPhysical(
        device, [device, snapshot = std::move(*snapshot)]() { SourceReplaySourceSampler(device, snapshot); });
}

SOURCE_GPU_EXPORT SourceGpuReadback* __cdecl SourceGpuRecordTextureRead(SourceGpuTexture* texture, uint32_t level,
                                                                        uint32_t slice, uint32_t x, uint32_t y,
                                                                        uint32_t z, uint32_t width, uint32_t height,
                                                                        uint32_t depth)
{
    if (!ValidTexture(texture))
        return nullptr;
    if (texture->blockWidth != 1 || texture->blockHeight != 1)
    {
        // Original FNA3D D3D11 GetTextureData rejects compressed reads and
        // leaves the caller's existing destination bytes untouched.
        SourceBackendLogError("GetData with compressed textures unsupported!");
        auto untouched = new SourceGpuReadback;
        untouched->completion.store(2, std::memory_order_release);
        return untouched;
    }
    auto retained = RetainTexture(texture);
    auto ticket = new SourceGpuReadback;
    ticket->references.fetch_add(1, std::memory_order_relaxed);
    auto lifetime = std::shared_ptr<SourceGpuReadback>(ticket, [](SourceGpuReadback* value) {
        if (value->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
            delete value;
    });
    uint32_t rowBytes = ((width + texture->blockWidth - 1) / texture->blockWidth) * texture->bytesPerBlock;
    uint32_t rows = (height + texture->blockHeight - 1) / texture->blockHeight;
    ticket->bytes.resize(static_cast<size_t>(rowBytes) * rows * depth);
    uint32_t subresource = D3D11CalcSubresource(level, slice, texture->levels);
    bool appended = SourceAppendPhysical(
        texture->device, [retained, lifetime, subresource, x, y, z, width, height, depth, rowBytes, rows]() {
            auto device = retained->device;
            ID3D11Resource* staging = nullptr;
            HRESULT status;
            if (retained->dimension == D3D11_RESOURCE_DIMENSION_TEXTURE3D)
            {
                D3D11_TEXTURE3D_DESC description;
                static_cast<ID3D11Texture3D*>(retained->resource)->GetDesc(&description);
                description.Usage = D3D11_USAGE_STAGING;
                description.BindFlags = 0;
                description.CPUAccessFlags = D3D11_CPU_ACCESS_READ;
                description.MiscFlags = 0;
                ID3D11Texture3D* resource = nullptr;
                status = device->device->CreateTexture3D(&description, nullptr, &resource);
                staging = resource;
            }
            else
            {
                D3D11_TEXTURE2D_DESC description;
                static_cast<ID3D11Texture2D*>(retained->resource)->GetDesc(&description);
                description.Usage = D3D11_USAGE_STAGING;
                description.BindFlags = 0;
                description.CPUAccessFlags = D3D11_CPU_ACCESS_READ;
                description.MiscFlags = 0;
                ID3D11Texture2D* resource = nullptr;
                status = device->device->CreateTexture2D(&description, nullptr, &resource);
                staging = resource;
            }
            if (FAILED(status))
            {
                SourceSetError("Texture readback staging allocation failed");
                lifetime->completion = -1;
                return;
            }
            device->context->CopyResource(staging, retained->resource);
            D3D11_MAPPED_SUBRESOURCE mapped = {};
            status = device->context->Map(staging, subresource, D3D11_MAP_READ, 0, &mapped);
            if (FAILED(status))
            {
                staging->Release();
                SourceSetError("Texture readback Map failed");
                lifetime->completion = -1;
                return;
            }
            auto base = static_cast<const uint8_t*>(mapped.pData) + static_cast<size_t>(z) * mapped.DepthPitch +
                        (y / retained->blockHeight) * mapped.RowPitch +
                        (x / retained->blockWidth) * retained->bytesPerBlock;
            for (uint32_t layer = 0; layer < depth; ++layer)
                for (uint32_t row = 0; row < rows; ++row)
                    std::memcpy(lifetime->bytes.data() + (static_cast<size_t>(layer) * rows + row) * rowBytes,
                                base + static_cast<size_t>(layer) * mapped.DepthPitch +
                                    static_cast<size_t>(row) * mapped.RowPitch,
                                rowBytes);
            device->context->Unmap(staging, subresource);
            staging->Release();
            lifetime->completion.store(1, std::memory_order_release);
        });
    if (!appended)
    {
        if (ticket->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
            delete ticket;
        return nullptr;
    }
    return ticket;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuReadbackCompletion(SourceGpuReadback* ticket)
{
    return ticket->completion.load(std::memory_order_acquire);
}
SOURCE_GPU_EXPORT const uint8_t* __cdecl SourceGpuReadbackBytes(SourceGpuReadback* ticket, uint32_t* count)
{
    if (ticket->completion.load(std::memory_order_acquire) != 1)
        return nullptr;
    *count = static_cast<uint32_t>(ticket->bytes.size());
    return ticket->bytes.data();
}
SOURCE_GPU_EXPORT void __cdecl SourceGpuReleaseReadback(SourceGpuReadback* ticket)
{
    if (ticket->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
        delete ticket;
}

static std::shared_ptr<SourceGpuRenderbuffer> RetainRenderbuffer(SourceGpuRenderbuffer* buffer)
{
    buffer->references.fetch_add(1, std::memory_order_relaxed);
    return std::shared_ptr<SourceGpuRenderbuffer>(buffer, [](SourceGpuRenderbuffer* value) {
        if (value->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
            delete value;
    });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateRenderbuffer(Direct3D11Device* device, uint32_t width, uint32_t height,
                                                          DXGI_FORMAT format, uint32_t samples,
                                                          int32_t sourceDepthFormat, SourceGpuTexture* texture,
                                                          uint32_t slice, SourceGpuRenderbuffer** result)
{
    if (!SourceRequireDevice(device) || !result)
        return 0;
    *result = nullptr;
    auto buffer = std::make_unique<SourceGpuRenderbuffer>(device);
    buffer->format = format;
    buffer->sourceDepthFormat = sourceDepthFormat;
    buffer->width = width;
    buffer->height = height;
    buffer->samples = samples;
    if (texture && samples <= 1)
    {
        if (!ValidTexture(texture, device))
            return 0;
        buffer->resource = static_cast<ID3D11Texture2D*>(texture->resource);
        buffer->resource->AddRef();
    }
    else
    {
        D3D11_TEXTURE2D_DESC desc = {};
        desc.Width = width;
        desc.Height = height;
        desc.MipLevels = 1;
        desc.ArraySize = 1;
        desc.Format = format;
        desc.SampleDesc.Count = std::max(1u, samples);
        desc.Usage = D3D11_USAGE_DEFAULT;
        desc.BindFlags = sourceDepthFormat ? D3D11_BIND_DEPTH_STENCIL : D3D11_BIND_RENDER_TARGET;
        if (FAILED(device->device->CreateTexture2D(&desc, nullptr, &buffer->resource)))
        {
            SourceSetError("D3D11 renderbuffer allocation failed");
            return 0;
        }
    }
    HRESULT status;
    if (sourceDepthFormat)
        status = device->device->CreateDepthStencilView(buffer->resource, nullptr, &buffer->depthView);
    else
    {
        D3D11_RENDER_TARGET_VIEW_DESC desc = {};
        desc.Format = format;
        if (samples > 1)
            desc.ViewDimension = D3D11_RTV_DIMENSION_TEXTURE2DMS;
        else if (texture && texture->arraySize > 1)
        {
            desc.ViewDimension = D3D11_RTV_DIMENSION_TEXTURE2DARRAY;
            desc.Texture2DArray.MipSlice = 0;
            desc.Texture2DArray.FirstArraySlice = slice;
            desc.Texture2DArray.ArraySize = 1;
        }
        else
            desc.ViewDimension = D3D11_RTV_DIMENSION_TEXTURE2D;
        if (texture && samples <= 1 && slice < texture->colorViews.size())
        {
            buffer->colorView = texture->colorViews[slice];
            buffer->colorView->AddRef();
            status = S_OK;
        }
        else
            status = device->device->CreateRenderTargetView(buffer->resource, &desc, &buffer->colorView);
    }
    if (FAILED(status))
    {
        SourceSetError("D3D11 renderbuffer view allocation failed");
        return 0;
    }
    *result = buffer.release();
    return 1;
}

SOURCE_GPU_EXPORT void __cdecl SourceGpuDisposeRenderbuffer(SourceGpuRenderbuffer* buffer)
{
    if (buffer && buffer->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
        delete buffer;
}

static bool ValidRenderbuffer(SourceGpuRenderbuffer* buffer, Direct3D11Device* device)
{
    if (buffer->device != device || buffer->generation != device->generation)
    {
        SourceSetError("Renderbuffer belongs to another device context or generation");
        return false;
    }
    return true;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordRenderTargets(Direct3D11Device* device,
                                                           SourceGpuRenderbuffer* const* colors, uint32_t count,
                                                           SourceGpuRenderbuffer* depth)
{
    if (!SourceRequirePhysicalScope(device) || !SourceRequireDevice(device))
        return 0;
    for (uint32_t i = 0; i < count; ++i)
        if (colors[i] && !ValidRenderbuffer(colors[i], device))
            return 0;
    if (depth && !ValidRenderbuffer(depth, device))
        return 0;
    auto targets = std::make_shared<std::vector<std::shared_ptr<SourceGpuRenderbuffer>>>();
    for (uint32_t i = 0; i < count; ++i)
        targets->push_back(colors[i] ? RetainRenderbuffer(colors[i]) : nullptr);
    auto retainedDepth = depth ? RetainRenderbuffer(depth) : std::shared_ptr<SourceGpuRenderbuffer>();
    if (!SourceAppendPhysical(device, [device, targets, retainedDepth]() {
            std::vector<ID3D11RenderTargetView*> views;
            views.reserve(targets->size());
            for (const auto& target : *targets)
                views.push_back(target ? target->colorView : nullptr);
            device->context->OMSetRenderTargets(static_cast<UINT>(views.size()), views.data(),
                                                retainedDepth ? retainedDepth->depthView : nullptr);
        }))
        return 0;
    device->physicalDepthFormat = depth ? depth->sourceDepthFormat : 0;
    auto binding = std::make_shared<SourceGpuRenderTargetBindings>();
    binding->colors = *targets;
    binding->depth = retainedDepth;
    device->physicalTargets = binding;
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuGetCurrentDepthFormat(Direct3D11Device* device)
{
    return device->physicalDepthFormat;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordResolve(SourceGpuRenderbuffer* source, SourceGpuTexture* destination,
                                                     uint32_t slice, uint32_t level)
{
    if (!source || !SourceRequireDevice(source->device) || !ValidRenderbuffer(source, source->device) ||
        !ValidTexture(destination, source->device))
        return 0;
    auto retained = RetainRenderbuffer(source);
    auto texture = RetainTexture(destination);
    uint32_t subresource = D3D11CalcSubresource(level, slice, destination->levels);
    return SourceAppendPhysical(source->device, [retained, texture, subresource]() {
        if (retained->samples > 1)
            retained->device->context->ResolveSubresource(texture->resource, subresource, retained->resource, 0,
                                                          texture->format);
    });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuGetFormatSupport(Direct3D11Device* device, DXGI_FORMAT format, uint32_t* support)
{
    if (!SourceRequireDevice(device) || !support)
        return 0;
    if (FAILED(device->device->CheckFormatSupport(format, support)))
    {
        SourceSetError("D3D11 CheckFormatSupport failed");
        return 0;
    }
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuGetMultisampleQuality(Direct3D11Device* device, DXGI_FORMAT format,
                                                             uint32_t samples, uint32_t* quality)
{
    if (!SourceRequireDevice(device) || !quality)
        return 0;
    if (FAILED(device->device->CheckMultisampleQualityLevels(format, samples, quality)))
    {
        SourceSetError("D3D11 CheckMultisampleQualityLevels failed");
        return 0;
    }
    return 1;
}

SOURCE_GPU_EXPORT SourceGpuReadback* __cdecl SourceGpuRecordVertexBufferRead(Direct3D11Device* device,
                                                                             ID3D11Buffer* buffer, uint32_t offset,
                                                                             uint32_t elementCount,
                                                                             uint32_t elementSize, uint32_t stride)
{
    if (!SourceRequireDevice(device))
        return nullptr;
    buffer->AddRef();
    auto retained = std::shared_ptr<ID3D11Buffer>(buffer, [](ID3D11Buffer* value) { value->Release(); });
    auto ticket = new SourceGpuReadback;
    ticket->bytes.resize(static_cast<size_t>(elementCount) * elementSize);
    ticket->references.fetch_add(1, std::memory_order_relaxed);
    auto lifetime = std::shared_ptr<SourceGpuReadback>(ticket, [](SourceGpuReadback* value) {
        if (value->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
            delete value;
    });
    bool appended =
        SourceAppendPhysical(device, [device, retained, lifetime, offset, elementCount, elementSize, stride]() {
            D3D11_BUFFER_DESC description;
            retained->GetDesc(&description);
            description.Usage = D3D11_USAGE_STAGING;
            description.BindFlags = 0;
            description.CPUAccessFlags = D3D11_CPU_ACCESS_READ;
            description.MiscFlags = 0;
            description.StructureByteStride = 0;
            ID3D11Buffer* staging = nullptr;
            if (FAILED(device->device->CreateBuffer(&description, nullptr, &staging)))
            {
                SourceSetError("Vertex readback staging allocation failed");
                lifetime->completion = -1;
                return;
            }
            device->context->CopyResource(staging, retained.get());
            D3D11_MAPPED_SUBRESOURCE mapped = {};
            if (FAILED(device->context->Map(staging, 0, D3D11_MAP_READ, 0, &mapped)))
            {
                staging->Release();
                SourceSetError("Vertex readback Map failed");
                lifetime->completion = -1;
                return;
            }
            auto source = static_cast<const uint8_t*>(mapped.pData) + offset;
            for (uint32_t i = 0; i < elementCount; ++i)
                std::memcpy(lifetime->bytes.data() + static_cast<size_t>(i) * elementSize,
                            source + static_cast<size_t>(i) * stride, elementSize);
            device->context->Unmap(staging, 0);
            staging->Release();
            lifetime->completion.store(1, std::memory_order_release);
        });
    if (!appended)
    {
        if (ticket->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
            delete ticket;
        return nullptr;
    }
    return ticket;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordClearRenderbuffer(SourceGpuRenderbuffer* buffer, const float* color,
                                                               uint32_t clearColor, uint32_t clearDepth,
                                                               uint32_t clearStencil, float depth, uint8_t stencil)
{
    if (!buffer || !SourceRequireDevice(buffer->device) || !ValidRenderbuffer(buffer, buffer->device))
        return 0;
    auto retained = RetainRenderbuffer(buffer);
    std::array<float, 4> values = {};
    if (color)
        std::memcpy(values.data(), color, sizeof(values));
    return SourceAppendPhysical(
        buffer->device, [retained, values, clearColor, clearDepth, clearStencil, depth, stencil]() {
            if (clearColor && retained->colorView)
                retained->device->context->ClearRenderTargetView(retained->colorView, values.data());
            UINT flags = (clearDepth ? D3D11_CLEAR_DEPTH : 0) | (clearStencil ? D3D11_CLEAR_STENCIL : 0);
            if (flags && retained->depthView)
                retained->device->context->ClearDepthStencilView(retained->depthView, flags, depth, stencil);
        });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordClearCurrent(Direct3D11Device* device, const float* color,
                                                          uint32_t clearColor, uint32_t clearDepth,
                                                          uint32_t clearStencil, float depth, uint8_t stencil)
{
    if (!SourceRequireDevice(device))
        return 0;
    auto binding = device->physicalTargets;
    if (!binding)
        return SourceGpuRecordClearBackbuffer(device, color, clearColor, clearDepth, clearStencil, depth, stencil);
    std::array<float, 4> values = {};
    if (color)
        std::memcpy(values.data(), color, sizeof(values));
    return SourceAppendPhysical(
        device, [device, binding, values, clearColor, clearDepth, clearStencil, depth, stencil]() {
            if (clearColor)
                for (const auto& target : binding->colors)
                    if (target && target->colorView)
                        device->context->ClearRenderTargetView(target->colorView, values.data());
            UINT flags = (clearDepth ? D3D11_CLEAR_DEPTH : 0) | (clearStencil ? D3D11_CLEAR_STENCIL : 0);
            if (flags && binding->depth)
                device->context->ClearDepthStencilView(binding->depth->depthView, flags, depth, stencil);
        });
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceTargets(Direct3D11Device* device,
                                                           const SourceGpuTargetBinding* bindings, uint32_t count,
                                                           SourceGpuRenderbuffer* depth)
{
    if (!count)
        return SourceGpuRecordBackbufferTargets(device);
    std::vector<SourceGpuRenderbuffer*> targets(count, nullptr);
    std::vector<std::unique_ptr<SourceGpuRenderbuffer>> aliases;
    aliases.reserve(count);
    for (uint32_t i = 0; i < count; ++i)
    {
        const auto& binding = bindings[i];
        if (binding.colorBuffer)
        {
            targets[i] = binding.colorBuffer;
            continue;
        }
        if (!ValidTexture(binding.texture, device))
            return 0;
        uint32_t slice = binding.type == 1 ? static_cast<uint32_t>(binding.data2) : 0;
        SourceGpuRenderbuffer* alias = nullptr;
        if (!SourceGpuCreateRenderbuffer(device, binding.texture->width, binding.texture->height,
                                         binding.texture->format, 1, 0, binding.texture, slice, &alias))
            return 0;
        targets[i] = alias;
        aliases.emplace_back(alias);
    }
    bool result = SourceGpuRecordRenderTargets(device, targets.data(), count, depth) != 0;
    // RecordRenderTargets owns its retains. Drop only the aliases' creator loan.
    for (auto& alias : aliases)
        SourceGpuDisposeRenderbuffer(alias.release());
    return result;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceResolve(const SourceGpuTargetBinding* binding)
{
    if (!binding)
        return 0;
    // Pinned D3D11_ResolveTarget does not dereference the texture for this case.
    if (binding->multiSampleCount <= 0 && binding->levelCount <= 1)
        return 1;
    if (!ValidTexture(binding->texture))
        return 0;
    uint32_t slice = binding->type == 1 ? static_cast<uint32_t>(binding->data2) : 0;
    if (binding->multiSampleCount > 0 && binding->colorBuffer)
        if (!SourceGpuRecordResolve(binding->colorBuffer, binding->texture, slice, 0))
            return 0;
    if (binding->levelCount > 1)
    {
        auto texture = RetainTexture(binding->texture);
        return SourceAppendPhysical(texture->device,
                                    [texture]() { texture->device->context->GenerateMips(texture->view); });
    }
    return 1;
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuSetTextureName(SourceGpuTexture* texture, const char* name, uint32_t length)
{
    if (!ValidTexture(texture))
        return 0;
    HRESULT status = texture->resource->SetPrivateData(WKPDID_D3DDebugObjectName, length, name);
    if (FAILED(status))
    {
        SourceSetError("D3D11 texture debug name assignment failed");
        return 0;
    }
    return 1;
}

// Source creator disposal is separate from temporary transport-retain release.
// Pinned D3D11_AddDisposeTexture/Renderbuffer clears cached target views without
// issuing a new OM/SRV binding. Existing queued commands retain their snapshots.
SOURCE_GPU_EXPORT void __cdecl SourceGpuAddDisposeTexture(SourceGpuTexture* texture)
{
    if (!texture)
        return;
    auto device = texture->device;
    {
        std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
        if (texture->generation == device->generation && device->physicalTargets)
        {
            auto next = std::make_shared<SourceGpuRenderTargetBindings>(*device->physicalTargets);
            for (auto& color : next->colors)
                if (color && std::find(texture->colorViews.begin(), texture->colorViews.end(), color->colorView) !=
                                 texture->colorViews.end())
                    color.reset();
            device->physicalTargets = next;
        }
    }
    SourceGpuDisposeTexture(texture);
}
SOURCE_GPU_EXPORT void __cdecl SourceGpuAddDisposeRenderbuffer(SourceGpuRenderbuffer* buffer)
{
    if (!buffer)
        return;
    auto device = buffer->device;
    {
        std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
        if (buffer->generation == device->generation && device->physicalTargets)
        {
            auto next = std::make_shared<SourceGpuRenderTargetBindings>(*device->physicalTargets);
            for (auto& color : next->colors)
                if (color && color->colorView == buffer->colorView && buffer->colorView)
                    color.reset();
            if (next->depth && next->depth->depthView == buffer->depthView && buffer->depthView)
                next->depth.reset();
            device->physicalTargets = next;
        }
    }
    SourceGpuDisposeRenderbuffer(buffer);
}
// Standalone output is deliberately separate from the source faux backbuffer.
// SourceGpuRecordPresent uses the existing FNA crop/scale blit into this RTV.
SOURCE_GPU_EXPORT int __cdecl SourceGpuConfigureFrameOutput(Direct3D11Device* device, uint32_t width, uint32_t height)
{
    if (!SourceRequireRenderThread(device) || !device->ownsPhysicalDevice || !width || !height ||
        width > D3D11_REQ_TEXTURE2D_U_OR_V_DIMENSION || height > D3D11_REQ_TEXTURE2D_U_OR_V_DIMENSION ||
        static_cast<uint64_t>(width) * height * 4 > UINT32_MAX)
    {
        SourceSetError("Valid independent RGBA frame output dimensions are required");
        return 0;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (SourceCurrentPhysicalPacket() || !device->physicalPackets.empty())
    {
        SourceSetError("Release completed packets before resizing frame output");
        return 0;
    }
    if (device->frameOutput && width == device->frameWidth && height == device->frameHeight)
        return 1;
    D3D11_TEXTURE2D_DESC desc = {};
    desc.Width = width;
    desc.Height = height;
    desc.MipLevels = 1;
    desc.ArraySize = 1;
    desc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
    desc.SampleDesc.Count = 1;
    desc.Usage = D3D11_USAGE_DEFAULT;
    desc.BindFlags = D3D11_BIND_RENDER_TARGET;
    ID3D11Texture2D* output = nullptr;
    if (FAILED(device->device->CreateTexture2D(&desc, nullptr, &output)))
    {
        SourceSetError("Independent frame output allocation failed");
        return 0;
    }
    std::shared_ptr<ID3D11Texture2D> ownedOutput(output, [](ID3D11Texture2D* value) { value->Release(); });
    auto host = std::make_shared<Direct3D11HostBackbuffer>();
    if (FAILED(device->device->CreateRenderTargetView(output, nullptr, &host->color)))
    {
        SourceSetError("Independent frame output view allocation failed");
        return 0;
    }
    host->width = width;
    host->height = height;
    host->samples = 1;
    host->format = desc.Format;
    device->frameOutput = ownedOutput;
    device->frameStaging.reset(); // Readback staging is allocated only for a real read request.
    device->hostBackbuffer = host;
    device->frameWidth = width;
    device->frameHeight = height;
    // Deterministic uncovered pixels before the first cropped Present.
    const float clear[4] = {0, 0, 0, 1};
    device->context->ClearRenderTargetView(host->color, clear);
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuReadFrameRgba(Direct3D11Device* device, uint8_t* destination,
                                                     uint32_t byteCapacity, uint32_t* written)
{
    if (written)
        *written = 0;
    if (!SourceRequireRenderThread(device) || !device->ownsPhysicalDevice || !destination || !written ||
        !device->frameOutput || SourceCurrentPhysicalPacket())
    {
        SourceSetError("Completed independent frame output and destination are required");
        return 0;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    // PresentCompleted follows successful execution of its frame packet. Other
    // threads may already hold recorded resource packets: those cannot modify
    // this output until the owner executes them. Read the completed output under
    // the same context lock, without requiring unrelated worker work to finish.
    uint32_t rowBytes = device->frameWidth * 4;
    uint32_t required = rowBytes * device->frameHeight;
    if (byteCapacity < required)
    {
        SourceSetError("RGBA frame destination is too small");
        return 0;
    }
    if (!device->frameStaging)
    {
        D3D11_TEXTURE2D_DESC desc = {};
        device->frameOutput->GetDesc(&desc);
        desc.Usage = D3D11_USAGE_STAGING;
        desc.BindFlags = 0;
        desc.CPUAccessFlags = D3D11_CPU_ACCESS_READ;
        ID3D11Texture2D* staging = nullptr;
        if (FAILED(device->device->CreateTexture2D(&desc, nullptr, &staging)))
        {
            SourceSetError("Independent frame staging allocation failed");
            return 0;
        }
        device->frameStaging =
            std::shared_ptr<ID3D11Texture2D>(staging, [](ID3D11Texture2D* value) { value->Release(); });
    }
    device->context->CopyResource(device->frameStaging.get(), device->frameOutput.get());
    D3D11_MAPPED_SUBRESOURCE mapped = {};
    if (FAILED(device->context->Map(device->frameStaging.get(), 0, D3D11_MAP_READ, 0, &mapped)))
    {
        SourceSetError("Independent frame readback Map failed");
        return 0;
    }
    for (uint32_t row = 0; row < device->frameHeight; ++row)
        std::memcpy(destination + static_cast<size_t>(row) * rowBytes,
                    static_cast<const uint8_t*>(mapped.pData) + static_cast<size_t>(row) * mapped.RowPitch, rowBytes);
    device->context->Unmap(device->frameStaging.get(), 0);
    *written = required;
    return 1;
}
