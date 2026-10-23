#pragma once
#include <cstdint>
namespace Celeste::Graphics::Direct3D12
{
    struct BindingRequirements
    {
        uint32_t srvCount = 0;
        uint32_t samplerCount = 0;
        uint32_t rtvCount = 0;
        uint32_t dsvCount = 0;
        uint64_t uniformBytes = 0;
    };
} // namespace Celeste::Graphics::Direct3D12
