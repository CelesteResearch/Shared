#include "VulkanDrawState.h"
#include "VulkanDrawContext.h"
#include "CelesteGraphicsPacket.h"
using namespace Celeste::Graphics::Vulkan;
VulkanDrawState::VulkanDrawState(VulkanDrawContext& context)
    : logical(context.logical), constants(std::make_shared<EffectConstantStorage>(context.uniformAlignment))
{
    if (context.lastConstants)
    {
        auto retained = context.lastEffect;
        for (int stage = 0; stage < 2; ++stage)
            if (retained.constantSizes[stage])
                retained.constantOffsets[stage] =
                    constants->AppendBytes(context.lastConstants->Bytes().data() + retained.constantOffsets[stage],
                                           retained.constantSizes[stage]);
        effects.push_back(std::move(retained));
    }
}
DrawLogicalState& VulkanDrawState::Edit(VulkanDrawContext& context)
{
    const long activeOwners = context.logical == logical ? 2 : 1;
    if (logical.use_count() > activeOwners)
        logical = std::make_shared<DrawLogicalState>(*logical);
    context.logical = logical;
    return *logical;
}
void VulkanDrawState::PrepareUniforms(VulkanDrawContext& context)
{
    if (!uploaded)
    {
        uniformPage = context.uniforms.Upload(constants->Bytes());
        uploaded = true;
    }
}
VulkanDrawState& CelesteGraphicsPacket::DrawState()
{
    if (!drawState)
        drawState = std::make_shared<VulkanDrawState>(device.Draws());
    return *drawState;
}
