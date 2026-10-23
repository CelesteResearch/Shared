#pragma once
#include "FenceTicket.h"
namespace Celeste::Graphics::Direct3D12
{
    class SubmissionCompletion
    {
        std::shared_ptr<DeviceContext> context;
        FenceTicket ticket;

      public:
        SubmissionCompletion(std::shared_ptr<DeviceContext> owner, FenceTicket completion)
            : context(std::move(owner)), ticket(std::move(completion))
        {
        }
        bool IsComplete() const
        {
            return ticket.IsComplete(*context);
        }
        void Wait() const
        {
            ticket.Wait(*context);
        }
    };
}
