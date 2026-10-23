#pragma once
#include <d3d12.h>
#include <array>
struct Direct3D12ConsumedInputs
{
    std::array<D3D12_INPUT_ELEMENT_DESC, D3D12_IA_VERTEX_INPUT_STRUCTURE_ELEMENT_COUNT> elements{};
    uint32_t count = 0;
};
