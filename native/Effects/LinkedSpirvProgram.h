#pragma once
#include "EffectFrontend.h"
#include <cstddef>
#include <cstdint>
#include <vector>

namespace Celeste::Graphics::Effects
{
    // Owns the linked binary; source parseData and its patch table are never mutated.
    struct LinkedSpirvProgram
    {
        std::vector<uint32_t> vertex;
        std::vector<uint32_t> pixel;
        static LinkedSpirvProgram Create(const ShaderDescription& vertex, const ShaderDescription& pixel,
                                         const MOJOSHADER_vertexAttribute* attributes, int count);
    };

}
