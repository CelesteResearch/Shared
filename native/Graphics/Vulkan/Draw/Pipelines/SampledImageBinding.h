#pragma once
#include "TextureImage.h"
namespace Celeste::Graphics::Vulkan
{
    struct SampledImageBinding
    {
        uint32_t slot;
        std::shared_ptr<TextureImage> image;
        VkSamplerCreateInfo sampler;
    };
}
