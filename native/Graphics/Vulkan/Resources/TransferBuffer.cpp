#include "TransferBuffer.h"
#include <cstring>
#include <stdexcept>
#include <string>
namespace Celeste::Graphics::Vulkan
{
    static void Check(VkResult result, const char* operation)
    {
        if (result != VK_SUCCESS)
            throw std::runtime_error(std::string(operation) + ": " + std::to_string(result));
    }
    TransferBuffer::TransferBuffer(std::shared_ptr<ResourceContext> resourceContext, VkDeviceSize bytes,
                                   VkBufferUsageFlags usage)
        : owner(std::move(resourceContext)),
          context(owner ? *owner : throw std::invalid_argument("Missing resource context")), size(bytes)
    {
        if (!bytes || !usage)
            throw std::invalid_argument("Empty transfer buffer");
        VkBufferCreateInfo info{VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO};
        info.size = bytes;
        info.usage = usage;
        info.sharingMode = VK_SHARING_MODE_EXCLUSIVE;
        Check(context.CreateBuffer(context.native.device, &info, nullptr, &buffer), "CreateBuffer");
        try
        {
            VkMemoryRequirements requirements{};
            context.GetBufferMemoryRequirements(context.native.device, buffer, &requirements);
            VkMemoryAllocateInfo allocation{VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO};
            allocation.allocationSize = requirements.size;
            allocation.memoryTypeIndex =
                context.MemoryType(requirements.memoryTypeBits, VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT);
            coherent = (context.memory.memoryTypes[allocation.memoryTypeIndex].propertyFlags &
                        VK_MEMORY_PROPERTY_HOST_COHERENT_BIT) != 0;
            Check(context.AllocateMemory(context.native.device, &allocation, nullptr, &memory), "AllocateMemory");
            Check(context.BindBufferMemory(context.native.device, buffer, memory, 0), "BindBufferMemory");
            Check(context.MapMemory(context.native.device, memory, 0, VK_WHOLE_SIZE, 0, &mapped), "MapMemory");
        }
        catch (...)
        {
            context.DestroyBuffer(context.native.device, buffer, nullptr);
            if (memory)
                context.FreeMemory(context.native.device, memory, nullptr);
            throw;
        }
    }
    TransferBuffer::~TransferBuffer()
    {
        if (mapped)
            context.UnmapMemory(context.native.device, memory);
        context.DestroyBuffer(context.native.device, buffer, nullptr);
        context.FreeMemory(context.native.device, memory, nullptr);
    }
    void* TransferBuffer::WriteAddress(size_t bytes)
    {
        if (bytes > size)
            throw std::invalid_argument("Transfer write range");
        return mapped;
    }
    void TransferBuffer::FlushWrittenData()
    {
        if (coherent)
            return;
        VkMappedMemoryRange range{VK_STRUCTURE_TYPE_MAPPED_MEMORY_RANGE};
        range.memory = memory;
        range.size = VK_WHOLE_SIZE;
        Check(context.FlushMappedMemoryRanges(context.native.device, 1, &range), "FlushMappedMemoryRanges");
    }
    void TransferBuffer::Write(const void* source, size_t bytes)
    {
        if (!source)
            throw std::invalid_argument("Missing transfer bytes");
        std::memcpy(WriteAddress(bytes), source, bytes);
        FlushWrittenData();
    }
    void TransferBuffer::Read(void* destination, size_t bytes)
    {
        if (!destination || bytes > size)
            throw std::invalid_argument("Transfer read range");
        VkMappedMemoryRange range{VK_STRUCTURE_TYPE_MAPPED_MEMORY_RANGE};
        range.memory = memory;
        range.size = VK_WHOLE_SIZE;
        auto result = coherent ? VK_SUCCESS : context.InvalidateMappedMemoryRanges(context.native.device, 1, &range);
        if (result == VK_SUCCESS)
            std::memcpy(destination, mapped, bytes);
        Check(result, "InvalidateMappedMemoryRanges");
    }
}
