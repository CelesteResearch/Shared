#pragma once
#include "TextureImage.h"
#include "CelesteGraphicsSourceTypes.h"
namespace Celeste::Graphics::Vulkan
{
    struct SourceSamplerBinding
    {
        std::shared_ptr<TextureImage> texture;
        SourceNativeSamplerState state{};
    };
}
