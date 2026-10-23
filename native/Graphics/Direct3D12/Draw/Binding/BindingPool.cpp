#include "BindingPool.h"
#include <stdexcept>
#include <algorithm>
#include <utility>
namespace Celeste::Graphics::Direct3D12
{
    BindingPool::BindingPool(std::shared_ptr<DeviceContext> device) : owner(std::move(device))
    {
        if (!owner)
            throw std::invalid_argument("Binding pool device is null");
    }
    std::shared_ptr<BindingBatch> BindingPool::Acquire(const BindingRequirements& requirements)
    {
        for (auto& batch : batches)
        {
            if (batch.use_count() == 1 && batch->Fits(requirements))
            {
                batch->Reset();
                return batch;
            }
        }
        BindingRequirements capacity = requirements;
        capacity.srvCount = std::max(capacity.srvCount, 2048u);
        capacity.samplerCount = std::max(capacity.samplerCount, 2048u);
        capacity.rtvCount = std::max(capacity.rtvCount, 256u);
        capacity.dsvCount = std::max(capacity.dsvCount, 64u);
        capacity.uniformBytes = std::max(capacity.uniformBytes, uint64_t{64} * 1024);
        auto batch = std::make_shared<BindingBatch>(owner, capacity);
        batches.push_back(batch);
        return batch;
    }
} // namespace Celeste::Graphics::Direct3D12
