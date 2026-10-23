#pragma once
#include <d3d12.h>
#include <array>
#include <cstdint>
namespace Celeste::Graphics::Direct3D12
{
    struct PipelineTargets
    {
        std::array<DXGI_FORMAT, 8> colors{};
        uint32_t colorCount = 0;
        DXGI_FORMAT depth = DXGI_FORMAT_UNKNOWN;
        DXGI_SAMPLE_DESC samples{1, 0};
    };
} // namespace Celeste::Graphics::Direct3D12
