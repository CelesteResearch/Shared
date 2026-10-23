#pragma once
#include "TransferBufferPool.h"
#include "ResourceStateTransaction.h"
namespace Celeste::Graphics::Direct3D12
{
    class BufferTransfer final
    {
      public:
        std::shared_ptr<BufferResource> buffer, staging;
        const uint64_t offset;
        const uint32_t count, elementBytes, stride;
        const bool upload;
        BufferTransfer(std::shared_ptr<BufferResource>, uint64_t offset, uint32_t count, uint32_t elementBytes,
                       uint32_t stride, bool upload, TransferBufferPool&);
        void Write(const void* bytes, size_t byteCount);
        void Read(void* bytes, size_t byteCount);
        void Retain(CommandLease&) const;
        void Record(CommandLease&, ResourceStateTransaction&) const;
        static void Record(CommandLease&, ResourceStateTransaction&, BufferResource&, BufferResource&, uint64_t offset,
                           uint32_t count, uint32_t elementBytes, uint32_t stride, bool upload);
    };
}
