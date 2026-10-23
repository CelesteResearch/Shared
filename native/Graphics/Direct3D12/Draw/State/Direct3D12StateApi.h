#pragma once
#include "CelesteGraphicsBackend.h"
namespace Celeste::Graphics::Direct3D12
{
    void SetViewport(CelesteGraphicsPacket*, const SourceCameraViewport*);
    void SetScissorRect(CelesteGraphicsPacket*, const CelesteGraphicsRect*);
    void SetBlendState(CelesteGraphicsPacket*, const SourceNativeBlendState*);
    void SetDepthStencilState(CelesteGraphicsPacket*, const SourceNativeDepthStencilState*);
    void SetRasterizerState(CelesteGraphicsPacket*, const SourceNativeRasterizerState*);
    void SetSampler(CelesteGraphicsPacket*, uint32_t, uint8_t, CelesteGraphicsTexture*,
                    const SourceNativeSamplerState*);
    void GetBlendFactor(CelesteGraphicsDevice*, uint32_t*);
    void SetBlendFactor(CelesteGraphicsPacket*, uint32_t);
    void GetSampleMask(CelesteGraphicsDevice*, int32_t*);
    void SetSampleMask(CelesteGraphicsPacket*, int32_t);
    void GetStencilReference(CelesteGraphicsDevice*, int32_t*);
    void SetStencilReference(CelesteGraphicsPacket*, int32_t);
    void SetRenderTargets(CelesteGraphicsPacket*, const SourceNativeRenderTargetBinding*, int32_t,
                          CelesteGraphicsRenderbuffer*, SourceDepthFormat, uint8_t);
    void SetVertexBindings(CelesteGraphicsPacket*, const SourceNativeVertexBufferBinding*, int32_t, uint8_t, int32_t);
} // namespace Celeste::Graphics::Direct3D12
