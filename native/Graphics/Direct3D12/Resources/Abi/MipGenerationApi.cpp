#include "MipGenerationApi.h"
#include "MipGenerationPlan.h"
#include "CelesteGraphicsPacket.h"
#include "PresentationContext.h"
namespace Celeste::Graphics::Direct3D12
{
    void ValidateMipGeneration(const TextureResource& image)
    {
        if (image.info.dimension == CelesteGraphicsTexture3D || !image.info.renderTarget ||
            image.description.SampleDesc.Count != 1)
            throw std::invalid_argument("Mipmap generation requires a single-sampled 2D/cube render target");
    }
    static void PrepareMips(CelesteGraphicsPacket& packet, void* payload)
    {
        auto& plan = packet.Resource<MipGenerationPlan>(*static_cast<uint32_t*>(payload));
        auto& owner = packet.Owner();
        if (!owner.presentation)
            owner.presentation = std::make_shared<PresentationContext>(owner.context);
        const auto& info = plan.image->info;
        const uint32_t layers = info.dimension == CelesteGraphicsTextureCube ? 6 : 1;
        plan.steps.reserve(layers * (info.levels - 1));
        for (uint32_t layer = 0; layer < layers; ++layer)
            for (uint32_t level = 1; level < info.levels; ++level)
            {
                auto pass =
                    owner.presentation->PrepareSample(plan.image, level - 1, layer, plan.image, level, layer, true);
                plan.steps.push_back({plan.image->Subresource(level - 1, layer), plan.image->Subresource(level, layer),
                                      std::move(pass)});
            }
    }
    static void RecordMips(CelesteGraphicsPacket& packet, const void* payload,
                           Direct3D12PacketRecordContext& recording) noexcept
    {
        const auto& plan = packet.Resource<MipGenerationPlan>(*static_cast<const uint32_t*>(payload));
        for (const auto& step : plan.steps)
        {
            recording.states.Transition(*plan.image, step.sourceSubresource,
                                        D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE);
            recording.states.Transition(*plan.image, step.destinationSubresource, D3D12_RESOURCE_STATE_RENDER_TARGET);
            step.pass->Draw(recording.lease.List());
        }
    }
    void GenerateMipmaps(CelesteGraphicsPacket* packet, std::shared_ptr<TextureResource> image)
    {
        if (!packet || !image || image->context->device.Get() != packet->Owner().context->device.Get())
            throw std::invalid_argument("Mipmap packet/resource mismatch");
        packet->RequireOpen();
        ValidateMipGeneration(*image);
        if (image->info.levels <= 1)
            return;
        auto plan = std::make_shared<MipGenerationPlan>();
        plan->image = image;
        const uint32_t index = packet->Retain(plan);
        packet->RegisterResource(std::move(image));
        packet->AddCommand(index, PrepareMips, RecordMips);
    }
}
