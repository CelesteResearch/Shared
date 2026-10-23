#pragma once
#include "EffectFrontendAbi.h"
#include <array>
struct Direct3D12EffectShaderLease
{
    void* handle = nullptr;
    CelesteEffectShaderDescription description{};
    std::array<int32_t, 16> samplerTypes;
    Direct3D12EffectShaderLease(void* effect, bool vertex);
    ~Direct3D12EffectShaderLease();
    Direct3D12EffectShaderLease(const Direct3D12EffectShaderLease&) = delete;
    Direct3D12EffectShaderLease& operator=(const Direct3D12EffectShaderLease&) = delete;
};
