#pragma once
#include "CelesteGraphicsBackend.h"
#include "TextureResource.h"
namespace Celeste::Graphics::Direct3D12
{
    void PresentImage(CelesteGraphicsPacket*, std::shared_ptr<TextureResource>, CelesteGraphicsOutput*,
                      const CelesteGraphicsRect*, const CelesteGraphicsRect*);
    void Present(CelesteGraphicsPacket*, CelesteGraphicsTexture*, CelesteGraphicsOutput*, const CelesteGraphicsRect*,
                 const CelesteGraphicsRect*);
    void PresentBackbuffer(CelesteGraphicsPacket*, CelesteGraphicsOutput*, const CelesteGraphicsRect*,
                           const CelesteGraphicsRect*);
    void BindPresentationApi(CelesteGraphicsDeviceApi&);
}
