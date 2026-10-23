#pragma once
#include "TextureResource.h"
struct Direct3D12SamplerBinding
{
    std::shared_ptr<Celeste::Graphics::Direct3D12::TextureResource> texture;
    SourceNativeSamplerState state{SourceTextureFilter_Linear,
                                   SourceTextureAddressMode_Wrap,
                                   SourceTextureAddressMode_Wrap,
                                   SourceTextureAddressMode_Wrap,
                                   0,
                                   4,
                                   0};
};
