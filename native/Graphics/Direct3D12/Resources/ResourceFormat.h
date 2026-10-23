#pragma once
#include "CelesteGraphicsBackend.h"
#include <dxgiformat.h>
namespace Celeste::Graphics::Direct3D12
{
    struct ResourceFormat final
    {
        DXGI_FORMAT native;
        uint32_t blockWidth, blockHeight, blockBytes;
        static ResourceFormat FromSource(SourceSurfaceFormat source);
        uint64_t RowBytes(uint32_t width) const;
        uint32_t Rows(uint32_t height) const;
        uint64_t ByteSize(uint32_t width, uint32_t height, uint32_t depth) const;
    };
}
