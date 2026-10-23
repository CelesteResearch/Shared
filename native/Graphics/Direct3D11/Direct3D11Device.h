#pragma once
#include <cstdint>
#include <atomic>
#include <d3d11.h>
#include <mutex>
#include <memory>
#include <unordered_set>
#include <unordered_map>
#include <string>
#include <vector>
#include "Direct3D11ImmutableStateKey.h"
#include "mojoshader.h"
#include "Direct3D11HostApi.h"

#define SOURCE_GPU_EXPORT extern "C" __declspec(dllexport)

// Owned or borrowed D3D11 device; host integration lives outside this backend.
// It holds no SpriteBatch, source viewport, dirty state, asset list, or draw queue.
class Direct3D11PhysicalStateScope;
struct Direct3D11PhysicalVertexBindings;
struct Direct3D11HostBackbuffer;
struct Direct3D11Backbuffer;
struct Direct3D11BackbufferBlitResources;
struct SourceGpuRenderTargetBindings;
struct Direct3D11PhysicalPacket;
struct Direct3D11Effect;
struct Direct3D11Device
{
    std::atomic<uint32_t> references{1};
    ID3D11Device* device = nullptr;
    ID3D11DeviceContext* context = nullptr;
    bool ownsPhysicalDevice = false;
    std::shared_ptr<ID3D11Texture2D> frameOutput;
    std::shared_ptr<ID3D11Texture2D> frameStaging;
    uint32_t frameWidth = 0, frameHeight = 0;
    // Window is borrowed; the standalone device owns only its presentation resources.
    std::shared_ptr<IDXGISwapChain> windowSwapChain;
    std::shared_ptr<ID3D11Texture2D> windowSwapBuffer;
    HWND presentationWindow = nullptr;
    uint32_t windowSwapWidth = 0, windowSwapHeight = 0;
    MOJOSHADER_d3d11Context* shaders = nullptr;
    uint32_t renderThread = 0;
    uint64_t generation = 0;
    std::recursive_mutex physicalLock;
    std::unordered_set<Direct3D11PhysicalPacket*> physicalPackets;
    std::unordered_set<Direct3D11Effect*> physicalEffects;
    // Physical GPU continuation across unrelated host draws only.
    // No source Blend/Depth/Sampler references or next/current dirty state.
    std::shared_ptr<Direct3D11PhysicalStateScope> physicalContinuation;
    // Executor-only under physicalLock; all active bytes are saved anew for every upload.
    std::vector<uint8_t> uniformRestoreScratch;
    // The single physical Mojo backend's active effect/pass, matching FNA3D.
    MOJOSHADER_effect* currentEffect = nullptr;
    const MOJOSHADER_effectTechnique* currentTechnique = nullptr;
    uint32_t currentPass = 0;
    std::shared_ptr<Direct3D11PhysicalVertexBindings> vertexBindings;
    // Actual immutable D3D layouts; the shader loan prevents key identity reuse.
    std::unordered_map<std::string, std::pair<std::shared_ptr<ID3D11InputLayout>, std::shared_ptr<void>>> inputLayouts;
    std::unordered_map<SourceImmutableStateKey<40>, std::shared_ptr<ID3D11RasterizerState>,
                       SourceImmutableStateKeyHash<40>>
        rasterizerStates;
    std::unordered_map<SourceImmutableStateKey<52>, std::shared_ptr<ID3D11SamplerState>,
                       SourceImmutableStateKeyHash<52>>
        samplerStates;
    std::unordered_map<SourceImmutableStateKey<240>, std::shared_ptr<ID3D11BlendState>,
                       SourceImmutableStateWideKeyHash<240>>
        blendStates;
    std::unordered_map<SourceImmutableStateKey<50>, std::shared_ptr<ID3D11DepthStencilState>,
                       SourceImmutableStateWideKeyHash<50>>
        depthStencilStates;
    int32_t physicalDepthFormat = 0;
    std::shared_ptr<Direct3D11HostBackbuffer> hostBackbuffer;
    std::shared_ptr<Direct3D11Backbuffer> sourceBackbuffer;
    std::shared_ptr<Direct3D11BackbufferBlitResources> sourceBlitResources;
    std::shared_ptr<SourceGpuRenderTargetBindings> physicalTargets;
    uint32_t physicalBlendFactor = 0xffffffffu;
    int32_t physicalSampleMask = -1;
    int32_t physicalStencilReference = 0;
    int32_t physicalPresentationSyncInterval = 0;
};

struct Direct3D11Effect
{
    Direct3D11Device* device;
    uint64_t generation;
    MOJOSHADER_effect* data;
    Direct3D11Effect(Direct3D11Device* owner, uint64_t epoch, MOJOSHADER_effect* effect)
        : device(owner), generation(epoch), data(effect)
    {
        SourceGpuRetainDeviceContext(device);
    }
};

bool SourceRequireRenderThread(Direct3D11Device* device);
CELESTE_D3D11_API bool SourceRequireDevice(Direct3D11Device* device);
CELESTE_D3D11_API void SourceSetError(const char* message);
void SourceMarkPhysicalFailure();
void SourceBackendLogError(const char* message);
void SourceCaptureHostBackbuffer(Direct3D11Device* device);
bool SourceCheckEffect(Direct3D11Effect* effect);
