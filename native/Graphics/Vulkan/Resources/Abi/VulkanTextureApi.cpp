#include "TextureCopyCommand.h"
#include "TextureTransferCommand.h"
#include "VulkanResourceApi.h"
#include "CelesteGraphicsTexture.h"
#include "CelesteGraphicsReadback.h"
#include "CelesteGraphicsPacket.h"
#include "TransferBufferPool.h"
#include "TextureBytes.h"
#include <limits>
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    static VkBufferImageCopy Region(const CelesteGraphicsTexture& texture, const CelesteGraphicsTextureRegion* region)
    {
        if (!region)
            throw std::invalid_argument("Missing texture region");
        const auto result = texture.image->Region(*region);
        if (texture.image->SourceByteSize(result) > UINT32_MAX)
            throw std::length_error("Texture region exceeds ABI byte range");
        return result;
    }
    static void Require(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* texture)
    {
        if (!packet || !texture || &packet->Owner() != texture->device)
            throw std::invalid_argument("Texture and packet must belong to one device");
        packet->RequireOpen();
    }
    void CreateTexture(CelesteGraphicsDevice* device, const CelesteGraphicsTextureInfo* info,
                       CelesteGraphicsTexture** result)
    {
        if (result)
            *result = nullptr;
        if (!device || !info || !result)
            throw std::invalid_argument("Texture creation requires device, info and output");
        auto texture = std::make_unique<CelesteGraphicsTexture>();
        texture->device = device;
        texture->info = *info;
        texture->image = std::make_shared<TextureImage>(device->Resources(), *info);
        *result = texture.release();
    }
    void ReleaseTexture(CelesteGraphicsTexture* texture) noexcept
    {
        delete texture;
    }
    void SetTextureName(CelesteGraphicsTexture* texture, const char* name, uint32_t length)
    {
        if (!texture || (!name && length))
            throw std::invalid_argument("Invalid texture name");
        texture->name.assign(name ? name : "", length);
    }

    static void RecordTransfer(CelesteGraphicsPacket& packet, const void* payload,
                               VulkanPacketRecordContext& recording) noexcept
    {
        const auto& command = *static_cast<const TextureTransferCommand*>(payload);
        auto& image = packet.Resource<TextureImage>(command.image);
        auto& buffer = packet.Resource<TransferBuffer>(command.staging);
        if (command.read)
            recording.images.Readback(image, buffer, command.region);
        else
            recording.images.Upload(image, buffer, command.region);
    }
    void WriteTexture(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* texture,
                      const CelesteGraphicsTextureRegion* region, const void* bytes, uint32_t byteCount)
    {
        Require(packet, texture);
        const auto copy = Region(*texture, region);
        const uint64_t required = texture->image->SourceByteSize(copy);
        const uint64_t storageBytes = texture->image->ByteSize(copy);
        if (!bytes || byteCount < required)
            throw std::invalid_argument("Texture upload byte count does not match region");
        auto staging = texture->device->StagingBuffers()->Acquire(storageBytes);
        if (texture->info.sourceFormat == SourceSurfaceFormat_Bgra4444 ||
            texture->info.sourceFormat == SourceSurfaceFormat_Alpha8)
        {
            auto* mapped = static_cast<uint8_t*>(staging->WriteAddress(static_cast<size_t>(storageBytes)));
            EncodeTextureBytes(texture->info.sourceFormat, mapped, static_cast<const uint8_t*>(bytes),
                               static_cast<size_t>(required));
            staging->FlushWrittenData();
        }
        else
            staging->Write(bytes, static_cast<size_t>(required));
        TextureTransferCommand command{packet->Retain(texture->image), packet->Retain(staging), copy, false};
        packet->RegisterImage(*texture->image);
        packet->AddCommand(command, nullptr, RecordTransfer);
    }
    void ReadTexture(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* texture,
                     const CelesteGraphicsTextureRegion* region, CelesteGraphicsReadback** result)
    {
        if (result)
            *result = nullptr;
        if (!result)
            throw std::invalid_argument("Readback requires output");
        Require(packet, texture);
        const auto copy = Region(*texture, region);
        const size_t bytes = static_cast<size_t>(texture->image->ByteSize(copy));
        auto state = std::make_shared<VulkanReadbackState>();
        state->device = texture->device;
        state->sourceFormat = texture->info.sourceFormat;
        if (texture->image->format.Compressed())
        {
            state->unchanged = true;
            auto handle = std::make_unique<CelesteGraphicsReadback>();
            handle->state = state;
            *result = handle.release();
            return;
        }
        state->staging = texture->device->StagingBuffers()->Acquire(bytes);
        state->completion = packet->Completion();
        state->bytes.resize(bytes);
        auto resultHandle = std::make_unique<CelesteGraphicsReadback>();
        resultHandle->state = state;
        TextureTransferCommand command{packet->Retain(texture->image), packet->Retain(state->staging), copy, true};
        packet->RegisterImage(*texture->image);
        packet->Retain(state);
        packet->AddCommand(command, nullptr, RecordTransfer);
        *result = resultHandle.release();
    }

    static void RecordCopy(CelesteGraphicsPacket& packet, const void* payload,
                           VulkanPacketRecordContext& recording) noexcept
    {
        const auto& command = *static_cast<const TextureCopyCommand*>(payload);
        recording.images.Copy(packet.Resource<TextureImage>(command.source),
                              packet.Resource<TextureImage>(command.destination));
    }
    void CopyTexture(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* source, CelesteGraphicsTexture* destination)
    {
        Require(packet, source);
        Require(packet, destination);
        if (source == destination || source->info.width != destination->info.width ||
            source->info.height != destination->info.height || source->info.depth != destination->info.depth ||
            source->info.dimension != destination->info.dimension || source->info.levels != destination->info.levels ||
            source->info.sourceFormat != destination->info.sourceFormat)
            throw std::invalid_argument("Texture copy requires distinct same-sized textures");
        TextureCopyCommand command{packet->Retain(source->image), packet->Retain(destination->image)};
        packet->RegisterImage(*source->image);
        packet->RegisterImage(*destination->image);
        packet->AddCommand(command, nullptr, RecordCopy);
    }
}
