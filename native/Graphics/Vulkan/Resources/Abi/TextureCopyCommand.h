#pragma once
#include <vulkan/vulkan_core.h>
#include <cstdint>
namespace Celeste::Graphics::Vulkan
{
    struct TextureCopyCommand
    {
        uint32_t source, destination;
    };
}
