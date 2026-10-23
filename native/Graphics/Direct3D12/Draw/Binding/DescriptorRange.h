#pragma once
#include <d3d12.h>
#include <cstdint>
namespace Celeste::Graphics::Direct3D12
{
    struct DescriptorRange
    {
        D3D12_CPU_DESCRIPTOR_HANDLE cpu{};
        D3D12_GPU_DESCRIPTOR_HANDLE gpu{};
        uint32_t increment = 0;
        uint32_t count = 0;
        D3D12_CPU_DESCRIPTOR_HANDLE Cpu(uint32_t index) const;
    };
} // namespace Celeste::Graphics::Direct3D12
