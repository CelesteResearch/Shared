#include "BufferTransfer.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    BufferTransfer::BufferTransfer(std::shared_ptr<BufferResource> source, uint64_t start, uint32_t elements,
                                   uint32_t size, uint32_t step, bool toGpu, TransferBufferPool& pool)
        : buffer(std::move(source)), offset(start), count(elements), elementBytes(size), stride(step), upload(toGpu)
    {
        if (!buffer || buffer->heap != D3D12_HEAP_TYPE_DEFAULT || !count || !elementBytes || stride < elementBytes ||
            offset > buffer->description.Width ||
            uint64_t(count - 1) * stride + elementBytes > buffer->description.Width - offset ||
            buffer->context->device.Get() != pool.Context().device.Get())
            throw std::invalid_argument("Invalid strided buffer transfer");
        staging =
            pool.Acquire(uint64_t(count) * elementBytes, upload ? D3D12_HEAP_TYPE_UPLOAD : D3D12_HEAP_TYPE_READBACK);
    }
    void BufferTransfer::Write(const void* bytes, size_t size)
    {
        if (!upload || size != uint64_t(count) * elementBytes)
            throw std::invalid_argument("Buffer upload size mismatch");
        staging->Write(0, bytes, size);
    }
    void BufferTransfer::Read(void* bytes, size_t size)
    {
        if (upload || size != uint64_t(count) * elementBytes)
            throw std::invalid_argument("Buffer readback size mismatch");
        staging->Read(0, bytes, size);
    }
    void BufferTransfer::Retain(CommandLease& lease) const
    {
        lease.Retain(buffer);
        lease.Retain(staging);
    }
    void BufferTransfer::Record(CommandLease& lease, ResourceStateTransaction& states) const
    {
        Record(lease, states, *buffer, *staging, offset, count, elementBytes, stride, upload);
    }
    void BufferTransfer::Record(CommandLease& lease, ResourceStateTransaction& states, BufferResource& destination,
                                BufferResource& transfer, uint64_t offset, uint32_t count, uint32_t elementBytes,
                                uint32_t stride, bool upload)
    {
        auto* buffer = &destination;
        auto* staging = &transfer;
        states.Transition(*buffer, 0, upload ? D3D12_RESOURCE_STATE_COPY_DEST : D3D12_RESOURCE_STATE_COPY_SOURCE);
        const uint32_t copies = stride == elementBytes ? 1 : count;
        for (uint32_t i = 0; i < copies; ++i)
        {
            const uint64_t packed = uint64_t(i) * elementBytes, strided = offset + uint64_t(i) * stride;
            lease.List()->CopyBufferRegion(
                upload ? buffer->resource.Get() : staging->resource.Get(), upload ? strided : packed,
                upload ? staging->resource.Get() : buffer->resource.Get(), upload ? packed : strided,
                copies == 1 ? uint64_t(count) * elementBytes : elementBytes);
        }
    }
}
