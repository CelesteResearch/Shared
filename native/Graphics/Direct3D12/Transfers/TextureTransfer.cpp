#include "TextureTransfer.h"
#include <stdexcept>
#include <algorithm>
namespace Celeste::Graphics::Direct3D12
{
    static TextureResource& RequireTexture(const std::shared_ptr<TextureResource>& texture)
    {
        if (!texture)
            throw std::invalid_argument("Texture transfer requires texture");
        return *texture;
    }
    TextureTransfer::TextureTransfer(std::shared_ptr<TextureResource> source,
                                     const CelesteGraphicsTextureRegion& requested, bool toGpu,
                                     TransferBufferPool& pool)
        : texture(std::move(source)), region(RequireTexture(texture).Region(&requested)), footprint(*texture, region),
          upload(toGpu)
    {
        if (pool.Context().device.Get() != texture->context->device.Get())
            throw std::invalid_argument("Transfer pool belongs to another device");
        staging = pool.Acquire(footprint.totalBytes, upload ? D3D12_HEAP_TYPE_UPLOAD : D3D12_HEAP_TYPE_READBACK);
    }
    void TextureTransfer::Write(const void* bytes, size_t count)
    {
        if (!upload)
            throw std::logic_error("Cannot upload to a readback transfer");
        footprint.Pack(staging->Map(), bytes, count);
    }
    void TextureTransfer::Read(void* bytes, size_t count)
    {
        if (upload)
            throw std::logic_error("Cannot read back an upload transfer");
        footprint.Unpack(bytes, count, staging->Map());
    }
    void TextureTransfer::Retain(CommandLease& lease) const
    {
        lease.Retain(texture);
        lease.Retain(staging);
    }
    void TextureTransfer::Record(CommandLease& lease, ResourceStateTransaction& states) const
    {
        Record(lease, states, *texture, *staging, region, footprint, upload);
    }
    void TextureTransfer::Record(CommandLease& lease, ResourceStateTransaction& states, TextureResource& imageResource,
                                 BufferResource& bufferResource, const CelesteGraphicsTextureRegion& region,
                                 const TransferFootprint& footprint, bool upload)
    {
        auto* texture = &imageResource;
        auto* staging = &bufferResource;
        const uint32_t subresource = texture->Subresource(region.level, region.layer);
        states.Transition(*texture, subresource,
                          upload ? D3D12_RESOURCE_STATE_COPY_DEST : D3D12_RESOURCE_STATE_COPY_SOURCE);
        D3D12_TEXTURE_COPY_LOCATION image{};
        image.pResource = texture->resource.Get();
        image.Type = D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX;
        image.SubresourceIndex = subresource;
        D3D12_TEXTURE_COPY_LOCATION buffer{};
        buffer.pResource = staging->resource.Get();
        buffer.Type = D3D12_TEXTURE_COPY_TYPE_PLACED_FOOTPRINT;
        buffer.PlacedFootprint = footprint.native;
        if (upload)
            lease.List()->CopyTextureRegion(&image, region.x, region.y, region.z, &buffer, nullptr);
        else
        {
            const bool whole = region.x == 0 && region.y == 0 && region.z == 0 &&
                               region.width == std::max(1u, texture->info.width >> region.level) &&
                               region.height == std::max(1u, texture->info.height >> region.level) &&
                               region.depth == std::max(1u, texture->info.depth >> region.level);
            const uint32_t right = (region.x + region.width + texture->format.blockWidth - 1) /
                                   texture->format.blockWidth * texture->format.blockWidth;
            const uint32_t bottom = (region.y + region.height + texture->format.blockHeight - 1) /
                                    texture->format.blockHeight * texture->format.blockHeight;
            const D3D12_BOX box{region.x, region.y, region.z, right, bottom, region.z + region.depth};
            lease.List()->CopyTextureRegion(&buffer, 0, 0, 0, &image, whole ? nullptr : &box);
        }
    }
}
