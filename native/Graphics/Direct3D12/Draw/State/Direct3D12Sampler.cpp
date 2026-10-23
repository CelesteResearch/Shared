#include "Direct3D12Sampler.h"
#include <cfloat>
#include <stdexcept>
D3D12_SAMPLER_DESC ConvertSampler(const SourceNativeSamplerState& source)
{
    static constexpr D3D12_FILTER filters[] = {D3D12_FILTER_MIN_MAG_MIP_LINEAR,
                                               D3D12_FILTER_MIN_MAG_MIP_POINT,
                                               D3D12_FILTER_ANISOTROPIC,
                                               D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT,
                                               D3D12_FILTER_MIN_MAG_POINT_MIP_LINEAR,
                                               D3D12_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR,
                                               D3D12_FILTER_MIN_LINEAR_MAG_MIP_POINT,
                                               D3D12_FILTER_MIN_POINT_MAG_MIP_LINEAR,
                                               D3D12_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT};
    static constexpr D3D12_TEXTURE_ADDRESS_MODE addresses[] = {
        D3D12_TEXTURE_ADDRESS_MODE_WRAP, D3D12_TEXTURE_ADDRESS_MODE_CLAMP, D3D12_TEXTURE_ADDRESS_MODE_MIRROR};
    if (source.filter < 0 || source.filter >= 9 || source.addressU < 0 || source.addressU >= 3 || source.addressV < 0 ||
        source.addressV >= 3 || source.addressW < 0 || source.addressW >= 3)
        throw std::invalid_argument("Invalid source sampler enum");
    D3D12_SAMPLER_DESC result{};
    result.Filter = filters[source.filter];
    result.AddressU = addresses[source.addressU];
    result.AddressV = addresses[source.addressV];
    result.AddressW = addresses[source.addressW];
    result.MipLODBias = source.mipMapLevelOfDetailBias;
    result.MaxAnisotropy = static_cast<UINT>(source.maxAnisotropy);
    result.ComparisonFunc = D3D12_COMPARISON_FUNC_NEVER;
    result.MinLOD = static_cast<float>(source.maxMipLevel);
    result.MaxLOD = FLT_MAX;
    for (auto& value : result.BorderColor)
        value = 1;
    return result;
}
