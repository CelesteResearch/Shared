#pragma once
#include "Direct3D11Device.h"

// Physical descriptor identity only: do not serialize padding or object addresses.
inline SourceImmutableStateKey<40> SourceRasterizerKey(const D3D11_RASTERIZER_DESC& d)
{
    SourceImmutableStateKey<40> k;
    size_t offset = 0;
    SourceStateKeyField(k, offset, d.FillMode);
    SourceStateKeyField(k, offset, d.CullMode);
    SourceStateKeyField(k, offset, d.FrontCounterClockwise);
    SourceStateKeyField(k, offset, d.DepthBias);
    SourceStateKeyField(k, offset, d.DepthBiasClamp);
    SourceStateKeyField(k, offset, d.SlopeScaledDepthBias);
    SourceStateKeyField(k, offset, d.DepthClipEnable);
    SourceStateKeyField(k, offset, d.ScissorEnable);
    SourceStateKeyField(k, offset, d.MultisampleEnable);
    SourceStateKeyField(k, offset, d.AntialiasedLineEnable);
    return k;
}
inline SourceImmutableStateKey<52> SourceSamplerKey(const D3D11_SAMPLER_DESC& d)
{
    SourceImmutableStateKey<52> k;
    size_t offset = 0;
    SourceStateKeyField(k, offset, d.Filter);
    SourceStateKeyField(k, offset, d.AddressU);
    SourceStateKeyField(k, offset, d.AddressV);
    SourceStateKeyField(k, offset, d.AddressW);
    SourceStateKeyField(k, offset, d.MipLODBias);
    SourceStateKeyField(k, offset, d.MaxAnisotropy);
    SourceStateKeyField(k, offset, d.ComparisonFunc);
    for (float border : d.BorderColor)
        SourceStateKeyField(k, offset, border);
    SourceStateKeyField(k, offset, d.MinLOD);
    SourceStateKeyField(k, offset, d.MaxLOD);
    return k;
}
inline std::shared_ptr<ID3D11RasterizerState> SourceBorrowRasterizerState(Direct3D11Device* device,
                                                                          const D3D11_RASTERIZER_DESC* description)
{
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto key = SourceRasterizerKey(*description);
    auto found = device->rasterizerStates.find(key);
    if (found != device->rasterizerStates.end())
        return found->second;
    ID3D11RasterizerState* state = nullptr;
    if (FAILED(device->device->CreateRasterizerState(description, &state)))
    {
        SourceSetError("D3D11 CreateRasterizerState failed");
        return {};
    }
    auto owner = std::shared_ptr<ID3D11RasterizerState>(state, [](ID3D11RasterizerState* value) { value->Release(); });
    device->rasterizerStates.emplace(std::move(key), owner);
    return owner;
}
inline std::shared_ptr<ID3D11SamplerState> SourceBorrowSamplerState(Direct3D11Device* device,
                                                                    const D3D11_SAMPLER_DESC* description,
                                                                    const char* error)
{
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto key = SourceSamplerKey(*description);
    auto found = device->samplerStates.find(key);
    if (found != device->samplerStates.end())
        return found->second;
    ID3D11SamplerState* state = nullptr;
    if (FAILED(device->device->CreateSamplerState(description, &state)))
    {
        SourceSetError(error);
        return {};
    }
    auto owner = std::shared_ptr<ID3D11SamplerState>(state, [](ID3D11SamplerState* value) { value->Release(); });
    device->samplerStates.emplace(std::move(key), owner);
    return owner;
}

inline SourceImmutableStateKey<240> SourceBlendKey(const D3D11_BLEND_DESC& d)
{
    SourceImmutableStateKey<240> k;
    size_t offset = 0;
    SourceStateKeyField(k, offset, d.AlphaToCoverageEnable);
    SourceStateKeyField(k, offset, d.IndependentBlendEnable);
    for (const auto& target : d.RenderTarget)
    {
        SourceStateKeyField(k, offset, target.BlendEnable);
        SourceStateKeyField(k, offset, target.SrcBlend);
        SourceStateKeyField(k, offset, target.DestBlend);
        SourceStateKeyField(k, offset, target.BlendOp);
        SourceStateKeyField(k, offset, target.SrcBlendAlpha);
        SourceStateKeyField(k, offset, target.DestBlendAlpha);
        SourceStateKeyField(k, offset, target.BlendOpAlpha);
        SourceStateKeyField(k, offset, target.RenderTargetWriteMask);
    }
    return k;
}
inline SourceImmutableStateKey<50> SourceDepthStencilKey(const D3D11_DEPTH_STENCIL_DESC& d)
{
    SourceImmutableStateKey<50> k;
    size_t offset = 0;
    SourceStateKeyField(k, offset, d.DepthEnable);
    SourceStateKeyField(k, offset, d.DepthWriteMask);
    SourceStateKeyField(k, offset, d.DepthFunc);
    SourceStateKeyField(k, offset, d.StencilEnable);
    SourceStateKeyField(k, offset, d.StencilReadMask);
    SourceStateKeyField(k, offset, d.StencilWriteMask);
    SourceStateKeyField(k, offset, d.FrontFace.StencilFailOp);
    SourceStateKeyField(k, offset, d.FrontFace.StencilDepthFailOp);
    SourceStateKeyField(k, offset, d.FrontFace.StencilPassOp);
    SourceStateKeyField(k, offset, d.FrontFace.StencilFunc);
    SourceStateKeyField(k, offset, d.BackFace.StencilFailOp);
    SourceStateKeyField(k, offset, d.BackFace.StencilDepthFailOp);
    SourceStateKeyField(k, offset, d.BackFace.StencilPassOp);
    SourceStateKeyField(k, offset, d.BackFace.StencilFunc);
    return k;
}
inline std::shared_ptr<ID3D11BlendState> SourceBorrowBlendState(Direct3D11Device* device,
                                                                const D3D11_BLEND_DESC* description)
{
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto key = SourceBlendKey(*description);
    auto found = device->blendStates.find(key);
    if (found != device->blendStates.end())
        return found->second;
    ID3D11BlendState* state = nullptr;
    if (FAILED(device->device->CreateBlendState(description, &state)))
    {
        SourceSetError("D3D11 CreateBlendState failed");
        return {};
    }
    auto owner = std::shared_ptr<ID3D11BlendState>(state, [](ID3D11BlendState* value) { value->Release(); });
    device->blendStates.emplace(std::move(key), owner);
    return owner;
}
inline std::shared_ptr<ID3D11DepthStencilState> SourceBorrowDepthStencilState(
    Direct3D11Device* device, const D3D11_DEPTH_STENCIL_DESC* description)
{
    std::lock_guard<std::recursive_mutex> lock(device->physicalLock);
    auto key = SourceDepthStencilKey(*description);
    auto found = device->depthStencilStates.find(key);
    if (found != device->depthStencilStates.end())
        return found->second;
    ID3D11DepthStencilState* state = nullptr;
    if (FAILED(device->device->CreateDepthStencilState(description, &state)))
    {
        SourceSetError("D3D11 CreateDepthStencilState failed");
        return {};
    }
    auto owner =
        std::shared_ptr<ID3D11DepthStencilState>(state, [](ID3D11DepthStencilState* value) { value->Release(); });
    device->depthStencilStates.emplace(std::move(key), owner);
    return owner;
}
