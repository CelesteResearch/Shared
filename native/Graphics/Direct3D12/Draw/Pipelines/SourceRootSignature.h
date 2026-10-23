#pragma once
#include "RootParameter.h"
#include <d3dcommon.h>
#include <wrl/client.h>
#include <array>
namespace Celeste::Graphics::Direct3D12
{

    constexpr UINT ShaderResourceSlots = 16;
    // No pointers escape this builder; Serialize reconstructs a descriptor referencing its own arrays.
    class SourceRootSignature
    {
        std::array<D3D12_DESCRIPTOR_RANGE, 4> ranges{};
        std::array<D3D12_ROOT_PARAMETER, 6> parameters{};

      public:
        SourceRootSignature();
        Microsoft::WRL::ComPtr<ID3DBlob> Serialize() const;
        Microsoft::WRL::ComPtr<ID3D12RootSignature> Create(ID3D12Device*) const;
    };
} // namespace Celeste::Graphics::Direct3D12
