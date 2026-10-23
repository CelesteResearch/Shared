#pragma once
#include "Direct3D11Device.h"
#include <atomic>
#include <vector>

// Opaque physical resource handles. These are the one native resource owner;
// the managed source resource stores only this pointer, not another table.
struct SourceGpuTexture
{
    Direct3D11Device* device;
    uint64_t generation;
    ID3D11Resource* resource = nullptr;
    ID3D11ShaderResourceView* view = nullptr;
    std::vector<ID3D11RenderTargetView*> colorViews;
    DXGI_FORMAT format;
    uint32_t width, height, depth, levels, arraySize;
    uint32_t bytesPerBlock, blockWidth, blockHeight;
    D3D11_RESOURCE_DIMENSION dimension;
    std::atomic<uint32_t> references{1};
    explicit SourceGpuTexture(Direct3D11Device* owner) : device(owner), generation(owner->generation)
    {
        SourceGpuRetainDeviceContext(device);
    }
    ~SourceGpuTexture()
    {
        for (auto color : colorViews)
            if (color)
                color->Release();
        if (view)
            view->Release();
        if (resource)
            resource->Release();
        SourceGpuReleaseDeviceContext(device);
    }
};

struct SourceGpuRenderbuffer
{
    Direct3D11Device* device;
    uint64_t generation;
    ID3D11Texture2D* resource = nullptr;
    ID3D11RenderTargetView* colorView = nullptr;
    ID3D11DepthStencilView* depthView = nullptr;
    DXGI_FORMAT format;
    int32_t sourceDepthFormat = 0;
    uint32_t width, height, samples;
    std::atomic<uint32_t> references{1};
    explicit SourceGpuRenderbuffer(Direct3D11Device* owner) : device(owner), generation(owner->generation)
    {
        SourceGpuRetainDeviceContext(device);
    }
    ~SourceGpuRenderbuffer()
    {
        if (colorView)
            colorView->Release();
        if (depthView)
            depthView->Release();
        if (resource)
            resource->Release();
        SourceGpuReleaseDeviceContext(device);
    }
};

struct SourceGpuReadback
{
    std::vector<uint8_t> bytes;
    std::atomic<int32_t> completion{0};
    std::atomic<uint32_t> references{1};
};

// Exact SourceNativeRenderTargetBinding/FNA3D x64 physical binding layout.
struct SourceGpuTargetBinding
{
    uint8_t type;
    int32_t data1, data2, levelCount, multiSampleCount;
    SourceGpuTexture* texture;
    SourceGpuRenderbuffer* colorBuffer;
};
static_assert(sizeof(SourceGpuTargetBinding) == 40);
static_assert(offsetof(SourceGpuTargetBinding, texture) == 24);
static_assert(offsetof(SourceGpuTargetBinding, colorBuffer) == 32);

struct SourceGpuRect
{
    int32_t x, y, width, height;
};
bool SourceGetActualBackbuffer(Direct3D11Device*, uint32_t*, uint32_t*, DXGI_FORMAT*, uint32_t*, int32_t*);
int SourceBindActualBackbuffer(Direct3D11Device*);
int SourceClearActualBackbuffer(Direct3D11Device*, const float*, uint32_t, uint32_t, uint32_t, float, uint8_t);
void SourceGetActualHostOutput(Direct3D11Device*, ID3D11RenderTargetView**, uint32_t*, uint32_t*);
