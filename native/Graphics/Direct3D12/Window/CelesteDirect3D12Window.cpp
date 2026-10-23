#include "CelesteDirect3D12Window.h"
#include "CelesteGraphicsPacket.h"
#include <algorithm>
#include <stdexcept>

using namespace Celeste::Graphics::Direct3D12;
using Microsoft::WRL::ComPtr;
static void Require(int32_t result)
{
    if (result != 1)
        throw std::runtime_error(CelesteDirect3D12GetLastError());
}

CelesteDirect3D12Window::CelesteDirect3D12Window(const CelesteDirect3D12WindowInfo& info)
{
    if (!info.window || info.interval > 2)
        throw std::invalid_argument("Invalid HWND or presentation interval");
    auto owner = std::make_unique<CelesteGraphicsDevice>();
    owner->context = DeviceContext::CreateOwned();
    D3D12_COMMAND_QUEUE_DESC queueInfo{};
    queueInfo.Type = D3D12_COMMAND_LIST_TYPE_DIRECT;
    ComPtr<ID3D12CommandQueue> queue;
    CheckResult(owner->context->device->CreateCommandQueue(&queueInfo, IID_PPV_ARGS(&queue)), "Create window queue");
    executor = std::make_shared<DirectQueueExecutor>(owner->context, queue.Get());
    ComPtr<IDXGIFactory5> factory;
    CheckResult(CreateDXGIFactory1(IID_PPV_ARGS(&factory)), "Create window factory");
    BOOL supported = FALSE;
    tearing =
        SUCCEEDED(factory->CheckFeatureSupport(DXGI_FEATURE_PRESENT_ALLOW_TEARING, &supported, sizeof(supported))) &&
        supported;
    width = std::max(1u, info.width);
    height = std::max(1u, info.height);
    interval = info.interval;
    drawable = info.width != 0 && info.height != 0;
    DXGI_SWAP_CHAIN_DESC1 description{};
    description.Width = width;
    description.Height = height;
    description.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
    description.SampleDesc.Count = 1;
    description.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
    description.BufferCount = BufferCount;
    description.SwapEffect = DXGI_SWAP_EFFECT_FLIP_DISCARD;
    description.Flags = tearing ? DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING : 0;
    ComPtr<IDXGISwapChain1> created;
    CheckResult(factory->CreateSwapChainForHwnd(queue.Get(), info.window, &description, nullptr, nullptr, &created),
                "Create window swapchain");
    CheckResult(factory->MakeWindowAssociation(info.window, DXGI_MWA_NO_ALT_ENTER), "Disable DXGI Alt+Enter");
    CheckResult(created.As(&swapchain), "Query swapchain3");
    LoadBuffers();
    owner->submissions = SubmissionQueue::Create(owner->context, executor);
    device = owner.release();
}

CelesteDirect3D12Window::~CelesteDirect3D12Window()
{
    const auto* api = CelesteDirect3D12GetDeviceApi();
    for (auto* completion : pending)
        if (completion)
            api->ReleaseSubmission(completion);
    // DestroyWindow performs the fallible drain before deleting this object.
}

void CelesteDirect3D12Window::LoadBuffers()
{
    for (uint32_t i = 0; i < BufferCount; ++i)
        CheckResult(swapchain->GetBuffer(i, IID_PPV_ARGS(&buffers[i])), "Get swapchain image");
}

void CelesteDirect3D12Window::Drain()
{
    device->submissions->Drain();
    executor->SignalCompletion().Wait(*device->context);
    const auto* api = CelesteDirect3D12GetDeviceApi();
    for (auto*& completion : pending)
    {
        if (completion)
            api->ReleaseSubmission(completion);
        completion = nullptr;
    }
}

void CelesteDirect3D12Window::Resize(uint32_t newWidth, uint32_t newHeight, uint32_t newInterval)
{
    if (acquired)
        throw std::logic_error("Cannot resize with an outstanding acquired output");
    if (newInterval > 2)
        throw std::invalid_argument("Unsupported presentation interval");
    interval = newInterval;
    drawable = newWidth != 0 && newHeight != 0;
    if (!drawable || (newWidth == width && newHeight == height))
        return;
    // Called before a new frame; caller must release its previous output loan.
    Drain();
    acquired = false;
    for (auto& buffer : buffers)
        buffer.Reset();
    const HRESULT resized = swapchain->ResizeBuffers(BufferCount, newWidth, newHeight, DXGI_FORMAT_R8G8B8A8_UNORM,
                                                     tearing ? DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING : 0);
    if (FAILED(resized))
    {
        LoadBuffers();
        CheckResult(resized, "Resize swapchain buffers");
    }
    width = newWidth;
    height = newHeight;
    LoadBuffers();
}

void CelesteDirect3D12Window::Acquire(CelesteGraphicsOutput** output)
{
    if (!output)
        throw std::invalid_argument("Missing output pointer");
    if (acquired)
        throw std::logic_error("An output is already acquired");
    *output = nullptr;
    index = swapchain->GetCurrentBackBufferIndex();
    const auto* api = CelesteDirect3D12GetDeviceApi();
    if (pending[index])
    {
        // Wait only when reusing an in-flight swapchain image, never device-wide per frame.
        Require(api->Wait(pending[index]));
        api->ReleaseSubmission(pending[index]);
        pending[index] = nullptr;
    }
    CelesteDirect3D12OutputInfo info{
        buffers[index].Get(),        0, width, height, DXGI_FORMAT_R8G8B8A8_UNORM, D3D12_RESOURCE_STATE_PRESENT,
        D3D12_RESOURCE_STATE_PRESENT};
    Require(CelesteDirect3D12AcquireOutput(device, &info, output));
    acquired = true;
    outputSubmitted = false;
}

void CelesteDirect3D12Window::Submit(CelesteGraphicsPacket* packet, bool wait)
{
    if (!packet || &packet->device != device)
        throw std::invalid_argument("Packet belongs to another window device");
    const auto* api = CelesteDirect3D12GetDeviceApi();
    CelesteGraphicsSubmission* completion = nullptr;
    const bool writesOutput =
        acquired && std::any_of(packet->storage->outputStates.begin(), packet->storage->outputStates.end(),
                                [&](const auto& state) { return state.resource == buffers[index].Get(); });
    Require(api->Submit(packet, &completion));
    if (writesOutput)
    {
        if (pending[index])
            api->ReleaseSubmission(pending[index]);
        pending[index] = completion;
        outputSubmitted = true;
        if (wait)
            Require(api->Wait(completion));
    }
    else
    {
        const int32_t result = wait ? api->Wait(completion) : 1;
        api->ReleaseSubmission(completion);
        Require(result);
    }
}

bool CelesteDirect3D12Window::Present(bool enabled)
{
    if (!acquired || !outputSubmitted)
        throw std::logic_error("Present requires a submitted acquired output");
    acquired = false;
    outputSubmitted = false;
    // The minimized path keeps rendering to the last valid image; no zero-sized swapchain is created.
    if (!drawable || !enabled)
        return false;
    const HRESULT result = swapchain->Present(interval, !interval && tearing ? DXGI_PRESENT_ALLOW_TEARING : 0);
    if (result == DXGI_STATUS_OCCLUDED)
        return false;
    CheckResult(result, "Present swapchain");
    return true;
}
