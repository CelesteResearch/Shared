#pragma once
#include "CelesteGraphicsBackend.h"
namespace Celeste::Graphics::Direct3D12
{
    void Clear(CelesteGraphicsPacket* packet, SourceClearOptions options, const float* rgba, float depth,
               int32_t stencil);
}
