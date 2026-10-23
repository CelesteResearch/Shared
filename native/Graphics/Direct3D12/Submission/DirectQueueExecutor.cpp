#include "DirectQueueExecutor.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    DirectQueueExecutor::DirectQueueExecutor(std::shared_ptr<DeviceContext> owner, ID3D12CommandQueue* borrowed)
        : context(std::move(owner)), queue(borrowed)
    {
        if (!context)
            throw std::invalid_argument("Missing queue device");
        if (queue)
        {
            Microsoft::WRL::ComPtr<ID3D12Device> actual;
            CheckResult(queue->GetDevice(IID_PPV_ARGS(&actual)), "Queue GetDevice");
            if (actual.Get() != context->device.Get() || queue->GetDesc().Type != D3D12_COMMAND_LIST_TYPE_DIRECT)
                throw std::invalid_argument("Borrowed queue must be DIRECT and belong to the device");
        }
        else
        {
            D3D12_COMMAND_QUEUE_DESC info{};
            info.Type = D3D12_COMMAND_LIST_TYPE_DIRECT;
            CheckResult(context->device->CreateCommandQueue(&info, IID_PPV_ARGS(&queue)), "CreateCommandQueue");
        }
        CheckResult(context->device->CreateFence(0, D3D12_FENCE_FLAG_NONE, IID_PPV_ARGS(&fence)), "CreateFence");
    }
    FenceTicket DirectQueueExecutor::Execute(ID3D12GraphicsCommandList* commands)
    {
        if (!commands || nextValue == UINT64_MAX)
            throw std::invalid_argument("Invalid D3D12 command submission");
        context->CheckAlive();

        ID3D12CommandList* lists[] = {commands};
        queue->ExecuteCommandLists(1, lists);
        return SignalCompletion();
    }
    FenceTicket DirectQueueExecutor::SignalCompletion()
    {
        if (nextValue == UINT64_MAX)
            throw std::overflow_error("Fence value exhausted");
        const uint64_t value = nextValue++;
        CheckResult(queue->Signal(fence.Get(), value), "Queue Signal");
        return {fence, value};
    }
}
