#pragma once
#include "TextureResource.h"
struct Direct3D12TargetBinding
{
    std::shared_ptr<Celeste::Graphics::Direct3D12::TextureResource> image;
    uint32_t layer = 0;
};
