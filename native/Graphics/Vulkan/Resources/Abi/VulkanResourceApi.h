#pragma once
#include "CelesteGraphicsBackend.h"
// Throwing implementation functions. The module's single VulkanApiInvoke boundary
// catches errors and publishes its shared thread-local error before crossing C ABI.
namespace Celeste::Graphics::Vulkan
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
}
