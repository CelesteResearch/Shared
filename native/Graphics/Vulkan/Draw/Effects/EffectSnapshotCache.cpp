#include "EffectSnapshotCache.h"
#include <stdexcept>

namespace Celeste::Graphics::Vulkan
{
    EffectSnapshot EffectSnapshotCache::Apply(void* effect, uint32_t pass, void* stateChanges,
                                              EffectConstantStorage& storage)
    {
        // Must occur at the source Apply call, before callers mutate parameters again.
        if (!CelesteEffectApply(effect, pass, stateChanges))
            throw std::runtime_error(CelesteEffectGetError());
        CelesteEffectRegisterView registers{};
        if (!CelesteEffectBorrowRegisters(effect, &registers))
            throw std::runtime_error(CelesteEffectGetError());
        const void* identities[] = {registers.vertexIdentity, registers.pixelIdentity};
        EffectSnapshot result;
        for (int stage = 0; stage < 2; ++stage)
        {
            if (!identities[stage])
                throw std::runtime_error("An applied Vulkan effect must bind both shader stages");
            auto found = shaders.find(identities[stage]);
            if (found == shaders.end())
                found =
                    shaders.emplace(identities[stage], std::make_shared<EffectShaderLease>(effect, stage == 0)).first;
            result.shaders[stage] = found->second;
            result.constantSizes[stage] = static_cast<uint32_t>(found->second->description.constantBufferBytes);
            result.constantOffsets[stage] = storage.Append(effect, stage == 0, result.constantSizes[stage]);
        }
        return result;
    }
}
