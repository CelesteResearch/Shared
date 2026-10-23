#pragma once
#include "TextureResource.h"
struct CelesteGraphicsTexture
{
    CelesteGraphicsDevice* device;
    std::shared_ptr<Celeste::Graphics::Direct3D12::TextureResource> image;
};
