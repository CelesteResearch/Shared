#include "Direct3D12DrawContext.h"
#include "CelesteGraphicsPacket.h"
Direct3D12DrawState::Direct3D12DrawState()
{
    blend.colorSourceBlend = blend.alphaSourceBlend = SourceBlendFactor_One;
    blend.colorDestinationBlend = blend.alphaDestinationBlend = SourceBlendFactor_Zero;
    blend.colorWriteEnable = blend.colorWriteEnable1 = blend.colorWriteEnable2 = blend.colorWriteEnable3 =
        SourceColorWriteChannels_All;
    blend.blendFactor = 0xffffffffu;
    blend.multiSampleMask = -1;
    depthState.depthBufferEnable = depthState.depthBufferWriteEnable = 1;
    depthState.depthBufferFunction = SourceCompareFunction_LessEqual;
    depthState.stencilMask = depthState.stencilWriteMask = -1;
    raster.cullMode = SourceCullMode_CullCounterClockwiseFace;
    raster.multiSampleAntiAlias = 1;
}
Direct3D12DrawContext& GetDrawContext(CelesteGraphicsDevice& device)
{
    if (!device.drawContext)
        device.drawContext = std::make_shared<Direct3D12DrawContext>(device.Resources());
    return *device.drawContext;
}
Direct3D12DrawState& GetDrawState(CelesteGraphicsPacket& packet)
{
    packet.RequireOpen();
    if (!packet.drawState)
    {
        packet.drawState = std::make_shared<Direct3D12DrawState>(*GetDrawContext(packet.Owner()).committed);
        packet.AddCommand(uint8_t{}, nullptr, nullptr, [](CelesteGraphicsPacket& p, const void*) noexcept {
            p.Owner().drawContext->committed = p.drawState;
        });
    }
    else if (packet.drawState.use_count() > 1)
        packet.drawState = std::make_shared<Direct3D12DrawState>(*packet.drawState);
    auto& context = GetDrawContext(packet.Owner());
    context.readView = packet.drawState;
    context.readCompletion = packet.Completion();
    return *packet.drawState;
}
std::shared_ptr<Celeste::Graphics::Direct3D12::BindingBatch> GetBindingBatch(
    CelesteGraphicsPacket& packet, const Celeste::Graphics::Direct3D12::BindingRequirements& requirements)
{
    if (!packet.drawBindings || !packet.drawBindings->CanAllocate(requirements))
    {
        packet.drawBindings = GetDrawContext(packet.Owner()).bindings.Acquire(requirements);
        packet.Retain(packet.drawBindings);
    }
    return packet.drawBindings;
}

std::shared_ptr<Direct3D12DrawState> GetReadableDrawState(CelesteGraphicsDevice& device)
{
    auto& context = GetDrawContext(device);
    auto completion = context.readCompletion.lock();
    if (completion && completion->phase.load(std::memory_order_acquire) != 2)
    {
        if (auto state = context.readView.lock())
            return state;
    }
    return context.committed;
}

std::shared_ptr<Direct3D12DrawState> GetDrawSnapshot(CelesteGraphicsPacket& packet)
{
    packet.RequireOpen();
    if (!packet.drawState)
        GetDrawState(packet);
    return packet.drawState;
}
