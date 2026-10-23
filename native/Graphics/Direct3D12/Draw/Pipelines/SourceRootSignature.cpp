#include "SourceRootSignature.h"
#include <stdexcept>
#include <string>
namespace Celeste::Graphics::Direct3D12
{
    SourceRootSignature::SourceRootSignature()
    {
        for (UINT stage = 0; stage < 2; ++stage)
        {
            parameters[stage].ParameterType = D3D12_ROOT_PARAMETER_TYPE_CBV;
            parameters[stage].Descriptor = {0, 0};
            parameters[stage].ShaderVisibility =
                stage == 0 ? D3D12_SHADER_VISIBILITY_VERTEX : D3D12_SHADER_VISIBILITY_PIXEL;
        }
        for (UINT i = 0; i < 4; ++i)
        {
            ranges[i] = {i < 2 ? D3D12_DESCRIPTOR_RANGE_TYPE_SRV : D3D12_DESCRIPTOR_RANGE_TYPE_SAMPLER,
                         ShaderResourceSlots, 0, 0, 0};
            parameters[i + 2].ParameterType = D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE;
            parameters[i + 2].ShaderVisibility =
                (i % 2) == 0 ? D3D12_SHADER_VISIBILITY_VERTEX : D3D12_SHADER_VISIBILITY_PIXEL;
        }
    }
    Microsoft::WRL::ComPtr<ID3DBlob> SourceRootSignature::Serialize() const
    {
        auto fixedParameters = parameters;
        for (UINT i = 0; i < 4; ++i)
            fixedParameters[i + 2].DescriptorTable = {1, &ranges[i]};
        D3D12_ROOT_SIGNATURE_DESC description{};
        description.NumParameters = static_cast<UINT>(fixedParameters.size());
        description.pParameters = fixedParameters.data();
        description.Flags = D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT |
                            D3D12_ROOT_SIGNATURE_FLAG_DENY_HULL_SHADER_ROOT_ACCESS |
                            D3D12_ROOT_SIGNATURE_FLAG_DENY_DOMAIN_SHADER_ROOT_ACCESS |
                            D3D12_ROOT_SIGNATURE_FLAG_DENY_GEOMETRY_SHADER_ROOT_ACCESS;
        Microsoft::WRL::ComPtr<ID3DBlob> blob, error;
        const auto status = D3D12SerializeRootSignature(&description, D3D_ROOT_SIGNATURE_VERSION_1, &blob, &error);
        if (FAILED(status))
            throw std::runtime_error(
                error ? std::string(static_cast<const char*>(error->GetBufferPointer()), error->GetBufferSize())
                      : "Root signature serialization failed");
        return blob;
    }
    Microsoft::WRL::ComPtr<ID3D12RootSignature> SourceRootSignature::Create(ID3D12Device* device) const
    {
        if (!device)
            throw std::invalid_argument("A D3D12 device is required");
        auto bytes = Serialize();
        Microsoft::WRL::ComPtr<ID3D12RootSignature> root;
        const auto result =
            device->CreateRootSignature(0, bytes->GetBufferPointer(), bytes->GetBufferSize(), IID_PPV_ARGS(&root));
        if (FAILED(result))
            throw std::runtime_error("D3D12 CreateRootSignature failed: " +
                                     std::to_string(static_cast<uint32_t>(result)));
        return root;
    }
} // namespace Celeste::Graphics::Direct3D12
