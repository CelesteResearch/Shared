#pragma once
#include "CelesteGraphicsBackend.h"
namespace Celeste::Graphics::Direct3D12
{
    void Draw(CelesteGraphicsPacket*, SourcePrimitiveType, int32_t startVertex, int32_t primitiveCount);
    void DrawIndexed(CelesteGraphicsPacket*, SourcePrimitiveType, int32_t baseVertex, int32_t minVertexIndex,
                     int32_t numVertices, int32_t startIndex, int32_t primitiveCount, int32_t instanceCount,
                     CelesteGraphicsBuffer*, SourceIndexElementSize);
} // namespace Celeste::Graphics::Direct3D12
