#pragma once
#include <vulkan/vulkan_core.h>
#include <cstdint>
namespace Celeste::Graphics::Vulkan
{
    struct TextureTransferCommand
    {
        uint32_t image, staging;
        VkBufferImageCopy region;
        bool read;
    };
}
