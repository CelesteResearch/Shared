#pragma once
#include "SpirvEffectAbi.h"
#include <array>
#include <vector>
#include <functional>

namespace Celeste::Graphics::Vulkan
{
    struct EffectProgramKey
    {
        std::array<const void*, 2> shaders;
        std::vector<CelesteSpirvVertexAttribute> attributes;
        bool operator==(const EffectProgramKey& other) const noexcept
        {
            if (shaders != other.shaders || attributes.size() != other.attributes.size())
                return false;
            for (size_t i = 0; i < attributes.size(); ++i)
                if (attributes[i].usage != other.attributes[i].usage ||
                    attributes[i].format != other.attributes[i].format ||
                    attributes[i].usageIndex != other.attributes[i].usageIndex)
                    return false;
            return true;
        }
        struct Hash
        {
            size_t operator()(const EffectProgramKey& key) const noexcept
            {
                size_t result = std::hash<const void*>{}(key.shaders[0]);
                auto append = [&](size_t value) { result ^= value + 0x9e3779b9u + (result << 6) + (result >> 2); };
                append(std::hash<const void*>{}(key.shaders[1]));
                for (const auto& attribute : key.attributes)
                {
                    append(attribute.usage);
                    append(attribute.format);
                    append(attribute.usageIndex);
                }
                return result;
            }
        };
    };
}
