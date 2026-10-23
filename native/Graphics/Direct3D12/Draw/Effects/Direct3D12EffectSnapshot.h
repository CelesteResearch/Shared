#pragma once
#include "Direct3D12EffectShaderLease.h"
#include <memory>
#include <vector>
struct Direct3D12EffectCache;
struct Direct3D12EffectSnapshot
{
    std::array<std::shared_ptr<Direct3D12EffectShaderLease>, 2> shaders;
    std::array<std::vector<uint8_t>, 2> constants;
    std::weak_ptr<Direct3D12EffectCache> cache;
};
