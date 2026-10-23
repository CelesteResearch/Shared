#pragma once
#include "CommandLease.h"
#include "SubmissionExecutor.h"
#include "SubmissionCompletion.h"
namespace Celeste::Graphics::Direct3D12
{
    class SubmissionQueue
    {
        struct Pending
        {
            std::unique_ptr<CommandLease> lease;
            std::shared_ptr<SubmissionCompletion> completion;
        };
        std::shared_ptr<DeviceContext> context;
        std::shared_ptr<SubmissionExecutor> executor;
        std::vector<Pending> pending;
        std::vector<std::unique_ptr<CommandLease>> available;
        bool uncertain = false;
        SubmissionQueue(std::shared_ptr<DeviceContext> context, std::shared_ptr<SubmissionExecutor> executor);
        ~SubmissionQueue() = default;

      public:
        SubmissionQueue(const SubmissionQueue&) = delete;
        SubmissionQueue& operator=(const SubmissionQueue&) = delete;
        // Explicit checked destruction: failed drain keeps the handle and every GPU loan alive.
        static SubmissionQueue* Create(std::shared_ptr<DeviceContext> context,
                                       std::shared_ptr<SubmissionExecutor> executor);
        static void Destroy(SubmissionQueue*& queue);
        std::unique_ptr<CommandLease> Begin();
        std::shared_ptr<SubmissionCompletion> Submit(std::unique_ptr<CommandLease> lease);
        std::shared_ptr<SubmissionCompletion> PrepareExternal(std::unique_ptr<CommandLease> lease);
        void CommitExternal(const std::shared_ptr<SubmissionCompletion>& completion, FenceTicket ticket);
        void CancelExternal(const std::shared_ptr<SubmissionCompletion>& completion);
        void Collect();
        void Drain();
        // Host supplies a fence after every possibly-enqueued list when Execute failed.
        void RecoverUncertain(FenceTicket completion);
    };
}
