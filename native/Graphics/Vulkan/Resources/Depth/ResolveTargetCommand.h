#pragma once
#include <cstdint>
namespace Celeste::Graphics::Vulkan
{
    struct ResolveTargetCommand
    {
        uint32_t source, destination, layer;
        bool resolve, mipmaps;
    };
}
