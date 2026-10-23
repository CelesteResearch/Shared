#pragma once
#include "DeviceContext.h"
#include <vector>
namespace Celeste::Graphics::Direct3D12
{
    class ResourceStateTransaction;
    class GpuResource
    {
        friend class ResourceStateTransaction;
        std::vector<D3D12_RESOURCE_STATES> states;

      public:
        std::shared_ptr<DeviceContext> context;
        Microsoft::WRL::ComPtr<ID3D12Resource> resource;
        D3D12_RESOURCE_DESC description{};
        GpuResource(std::shared_ptr<DeviceContext> owner, const D3D12_RESOURCE_DESC& description, D3D12_HEAP_TYPE heap,
                    D3D12_RESOURCE_STATES initialState, const D3D12_CLEAR_VALUE* clear = nullptr);
        virtual ~GpuResource() = default;
        uint32_t Subresources() const noexcept
        {
            return static_cast<uint32_t>(states.size());
        }
    };
}
