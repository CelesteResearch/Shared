#pragma once
#include "ResourceContext.h"
#include <cstddef>
#include <memory>
namespace Celeste::Graphics::Vulkan
{
    // Context and native device must outlive resources. Destruction requires GPU retirement.
    class TransferBuffer final
    {
        std::shared_ptr<ResourceContext> owner;
        void* mapped = nullptr;
        bool coherent = false;

      public:
        ResourceContext& context;
        VkBuffer buffer = VK_NULL_HANDLE;
        VkDeviceMemory memory = VK_NULL_HANDLE;
        VkDeviceSize size;
        explicit TransferBuffer(std::shared_ptr<ResourceContext> context, VkDeviceSize size,
                                VkBufferUsageFlags usage = VK_BUFFER_USAGE_TRANSFER_SRC_BIT |
                                                           VK_BUFFER_USAGE_TRANSFER_DST_BIT);
        ~TransferBuffer();
        TransferBuffer(const TransferBuffer&) = delete;
        TransferBuffer& operator=(const TransferBuffer&) = delete;
        // Borrowed CPU write span; callers own the lease and flush after filling it.
        void* WriteAddress(size_t bytes);
        void FlushWrittenData();
        void Write(const void* source, size_t bytes);
        void Read(void* destination, size_t bytes);
    };

}
