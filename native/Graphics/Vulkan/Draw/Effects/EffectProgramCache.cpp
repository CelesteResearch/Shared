#include "EffectProgramCache.h"

namespace Celeste::Graphics::Vulkan
{
    std::shared_ptr<EffectProgram> EffectProgramCache::Get(const EffectSnapshot& effect,
                                                           const std::vector<CelesteSpirvVertexAttribute>& attributes)
    {
        lookup.shaders = {effect.shaders[0]->description.identity, effect.shaders[1]->description.identity};
        lookup.attributes.assign(attributes.begin(), attributes.end());
        auto found = programs.find(lookup);
        if (found == programs.end())
            found = programs.emplace(lookup, std::make_shared<EffectProgram>(effect, attributes)).first;
        return found->second;
    }
}
