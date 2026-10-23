#include "Direct3D12EffectShaderLease.h"
#include <mojoshader.h>
#include <cstring>
#include <stdexcept>
Direct3D12EffectShaderLease::Direct3D12EffectShaderLease(void* effect, bool vertex)
{
    samplerTypes.fill(-1);
    if (!CelesteEffectAcquireBoundShader(effect, vertex, &handle))
        throw std::runtime_error(CelesteEffectGetError());
    try
    {
        if (!handle || !CelesteEffectGetShaderDescription(handle, &description))
            throw std::runtime_error(CelesteEffectGetError());
        if (!description.profile || std::strcmp(description.profile, "hlsl") != 0)
            throw std::invalid_argument("D3D12 requires an HLSL effect frontend");
        auto parsed = static_cast<const MOJOSHADER_parseData*>(description.parsed);
        for (int i = 0; i < parsed->sampler_count; i++)
        {
            auto sampler = parsed->samplers[i];
            if (sampler.index < 0 || sampler.index >= 16)
                throw std::out_of_range("Sampler outside Source stage");
            samplerTypes[sampler.index] = sampler.type;
        }
    }
    catch (...)
    {
        if (handle)
            CelesteEffectReleaseShader(handle);
        handle = nullptr;
        throw;
    }
}
Direct3D12EffectShaderLease::~Direct3D12EffectShaderLease()
{
    if (handle)
        CelesteEffectReleaseShader(handle);
}
