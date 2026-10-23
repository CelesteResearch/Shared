#pragma once
#include "CelesteGraphicsBackend.h"
struct Direct3D12DrawPayload
{
    uint32_t stateIndex = 0, preparedIndex = 0, indexResource = UINT32_MAX;
    SourcePrimitiveType primitive = SourcePrimitiveType_TriangleList;
    uint32_t count = 0, start = 0, instances = 1;
    int32_t baseVertex = 0;
    SourceIndexElementSize indexSize = SourceIndexElementSize_SixteenBits;
};
