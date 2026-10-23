#pragma once
#include "FenceTicket.h"
namespace Celeste::Graphics::Direct3D12
{
    class SubmissionExecutor
    {
      public:
        virtual ~SubmissionExecutor() = default;
        // All preparation before this call. On failure, work may already have been enqueued;
        // the queue retains the entire lease until explicit recovery or device removal.
        virtual FenceTicket Execute(ID3D12GraphicsCommandList* commands) = 0;
    };
}
