#include "Direct3D11Device.h"
#include "Direct3D11PhysicalStateScope.h"
#include "Direct3D11Transport.h"
#include <windows.h>
#include <string>
#include <cstdlib>
#include <new>

static std::atomic<uint64_t> nextGeneration{1};
static std::string lastError;
static std::mutex errorLock;
using SourceGpuLogFunction = void(__cdecl*)(const char*);
static SourceGpuLogFunction logInfo = nullptr, logWarning = nullptr, logError = nullptr;

SOURCE_GPU_EXPORT void __cdecl SourceGpuHookLogFunctions(SourceGpuLogFunction info, SourceGpuLogFunction warning,
                                                         SourceGpuLogFunction error)
{
    logInfo = info;
    logWarning = warning;
    logError = error;
}

void SourceBackendLogError(const char* message)
{
    if (logError)
        logError(message);
    else
        SourceSetError("Actual source FNA logging callbacks have not been initialized");
}

void SourceSetError(const char* message)
{
    SourceMarkPhysicalFailure();
    std::lock_guard<std::mutex> lock(errorLock);
    lastError = message ? message : "Unknown physical graphics error";
}
SOURCE_GPU_EXPORT const char* __cdecl SourceGpuGetLastError()
{
    static thread_local std::string result;
    std::lock_guard<std::mutex> lock(errorLock);
    result = lastError;
    return result.c_str();
}

bool SourceRequireDevice(Direct3D11Device* device)
{
    if (!device || !device->device || !device->context || !device->shaders)
    {
        SourceSetError("D3D11 device is not initialized");
        return false;
    }
    return true;
}
bool SourceRequireRenderThread(Direct3D11Device* device)
{
    if (!SourceRequireDevice(device))
        return false;
    if (device->renderThread != GetCurrentThreadId())
    {
        SourceSetError("Physical rendering must execute on the assigned render thread");
        return false;
    }
    return true;
}

static void ShutdownPhysicalDevice(Direct3D11Device* device)
{
    if (!device->device && !device->context && !device->shaders)
        return;
    // Invalidate pending physical work before its shader context disappears.
    // Packet handles retain their observer/event loans until each owner releases.
    for (auto packet : device->physicalPackets)
    {
        packet->completion.store(-1, std::memory_order_release);
        packet->writes.clear();
        packet->lastUniforms.reset();
    }
    std::vector<uint8_t>().swap(device->uniformRestoreScratch);
    if (device->currentEffect)
    {
        MOJOSHADER_effectEndPass(device->currentEffect);
        MOJOSHADER_effectEnd(device->currentEffect);
    }
    for (auto effect : device->physicalEffects)
    {
        if (effect->data)
            MOJOSHADER_deleteEffect(effect->data);
        effect->data = nullptr;
    }
    device->physicalContinuation.reset();
    device->vertexBindings.reset();
    device->inputLayouts.clear();
    device->rasterizerStates.clear();
    device->samplerStates.clear();
    device->blendStates.clear();
    device->depthStencilStates.clear();
    device->hostBackbuffer.reset();
    device->sourceBackbuffer.reset();
    device->sourceBlitResources.reset();
    device->physicalTargets.reset();
    device->currentEffect = nullptr;
    device->currentTechnique = nullptr;
    if (device->shaders)
        MOJOSHADER_d3d11DestroyContext(device->shaders);
    if (device->context)
    {
        if (device->ownsPhysicalDevice)
        {
            device->context->ClearState();
            device->context->Flush();
        }
        device->context->Release();
    }
    device->windowSwapBuffer.reset();
    device->windowSwapChain.reset();
    device->presentationWindow = nullptr;
    device->windowSwapWidth = device->windowSwapHeight = 0;
    device->frameOutput.reset();
    device->frameStaging.reset();
    device->frameWidth = device->frameHeight = 0;
    if (device->device)
        device->device->Release();
    device->shaders = nullptr;
    device->context = nullptr;
    device->device = nullptr;
    device->ownsPhysicalDevice = false;
    device->generation = nextGeneration.fetch_add(1, std::memory_order_relaxed);
}

