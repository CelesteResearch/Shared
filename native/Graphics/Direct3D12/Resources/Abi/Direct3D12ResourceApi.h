#pragma once
#include "CelesteGraphicsBackend.h"
namespace Celeste::Graphics::Direct3D12
{
    void CreateTexture(CelesteGraphicsDevice*, const CelesteGraphicsTextureInfo*, CelesteGraphicsTexture**);
    void ReleaseTexture(CelesteGraphicsTexture*) noexcept;
    void SetTextureName(CelesteGraphicsTexture*, const char*, uint32_t);
    void WriteTexture(CelesteGraphicsPacket*, CelesteGraphicsTexture*, const CelesteGraphicsTextureRegion*, const void*,
                      uint32_t);
    void CopyTexture(CelesteGraphicsPacket*, CelesteGraphicsTexture*, CelesteGraphicsTexture*);
    void ReadTexture(CelesteGraphicsPacket*, CelesteGraphicsTexture*, const CelesteGraphicsTextureRegion*,
                     CelesteGraphicsReadback**);
    void CreateBuffer(CelesteGraphicsDevice*, uint8_t, uint8_t, SourceBufferUsage, int32_t, CelesteGraphicsBuffer**);
    void ReleaseBuffer(CelesteGraphicsBuffer*) noexcept;
    void WriteBuffer(CelesteGraphicsPacket*, CelesteGraphicsBuffer*, int32_t, const void*, int32_t, int32_t, int32_t,
                     SourceSetDataOptions);
    void ReadBuffer(CelesteGraphicsPacket*, CelesteGraphicsBuffer*, int32_t, int32_t, int32_t, int32_t,
                    CelesteGraphicsReadback**);
    int32_t GetReadbackStatus(CelesteGraphicsReadback*);
    void GetReadbackBytes(CelesteGraphicsReadback*, const void**, uint32_t*);
    void ReleaseReadback(CelesteGraphicsReadback*) noexcept;
    void CreateDepthRenderbuffer(CelesteGraphicsDevice*, int32_t, int32_t, SourceDepthFormat, int32_t,
                                 CelesteGraphicsRenderbuffer**);
    void CreateColorRenderbuffer(CelesteGraphicsDevice*, int32_t, int32_t, SourceSurfaceFormat, int32_t,
                                 CelesteGraphicsTexture*, CelesteGraphicsRenderbuffer**);
    void ReleaseRenderbuffer(CelesteGraphicsRenderbuffer*) noexcept;
    void ResolveTarget(CelesteGraphicsPacket*, const SourceNativeRenderTargetBinding*);
    void GetCapabilities(CelesteGraphicsDevice*, CelesteGraphicsCapabilities*);
    void GetMaxMultiSampleCount(CelesteGraphicsDevice*, SourceSurfaceFormat, int32_t, int32_t*);
}
