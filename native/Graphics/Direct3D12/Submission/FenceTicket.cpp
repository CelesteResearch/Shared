#include "FenceTicket.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    bool FenceTicket::IsComplete(const DeviceContext& context) const
    {
        if (!fence)
            throw std::logic_error("Submission has no completion fence");
        const auto completed = fence->GetCompletedValue();
        if (completed == UINT64_MAX)
        {
            context.CheckAlive();
            throw std::runtime_error("D3D12 fence device removal");
        }
        return completed >= value;
    }
    void FenceTicket::Wait(const DeviceContext& context) const
    {
        if (IsComplete(context))
            return;
        HANDLE event = CreateEventW(nullptr, FALSE, FALSE, nullptr);
        if (!event)
            CheckResult(HRESULT_FROM_WIN32(GetLastError()), "Create fence event");
        try
        {
            CheckResult(fence->SetEventOnCompletion(value, event), "SetEventOnCompletion");
            const auto status = WaitForSingleObject(event, INFINITE);
            if (status != WAIT_OBJECT_0)
                CheckResult(HRESULT_FROM_WIN32(GetLastError()), "Wait fence");
            context.CheckAlive();
            if (!IsComplete(context))
                throw std::runtime_error("Fence woke before completion");
        }
        catch (...)
        {
            CloseHandle(event);
            throw;
        }
        CloseHandle(event);
    }
}
