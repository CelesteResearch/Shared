#pragma once
#include "EffectProgram.h"
#include "EffectProgramKey.h"
#include <unordered_map>

namespace Celeste::Graphics::Vulkan
{
    class EffectProgramCache final
    {
        std::unordered_map<EffectProgramKey, std::shared_ptr<EffectProgram>, EffectProgramKey::Hash> programs;
        EffectProgramKey lookup;

      public:
        std::shared_ptr<EffectProgram> Get(const EffectSnapshot& effect,
                                           const std::vector<CelesteSpirvVertexAttribute>& attributes);
    };
}
