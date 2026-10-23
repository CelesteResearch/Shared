#pragma once
#include "DeviceContext.h"
namespace Celeste::Graphics::Direct3D12
{
    struct PresentationPipeline
    {
        Microsoft::WRL::ComPtr<ID3D12RootSignature> root;
        Microsoft::WRL::ComPtr<ID3D12PipelineState> pipeline;
    };
}
