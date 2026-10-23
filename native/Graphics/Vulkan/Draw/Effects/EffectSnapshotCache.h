#pragma once
#include "EffectSnapshot.h"
#include "EffectConstantStorage.h"
#include <unordered_map>

namespace Celeste::Graphics::Vulkan
{
    // Device-local identity cache. Retention keeps identity addresses stable.
    class EffectSnapshotCache final
    {
        std::unordered_map<const void*, std::shared_ptr<EffectShaderLease>> shaders;

      public:
        EffectSnapshot Apply(void* effect, uint32_t pass, void* stateChanges, EffectConstantStorage& storage);
    };
}
