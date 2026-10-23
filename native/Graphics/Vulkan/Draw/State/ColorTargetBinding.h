#pragma once
#include "TextureImage.h"
namespace Celeste::Graphics::Vulkan
{
    struct ColorTargetBinding
    {
        std::shared_ptr<TextureImage> image;
        uint32_t level = 0, layer = 0;
    };
}
