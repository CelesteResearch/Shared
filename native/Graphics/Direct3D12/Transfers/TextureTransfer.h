#pragma once
#include "TransferFootprint.h"
#include "BufferResource.h"
#include "ResourceStateTransaction.h"
#include "TransferBufferPool.h"
namespace Celeste::Graphics::Direct3D12
{
    class TextureTransfer final
    {
      public:
        std::shared_ptr<TextureResource> texture;
        std::shared_ptr<BufferResource> staging;
        CelesteGraphicsTextureRegion region;
        TransferFootprint footprint;
        const bool upload;
        TextureTransfer(std::shared_ptr<TextureResource>, const CelesteGraphicsTextureRegion&, bool upload,
                        TransferBufferPool&);
        void Write(const void* bytes, size_t count);
        void Read(void* bytes, size_t count);
        void Retain(CommandLease&) const;
        void Record(CommandLease&, ResourceStateTransaction&) const;
        static void Record(CommandLease&, ResourceStateTransaction&, TextureResource&, BufferResource&,
                           const CelesteGraphicsTextureRegion&, const TransferFootprint&, bool upload);
    };
}
