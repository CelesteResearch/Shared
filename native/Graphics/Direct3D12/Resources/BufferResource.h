#pragma once
#include "GpuResource.h"
namespace Celeste::Graphics::Direct3D12
{
    class BufferResource final : public GpuResource
    {
        void* mapped = nullptr;

      public:
        const D3D12_HEAP_TYPE heap;
        BufferResource(std::shared_ptr<DeviceContext> context, uint64_t bytes,
                       D3D12_HEAP_TYPE heap = D3D12_HEAP_TYPE_DEFAULT);
        ~BufferResource() override;
        void* Map();
        void Write(uint64_t offset, const void* bytes, size_t count);
        void Read(uint64_t offset, void* bytes, size_t count);
    };
}
