#pragma once
#include "TextureImage.h"
#include <array>
namespace Celeste::Graphics::Vulkan
{
    class NullTextureCache final
    {
        std::shared_ptr<ResourceContext> context;
        std::array<std::shared_ptr<TextureImage>, 3> images;

      public:
        explicit NullTextureCache(std::shared_ptr<ResourceContext> value) : context(std::move(value))
        {
        }
        static uint32_t Dimension(int shaderSamplerType);
        const std::shared_ptr<TextureImage>& Get(int shaderSamplerType);
    };
}
