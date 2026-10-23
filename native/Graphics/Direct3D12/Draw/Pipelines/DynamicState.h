#pragma once
#include <array>
#include <cstdint>
namespace Celeste::Graphics::Direct3D12
{
    struct DynamicState
    {
        std::array<float, 4> blendFactor{};
        uint32_t stencilReference = 0;
        bool scissorEnabled = false;
    };
} // namespace Celeste::Graphics::Direct3D12
