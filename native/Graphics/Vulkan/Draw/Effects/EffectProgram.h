#pragma once
#include "EffectSnapshot.h"
#include "SpirvEffectAbi.h"
#include <vector>

namespace Celeste::Graphics::Vulkan
{
    class EffectProgram final
    {
        void* program = nullptr;
        std::array<std::shared_ptr<EffectShaderLease>, 2> shaders;

      public:
        EffectProgram(const EffectSnapshot& effect, const std::vector<CelesteSpirvVertexAttribute>& attributes);
        ~EffectProgram();
        EffectProgram(const EffectProgram&) = delete;
        EffectProgram& operator=(const EffectProgram&) = delete;
        CelesteSpirvBinaryView Binary(bool vertex) const;
        int32_t VertexLocation(int32_t usage, int32_t usageIndex) const;
    };
}
