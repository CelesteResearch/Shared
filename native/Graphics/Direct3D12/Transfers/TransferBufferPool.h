#pragma once
#include "BufferResource.h"
#include <atomic>
namespace Celeste::Graphics::Direct3D12
{
    class TransferBufferPool final : public std::enable_shared_from_this<TransferBufferPool>
    {
        struct Slot
        {
            std::unique_ptr<BufferResource> buffer;
            const uint64_t allocationBytes;
            std::atomic<bool> free{true};
            explicit Slot(std::unique_ptr<BufferResource> value)
                : buffer(std::move(value)),
                  allocationBytes(
                      buffer->context->device->GetResourceAllocationInfo(0, 1, &buffer->description).SizeInBytes)
            {
            }
        };
        // Acquisition is serialized by the producer. Last leases can retire on the host render thread.
        std::vector<std::unique_ptr<Slot>> slots;
        std::shared_ptr<DeviceContext> context;
        static constexpr uint64_t MaxFreeBytes = 32ull * 1024 * 1024;
        static constexpr size_t MaxFreeSlots = 256;
        void TrimFreeCache();

      public:
        explicit TransferBufferPool(std::shared_ptr<DeviceContext> owner) : context(std::move(owner))
        {
        }
        std::shared_ptr<BufferResource> Acquire(uint64_t bytes, D3D12_HEAP_TYPE heap);
        const DeviceContext& Context() const noexcept
        {
            return *context;
        }
    };
}
