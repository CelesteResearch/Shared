#pragma once
#include <d3d12.h>
#include <vector>
#include <cstdint>
namespace Celeste::Graphics::Direct3D12
{
    struct InputLayout
    {
        std::vector<D3D12_INPUT_ELEMENT_DESC> elements;
        std::vector<uint32_t> strides;
    };
} // namespace Celeste::Graphics::Direct3D12
