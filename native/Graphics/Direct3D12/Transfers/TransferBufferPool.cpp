#include "TransferBufferPool.h"
#include <stdexcept>
#include <algorithm>
#include <functional>
namespace Celeste::Graphics::Direct3D12
{
    void TransferBufferPool::TrimFreeCache()
    {
        uint64_t freeBytes = 0;
        size_t freeCount = 0;
        for (const auto& slot : slots)
            if (slot->free.load(std::memory_order_acquire))
            {
                freeBytes += slot->allocationBytes;
                ++freeCount;
            }
        if (freeBytes <= MaxFreeBytes && freeCount <= MaxFreeSlots)
            return;

        // Only the producer changes the vector. Leases keep their heap-allocated Slot addresses.
        std::vector<Slot*> idle;
        idle.reserve(freeCount);
        for (const auto& slot : slots)
            if (slot->free.load(std::memory_order_acquire))
                idle.push_back(slot.get());
        std::sort(idle.begin(), idle.end(),
                  [](const Slot* left, const Slot* right) { return left->allocationBytes > right->allocationBytes; });
        // A lease can retire during the first scan; account for the complete second snapshot.
        freeBytes = 0;
        for (const auto* slot : idle)
            freeBytes += slot->allocationBytes;
        size_t retainedCount = idle.size();
        size_t removeCount = 0;
        while (freeBytes > MaxFreeBytes || retainedCount > MaxFreeSlots)
        {
            freeBytes -= idle[removeCount++]->allocationBytes;
            --retainedCount;
        }
        idle.resize(removeCount);
        std::sort(idle.begin(), idle.end(), std::less<Slot*>{});
        slots.erase(std::remove_if(slots.begin(), slots.end(),
                                   [&idle](const auto& slot) {
                                       return std::binary_search(idle.begin(), idle.end(), slot.get(),
                                                                 std::less<Slot*>{});
                                   }),
                    slots.end());
    }
    std::shared_ptr<BufferResource> TransferBufferPool::Acquire(uint64_t bytes, D3D12_HEAP_TYPE heap)
    {
        if (!bytes || (heap != D3D12_HEAP_TYPE_UPLOAD && heap != D3D12_HEAP_TYPE_READBACK))
            throw std::invalid_argument("Invalid transfer heap request");
        auto owner = shared_from_this();
        TrimFreeCache();
        size_t selected = slots.size();
        for (size_t i = 0; i < slots.size(); ++i)
            if (slots[i]->free.load(std::memory_order_acquire) && slots[i]->buffer->heap == heap &&
                slots[i]->buffer->description.Width >= bytes &&
                (selected == slots.size() ||
                 slots[i]->buffer->description.Width < slots[selected]->buffer->description.Width))
                selected = i;
        if (selected == slots.size())
            slots.push_back(std::make_unique<Slot>(std::make_unique<BufferResource>(context, bytes, heap)));
        auto* slot = slots[selected].get();
        slot->free.store(false, std::memory_order_relaxed);
        try
        {
            return std::shared_ptr<BufferResource>(slot->buffer.get(), [owner, slot](BufferResource*) noexcept {
                slot->free.store(true, std::memory_order_release);
            });
        }
        catch (...)
        {
            slot->free.store(true, std::memory_order_release);
            throw;
        }
    }
}
