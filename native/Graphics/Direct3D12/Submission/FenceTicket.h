#pragma once
#include "DeviceContext.h"
namespace Celeste::Graphics::Direct3D12
{
    struct FenceTicket
    {
        Microsoft::WRL::ComPtr<ID3D12Fence> fence;
        uint64_t value = 0;
        bool IsComplete(const DeviceContext& context) const;
        void Wait(const DeviceContext& context) const;
    };
}
