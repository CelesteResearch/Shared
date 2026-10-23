#include "Direct3D12PresentationApi.h"
#include "PresentationOutput.h"
#include "CopyFormatCompatibility.h"
#include "PresentCommand.h"
#include "CelesteGraphicsOutput.h"
#include "CelesteGraphicsTexture.h"
#include "Direct3D12ApiErrors.h"
#include "Direct3D12Backbuffer.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    static CelesteGraphicsRect Rectangle(const CelesteGraphicsRect* value, uint32_t width, uint32_t height)
    {
        const auto result =
            value ? *value : CelesteGraphicsRect{0, 0, static_cast<int32_t>(width), static_cast<int32_t>(height)};
        if (result.x < 0 || result.y < 0 || result.width <= 0 || result.height <= 0 ||
            uint64_t(result.x) + result.width > width || uint64_t(result.y) + result.height > height)
            throw std::invalid_argument("Presentation rectangle outside image");
        return result;
    }
    void PresentImage(CelesteGraphicsPacket* packet, std::shared_ptr<TextureResource> source,
                      CelesteGraphicsOutput* output, const CelesteGraphicsRect* from, const CelesteGraphicsRect* to)
    {
        if (!packet || !source || !output || output->device != &packet->Owner() ||
            source->context != packet->Owner().context)
            throw std::invalid_argument("Presentation resources belong to different devices");
        packet->RequireOpen();
        if (source->info.dimension != CelesteGraphicsTexture2D || source->description.SampleDesc.Count != 1 ||
            source->resource.Get() == output->resource.Get())
            throw std::invalid_argument("Presentation requires a resolved 2D source distinct from output");
        const auto desc = output->resource->GetDesc();
        const auto sourceRect = Rectangle(from, source->info.width, source->info.height),
                   destinationRect = Rectangle(to, output->info.width, output->info.height);
        const bool copy = CopyFormatsCompatible(source->format.native, output->info.format) &&
                          source->info.width == output->info.width && source->info.height == output->info.height &&
                          sourceRect.x == 0 && sourceRect.y == 0 && sourceRect.width == source->info.width &&
                          sourceRect.height == source->info.height && destinationRect.x == 0 &&
                          destinationRect.y == 0 && destinationRect.width == output->info.width &&
                          destinationRect.height == output->info.height;
        if (!copy && !(desc.Flags & D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET))
            throw std::invalid_argument("Scaled or converted presentation requires a renderable output");
        auto retainedOutput = std::make_shared<PresentationOutput>();
        retainedOutput->resource = output->resource;
        retainedOutput->info = output->info;
        retainedOutput->texture = output->texture;
        auto& states = packet->storage->outputStates;
        size_t existing = states.size();
        for (size_t i = 0; i < states.size(); ++i)
            if (states[i].resource == output->resource.Get())
            {
                existing = i;
                retainedOutput->info.incomingState = states[i].currentState;
                break;
            }
        // Source is held both by tracked states and the prepared binding. Preserve its shared owner for preparation.
        const auto sourceIndex = packet->Retain(source);
        const auto outputIndex = packet->Retain(retainedOutput);
        packet->RegisterResource(source);
        if (output->texture)
            packet->RegisterResource(output->texture);
        PresentCommand command{sourceIndex, outputIndex, UINT32_MAX, sourceRect, destinationRect, copy};
        if (!output->texture && existing == states.size())
            states.reserve(states.size() + 1);
        packet->AddCommand(command, PresentCommand::Prepare, PresentCommand::Record);
        if (!output->texture && existing == states.size())
            states.push_back({output->resource.Get(), output->info.incomingState, output->info.outgoingState});
        else if (!output->texture)
            states[existing].currentState = output->info.outgoingState;
    }
    void Present(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* source, CelesteGraphicsOutput* output,
                 const CelesteGraphicsRect* from, const CelesteGraphicsRect* to)
    {
        if (!packet || !source || source->device != &packet->Owner())
            throw std::invalid_argument("Invalid presentation source");
        PresentImage(packet, source->image, output, from, to);
    }
    void PresentBackbuffer(CelesteGraphicsPacket* packet, CelesteGraphicsOutput* output,
                           const CelesteGraphicsRect* from, const CelesteGraphicsRect* to)
    {
        if (!packet)
            throw std::invalid_argument("Missing presentation packet");
        ResolveBackbuffer(*packet);
        PresentImage(packet, GetBackbuffer(*packet), output, from, to);
    }
    void BindPresentationApi(CelesteGraphicsDeviceApi& api)
    {
        api.Present = [](CelesteGraphicsPacket* packet, CelesteGraphicsTexture* source, CelesteGraphicsOutput* output,
                         const CelesteGraphicsRect* from, const CelesteGraphicsRect* to) -> int32_t {
            return Invoke([&] { Present(packet, source, output, from, to); });
        };
        api.PresentBackbuffer = [](CelesteGraphicsPacket* packet, CelesteGraphicsOutput* output,
                                   const CelesteGraphicsRect* from, const CelesteGraphicsRect* to) -> int32_t {
            return Invoke([&] { PresentBackbuffer(packet, output, from, to); });
        };
    }
}
