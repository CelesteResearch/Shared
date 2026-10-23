#pragma once
#include <d3d12.h>
namespace Celeste::Graphics::Direct3D12
{
    enum class RootParameter : UINT
    {
        VertexConstants,
        PixelConstants,
        VertexTextures,
        PixelTextures,
        VertexSamplers,
        PixelSamplers,
        Count
    };
} // namespace Celeste::Graphics::Direct3D12
