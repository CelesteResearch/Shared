#include "EffectProgram.h"
#include <stdexcept>

namespace Celeste::Graphics::Vulkan
{
    EffectProgram::EffectProgram(const EffectSnapshot& effect,
                                 const std::vector<CelesteSpirvVertexAttribute>& attributes)
        : shaders(effect.shaders)
    {
        if (!CelesteSpirvCreateProgram(shaders[0]->Handle(), shaders[1]->Handle(), attributes.data(),
                                       static_cast<int32_t>(attributes.size()), &program))
            throw std::runtime_error(CelesteSpirvGetError());
    }
    EffectProgram::~EffectProgram()
    {
        if (program)
            CelesteSpirvDestroyProgram(program);
    }
    CelesteSpirvBinaryView EffectProgram::Binary(bool vertex) const
    {
        CelesteSpirvBinaryView result{};
        if (!CelesteSpirvGetBinary(program, vertex, &result))
            throw std::runtime_error(CelesteSpirvGetError());
        return result;
    }
    int32_t EffectProgram::VertexLocation(int32_t usage, int32_t usageIndex) const
    {
        int32_t result = -1;
        if (!CelesteSpirvGetVertexLocation(program, usage, usageIndex, &result))
            throw std::runtime_error(CelesteSpirvGetError());
        return result;
    }
}
