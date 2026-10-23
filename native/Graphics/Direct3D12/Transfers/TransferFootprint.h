#pragma once
#include "TextureResource.h"
namespace Celeste::Graphics::Direct3D12
{
    struct TransferFootprint final
    {
        D3D12_PLACED_SUBRESOURCE_FOOTPRINT native{};
        uint32_t rows;
        uint64_t rowBytes, slicePitch, totalBytes;
        TransferFootprint(const TextureResource&, const CelesteGraphicsTextureRegion&);
        void Pack(void* destination, const void* source, size_t sourceBytes) const;
        void Unpack(void* destination, size_t destinationBytes, const void* source) const;
    };
}
