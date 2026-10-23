#pragma once
#include "CelesteGraphicsBackend.h"

namespace Celeste::Graphics::Vulkan
{
    void ResolveBackbuffer(CelesteGraphicsPacket*);
    void ConfigureBackbuffer(CelesteGraphicsPacket*, const SourceNativePresentationParameters*);
    void GetBackbufferInfo(CelesteGraphicsDevice*, CelesteGraphicsBackbufferInfo*);
    void Clear(CelesteGraphicsPacket*, SourceClearOptions, const float* rgba, float depth, int32_t stencil);
    void GetBlendFactor(CelesteGraphicsDevice*, uint32_t*);
    void GetSampleMask(CelesteGraphicsDevice*, int32_t*);
    void GetStencilReference(CelesteGraphicsDevice*, int32_t*);
    void SetViewport(CelesteGraphicsPacket*, const SourceCameraViewport*);
    void SetScissorRect(CelesteGraphicsPacket*, const CelesteGraphicsRect*);
    void SetBlendState(CelesteGraphicsPacket*, const SourceNativeBlendState*);
    void SetDepthStencilState(CelesteGraphicsPacket*, const SourceNativeDepthStencilState*);
    void SetRasterizerState(CelesteGraphicsPacket*, const SourceNativeRasterizerState*);
    void SetSampler(CelesteGraphicsPacket*, uint32_t slot, uint8_t vertexStage, CelesteGraphicsTexture*,
                    const SourceNativeSamplerState*);
    void SetBlendFactor(CelesteGraphicsPacket*, uint32_t rgba);
    void SetSampleMask(CelesteGraphicsPacket*, int32_t);
    void SetStencilReference(CelesteGraphicsPacket*, int32_t);
    void SetRenderTargets(CelesteGraphicsPacket*, const SourceNativeRenderTargetBinding*, int32_t count,
                          CelesteGraphicsRenderbuffer*, SourceDepthFormat, uint8_t preserve);
    void SetVertexBindings(CelesteGraphicsPacket*, const SourceNativeVertexBufferBinding*, int32_t count,
                           uint8_t updated, int32_t baseVertex);
    void Draw(CelesteGraphicsPacket*, SourcePrimitiveType, int32_t startVertex, int32_t primitiveCount);
    void DrawIndexed(CelesteGraphicsPacket*, SourcePrimitiveType, int32_t baseVertex, int32_t minVertexIndex,
                     int32_t numVertices, int32_t startIndex, int32_t primitiveCount, int32_t instanceCount,
                     CelesteGraphicsBuffer*, SourceIndexElementSize);
    void ApplyEffect(CelesteGraphicsPacket*, void* effect, uint32_t pass, void* stateChanges);
}
