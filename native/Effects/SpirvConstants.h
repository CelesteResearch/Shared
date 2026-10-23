#pragma once
#include "EffectFrontend.h"
#include <cstddef>
namespace Celeste::Graphics::Effects
{
    // Existing frontend register packing; no shader parse or allocation during copy.
    void CopySpirvConstants(const ShaderDescription& shader, const RegisterView& registers, bool vertex,
                            void* destination, size_t capacityBytes);
}
