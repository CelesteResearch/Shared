#pragma once
#include "DepthResource.h"
#include "TextureResource.h"
struct CelesteGraphicsRenderbuffer
{
    CelesteGraphicsDevice* device;
    std::shared_ptr<Celeste::Graphics::Direct3D12::DepthResource> depth;
    std::shared_ptr<Celeste::Graphics::Direct3D12::TextureResource> color;
};
