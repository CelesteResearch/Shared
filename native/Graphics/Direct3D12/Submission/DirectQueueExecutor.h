#pragma once
#include "SubmissionExecutor.h"
namespace Celeste::Graphics::Direct3D12
{
    class DirectQueueExecutor final : public SubmissionExecutor
    {
        std::shared_ptr<DeviceContext> context;
        Microsoft::WRL::ComPtr<ID3D12CommandQueue> queue;
        Microsoft::WRL::ComPtr<ID3D12Fence> fence;
        uint64_t nextValue = 1;

      public:
        explicit DirectQueueExecutor(std::shared_ptr<DeviceContext> context, ID3D12CommandQueue* borrowed = nullptr);
        FenceTicket Execute(ID3D12GraphicsCommandList* commands) override;
        FenceTicket SignalCompletion();
    };
}
