#pragma once
#include "EffectShaderLease.h"
#include <array>
#include <memory>

namespace Celeste::Graphics::Vulkan
{
    struct EffectSnapshot
    {
        std::array<std::shared_ptr<EffectShaderLease>, 2> shaders;
        std::array<uint32_t, 2> constantOffsets{};
        std::array<uint32_t, 2> constantSizes{};
    };
}
