#pragma once
#include "BindingRequirements.h"
#include "DescriptorRange.h"
#include "Device/DeviceContext.h"
#include <array>
namespace Celeste::Graphics::Direct3D12
{
    class BindingBatch
    {
      public:
        BindingBatch(std::shared_ptr<DeviceContext> device, const BindingRequirements& capacity);
        ~BindingBatch();
        BindingBatch(const BindingBatch&) = delete;
        BindingBatch& operator=(const BindingBatch&) = delete;
        bool Fits(const BindingRequirements& required) const;
        bool CanAllocate(const BindingRequirements& required) const;

        DescriptorRange AllocateViews(uint32_t count);
        DescriptorRange AllocateSamplers(uint32_t count);
        DescriptorRange AllocateRenderTargets(uint32_t count);
        DescriptorRange AllocateDepthTargets(uint32_t count);
        D3D12_GPU_VIRTUAL_ADDRESS UploadUniform(const void* data, uint32_t bytes);
        void BindHeaps(ID3D12GraphicsCommandList* list) const;

      private:
        friend class BindingPool;
        void Reset();
        std::shared_ptr<DeviceContext> owner;
        BindingRequirements capacity;
        std::array<Microsoft::WRL::ComPtr<ID3D12DescriptorHeap>, 4> heaps;
        std::array<uint32_t, 4> used{};
        std::array<uint32_t, 4> limits{};
        std::array<uint32_t, 4> increments{};
        Microsoft::WRL::ComPtr<ID3D12Resource> uniforms;
        uint8_t* mapped = nullptr;
        uint64_t uniformCursor = 0;
        DescriptorRange Allocate(size_t heap, uint32_t count);
    };
} // namespace Celeste::Graphics::Direct3D12
