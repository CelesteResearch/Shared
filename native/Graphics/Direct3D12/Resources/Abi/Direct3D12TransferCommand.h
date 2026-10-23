#pragma once
#include "TransferFootprint.h"
namespace Celeste::Graphics::Direct3D12
{
    struct TextureTransferCommand
    {
        uint32_t image, staging;
        CelesteGraphicsTextureRegion region;
        TransferFootprint footprint;
        bool upload;
    };
    struct BufferTransferCommand
    {
        uint32_t buffer, staging;
        uint64_t offset;
        uint32_t count, size, stride;
        bool upload;
    };
}
