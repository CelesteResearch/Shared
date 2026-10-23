#pragma once
#include "Device/DeviceContext.h"
#include <d3d12.h>
namespace Celeste::Graphics::Direct3D12
{
    struct PipelineObjects
    {
        std::shared_ptr<DeviceContext> context;
        Microsoft::WRL::ComPtr<ID3D12RootSignature> root;
        Microsoft::WRL::ComPtr<ID3D12PipelineState> pipeline;
        D3D12_PRIMITIVE_TOPOLOGY topology{};
    };
} // namespace Celeste::Graphics::Direct3D12
