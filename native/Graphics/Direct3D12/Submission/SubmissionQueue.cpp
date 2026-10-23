#include "SubmissionQueue.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    SubmissionQueue::SubmissionQueue(std::shared_ptr<DeviceContext> owner,
                                     std::shared_ptr<SubmissionExecutor> execution)
        : context(std::move(owner)), executor(std::move(execution))
    {
        if (!context)
            throw std::invalid_argument("Missing submission context or executor");
    }
    SubmissionQueue* SubmissionQueue::Create(std::shared_ptr<DeviceContext> context,
                                             std::shared_ptr<SubmissionExecutor> executor)
    {
        return new SubmissionQueue(std::move(context), std::move(executor));
    }
    void SubmissionQueue::Destroy(SubmissionQueue*& queue)
    {
        if (!queue)
            return;
        queue->Drain();
        delete queue;
        queue = nullptr;
    }
    std::unique_ptr<CommandLease> SubmissionQueue::Begin()
    {
        if (uncertain)
            throw std::logic_error("Recover the failed submission before recording more work");
        Collect();
        if (available.empty())
            return std::make_unique<CommandLease>(context);
        auto lease = std::move(available.back());
        available.pop_back();
        lease->Recycle();
        return lease;
    }
    std::shared_ptr<SubmissionCompletion> SubmissionQueue::PrepareExternal(std::unique_ptr<CommandLease> lease)
    {
        if (uncertain || !lease || &lease->Context() != context.get())
            throw std::invalid_argument("Invalid command lease or unresolved submission");
        lease->Close();
        auto completion = std::make_shared<SubmissionCompletion>(context, FenceTicket{});
        pending.push_back({std::move(lease), completion});
        uncertain = true;
        return completion;
    }
    void SubmissionQueue::CommitExternal(const std::shared_ptr<SubmissionCompletion>& completion, FenceTicket ticket)
    {
        if (!uncertain || pending.empty() || pending.back().completion != completion || !ticket.fence || !ticket.value)
            throw std::invalid_argument("Invalid prepared submission completion");
        Microsoft::WRL::ComPtr<ID3D12Device> actual;
        CheckResult(ticket.fence->GetDevice(IID_PPV_ARGS(&actual)), "Fence GetDevice");
        if (actual.Get() != context->device.Get())
            throw std::invalid_argument("Completion fence belongs to another device");
        *completion = SubmissionCompletion(context, std::move(ticket));
        uncertain = false;
    }
    void SubmissionQueue::CancelExternal(const std::shared_ptr<SubmissionCompletion>& completion)
    {
        if (!uncertain || pending.empty() || pending.back().completion != completion)
            throw std::invalid_argument("Invalid prepared submission cancellation");
        // Caller proves the list was never executed. GPU-submitted failures use a recovery fence instead.
        pending.pop_back();
        uncertain = false;
    }
    std::shared_ptr<SubmissionCompletion> SubmissionQueue::Submit(std::unique_ptr<CommandLease> lease)
    {
        if (!executor)
            throw std::logic_error("Host-owned execution uses prepare/commit");
        auto completion = PrepareExternal(std::move(lease));
        auto ticket = executor->Execute(pending.back().lease->List());
        CommitExternal(completion, std::move(ticket));
        return completion;
    }
    void SubmissionQueue::Collect()
    {
        for (size_t i = 0; i < pending.size();)
        {
            if (uncertain && i + 1 == pending.size())
                break;
            if (!pending[i].completion->IsComplete())
            {
                ++i;
                continue;
            }
            pending[i].lease->retained.clear();
            available.push_back(std::move(pending[i].lease));
            pending.erase(pending.begin() + i);
        }
    }
    void SubmissionQueue::Drain()
    {
        if (FAILED(context->device->GetDeviceRemovedReason()))
        {
            // Device removal means the GPU no longer executes these resource loans.
            pending.clear();
            available.clear();
            uncertain = false;
            return;
        }
        if (uncertain)
            throw std::logic_error("Failed host submission requires a recovery fence before release");
        for (const auto& entry : pending)
            entry.completion->Wait();
        pending.clear();
        available.clear();
    }
    void SubmissionQueue::RecoverUncertain(FenceTicket ticket)
    {
        if (!uncertain || pending.empty() || !ticket.fence || !ticket.value)
            throw std::invalid_argument("Missing uncertain submission or recovery fence");
        *pending.back().completion = SubmissionCompletion(context, std::move(ticket));
        uncertain = false;
    }
}
