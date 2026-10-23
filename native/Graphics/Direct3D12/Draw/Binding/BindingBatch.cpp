#include "BindingBatch.h"
#include <cstring>
#include <stdexcept>
#include <utility>
namespace Celeste::Graphics::Direct3D12
{
    D3D12_CPU_DESCRIPTOR_HANDLE DescriptorRange::Cpu(uint32_t index) const
    {
        if (index >= count)
            throw std::out_of_range("Descriptor index");
        return {cpu.ptr + static_cast<SIZE_T>(index) * increment};
    }
    BindingBatch::BindingBatch(std::shared_ptr<DeviceContext> device, const BindingRequirements& requested)
        : owner(std::move(device)), capacity(requested)
    {
        if (!owner)
            throw std::invalid_argument("Binding device is null");
        owner->CheckAlive();
        if (capacity.samplerCount > D3D12_MAX_SHADER_VISIBLE_SAMPLER_HEAP_SIZE ||
            capacity.srvCount > D3D12_MAX_SHADER_VISIBLE_DESCRIPTOR_HEAP_SIZE_TIER_1)
            throw std::invalid_argument("Binding batch exceeds shader-visible heap capacity; split the packet");
        limits = {capacity.srvCount, capacity.samplerCount, capacity.rtvCount, capacity.dsvCount};
        for (size_t i = 0; i < heaps.size(); ++i)
        {
            if (!limits[i])
                continue;
            D3D12_DESCRIPTOR_HEAP_DESC desc{};
            desc.Type = static_cast<D3D12_DESCRIPTOR_HEAP_TYPE>(i);
            desc.NumDescriptors = limits[i];
            desc.Flags = i < 2 ? D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE : D3D12_DESCRIPTOR_HEAP_FLAG_NONE;
            CheckResult(owner->device->CreateDescriptorHeap(&desc, IID_PPV_ARGS(&heaps[i])), "Create binding heap");
            increments[i] = owner->device->GetDescriptorHandleIncrementSize(desc.Type);
        }
        if (!capacity.uniformBytes)
            return;
        D3D12_HEAP_PROPERTIES heap{};
        heap.Type = D3D12_HEAP_TYPE_UPLOAD;
        heap.CreationNodeMask = heap.VisibleNodeMask = 1;
        D3D12_RESOURCE_DESC desc{};
        desc.Dimension = D3D12_RESOURCE_DIMENSION_BUFFER;
        desc.Width = capacity.uniformBytes;
        desc.Height = 1;
        desc.DepthOrArraySize = desc.MipLevels = 1;
        desc.SampleDesc.Count = 1;
        desc.Layout = D3D12_TEXTURE_LAYOUT_ROW_MAJOR;
        CheckResult(owner->device->CreateCommittedResource(&heap, D3D12_HEAP_FLAG_NONE, &desc,
                                                           D3D12_RESOURCE_STATE_GENERIC_READ, nullptr,
                                                           IID_PPV_ARGS(&uniforms)),
                    "Create uniform batch");
        D3D12_RANGE readRange{0, 0};
        CheckResult(uniforms->Map(0, &readRange, reinterpret_cast<void**>(&mapped)), "Map uniform batch");
    }
    BindingBatch::~BindingBatch()
    {
        if (mapped)
            uniforms->Unmap(0, nullptr);
    }
    bool BindingBatch::Fits(const BindingRequirements& r) const
    {
        return r.srvCount <= capacity.srvCount && r.samplerCount <= capacity.samplerCount &&
               r.rtvCount <= capacity.rtvCount && r.dsvCount <= capacity.dsvCount &&
               r.uniformBytes <= capacity.uniformBytes;
    }
    bool BindingBatch::CanAllocate(const BindingRequirements& r) const
    {
        return r.srvCount <= limits[0] - used[0] && r.samplerCount <= limits[1] - used[1] &&
               r.rtvCount <= limits[2] - used[2] && r.dsvCount <= limits[3] - used[3] &&
               r.uniformBytes <= capacity.uniformBytes - uniformCursor;
    }
    void BindingBatch::Reset()
    {
        used.fill(0);
        uniformCursor = 0;
    }
    DescriptorRange BindingBatch::Allocate(size_t heap, uint32_t count)
    {
        if (count > limits[heap] - used[heap])
            throw std::out_of_range("Binding batch exhausted");
        if (!count)
            return {};
        DescriptorRange range{};
        range.cpu = heaps[heap]->GetCPUDescriptorHandleForHeapStart();
        range.cpu.ptr += static_cast<SIZE_T>(used[heap]) * increments[heap];
        if (heap < 2)
        {
            range.gpu = heaps[heap]->GetGPUDescriptorHandleForHeapStart();
            range.gpu.ptr += static_cast<UINT64>(used[heap]) * increments[heap];
        }
        range.increment = increments[heap];
        range.count = count;
        used[heap] += count;
        return range;
    }
    DescriptorRange BindingBatch::AllocateViews(uint32_t count)
    {
        return Allocate(0, count);
    }
    DescriptorRange BindingBatch::AllocateSamplers(uint32_t count)
    {
        return Allocate(1, count);
    }
    DescriptorRange BindingBatch::AllocateRenderTargets(uint32_t count)
    {
        return Allocate(2, count);
    }
    DescriptorRange BindingBatch::AllocateDepthTargets(uint32_t count)
    {
        return Allocate(3, count);
    }
    D3D12_GPU_VIRTUAL_ADDRESS BindingBatch::UploadUniform(const void* data, uint32_t bytes)
    {
        if (!bytes || !data)
            throw std::invalid_argument("Uniform payload is empty");
        if (bytes > D3D12_REQ_CONSTANT_BUFFER_ELEMENT_COUNT * 16u)
            throw std::invalid_argument("Uniform payload exceeds constant buffer limit");
        const uint64_t padded = (static_cast<uint64_t>(bytes) + 255u) & ~uint64_t{255u};
        if (padded > capacity.uniformBytes - uniformCursor)
            throw std::out_of_range("Uniform batch exhausted");
        std::memcpy(mapped + uniformCursor, data, bytes);
        std::memset(mapped + uniformCursor + bytes, 0, static_cast<size_t>(padded - bytes));
        const auto address = uniforms->GetGPUVirtualAddress() + uniformCursor;
        uniformCursor += padded;
        return address;
    }
    void BindingBatch::BindHeaps(ID3D12GraphicsCommandList* list) const
    {
        ID3D12DescriptorHeap* selected[2]{};
        UINT count = 0;
        for (size_t i = 0; i < 2; ++i)
            if (heaps[i])
                selected[count++] = heaps[i].Get();
        list->SetDescriptorHeaps(count, selected);
    }
} // namespace Celeste::Graphics::Direct3D12
