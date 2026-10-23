#include "ResourceStateTransaction.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    ResourceStateTransaction::ResourceStateTransaction(CommandLease& lease,
                                                       const std::vector<std::shared_ptr<GpuResource>>& resources)
        : list(lease.List())
    {
        entries.reserve(resources.size());
        for (const auto& resource : resources)
        {
            if (!resource || resource->context->device.Get() != lease.Context().device.Get())
                throw std::invalid_argument("Resource belongs to a different device");
            bool exists = false;
            for (const auto& entry : entries)
                if (entry.resource == resource)
                {
                    exists = true;
                    break;
                }
            if (!exists)
            {
                Entry entry{resource, resource->states.front(), {}};
                if (resource->states.size() > 1)
                    entry.multiple = resource->states;
                entries.push_back(std::move(entry));
                lease.Retain(resource);
            }
        }
    }
    void ResourceStateTransaction::Transition(GpuResource& resource, uint32_t subresource, D3D12_RESOURCE_STATES state)
    {
        for (auto& entry : entries)
            if (entry.resource.get() == &resource)
            {
                if (subresource >= entry.resource->states.size())
                    throw std::out_of_range("Resource state subresource outside range");
                auto& before = entry.multiple.empty() ? entry.single : entry.multiple[subresource];
                if (before == state)
                    return;
                D3D12_RESOURCE_BARRIER barrier{};
                barrier.Type = D3D12_RESOURCE_BARRIER_TYPE_TRANSITION;
                barrier.Transition = {resource.resource.Get(), subresource, before, state};
                list->ResourceBarrier(1, &barrier);
                before = state;
                return;
            }
        throw std::logic_error("Resource was not registered before recording");
    }
    void ResourceStateTransaction::TransitionAll(GpuResource& resource, D3D12_RESOURCE_STATES state)
    {
        for (uint32_t i = 0; i < resource.Subresources(); ++i)
            Transition(resource, i, state);
    }
    void ResourceStateTransaction::Commit() noexcept
    {
        for (auto& entry : entries)
        {
            if (entry.multiple.empty())
                entry.resource->states[0] = entry.single;
            else
                entry.resource->states.swap(entry.multiple);
        }
    }
}
