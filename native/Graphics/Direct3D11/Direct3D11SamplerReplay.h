#pragma once
#include "Direct3D11Resources.h"
#include <memory>
#include <optional>
struct Direct3D11TextureLease
{
    SourceGpuTexture* texture;
    explicit Direct3D11TextureLease(SourceGpuTexture* value) : texture(value)
    {
        if (texture)
            texture->references.fetch_add(1, std::memory_order_relaxed);
    }
    Direct3D11TextureLease(const Direct3D11TextureLease& other) : Direct3D11TextureLease(other.texture)
    {
    }
    Direct3D11TextureLease(Direct3D11TextureLease&& other) noexcept : texture(other.texture)
    {
        other.texture = nullptr;
    }
    ~Direct3D11TextureLease()
    {
        if (texture && texture->references.fetch_sub(1, std::memory_order_acq_rel) == 1)
            delete texture;
    }
    explicit operator bool() const noexcept
    {
        return texture != nullptr;
    }
    SourceGpuTexture* operator->() const noexcept
    {
        return texture;
    }
};

struct Direct3D11SourceSamplerReplay
{
    uint32_t slot, vertexStage;
    Direct3D11TextureLease retained;
    std::shared_ptr<ID3D11SamplerState> sampler;
    Direct3D11SourceSamplerReplay(uint32_t s, uint32_t v, Direct3D11TextureLease&& t,
                                  std::shared_ptr<ID3D11SamplerState>&& state)
        : slot(s), vertexStage(v), retained(std::move(t)), sampler(std::move(state))
    {
    }
};
std::optional<Direct3D11SourceSamplerReplay> SourceCaptureSourceSampler(Direct3D11Device*, uint32_t, SourceGpuTexture*,
                                                                        const D3D11_SAMPLER_DESC*, uint32_t);
void SourceReplaySourceSampler(Direct3D11Device*, const Direct3D11SourceSamplerReplay&);
