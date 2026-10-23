#pragma once
#include <cstddef>
#include <cstdint>
namespace Celeste::Graphics::Vulkan
{
    struct ShaderBinary
    {
        const uint32_t* words;
        size_t byteCount;
        const char* entryPoint;
    };
}
