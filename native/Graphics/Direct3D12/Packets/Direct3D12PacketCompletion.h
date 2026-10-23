#pragma once
#include "SubmissionCompletion.h"
#include <atomic>
#include <stdexcept>
struct Direct3D12PacketCompletion
{
    std::atomic<int> phase{0}; // 0 queued, 1 submitted with real fence, 2 canceled/failed.
    std::shared_ptr<Celeste::Graphics::Direct3D12::SubmissionCompletion> submission;
    void Publish(std::shared_ptr<Celeste::Graphics::Direct3D12::SubmissionCompletion> value)
    {
        submission = std::move(value);
        phase.store(1, std::memory_order_release);
    }
    void Cancel() noexcept
    {
        phase.store(2, std::memory_order_release);
    }
    bool Ready() const
    {
        const int state = phase.load(std::memory_order_acquire);
        if (state == 2)
            throw std::runtime_error("The resource readback packet was canceled");
        return state == 1 && submission->IsComplete();
    }
};
