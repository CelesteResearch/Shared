#include "BufferTransferCommand.h"
#include "VulkanResourceApi.h"
#include "CelesteGraphicsBuffer.h"
#include "CelesteGraphicsReadback.h"
#include "CelesteGraphicsPacket.h"
#include "TransferBufferPool.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    void CreateBuffer(CelesteGraphicsDevice* device, uint8_t index, uint8_t dynamic, SourceBufferUsage usage,
                      int32_t bytes, CelesteGraphicsBuffer** result)
    {
        if (result)
            *result = nullptr;
        if (!device || !result || bytes <= 0 || index > 1 || dynamic > 1 ||
            (usage != SourceBufferUsage_None && usage != SourceBufferUsage_WriteOnly))
            throw std::invalid_argument("Invalid buffer creation arguments");
        auto buffer = std::make_unique<CelesteGraphicsBuffer>();
        buffer->device = device;
        buffer->index = index != 0;
        buffer->dynamic = dynamic != 0;
        buffer->usage = usage;
        buffer->buffer = std::make_shared<TransferBuffer>(
            device->Resources(), bytes,
            VK_BUFFER_USAGE_TRANSFER_SRC_BIT | VK_BUFFER_USAGE_TRANSFER_DST_BIT |
                (index ? VK_BUFFER_USAGE_INDEX_BUFFER_BIT : VK_BUFFER_USAGE_VERTEX_BUFFER_BIT));
        *result = buffer.release();
    }
    void ReleaseBuffer(CelesteGraphicsBuffer* buffer) noexcept
    {
        delete buffer;
    }
    static uint32_t Range(CelesteGraphicsPacket* packet, CelesteGraphicsBuffer* buffer, int32_t offset, int32_t count,
                          int32_t size, int32_t stride)
    {
        if (!packet || !buffer || buffer->device != &packet->Owner())
            throw std::invalid_argument("Buffer and packet must belong to one device");
        packet->RequireOpen();
        if (offset < 0 || count <= 0 || size <= 0 || stride < size ||
            uint64_t(offset) + uint64_t(count - 1) * stride + size > buffer->buffer->size ||
            uint64_t(count) * size > UINT32_MAX)
            throw std::invalid_argument("Invalid buffer transfer range");
        return static_cast<uint32_t>(uint64_t(count) * size);
    }

    static void Barrier(TransferBuffer& buffer, VkCommandBuffer commands, VkPipelineStageFlags sourceStage,
                        VkAccessFlags sourceAccess, VkPipelineStageFlags destinationStage,
                        VkAccessFlags destinationAccess) noexcept
    {
        VkBufferMemoryBarrier barrier{VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER};
        barrier.srcAccessMask = sourceAccess;
        barrier.dstAccessMask = destinationAccess;
        barrier.srcQueueFamilyIndex = VK_QUEUE_FAMILY_IGNORED;
        barrier.dstQueueFamilyIndex = VK_QUEUE_FAMILY_IGNORED;
        barrier.buffer = buffer.buffer;
        barrier.size = VK_WHOLE_SIZE;
        buffer.context.CmdPipelineBarrier(commands, sourceStage, destinationStage, 0, 0, nullptr, 1, &barrier, 0,
                                          nullptr);
    }
    static void RecordBufferTransfer(CelesteGraphicsPacket& packet, const void* payload,
                                     VulkanPacketRecordContext& recording) noexcept
    {
        const auto& command = *static_cast<const BufferTransferCommand*>(payload);
        auto& buffer = packet.Resource<TransferBuffer>(command.buffer);
        auto& staging = packet.Resource<TransferBuffer>(command.staging);
        Barrier(buffer, recording.commandBuffer, VK_PIPELINE_STAGE_ALL_COMMANDS_BIT,
                VK_ACCESS_MEMORY_READ_BIT | VK_ACCESS_MEMORY_WRITE_BIT, VK_PIPELINE_STAGE_TRANSFER_BIT,
                command.read ? VK_ACCESS_TRANSFER_READ_BIT : VK_ACCESS_TRANSFER_WRITE_BIT);
        const uint32_t copies = command.size == command.stride ? 1 : command.count;
        for (uint32_t index = 0; index < copies; ++index)
        {
            VkBufferCopy copy{};
            const VkDeviceSize packed = VkDeviceSize(index) * command.size;
            const VkDeviceSize strided = command.offset + VkDeviceSize(index) * command.stride;
            copy.srcOffset = command.read ? strided : packed;
            copy.dstOffset = command.read ? packed : strided;
            copy.size = copies == 1 ? VkDeviceSize(command.count) * command.size : command.size;
            buffer.context.CmdCopyBuffer(recording.commandBuffer, command.read ? buffer.buffer : staging.buffer,
                                         command.read ? staging.buffer : buffer.buffer, 1, &copy);
        }
        if (command.read)
            Barrier(staging, recording.commandBuffer, VK_PIPELINE_STAGE_TRANSFER_BIT, VK_ACCESS_TRANSFER_WRITE_BIT,
                    VK_PIPELINE_STAGE_HOST_BIT, VK_ACCESS_HOST_READ_BIT);
        Barrier(buffer, recording.commandBuffer, VK_PIPELINE_STAGE_TRANSFER_BIT,
                command.read ? VK_ACCESS_TRANSFER_READ_BIT : VK_ACCESS_TRANSFER_WRITE_BIT,
                VK_PIPELINE_STAGE_ALL_COMMANDS_BIT, VK_ACCESS_MEMORY_READ_BIT | VK_ACCESS_MEMORY_WRITE_BIT);
    }
    void WriteBuffer(CelesteGraphicsPacket* packet, CelesteGraphicsBuffer* buffer, int32_t offset, const void* bytes,
                     int32_t count, int32_t size, int32_t stride, SourceSetDataOptions options)
    {
        const uint32_t byteCount = Range(packet, buffer, offset, count, size, stride);
        if (!bytes || (options != SourceSetDataOptions_None && options != SourceSetDataOptions_Discard &&
                       options != SourceSetDataOptions_NoOverwrite))
            throw std::invalid_argument("Invalid buffer upload data/options");
        // Queued staging copies preserve ordering with previous draws, including dynamic
        // Discard/NoOverwrite. No host overwrite races against earlier GPU readers.
        auto staging = buffer->device->StagingBuffers()->Acquire(byteCount);
        staging->Write(bytes, byteCount);
        BufferTransferCommand command{packet->Retain(buffer->buffer),
                                      packet->Retain(staging),
                                      static_cast<uint32_t>(offset),
                                      static_cast<uint32_t>(count),
                                      static_cast<uint32_t>(size),
                                      static_cast<uint32_t>(stride),
                                      false};
        packet->AddCommand(command, nullptr, RecordBufferTransfer);
    }
    void ReadBuffer(CelesteGraphicsPacket* packet, CelesteGraphicsBuffer* buffer, int32_t offset, int32_t count,
                    int32_t size, int32_t stride, CelesteGraphicsReadback** result)
    {
        if (result)
            *result = nullptr;
        if (!result)
            throw std::invalid_argument("Readback requires output");
        const uint32_t byteCount = Range(packet, buffer, offset, count, size, stride);
        if (buffer->usage == SourceBufferUsage_WriteOnly)
            throw std::invalid_argument("Cannot read a write-only buffer");
        auto state = std::make_shared<VulkanReadbackState>();
        state->device = buffer->device;
        state->completion = packet->Completion();
        state->staging = buffer->device->StagingBuffers()->Acquire(byteCount);
        state->bytes.resize(byteCount);
        auto handle = std::make_unique<CelesteGraphicsReadback>();
        handle->state = state;
        BufferTransferCommand command{packet->Retain(buffer->buffer),
                                      packet->Retain(state->staging),
                                      static_cast<uint32_t>(offset),
                                      static_cast<uint32_t>(count),
                                      static_cast<uint32_t>(size),
                                      static_cast<uint32_t>(stride),
                                      true};
        packet->Retain(state);
        packet->AddCommand(command, nullptr, RecordBufferTransfer);
        *result = handle.release();
    }
}
