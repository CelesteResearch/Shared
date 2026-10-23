#pragma once
#include <d3dcompiler.h>
#include <wrl/client.h>
namespace Celeste::Graphics::Direct3D12
{
    struct CompiledShaders
    {
        Microsoft::WRL::ComPtr<ID3DBlob> vertex, pixel;
    };
}
