#pragma once
#include <d3d12.h>
#include <cstdint>
namespace Celeste::Graphics::Direct3D12
{
    struct PipelineState
    {
        D3D12_BLEND_DESC blend{};
        D3D12_DEPTH_STENCIL_DESC depth{};
        D3D12_RASTERIZER_DESC rasterizer{};
        uint32_t sampleMask = UINT32_MAX;
    };
} // namespace Celeste::Graphics::Direct3D12
