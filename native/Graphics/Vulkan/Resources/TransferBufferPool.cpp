#include "TransferBufferPool.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    TransferBufferPool::TransferBufferPool(std::shared_ptr<ResourceContext> resourceContext)
        : context(std::move(resourceContext))
    {
        if (!context)
            throw std::invalid_argument("Missing transfer pool context");
    }
    std::shared_ptr<TransferBuffer> TransferBufferPool::Acquire(VkDeviceSize requiredBytes)
    {
        if (!requiredBytes)
            throw std::invalid_argument("Empty transfer lease");
        size_t bucketIndex = 0;
        VkDeviceSize capacity = 4096;
        while (capacity < requiredBytes)
        {
            if (capacity > UINT64_MAX / 2)
                throw std::length_error("Transfer lease exceeds addressable memory");
            capacity <<= 1;
            ++bucketIndex;
        }
        auto self = shared_from_this();
        auto& bucket = buckets[bucketIndex];
        size_t slot;
        if (bucket.available.empty())
        {
            // Reserve the eventual return slot before publishing a lease, so the
            // custom deleter never allocates or throws during fence retirement.
            bucket.available.reserve(bucket.buffers.size() + 1);
            slot = bucket.buffers.size();
            bucket.buffers.push_back(std::make_unique<TransferBuffer>(context, capacity));
        }
        else
        {
            slot = bucket.available.back();
            bucket.available.pop_back();
        }
        // If control-block allocation throws, shared_ptr invokes this same deleter
        // and returns the slot. No GPU storage leaks and no busy slot is published.
        return std::shared_ptr<TransferBuffer>(bucket.buffers[slot].get(),
                                               [self, bucketIndex, slot](TransferBuffer*) noexcept {
                                                   self->buckets[bucketIndex].available.push_back(slot);
                                               });
    }
}
