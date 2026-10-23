#pragma once
#include "Direct3D11Device.h"
#include <functional>
#include <memory>
#include <vector>
#include <atomic>

struct ShaderUniformSnapshot;

// Physical command order only. Source SpriteBatch owns all batching and sorting.
// Each callback owns immutable argument bytes and native resource references.
struct Direct3D11PhysicalPacket
{
    explicit Direct3D11PhysicalPacket(Direct3D11Device* owner) : device(owner), generation(owner->generation)
    {
        SourceGpuRetainDeviceContext(device);
    }
    ~Direct3D11PhysicalPacket();
    Direct3D11Device* device;
    uint64_t generation;
    std::vector<std::function<void()>> writes;
    std::shared_ptr<ShaderUniformSnapshot> lastUniforms;
    Direct3D11Device* lastRasterizerDevice = nullptr;
    ID3D11RasterizerState* lastRasterizerState = nullptr;
    // Packet-local input bindings. The first binding in every packet remains explicit.
    const Direct3D11PhysicalVertexBindings* lastVertexBindings = nullptr;
    ID3D11Buffer* lastIndexBuffer = nullptr;
    DXGI_FORMAT lastIndexFormat = DXGI_FORMAT_UNKNOWN;
    uint32_t lastIndexOffset = 0;
    bool hasIndexBinding = false;
    std::atomic<uint32_t> references{1};
    std::atomic<int> completion{0};
};

Direct3D11PhysicalPacket* SourceCurrentPhysicalPacket();
bool SourceRequirePhysicalScope(Direct3D11Device* device);
bool SourceAppendPhysical(Direct3D11Device* device, std::function<void()> write);
bool SourceAppendPhysicalRasterizer(Direct3D11Device* device, std::shared_ptr<ID3D11RasterizerState> state);
bool SourceCanAppendPhysicalPacketLocked(Direct3D11Device* device);
void SourceInvalidatePhysicalInputBindings(Direct3D11Device* device, bool vertex, bool index);
// Internal held-lock entries; retain the same qualification and recording algorithms.
bool SourceAppendPhysicalDeviceLocked(Direct3D11Device* heldDevice, std::function<void()> write);
Direct3D11PhysicalPacket* SourceBorrowOrBeginPhysicalPacketLocked(Direct3D11Device* device, uint32_t* ownsScope);
void SourceCaptureEffectUniforms(const void* context);
