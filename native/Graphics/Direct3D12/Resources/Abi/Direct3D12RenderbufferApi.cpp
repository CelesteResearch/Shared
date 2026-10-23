#include "Direct3D12ResourceApi.h"
#include "CelesteGraphicsRenderbuffer.h"
#include "CelesteGraphicsTexture.h"
#include "CelesteGraphicsPacket.h"
#include "TextureCopy.h"
#include "MipGenerationApi.h"
namespace Celeste::Graphics::Direct3D12
{
    void CreateDepthRenderbuffer(CelesteGraphicsDevice* device, int32_t width, int32_t height, SourceDepthFormat format,
                                 int32_t samples, CelesteGraphicsRenderbuffer** output)
    {
        if (output)
            *output = nullptr;
        if (!device || !output || width <= 0 || height <= 0 || samples < 0)
            throw std::invalid_argument("Invalid depth renderbuffer parameters");
        auto result = std::make_unique<CelesteGraphicsRenderbuffer>();
        result->device = device;
        result->depth = std::make_shared<DepthResource>(device->Resources(), width, height, format,
                                                        samples ? static_cast<uint32_t>(samples) : 1);
        *output = result.release();
    }
    void CreateColorRenderbuffer(CelesteGraphicsDevice* device, int32_t width, int32_t height,
                                 SourceSurfaceFormat format, int32_t samples, CelesteGraphicsTexture* texture,
                                 CelesteGraphicsRenderbuffer** output)
    {
        if (output)
            *output = nullptr;
        if (!device || !output || width <= 0 || height <= 0 || samples < 0)
            throw std::invalid_argument("Invalid color renderbuffer parameters");
        if (texture &&
            (texture->device != device || texture->image->info.width != uint32_t(width) ||
             texture->image->info.height != uint32_t(height) || texture->image->info.sourceFormat != format ||
             !texture->image->info.renderTarget || texture->image->info.dimension == CelesteGraphicsTexture3D))
            throw std::invalid_argument("Renderbuffer/texture mismatch");
        auto result = std::make_unique<CelesteGraphicsRenderbuffer>();
        result->device = device;
        if (samples <= 1 && texture)
            result->color = texture->image;
        else
            result->color = std::make_shared<TextureResource>(
                device->Resources(),
                CelesteGraphicsTextureInfo{format, CelesteGraphicsTexture2D, static_cast<uint32_t>(width),
                                           static_cast<uint32_t>(height), 1, 1, 1},
                samples ? static_cast<uint32_t>(samples) : 1);
        *output = result.release();
    }
    void ReleaseRenderbuffer(CelesteGraphicsRenderbuffer* value) noexcept
    {
        delete value;
    }
    struct ResolveCommand
    {
        uint32_t source, destination, layer;
    };
    static void RecordResolve(CelesteGraphicsPacket& packet, const void* payload,
                              Direct3D12PacketRecordContext& context) noexcept
    {
        const auto& c = *static_cast<const ResolveCommand*>(payload);
        ResolveTexture(context.lease, context.states, packet.Resource<TextureResource>(c.source),
                       packet.Resource<TextureResource>(c.destination), 0, c.layer);
    }
    void ResolveTarget(CelesteGraphicsPacket* packet, const SourceNativeRenderTargetBinding* binding)
    {
        if (!packet || !binding)
            throw std::invalid_argument("Resolve packet/binding missing");
        packet->RequireOpen();
        auto* texture = static_cast<CelesteGraphicsTexture*>(binding->texture);
        if (!texture || texture->device != &packet->Owner() || binding->type > 1)
            throw std::invalid_argument("Resolve texture device/type mismatch");
        const bool mipmaps = binding->levelCount > 1;
        if (mipmaps)
            ValidateMipGeneration(*texture->image);
        const uint32_t layer = binding->type == 1 ? static_cast<uint32_t>(binding->data2) : 0;
        texture->image->Subresource(0, layer);
        if (binding->multiSampleCount <= 1)
        {
            if (mipmaps)
                GenerateMipmaps(packet, texture->image);
            return;
        }
        auto* color = static_cast<CelesteGraphicsRenderbuffer*>(binding->colorBuffer);
        if (!color || color->device != &packet->Owner() || !color->color)
            throw std::invalid_argument("Resolve color buffer missing or wrong device");
        const auto& source = *color->color;
        const auto& destination = *texture->image;
        if (source.description.SampleDesc.Count <= 1 || destination.description.SampleDesc.Count != 1 ||
            source.info.width != destination.info.width || source.info.height != destination.info.height ||
            source.format.native != destination.format.native || destination.info.dimension == CelesteGraphicsTexture3D)
            throw std::invalid_argument("Invalid multisample resolve resources");
        ResolveCommand command{packet->Retain(color->color), packet->Retain(texture->image), layer};
        packet->RegisterResource(color->color);
        packet->RegisterResource(texture->image);
        packet->AddCommand(command, nullptr, RecordResolve);
        if (mipmaps)
            GenerateMipmaps(packet, texture->image);
    }
}
