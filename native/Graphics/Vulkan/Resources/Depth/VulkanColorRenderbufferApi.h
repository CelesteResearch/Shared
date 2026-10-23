#pragma once
#include "CelesteGraphicsBackend.h"
namespace Celeste::Graphics::Vulkan
{
    void CreateColorRenderbuffer(CelesteGraphicsDevice*, int32_t, int32_t, SourceSurfaceFormat, int32_t,
                                 CelesteGraphicsTexture*, CelesteGraphicsRenderbuffer**);
    void ResolveTarget(CelesteGraphicsPacket*, const SourceNativeRenderTargetBinding*);
    void GetMaxMultiSampleCount(CelesteGraphicsDevice*, SourceSurfaceFormat, int32_t, int32_t*);
}
