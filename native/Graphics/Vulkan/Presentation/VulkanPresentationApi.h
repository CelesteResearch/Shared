#pragma once
#include "CelesteGraphicsBackend.h"
namespace Celeste::Graphics::Vulkan
{
    void Present(CelesteGraphicsPacket*, CelesteGraphicsTexture*, CelesteGraphicsOutput*, const CelesteGraphicsRect*,
                 const CelesteGraphicsRect*);
    void PresentBackbuffer(CelesteGraphicsPacket*, CelesteGraphicsOutput*, const CelesteGraphicsRect*,
                           const CelesteGraphicsRect*);
    void ReadBackbuffer(CelesteGraphicsPacket*, const CelesteGraphicsRect*, CelesteGraphicsReadback**);
    void GetCapabilities(CelesteGraphicsDevice*, CelesteGraphicsCapabilities*);
    void GetMaxMultiSampleCount(CelesteGraphicsDevice*, SourceSurfaceFormat, int32_t, int32_t*);
}
