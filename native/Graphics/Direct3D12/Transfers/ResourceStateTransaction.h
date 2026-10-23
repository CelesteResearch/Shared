#pragma once
#include "GpuResource.h"
#include "CommandLease.h"
namespace Celeste::Graphics::Direct3D12
{
    class ResourceStateTransaction final
    {
        struct Entry
        {
            std::shared_ptr<GpuResource> resource;
            D3D12_RESOURCE_STATES single;
            std::vector<D3D12_RESOURCE_STATES> multiple;
        };
        std::vector<Entry> entries;
        ID3D12GraphicsCommandList* list;

      public:
        ResourceStateTransaction(CommandLease&, const std::vector<std::shared_ptr<GpuResource>>& resources);
        void Transition(GpuResource&, uint32_t subresource, D3D12_RESOURCE_STATES);
        void TransitionAll(GpuResource&, D3D12_RESOURCE_STATES);
        void Commit() noexcept;
    };
}
