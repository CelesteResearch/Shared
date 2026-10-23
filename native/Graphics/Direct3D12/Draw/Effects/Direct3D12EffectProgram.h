#pragma once
#include "CompiledShaders.h"
#include <string>
struct Direct3D12EffectProgram
{
    Celeste::Graphics::Direct3D12::CompiledShaders shaders;
    std::string cacheKey;
};
