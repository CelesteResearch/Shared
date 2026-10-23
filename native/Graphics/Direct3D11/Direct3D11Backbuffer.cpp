#include "Direct3D11Commands.h"
#include "Direct3D11PhysicalStateScope.h"
#include "Reference/FNA3D_Driver_D3D11_shaders.h"
#include <cstring>
#include <algorithm>
#include <string>

// FNA3D's faux backbuffer resources, on the host's existing physical device.
// This is the source backbuffer resource, not a second window or swap chain.
struct Direct3D11BackbufferBlitResources
{
    ID3D11VertexShader* vertexShader = nullptr;
    ID3D11PixelShader* pixelShader = nullptr;
    ID3D11InputLayout* layout = nullptr;
    ID3D11SamplerState* sampler = nullptr;
    ID3D11Buffer* vertices = nullptr;
    ID3D11Buffer* indices = nullptr;
    ID3D11RasterizerState* rasterizer = nullptr;
    ID3D11BlendState* blend = nullptr;
    ~Direct3D11BackbufferBlitResources()
    {
        if (vertexShader)
            vertexShader->Release();
        if (pixelShader)
            pixelShader->Release();
        if (layout)
            layout->Release();
        if (sampler)
            sampler->Release();
        if (vertices)
            vertices->Release();
        if (indices)
            indices->Release();
        if (rasterizer)
            rasterizer->Release();
        if (blend)
            blend->Release();
    }
};
struct Direct3D11Backbuffer
{
    Direct3D11Device* device;
    std::shared_ptr<SourceGpuTexture> texture;
    std::shared_ptr<SourceGpuRenderbuffer> color, depth;
    uint32_t samples = 1;
    int32_t depthFormat = 0;
    int32_t surfaceFormat = 0;
    std::shared_ptr<Direct3D11BackbufferBlitResources> blit;
};
static bool CreateBlitResources(Direct3D11Device* sourceDevice, Direct3D11BackbufferBlitResources& b, bool nearest)
{
    auto device = sourceDevice->device;
    if (FAILED(device->CreateVertexShader(FAUX_BLIT_VERTEX_SHADER, sizeof(FAUX_BLIT_VERTEX_SHADER), nullptr,
                                          &b.vertexShader)) ||
        FAILED(
            device->CreatePixelShader(FAUX_BLIT_PIXEL_SHADER, sizeof(FAUX_BLIT_PIXEL_SHADER), nullptr, &b.pixelShader)))
    {
        SourceSetError("Actual FNA3D blit shader creation failed");
        return false;
    }
    D3D11_INPUT_ELEMENT_DESC elements[2] = {
        {"SV_POSITION", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0},
        {"TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 8, D3D11_INPUT_PER_VERTEX_DATA, 0}};
    if (FAILED(device->CreateInputLayout(elements, 2, FAUX_BLIT_VERTEX_SHADER, sizeof(FAUX_BLIT_VERTEX_SHADER),
                                         &b.layout)))
    {
        SourceSetError("Actual FNA3D blit input layout creation failed");
        return false;
    }
    D3D11_SAMPLER_DESC sampler = {};
    sampler.Filter = nearest ? D3D11_FILTER_MIN_MAG_MIP_POINT : D3D11_FILTER_MIN_MAG_MIP_LINEAR;
    sampler.AddressU = sampler.AddressV = sampler.AddressW = D3D11_TEXTURE_ADDRESS_CLAMP;
    sampler.MaxAnisotropy = 1;
    sampler.ComparisonFunc = D3D11_COMPARISON_ALWAYS;
    if (FAILED(device->CreateSamplerState(&sampler, &b.sampler)))
    {
        SourceSetError("Backbuffer sampler allocation failed");
        return false;
    }
    D3D11_BUFFER_DESC vertices = {};
    vertices.ByteWidth = 16 * sizeof(float);
    vertices.Usage = D3D11_USAGE_DYNAMIC;
    vertices.BindFlags = D3D11_BIND_VERTEX_BUFFER;
    vertices.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
    if (FAILED(device->CreateBuffer(&vertices, nullptr, &b.vertices)))
    {
        SourceSetError("Backbuffer vertex allocation failed");
        return false;
    }
    const uint16_t indices[6] = {0, 1, 3, 1, 2, 3};
    D3D11_SUBRESOURCE_DATA data = {indices, 0, 0};
    D3D11_BUFFER_DESC index = {};
    index.ByteWidth = sizeof(indices);
    index.Usage = D3D11_USAGE_IMMUTABLE;
    index.BindFlags = D3D11_BIND_INDEX_BUFFER;
    if (FAILED(device->CreateBuffer(&index, &data, &b.indices)))
    {
        SourceSetError("Backbuffer index allocation failed");
        return false;
    }
    D3D11_RASTERIZER_DESC raster = {};
    raster.FillMode = D3D11_FILL_SOLID;
    raster.CullMode = D3D11_CULL_NONE;
    raster.DepthClipEnable = TRUE;
    if (FAILED(device->CreateRasterizerState(&raster, &b.rasterizer)))
    {
        SourceSetError("Backbuffer rasterizer allocation failed");
        return false;
    }
    D3D11_BLEND_DESC blend = {};
    blend.RenderTarget[0].SrcBlend = blend.RenderTarget[0].SrcBlendAlpha = D3D11_BLEND_ONE;
    blend.RenderTarget[0].DestBlend = blend.RenderTarget[0].DestBlendAlpha = D3D11_BLEND_ZERO;
    blend.RenderTarget[0].BlendOp = blend.RenderTarget[0].BlendOpAlpha = D3D11_BLEND_OP_ADD;
    blend.RenderTarget[0].RenderTargetWriteMask = D3D11_COLOR_WRITE_ENABLE_ALL;
    if (FAILED(device->CreateBlendState(&blend, &b.blend)))
    {
        SourceSetError("Backbuffer blend allocation failed");
        return false;
    }
    return true;
}

static int RecreateSourceBackbuffer(Direct3D11Device* device, uint32_t width, uint32_t height, DXGI_FORMAT format,
                                    uint32_t bytesPerPixel, uint32_t samples, DXGI_FORMAT depthFormat,
                                    int32_t sourceDepthFormat, int32_t sourceSurfaceFormat)
{
    if (!SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!SourceRequireDevice(device))
        return 0;
    // Original CreateBackbuffer disposes the old backbuffer before format validation.
    device->sourceBackbuffer.reset();
    if (sourceSurfaceFormat != 0)
    {
        UINT support = 0;
        if (FAILED(device->device->CheckFormatSupport(format, &support)) || !(support & D3D11_FORMAT_SUPPORT_DISPLAY))
        {
            SourceBackendLogError("Unsupported backbuffer DXGI format");
            return 0;
        }
    }
    auto buffer = std::make_shared<Direct3D11Backbuffer>();
    buffer->device = device;
    buffer->blit = device->sourceBlitResources;
    buffer->surfaceFormat = sourceSurfaceFormat;
    buffer->samples = std::max(1u, samples);
    buffer->depthFormat = sourceDepthFormat;
    SourceGpuTexture* texture = nullptr;
    if (!SourceGpuCreateTexture(device, format, width, height, 1, 1, 1, D3D11_RESOURCE_DIMENSION_TEXTURE2D, 1,
                                bytesPerPixel, 1, 1, &texture))
        return 0;
    buffer->texture = std::shared_ptr<SourceGpuTexture>(texture, SourceGpuDisposeTexture);
    SourceGpuRenderbuffer* color = nullptr;
    if (!SourceGpuCreateRenderbuffer(device, width, height, format, buffer->samples, 0,
                                     buffer->samples > 1 ? nullptr : texture, 0, &color))
        return 0;
    buffer->color = std::shared_ptr<SourceGpuRenderbuffer>(color, SourceGpuDisposeRenderbuffer);
    if (sourceDepthFormat)
    {
        SourceGpuRenderbuffer* depth = nullptr;
        if (!SourceGpuCreateRenderbuffer(device, width, height, depthFormat, buffer->samples, sourceDepthFormat,
                                         nullptr, 0, &depth))
            return 0;
        buffer->depth = std::shared_ptr<SourceGpuRenderbuffer>(depth, SourceGpuDisposeRenderbuffer);
    }
    device->sourceBackbuffer = buffer;
    return SourceBindActualBackbuffer(device);
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuInitializeBackbuffer(Direct3D11Device* device, uint32_t width, uint32_t height,
                                                            DXGI_FORMAT format, uint32_t bytesPerPixel,
                                                            uint32_t samples, DXGI_FORMAT depthFormat,
                                                            int32_t sourceDepthFormat, int32_t sourceSurfaceFormat,
                                                            uint32_t scaleNearest)
{
    if (!SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (device->sourceBackbuffer)
    {
        SourceSetError("Source backbuffer initialization must occur once per device generation");
        return 0;
    }
    // Source creation order: create/bind the source backbuffer, then initialize
    // the original blit resources with the one actual native hint read.
    if (!RecreateSourceBackbuffer(device, width, height, format, bytesPerPixel, samples, depthFormat, sourceDepthFormat,
                                  sourceSurfaceFormat))
        return 0;
    auto blit = std::make_shared<Direct3D11BackbufferBlitResources>();
    if (!CreateBlitResources(device, *blit, scaleNearest != 0))
        return 0;
    device->sourceBlitResources = blit;
    device->sourceBackbuffer->blit = blit;
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuResetBackbuffer(Direct3D11Device* device, uint32_t width, uint32_t height,
                                                       DXGI_FORMAT format, uint32_t bytesPerPixel, uint32_t samples,
                                                       DXGI_FORMAT depthFormat, int32_t sourceDepthFormat,
                                                       int32_t sourceSurfaceFormat)
{
    if (!SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!device->sourceBlitResources)
    {
        SourceSetError("Actual source initial backbuffer/blit resources are required before Reset");
        return 0;
    }
    return RecreateSourceBackbuffer(device, width, height, format, bytesPerPixel, samples, depthFormat,
                                    sourceDepthFormat, sourceSurfaceFormat);
}

bool SourceGetActualBackbuffer(Direct3D11Device* device, uint32_t* width, uint32_t* height, DXGI_FORMAT* format,
                               uint32_t* samples, int32_t* depthFormat)
{
    auto buffer = device->sourceBackbuffer;
    if (!buffer)
        return false;
    *width = buffer->texture->width;
    *height = buffer->texture->height;
    *format = buffer->texture->format;
    *samples = buffer->samples;
    *depthFormat = buffer->depthFormat;
    return true;
}
int SourceBindActualBackbuffer(Direct3D11Device* device)
{
    auto buffer = device->sourceBackbuffer;
    if (!buffer)
    {
        SourceSetError("Source backbuffer has not been created");
        return 0;
    }
    SourceGpuRenderbuffer* color = buffer->color.get();
    return SourceGpuRecordRenderTargets(device, &color, 1, buffer->depth.get());
}
int SourceClearActualBackbuffer(Direct3D11Device* device, const float* color, uint32_t clearColor, uint32_t clearDepth,
                                uint32_t clearStencil, float depth, uint8_t stencil)
{
    auto buffer = device->sourceBackbuffer;
    if (!buffer)
        return 0;
    if (clearColor && !SourceGpuRecordClearRenderbuffer(buffer->color.get(), color, 1, 0, 0, depth, stencil))
        return 0;
    if (buffer->depth && (clearDepth || clearStencil))
        return SourceGpuRecordClearRenderbuffer(buffer->depth.get(), color, 0, clearDepth, clearStencil, depth,
                                                stencil);
    return 1;
}

SOURCE_GPU_EXPORT SourceGpuReadback* __cdecl SourceGpuReadBackbuffer(Direct3D11Device* device, uint32_t x, uint32_t y,
                                                                     uint32_t width, uint32_t height)
{
    auto buffer = device->sourceBackbuffer;
    if (!buffer)
    {
        SourceSetError("Source backbuffer has not been created");
        return nullptr;
    }
    if (buffer->samples > 1 && !SourceGpuRecordResolve(buffer->color.get(), buffer->texture.get(), 0, 0))
        return nullptr;
    return SourceGpuRecordTextureRead(buffer->texture.get(), 0, 0, x, y, 0, width, height, 1);
}

SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordPresent(Direct3D11Device* device, const SourceGpuRect* source,
                                                     const SourceGpuRect* destination)
{
    if (!SourceRequireDevice(device))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto buffer = device->sourceBackbuffer;
    if (!buffer || !buffer->blit)
    {
        SourceSetError("Source backbuffer/blit resources have not been initialized");
        return 0;
    }
    const SourceGpuRect src = source ? *source
                                     : SourceGpuRect{0, 0, static_cast<int32_t>(buffer->texture->width),
                                                     static_cast<int32_t>(buffer->texture->height)};
    const bool hasDestination = destination != nullptr;
    const SourceGpuRect dst = destination ? *destination : SourceGpuRect{};
    if (buffer->samples > 1 && !SourceGpuRecordResolve(buffer->color.get(), buffer->texture.get(), 0, 0))
        return 0;
    if (!SourceAppendPhysical(device, [device, buffer, src, dst, hasDestination]() {
            ID3D11RenderTargetView* output = nullptr;
            uint32_t width, height;
            SourceGetActualHostOutput(device, &output, &width, &height);
            if (!output || !width || !height)
            {
                SourceSetError("Actual host output is required for source Present");
                return;
            }
            Direct3D11PhysicalStateScope sourceState(device->context);
            const SourceGpuRect target =
                hasDestination ? dst : SourceGpuRect{0, 0, static_cast<int32_t>(width), static_cast<int32_t>(height)};
            float backbufferWidth = static_cast<float>(buffer->texture->width),
                  backbufferHeight = static_cast<float>(buffer->texture->height);
            const float sx0 = src.x / backbufferWidth, sy0 = src.y / backbufferHeight;
            const float sx1 = (src.x + src.width) / backbufferWidth, sy1 = (src.y + src.height) / backbufferHeight;
            const float dx0 = (target.x / static_cast<float>(width)) * 2.0f - 1.0f;
            const float dy0 = (target.y / static_cast<float>(height)) * 2.0f - 1.0f;
            const float dx1 = ((target.x + target.width) / static_cast<float>(width)) * 2.0f - 1.0f;
            const float dy1 = ((target.y + target.height) / static_cast<float>(height)) * 2.0f - 1.0f;
            const float vertices[16] = {dx0, dy0, sx0, sy0, dx1, dy0, sx1, sy0, dx1, dy1, sx1, sy1, dx0, dy1, sx0, sy1};
            D3D11_MAPPED_SUBRESOURCE mapped = {};
            if (FAILED(device->context->Map(buffer->blit->vertices, 0, D3D11_MAP_WRITE_DISCARD, 0, &mapped)))
            {
                SourceSetError("Backbuffer blit vertex upload failed");
                return;
            }
            std::memcpy(mapped.pData, vertices, sizeof(vertices));
            device->context->Unmap(buffer->blit->vertices, 0);
            UINT stride = 16, offset = 0;
            const float factor[4] = {1, 1, 1, 1};
            D3D11_VIEWPORT viewport = {0, 0, static_cast<float>(width), static_cast<float>(height), 0, 1};
            device->context->OMSetRenderTargets(1, &output, nullptr);
            // Host output textures persist between presentations. Clear uncovered
            // margins so a previous full-output presentation cannot leak through.
            const bool coversOutput = target.x <= 0 && target.y <= 0 &&
                                      static_cast<int64_t>(target.x) + target.width >= width &&
                                      static_cast<int64_t>(target.y) + target.height >= height;
            if (!coversOutput)
            {
                const float black[4] = {0, 0, 0, 1};
                device->context->ClearRenderTargetView(output, black);
            }
            device->context->IASetVertexBuffers(0, 1, &buffer->blit->vertices, &stride, &offset);
            device->context->IASetIndexBuffer(buffer->blit->indices, DXGI_FORMAT_R16_UINT, 0);
            device->context->RSSetViewports(1, &viewport);
            device->context->OMSetBlendState(buffer->blit->blend, factor, 0xffffffffu);
            device->context->OMSetDepthStencilState(nullptr, 0);
            device->context->RSSetState(buffer->blit->rasterizer);
            device->context->IASetInputLayout(buffer->blit->layout);
            device->context->VSSetShader(buffer->blit->vertexShader, nullptr, 0);
            device->context->PSSetShader(buffer->blit->pixelShader, nullptr, 0);
            device->context->PSSetShaderResources(0, 1, &buffer->texture->view);
            device->context->PSSetSamplers(0, 1, &buffer->blit->sampler);
            device->context->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
            device->context->DrawIndexed(6, 0, 0);
            sourceState.Restore();
        }))
        return 0;
    // Present temporarily binds its own IA buffers, then restores the source
    // state. Conservatively force a later source draw to reassert both inputs.
    SourceInvalidatePhysicalInputBindings(device, true, true);
    return 1;
}

SOURCE_GPU_EXPORT int32_t __cdecl SourceGpuGetBackbufferSurfaceFormat(Direct3D11Device* device)
{
    if (!SourceRequireDevice(device))
        return -1;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!device->sourceBackbuffer)
    {
        SourceSetError("Source backbuffer has not been created");
        return -1;
    }
    return device->sourceBackbuffer->surfaceFormat;
}

SOURCE_GPU_EXPORT int32_t __cdecl SourceGpuSetPresentationInterval(Direct3D11Device* device, int32_t interval)
{
    if (!SourceRequireDevice(device))
        return -1;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    switch (interval)
    {
    case 0:
    case 1:
        device->physicalPresentationSyncInterval = 1;
        break;
    case 2:
        device->physicalPresentationSyncInterval = 2;
        break;
    case 3:
        device->physicalPresentationSyncInterval = 0;
        break;
    default: {
        std::string message = "Unrecognized PresentInterval: " + std::to_string(interval);
        SourceBackendLogError(message.c_str());
        break;
    }
    }
    // The Borrowed host consumes this physical interval on its existing present loop.
    return device->physicalPresentationSyncInterval;
}
