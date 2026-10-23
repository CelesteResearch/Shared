#pragma once
#include "DeviceContext.h"
namespace Celeste::Graphics::Direct3D12
{
    struct PresentationDescriptors
    {
        Microsoft::WRL::ComPtr<ID3D12DescriptorHeap> shaderHeap, renderHeap;
        explicit PresentationDescriptors(const DeviceContext&);
    };
}
