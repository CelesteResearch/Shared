#pragma once
#include "CelesteGraphicsDirect3D12Window.h"
#include "CelesteGraphicsDevice.h"
#include "DirectQueueExecutor.h"
#include <dxgi1_6.h>
#include <array>

struct CelesteDirect3D12Window final
{
    static constexpr uint32_t BufferCount = 3;
    CelesteGraphicsDevice* device = nullptr;
    std::shared_ptr<Celeste::Graphics::Direct3D12::DirectQueueExecutor> executor;
    Microsoft::WRL::ComPtr<IDXGISwapChain3> swapchain;
    std::array<Microsoft::WRL::ComPtr<ID3D12Resource>, BufferCount> buffers;
    std::array<CelesteGraphicsSubmission*, BufferCount> pending{};
    uint32_t width = 0, height = 0, interval = 1, index = 0;
    bool drawable = false, acquired = false, outputSubmitted = false, tearing = false;
    explicit CelesteDirect3D12Window(const CelesteDirect3D12WindowInfo&);
    ~CelesteDirect3D12Window();
    void Drain();
    void Resize(uint32_t newWidth, uint32_t newHeight, uint32_t newInterval);
    void Acquire(CelesteGraphicsOutput**);
    void Submit(CelesteGraphicsPacket*, bool wait);
    bool Present(bool enabled);

  private:
    void LoadBuffers();
};