SOURCE_GPU_EXPORT uint64_t __cdecl SourceGpuDeviceGeneration(Direct3D11Device* device)
{
    return device ? device->generation : 0;
}
SOURCE_GPU_EXPORT void* __cdecl SourceGpuAllocate(uint32_t bytes)
{
    return std::malloc(bytes);
}
SOURCE_GPU_EXPORT void __cdecl SourceGpuFree(void* pointer)
{
    std::free(pointer);
}

SOURCE_GPU_EXPORT Direct3D11Device* __cdecl SourceGpuCreateDeviceContext()
{
    auto device = new (std::nothrow) Direct3D11Device;
    if (!device)
    {
        SourceSetError("D3D11 device context allocation failed");
        return nullptr;
    }
    device->generation = nextGeneration.fetch_add(1, std::memory_order_relaxed);
    return device;
}

SOURCE_GPU_EXPORT void __cdecl SourceGpuRetainDeviceContext(Direct3D11Device* device)
{
    if (device)
        device->references.fetch_add(1, std::memory_order_relaxed);
}

SOURCE_GPU_EXPORT void __cdecl SourceGpuReleaseDeviceContext(Direct3D11Device* device)
{
    if (!device || device->references.fetch_sub(1, std::memory_order_acq_rel) != 1)
        return;
    {
        std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
        ShutdownPhysicalDevice(device);
    }
    delete device;
}

SOURCE_GPU_EXPORT void __cdecl SourceGpuDestroySourceDevice(Direct3D11Device* device)
{
    if (!device)
        return;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    ShutdownPhysicalDevice(device);
}

static bool InitializePhysicalDevice(Direct3D11Device* device)
{
    device->renderThread = GetCurrentThreadId();
    device->generation = nextGeneration.fetch_add(1, std::memory_order_relaxed);
    device->physicalBlendFactor = 0xffffffffu;
    device->physicalSampleMask = -1;
    device->physicalStencilReference = 0;
    device->physicalDepthFormat = 0;
    device->physicalPresentationSyncInterval = 0;
    device->currentPass = 0;
    device->shaders = MOJOSHADER_d3d11CreateContext(device->device, device->context, nullptr, nullptr, nullptr);
    if (device->shaders)
        return true;
    SourceSetError("D3D11 MojoShader context creation failed");
    ShutdownPhysicalDevice(device);
    return false;
}

SOURCE_GPU_EXPORT Direct3D11Device* __cdecl SourceGpuAttachD3D11Device(Direct3D11Device* device,
                                                                       ID3D11Device* borrowedDevice)
{
    if (!device || !borrowedDevice)
    {
        SourceSetError("Source and host D3D11 devices are required");
        return nullptr;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (device->device)
    {
        if (!device->ownsPhysicalDevice && device->device == borrowedDevice)
            return SourceRequireDevice(device) ? device : nullptr;
        SourceSetError("Destroy this source context before attaching another physical device");
        return nullptr;
    }
    borrowedDevice->AddRef();
    device->device = borrowedDevice;
    borrowedDevice->GetImmediateContext(&device->context);
    device->ownsPhysicalDevice = false;
    return InitializePhysicalDevice(device) ? device : nullptr;
}

SOURCE_GPU_EXPORT Direct3D11Device* __cdecl SourceGpuEnsureSourceDevice(Direct3D11Device* device)
{
    if (!device)
    {
        SourceSetError("A source D3D11 context is required");
        return nullptr;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (!device->device)
    {
        D3D_FEATURE_LEVEL level;
        const D3D_FEATURE_LEVEL levels[] = {D3D_FEATURE_LEVEL_11_0};
        HRESULT status = D3D11CreateDevice(nullptr, D3D_DRIVER_TYPE_HARDWARE, nullptr, 0, levels, 1, D3D11_SDK_VERSION,
                                           &device->device, &level, &device->context);
        if (FAILED(status))
        {
            SourceSetError("Independent D3D11 hardware device creation failed");
            return nullptr;
        }
        device->ownsPhysicalDevice = true;
        if (!InitializePhysicalDevice(device))
            return nullptr;
    }
    return SourceRequireDevice(device) ? device : nullptr;
}
