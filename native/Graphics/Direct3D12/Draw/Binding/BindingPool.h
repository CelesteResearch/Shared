#pragma once
#include "BindingBatch.h"
#include <vector>
namespace Celeste::Graphics::Direct3D12
{
    // Single recording thread. A submitted command lease retains its batch until fence completion.
    class BindingPool
    {
      public:
        explicit BindingPool(std::shared_ptr<DeviceContext> device);
        std::shared_ptr<BindingBatch> Acquire(const BindingRequirements& requirements);

      private:
        std::shared_ptr<DeviceContext> owner;
        std::vector<std::shared_ptr<BindingBatch>> batches;
    };
} // namespace Celeste::Graphics::Direct3D12
