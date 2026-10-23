#include "EffectShaderLease.h"
#include <stdexcept>
#include <cstring>

namespace Celeste::Graphics::Vulkan
{
    EffectShaderLease::EffectShaderLease(void* effect, bool vertex)
    {
        if (!CelesteEffectAcquireBoundShader(effect, vertex, &handle))
            throw std::runtime_error(CelesteEffectGetError());
        try
        {
            if (!handle)
                throw std::runtime_error("The effect has no bound shader for the requested stage");
            if (!CelesteEffectGetShaderDescription(handle, &description))
                throw std::runtime_error(CelesteEffectGetError());
            if (!description.profile || std::strcmp(description.profile, "spirv") != 0)
                throw std::invalid_argument("Vulkan requires a spirv effect frontend");
        }
        catch (...)
        {
            if (handle)
                CelesteEffectReleaseShader(handle);
            throw;
        }
    }
    EffectShaderLease::~EffectShaderLease()
    {
        if (handle)
            CelesteEffectReleaseShader(handle);
    }
}
