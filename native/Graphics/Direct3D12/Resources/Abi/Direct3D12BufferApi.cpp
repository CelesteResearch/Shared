#include "Direct3D12ResourceApi.h"
#include "Direct3D12TransferCommand.h"
#include "CelesteGraphicsBuffer.h"
#include "CelesteGraphicsReadback.h"
#include "CelesteGraphicsPacket.h"
#include "BufferTransfer.h"
namespace Celeste::Graphics::Direct3D12
{
    void CreateBuffer(CelesteGraphicsDevice* device, uint8_t index, uint8_t dynamic, SourceBufferUsage usage,
                      int32_t bytes, CelesteGraphicsBuffer** output)
    {
        if (output)
            *output = nullptr;
        if (!device || !output || bytes <= 0 || index > 1 || dynamic > 1 ||
            (usage != SourceBufferUsage_None && usage != SourceBufferUsage_WriteOnly))
            throw std::invalid_argument("Invalid buffer creation arguments");
        auto result = std::make_unique<CelesteGraphicsBuffer>();
        result->device = device;
        result->index = index != 0;
        result->dynamic = dynamic != 0;
        result->usage = usage;
        result->buffer = std::make_shared<BufferResource>(device->Resources(), bytes);
        *output = result.release();
    }
    void ReleaseBuffer(CelesteGraphicsBuffer* buffer) noexcept
    {
        delete buffer;
    }
    static uint32_t Range(CelesteGraphicsPacket* packet, CelesteGraphicsBuffer* buffer, int32_t offset, int32_t count,
                          int32_t size, int32_t stride)
    {
        if (!packet || !buffer || buffer->device != &packet->Owner())
            throw std::invalid_argument("Buffer/packet device mismatch");
        packet->RequireOpen();
        if (offset < 0 || count <= 0 || size <= 0 || stride < size ||
            uint64_t(offset) + uint64_t(count - 1) * stride + size > buffer->buffer->description.Width ||
            uint64_t(count) * size > UINT32_MAX)
            throw std::invalid_argument("Invalid buffer range");
        return static_cast<uint32_t>(uint64_t(count) * size);
    }
    static void RecordTransfer(CelesteGraphicsPacket& packet, const void* payload,
                               Direct3D12PacketRecordContext& recording) noexcept
    {
        const auto& c = *static_cast<const BufferTransferCommand*>(payload);
        BufferTransfer::Record(recording.lease, recording.states, packet.Resource<BufferResource>(c.buffer),
                               packet.Resource<BufferResource>(c.staging), c.offset, c.count, c.size, c.stride,
                               c.upload);
    }
    void WriteBuffer(CelesteGraphicsPacket* packet, CelesteGraphicsBuffer* buffer, int32_t offset, const void* bytes,
                     int32_t count, int32_t size, int32_t stride, SourceSetDataOptions options)
    {
        const uint32_t length = Range(packet, buffer, offset, count, size, stride);
        if (!bytes || (options != SourceSetDataOptions_None && options != SourceSetDataOptions_Discard &&
                       options != SourceSetDataOptions_NoOverwrite))
            throw std::invalid_argument("Invalid upload options");
        auto staging = packet->Owner().TransferBuffers()->Acquire(length, D3D12_HEAP_TYPE_UPLOAD);
        staging->Write(0, bytes, length);
        BufferTransferCommand command{packet->Retain(buffer->buffer),
                                      packet->Retain(staging),
                                      static_cast<uint64_t>(offset),
                                      static_cast<uint32_t>(count),
                                      static_cast<uint32_t>(size),
                                      static_cast<uint32_t>(stride),
                                      true};
        packet->RegisterResource(buffer->buffer);
        packet->AddCommand(command, nullptr, RecordTransfer);
    }
    void ReadBuffer(CelesteGraphicsPacket* packet, CelesteGraphicsBuffer* buffer, int32_t offset, int32_t count,
                    int32_t size, int32_t stride, CelesteGraphicsReadback** output)
    {
        if (output)
            *output = nullptr;
        if (!output)
            throw std::invalid_argument("Readback output missing");
        const uint32_t length = Range(packet, buffer, offset, count, size, stride);
        if (buffer->usage == SourceBufferUsage_WriteOnly)
            throw std::invalid_argument("Buffer is write-only");
        auto result = std::make_unique<CelesteGraphicsReadback>();
        result->completion = packet->Completion();
        result->bytes.resize(length);
        result->staging = packet->Owner().TransferBuffers()->Acquire(length, D3D12_HEAP_TYPE_READBACK);
        BufferTransferCommand command{packet->Retain(buffer->buffer),
                                      packet->Retain(result->staging),
                                      static_cast<uint64_t>(offset),
                                      static_cast<uint32_t>(count),
                                      static_cast<uint32_t>(size),
                                      static_cast<uint32_t>(stride),
                                      false};
        packet->RegisterResource(buffer->buffer);
        packet->AddCommand(command, nullptr, RecordTransfer);
        *output = result.release();
    }
}
