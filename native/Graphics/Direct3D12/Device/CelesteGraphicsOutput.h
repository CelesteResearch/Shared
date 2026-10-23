#pragma once
#include "CelesteGraphicsDevice.h"
#include "TextureResource.h"
struct CelesteGraphicsOutput
{
    CelesteGraphicsDevice* device;
    Microsoft::WRL::ComPtr<ID3D12Resource> resource;
    CelesteDirect3D12OutputInfo info;
    std::shared_ptr<Celeste::Graphics::Direct3D12::TextureResource> texture;
};
