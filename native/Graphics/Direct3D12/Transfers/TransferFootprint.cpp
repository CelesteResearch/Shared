#include "TransferFootprint.h"
#include <cstring>
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    TransferFootprint::TransferFootprint(const TextureResource& texture, const CelesteGraphicsTextureRegion& requested)
    {
        const auto r = texture.Region(&requested);
        if (texture.description.SampleDesc.Count != 1)
            throw std::invalid_argument("Resolve multisampled texture before transfer");
        UINT nativeRows;
        UINT64 nativeRowBytes, nativeBytes;
        texture.context->device->GetCopyableFootprints(&texture.description, texture.Subresource(r.level, r.layer), 1,
                                                       0, &native, &nativeRows, &nativeRowBytes, &nativeBytes);
        if (nativeBytes == UINT64_MAX)
            throw std::runtime_error("GetCopyableFootprints rejected texture");
        // Keep the exact subresource format, but pack only the requested block rectangle.
        rowBytes = texture.format.RowBytes(r.width);
        rows = texture.format.Rows(r.height);
        const uint64_t pitch =
            (rowBytes + D3D12_TEXTURE_DATA_PITCH_ALIGNMENT - 1) & ~uint64_t(D3D12_TEXTURE_DATA_PITCH_ALIGNMENT - 1);
        if (pitch > UINT32_MAX)
            throw std::length_error("Texture transfer pitch exceeds D3D12 range");
        native.Offset = 0;
        native.Footprint.Width =
            (r.width + texture.format.blockWidth - 1) / texture.format.blockWidth * texture.format.blockWidth;
        native.Footprint.Height =
            (r.height + texture.format.blockHeight - 1) / texture.format.blockHeight * texture.format.blockHeight;
        native.Footprint.Depth = r.depth;
        native.Footprint.RowPitch = static_cast<UINT>(pitch);
        slicePitch = pitch * rows;
        totalBytes = slicePitch * (r.depth - 1) + pitch * (rows - 1) + rowBytes;
    }
    void TransferFootprint::Pack(void* destination, const void* source, size_t bytes) const
    {
        if (!destination || !source || bytes != rowBytes * rows * native.Footprint.Depth)
            throw std::invalid_argument("Texture upload byte count mismatch");
        for (uint32_t z = 0; z < native.Footprint.Depth; ++z)
            for (uint32_t y = 0; y < rows; ++y)
                std::memcpy(
                    static_cast<char*>(destination) + native.Offset + z * slicePitch + y * native.Footprint.RowPitch,
                    static_cast<const char*>(source) + (z * rows + y) * rowBytes, static_cast<size_t>(rowBytes));
    }
    void TransferFootprint::Unpack(void* destination, size_t bytes, const void* source) const
    {
        if (!destination || !source || bytes != rowBytes * rows * native.Footprint.Depth)
            throw std::invalid_argument("Texture readback byte count mismatch");
        for (uint32_t z = 0; z < native.Footprint.Depth; ++z)
            for (uint32_t y = 0; y < rows; ++y)
                std::memcpy(static_cast<char*>(destination) + (z * rows + y) * rowBytes,
                            static_cast<const char*>(source) + native.Offset + z * slicePitch +
                                y * native.Footprint.RowPitch,
                            static_cast<size_t>(rowBytes));
    }
}
