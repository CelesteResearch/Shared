#pragma once
#include <string>
namespace Celeste::Graphics::Direct3D12
{
    struct PreparedShaders
    {
        std::string vertexSource, pixelSource, vertexEntry, pixelEntry, cacheKey;
    };
}
