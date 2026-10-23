#pragma once
#include "CelesteGraphicsBackend.h"
#include "TextureImage.h"
#include <memory>
#include <string>
struct CelesteGraphicsTexture final
{
    CelesteGraphicsDevice* device;
    std::shared_ptr<Celeste::Graphics::Vulkan::TextureImage> image;
    CelesteGraphicsTextureInfo info;
    std::string name;
};
