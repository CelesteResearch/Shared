#include "Direct3D12PreparedTargets.h"
#include "CelesteGraphicsPacket.h"
#include <stdexcept>
using namespace Celeste::Graphics::Direct3D12;
void PrepareTargets(CelesteGraphicsPacket& packet, const Direct3D12DrawState& state,
                    std::shared_ptr<BindingBatch> batch, Direct3D12PreparedTargets& result)
{
    result.batch = std::move(batch);
    if (!result.batch)
        throw std::invalid_argument("Target descriptor batch is null");
    if (state.usesBackbuffer)
    {
        auto image = state.backbufferMsaa ? state.backbufferMsaa : state.backbuffer;
        if (!image)
            throw std::logic_error("Backbuffer is not configured");
        result.colors[0] = {std::move(image), 0};
        result.count = 1;
        result.depth = state.backbufferDepth;
    }
    else
    {
        if (state.targets.size() > result.colors.size())
            throw std::invalid_argument("Too many render targets");
        result.count = static_cast<uint32_t>(state.targets.size());
        for (uint32_t i = 0; i < result.count; ++i)
            result.colors[i] = state.targets[i];
        result.depth = state.depth;
    }
    bool hasExtent = false;
    const auto check = [&](const GpuResource& resource) {
        if (resource.context != packet.Owner().Resources())
            throw std::invalid_argument("Target belongs to another device");
        const auto& d = resource.description;
        if (!hasExtent)
        {
            result.width = static_cast<uint32_t>(d.Width);
            result.height = d.Height;
            result.formats.samples = d.SampleDesc;
            hasExtent = true;
        }
        else if (d.Width != result.width || d.Height != result.height ||
                 d.SampleDesc.Count != result.formats.samples.Count ||
                 d.SampleDesc.Quality != result.formats.samples.Quality)
            throw std::invalid_argument("Render target size or samples mismatch");
    };
    for (uint32_t i = 0; i < result.count; ++i)
    {
        auto& binding = result.colors[i];
        if (!binding.image)
            throw std::invalid_argument("Render target is null");
        check(*binding.image);
        result.subresources[i] = binding.image->Subresource(0, binding.layer);
        result.formats.colors[i] = binding.image->description.Format;
    }
    result.formats.colorCount = result.count;
    if (result.depth)
    {
        check(*result.depth);
        result.formats.depth = result.depth->description.Format;
    }
    if (!hasExtent)
        throw std::logic_error("No render target configured");
    result.renderViews = result.batch->AllocateRenderTargets(result.count);
    for (uint32_t i = 0; i < result.count; ++i)
    {
        auto& binding = result.colors[i];
        binding.image->CreateRenderView(result.renderViews.Cpu(i), 0, binding.layer);
        packet.RegisterResource(binding.image);
    }
    if (result.depth)
    {
        result.depthView = result.batch->AllocateDepthTargets(1).cpu;
        result.depth->CreateDepthView(result.depthView);
        packet.RegisterResource(result.depth);
    }
}
void BindTargets(const Direct3D12PreparedTargets& targets, Direct3D12PacketRecordContext& context) noexcept
{
    for (uint32_t i = 0; i < targets.count; ++i)
        context.states.Transition(*targets.colors[i].image, targets.subresources[i],
                                  D3D12_RESOURCE_STATE_RENDER_TARGET);
    if (targets.depth)
        context.states.TransitionAll(*targets.depth, D3D12_RESOURCE_STATE_DEPTH_WRITE);
    const auto render = targets.renderViews.cpu;
    context.lease.List()->OMSetRenderTargets(targets.count, targets.count ? &render : nullptr, TRUE,
                                             targets.depth ? &targets.depthView : nullptr);
}
