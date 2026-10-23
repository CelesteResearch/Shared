#pragma once
#include "CelesteGraphicsBackend.h"
#include "TextureResource.h"
namespace Celeste::Graphics::Direct3D12
{
    void ValidateMipGeneration(const TextureResource&);
    void GenerateMipmaps(CelesteGraphicsPacket*, std::shared_ptr<TextureResource>);
}
