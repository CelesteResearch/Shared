#pragma once
#include "TransferBuffer.h"
#include <array>
#include <memory>
#include <vector>
namespace Celeste::Graphics::Vulkan
{
    // Used by the serialized packet/submission owner. Leases are retained by packet
    // storage until its real fence/host serial retires; readbacks retain longer.
    class TransferBufferPool final : public std::enable_shared_from_this<TransferBufferPool>
    {
        struct Bucket
        {
            std::vector<std::unique_ptr<TransferBuffer>> buffers;
            std::vector<size_t> available;
        };
        std::shared_ptr<ResourceContext> context;
        std::array<Bucket, 53> buckets;

      public:
        explicit TransferBufferPool(std::shared_ptr<ResourceContext> context);
        std::shared_ptr<TransferBuffer> Acquire(VkDeviceSize requiredBytes);
    };
}
