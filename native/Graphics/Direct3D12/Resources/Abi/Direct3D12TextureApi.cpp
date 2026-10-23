#include "Direct3D12ResourceApi.h"
#include "Direct3D12TransferCommand.h"
#include "CelesteGraphicsTexture.h"
#include "CelesteGraphicsReadback.h"
#include "CelesteGraphicsPacket.h"
#include "TextureTransfer.h"
#include "TextureCopy.h"
#include <string>
namespace Celeste::Graphics::Direct3D12
{
    static void Require(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* texture)
    {
        if (!packet || !texture || texture->device != &packet->Owner())
            throw std::invalid_argument("Texture/packet device mismatch");
        packet->RequireOpen();
    }
    void CreateTexture(CelesteGraphicsDevice* device, const CelesteGraphicsTextureInfo* info,
                       CelesteGraphicsTexture** output)
    {
        if (output)
            *output = nullptr;
        if (!device || !info || !output)
            throw std::invalid_argument("Invalid texture creation arguments");
        auto result = std::make_unique<CelesteGraphicsTexture>();
        result->device = device;
        result->image = std::make_shared<TextureResource>(device->Resources(), *info);
        *output = result.release();
    }
    void ReleaseTexture(CelesteGraphicsTexture* texture) noexcept
    {
        delete texture;
    }
    void SetTextureName(CelesteGraphicsTexture* texture, const char* name, uint32_t length)
    {
        if (!texture || (!name && length) || length > INT_MAX)
            throw std::invalid_argument("Invalid texture name");
        if (!length)
        {
            CheckResult(texture->image->resource->SetName(L""), "Set texture name");
            return;
        }
        const int count =
            MultiByteToWideChar(CP_UTF8, MB_ERR_INVALID_CHARS, name, static_cast<int>(length), nullptr, 0);
        if (!count)
            throw std::invalid_argument("Texture name is not valid UTF-8");
        std::wstring wide(count, L'\0');
        MultiByteToWideChar(CP_UTF8, MB_ERR_INVALID_CHARS, name, static_cast<int>(length), wide.data(), count);
        CheckResult(texture->image->resource->SetName(wide.c_str()), "Set texture name");
    }
    static void RecordTransfer(CelesteGraphicsPacket& packet, const void* payload,
                               Direct3D12PacketRecordContext& recording) noexcept
    {
        const auto& command = *static_cast<const TextureTransferCommand*>(payload);
        TextureTransfer::Record(recording.lease, recording.states, packet.Resource<TextureResource>(command.image),
                                packet.Resource<BufferResource>(command.staging), command.region, command.footprint,
                                command.upload);
    }
    void WriteTexture(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* texture,
                      const CelesteGraphicsTextureRegion* requested, const void* bytes, uint32_t count)
    {
        Require(packet, texture);
        const auto region = texture->image->Region(requested);
        TransferFootprint footprint(*texture->image, region);
        auto staging = packet->Owner().TransferBuffers()->Acquire(footprint.totalBytes, D3D12_HEAP_TYPE_UPLOAD);
        footprint.Pack(staging->Map(), bytes, count);
        const TextureTransferCommand command{packet->Retain(texture->image), packet->Retain(staging), region, footprint,
                                             true};
        packet->RegisterResource(texture->image);
        packet->AddCommand(command, nullptr, RecordTransfer);
    }
    void ReadTexture(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* texture,
                     const CelesteGraphicsTextureRegion* requested, CelesteGraphicsReadback** output)
    {
        if (output)
            *output = nullptr;
        if (!output)
            throw std::invalid_argument("Readback output missing");
        Require(packet, texture);
        const auto region = texture->image->Region(requested);
        auto result = std::make_unique<CelesteGraphicsReadback>();
        if (texture->image->format.blockWidth > 1)
        {
            result->unchanged = true;
            *output = result.release();
            return;
        }
        result->footprint.emplace(*texture->image, region);
        const auto& footprint = *result->footprint;
        const uint64_t bytes = texture->image->format.ByteSize(region.width, region.height, region.depth);
        if (bytes > UINT32_MAX)
            throw std::length_error("Readback exceeds source ABI byte range");
        result->bytes.resize(static_cast<size_t>(bytes));
        result->completion = packet->Completion();
        result->staging = packet->Owner().TransferBuffers()->Acquire(footprint.totalBytes, D3D12_HEAP_TYPE_READBACK);
        const TextureTransferCommand command{packet->Retain(texture->image), packet->Retain(result->staging), region,
                                             footprint, false};
        packet->RegisterResource(texture->image);
        packet->AddCommand(command, nullptr, RecordTransfer);
        *output = result.release();
    }
    struct CopyCommand
    {
        uint32_t source, destination;
    };
    static void RecordCopy(CelesteGraphicsPacket& packet, const void* payload,
                           Direct3D12PacketRecordContext& recording) noexcept
    {
        const auto& command = *static_cast<const CopyCommand*>(payload);
        CopyTexture(recording.lease, recording.states, packet.Resource<TextureResource>(command.source),
                    packet.Resource<TextureResource>(command.destination));
    }
    void CopyTexture(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* source, CelesteGraphicsTexture* destination)
    {
        Require(packet, source);
        Require(packet, destination);
        const auto& a = source->image->description;
        const auto& b = destination->image->description;
        if (source->image == destination->image || a.Dimension != b.Dimension || a.Width != b.Width ||
            a.Height != b.Height || a.DepthOrArraySize != b.DepthOrArraySize || a.MipLevels != b.MipLevels ||
            a.Format != b.Format || a.SampleDesc.Count != b.SampleDesc.Count)
            throw std::invalid_argument("Texture copy requires matching distinct resources");
        CopyCommand command{packet->Retain(source->image), packet->Retain(destination->image)};
        packet->RegisterResource(source->image);
        packet->RegisterResource(destination->image);
        packet->AddCommand(command, nullptr, RecordCopy);
    }
}
