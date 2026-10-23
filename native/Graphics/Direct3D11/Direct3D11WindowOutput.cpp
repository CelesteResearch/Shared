#include "Direct3D11Commands.h"
#include <windows.h>
#include <memory>
#include <mutex>

// Borrow a host-owned HWND, retaining the same original complete-frame blit.
SOURCE_GPU_EXPORT int __cdecl SourceGpuConfigureWindowOutput(Direct3D11Device* device, HWND window, uint32_t width,
                                                             uint32_t height)
{
    if (!SourceRequireRenderThread(device) || !device->ownsPhysicalDevice || !window || !IsWindow(window))
    {
        SourceSetError("An existing host window and owned source device are required");
        return 0;
    }
    if (!SourceGpuConfigureFrameOutput(device, width, height))
        return 0;
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    if (device->windowSwapChain && window != device->presentationWindow)
    {
        SourceSetError("The source presentation window cannot change within a device generation");
        return 0;
    }
    if (device->windowSwapBuffer && width == device->windowSwapWidth && height == device->windowSwapHeight)
        return 1;
    if (!device->windowSwapChain)
    {
        IDXGIDevice* dxgiDevice = nullptr;
        IDXGIAdapter* adapter = nullptr;
        IDXGIFactory* factory = nullptr;
        HRESULT status = device->device->QueryInterface(__uuidof(IDXGIDevice), reinterpret_cast<void**>(&dxgiDevice));
        if (SUCCEEDED(status))
            status = dxgiDevice->GetAdapter(&adapter);
        if (SUCCEEDED(status))
            status = adapter->GetParent(__uuidof(IDXGIFactory), reinterpret_cast<void**>(&factory));
        if (dxgiDevice)
            dxgiDevice->Release();
        if (adapter)
            adapter->Release();
        if (FAILED(status))
        {
            if (factory)
                factory->Release();
            SourceSetError("Source device DXGI factory query failed");
            return 0;
        }
        DXGI_SWAP_CHAIN_DESC desc = {};
        desc.BufferDesc.Width = width;
        desc.BufferDesc.Height = height;
        desc.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
        desc.SampleDesc.Count = 1;
        desc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
        desc.BufferCount = 1;
        desc.OutputWindow = window;
        desc.Windowed = TRUE;
        desc.SwapEffect = DXGI_SWAP_EFFECT_DISCARD;
        IDXGISwapChain* swap = nullptr;
        status = factory->CreateSwapChain(device->device, &desc, &swap);
        if (SUCCEEDED(status))
            status = factory->MakeWindowAssociation(window, DXGI_MWA_NO_ALT_ENTER | DXGI_MWA_NO_WINDOW_CHANGES);
        factory->Release();
        if (FAILED(status))
        {
            if (swap)
                swap->Release();
            SourceSetError("Borrowed host window swapchain creation failed");
            return 0;
        }
        device->windowSwapChain =
            std::shared_ptr<IDXGISwapChain>(swap, [](IDXGISwapChain* value) { value->Release(); });
        device->presentationWindow = window;
    }
    else if (width != device->windowSwapWidth || height != device->windowSwapHeight)
    {
        // The swap buffer is only a CopyResource destination, never a bound RTV/SRV.
        // Therefore this is its sole retained resource loan; source state stays intact.
        device->windowSwapBuffer.reset();
        if (FAILED(device->windowSwapChain->ResizeBuffers(1, width, height, DXGI_FORMAT_UNKNOWN, 0)))
        {
            SourceSetError("Borrowed host window swapchain resize failed");
            return 0;
        }
    }
    // Keep the successful size even if GetBuffer fails; retry acquisition without
    // treating a failed view acquisition as a completed output or resizing again.
    device->windowSwapWidth = width;
    device->windowSwapHeight = height;
    ID3D11Texture2D* buffer = nullptr;
    if (FAILED(device->windowSwapChain->GetBuffer(0, __uuidof(ID3D11Texture2D), reinterpret_cast<void**>(&buffer))))
    {
        SourceSetError("Borrowed host window swap buffer acquisition failed");
        return 0;
    }
    device->windowSwapBuffer =
        std::shared_ptr<ID3D11Texture2D>(buffer, [](ID3D11Texture2D* value) { value->Release(); });
    return 1;
}
SOURCE_GPU_EXPORT int __cdecl SourceGpuPresentWindowOutput(Direct3D11Device* device)
{
    if (!SourceRequireRenderThread(device) || !device->windowSwapChain || !device->windowSwapBuffer ||
        !device->frameOutput || SourceCurrentPhysicalPacket())
    {
        SourceSetError("A completed source frame and borrowed window swapchain are required");
        return 0;
    }
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    // A minimized host retains resources and simulation. Never resize to zero or wait on visibility.
    if (IsIconic(device->presentationWindow))
        return 1;
    // PresentCompleted is called after SubmitAndWait and release of its owner packet.
    device->context->CopyResource(device->windowSwapBuffer.get(), device->frameOutput.get());
    HRESULT status = device->windowSwapChain->Present(device->physicalPresentationSyncInterval, 0);
    if (FAILED(status))
    {
        SourceSetError("Borrowed host window presentation failed");
        return 0;
    }
    return 1; // DXGI_STATUS_OCCLUDED is a successful visibility status, not a simulation failure.
}
