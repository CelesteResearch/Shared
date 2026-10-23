#pragma once
#include "TextureResource.h"
struct CelesteGraphicsPacket;
namespace Celeste::Graphics::Direct3D12
{
    void ConfigureBackbuffer(CelesteGraphicsPacket*, const SourceNativePresentationParameters*);
    void GetBackbufferInfo(CelesteGraphicsDevice*, CelesteGraphicsBackbufferInfo*);
    std::shared_ptr<TextureResource> GetBackbuffer(CelesteGraphicsPacket&);
    void ResolveBackbuffer(CelesteGraphicsPacket&);
    void ReadBackbuffer(CelesteGraphicsPacket*, const CelesteGraphicsRect*, CelesteGraphicsReadback**);
} // namespace Celeste::Graphics::Direct3D12
