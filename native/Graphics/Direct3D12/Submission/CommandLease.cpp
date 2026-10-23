#include "CommandLease.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    CommandLease::CommandLease(std::shared_ptr<DeviceContext> owner) : context(std::move(owner))
    {
        if (!context)
            throw std::invalid_argument("Missing command device");
        CheckResult(context->device->CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT, IID_PPV_ARGS(&allocator)),
                    "CreateCommandAllocator");
        CheckResult(context->device->CreateCommandList(0, D3D12_COMMAND_LIST_TYPE_DIRECT, allocator.Get(), nullptr,
                                                       IID_PPV_ARGS(&commands)),
                    "CreateCommandList");
    }
    void CommandLease::Close()
    {
        if (closed)
            throw std::logic_error("Command list already closed");
        CheckResult(commands->Close(), "Close command list");
        closed = true;
    }
    void CommandLease::Recycle()
    {
        // Called only after the actual completion fence, or for a never-submitted lease.
        retained.clear();
        if (!closed)
            Close();
        CheckResult(allocator->Reset(), "Reset command allocator");
        CheckResult(commands->Reset(allocator.Get(), nullptr), "Reset command list");
        closed = false;
    }
}
