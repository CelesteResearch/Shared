#include "Direct3D12Backbuffer.h"
#include "Direct3D12DrawContext.h"
#include "CelesteGraphicsPacket.h"
#include "CelesteGraphicsTexture.h"
#include "Direct3D12ResourceApi.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    void ConfigureBackbuffer(CelesteGraphicsPacket* packet, const SourceNativePresentationParameters* info)
    {
        if (!packet || !info || info->backBufferWidth <= 0 || info->backBufferHeight <= 0 || info->multiSampleCount < 0)
            throw std::invalid_argument("Invalid backbuffer configuration");
        auto& state = GetDrawState(*packet);
        const auto samples = static_cast<uint32_t>(info->multiSampleCount > 1 ? info->multiSampleCount : 1);
        CelesteGraphicsTextureInfo texture{info->backBufferFormat,
                                           CelesteGraphicsTexture2D,
                                           static_cast<uint32_t>(info->backBufferWidth),
                                           static_cast<uint32_t>(info->backBufferHeight),
                                           1,
                                           1,
                                           1};
        auto color = std::make_shared<TextureResource>(packet->Owner().Resources(), texture);
        std::shared_ptr<TextureResource> msaa;
        if (samples > 1)
            msaa = std::make_shared<TextureResource>(packet->Owner().Resources(), texture, samples);
        std::shared_ptr<DepthResource> depth;
        if (info->depthStencilFormat != SourceDepthFormat_None)
            depth = std::make_shared<DepthResource>(packet->Owner().Resources(), texture.width, texture.height,
                                                    info->depthStencilFormat, samples);
        state.presentation = *info;
        state.backbuffer = std::move(color);
        state.backbufferMsaa = std::move(msaa);
        state.backbufferDepth = std::move(depth);
        state.usesBackbuffer = true;
        state.targets.clear();
        state.depth.reset();
        state.depthFormat = info->depthStencilFormat;
    }
    void GetBackbufferInfo(CelesteGraphicsDevice* device, CelesteGraphicsBackbufferInfo* output)
    {
        if (!device || !output)
            throw std::invalid_argument("Invalid backbuffer query");
        const auto& p = GetReadableDrawState(*device)->presentation;
        *output = {p.backBufferWidth, p.backBufferHeight, p.backBufferFormat, p.depthStencilFormat, p.multiSampleCount};
    }
    std::shared_ptr<TextureResource> GetBackbuffer(CelesteGraphicsPacket& packet)
    {
        auto image = GetDrawState(packet).backbuffer;
        if (!image)
            throw std::logic_error("Backbuffer is not configured");
        return image;
    }
    void ResolveBackbuffer(CelesteGraphicsPacket& packet)
    {
        auto& state = GetDrawState(packet);
        if (!state.backbufferMsaa)
            return;
        struct Resolve
        {
            uint32_t source, destination;
        };
        auto source = state.backbufferMsaa, destination = state.backbuffer;
        packet.RegisterResource(source);
        packet.RegisterResource(destination);
        packet.AddCommand(
            Resolve{packet.Retain(source), packet.Retain(destination)}, nullptr,
            [](CelesteGraphicsPacket& p, const void* data, Direct3D12PacketRecordContext& context) noexcept {
                const auto& cmd = *static_cast<const Resolve*>(data);
                auto& src = p.Resource<TextureResource>(cmd.source);
                auto& dst = p.Resource<TextureResource>(cmd.destination);
                context.states.Transition(src, 0, D3D12_RESOURCE_STATE_RESOLVE_SOURCE);
                context.states.Transition(dst, 0, D3D12_RESOURCE_STATE_RESOLVE_DEST);
                context.lease.List()->ResolveSubresource(dst.resource.Get(), 0, src.resource.Get(), 0,
                                                         dst.format.native);
            });
    }
    void ReadBackbuffer(CelesteGraphicsPacket* packet, const CelesteGraphicsRect* rect,
                        CelesteGraphicsReadback** output)
    {
        if (!packet)
            throw std::invalid_argument("Packet is null");
        ResolveBackbuffer(*packet);
        auto image = GetBackbuffer(*packet);
        CelesteGraphicsTexture handle{&packet->Owner(), image};
        if (!rect)
        {
            ReadTexture(packet, &handle, nullptr, output);
            return;
        }
        if (rect->x < 0 || rect->y < 0 || rect->width < 0 || rect->height < 0)
            throw std::invalid_argument("Invalid backbuffer read rectangle");
        CelesteGraphicsTextureRegion region{0,
                                            0,
                                            static_cast<uint32_t>(rect->x),
                                            static_cast<uint32_t>(rect->y),
                                            0,
                                            static_cast<uint32_t>(rect->width),
                                            static_cast<uint32_t>(rect->height),
                                            1};
        ReadTexture(packet, &handle, &region, output);
    }
} // namespace Celeste::Graphics::Direct3D12
