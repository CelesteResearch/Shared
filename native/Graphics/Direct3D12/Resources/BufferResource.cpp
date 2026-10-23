#include "BufferResource.h"
#include <cstring>
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    static D3D12_RESOURCE_DESC DescribeBuffer(uint64_t bytes)
    {
        if (!bytes)
            throw std::invalid_argument("Buffer size must be positive");
        D3D12_RESOURCE_DESC result{};
        result.Dimension = D3D12_RESOURCE_DIMENSION_BUFFER;
        result.Width = bytes;
        result.Height = 1;
        result.DepthOrArraySize = 1;
        result.MipLevels = 1;
        result.SampleDesc.Count = 1;
        result.Layout = D3D12_TEXTURE_LAYOUT_ROW_MAJOR;
        return result;
    }
    BufferResource::BufferResource(std::shared_ptr<DeviceContext> owner, uint64_t bytes, D3D12_HEAP_TYPE type)
        : GpuResource(std::move(owner), DescribeBuffer(bytes), type,
                      type == D3D12_HEAP_TYPE_UPLOAD     ? D3D12_RESOURCE_STATE_GENERIC_READ
                      : type == D3D12_HEAP_TYPE_READBACK ? D3D12_RESOURCE_STATE_COPY_DEST
                                                         : D3D12_RESOURCE_STATE_COMMON),
          heap(type)
    {
    }
    BufferResource::~BufferResource()
    {
        if (mapped)
            resource->Unmap(0, nullptr);
    }
    void* BufferResource::Map()
    {
        if (heap != D3D12_HEAP_TYPE_UPLOAD && heap != D3D12_HEAP_TYPE_READBACK)
            throw std::logic_error("Only transfer heaps can be mapped");
        if (!mapped)
        {
            D3D12_RANGE range{0, heap == D3D12_HEAP_TYPE_READBACK ? static_cast<SIZE_T>(description.Width) : 0};
            CheckResult(resource->Map(0, &range, &mapped), "Map transfer buffer");
        }
        return mapped;
    }
    void BufferResource::Write(uint64_t offset, const void* bytes, size_t count)
    {
        if (heap != D3D12_HEAP_TYPE_UPLOAD || !bytes || offset > description.Width ||
            count > description.Width - offset)
            throw std::invalid_argument("Invalid upload buffer write");
        std::memcpy(static_cast<char*>(Map()) + offset, bytes, count);
    }
    void BufferResource::Read(uint64_t offset, void* bytes, size_t count)
    {
        if (heap != D3D12_HEAP_TYPE_READBACK || !bytes || offset > description.Width ||
            count > description.Width - offset)
            throw std::invalid_argument("Invalid readback buffer read");
        std::memcpy(bytes, static_cast<const char*>(Map()) + offset, count);
    }
}
