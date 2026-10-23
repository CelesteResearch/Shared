#pragma once
#include "DrawLogicalState.h"
#include "EffectSnapshot.h"
#include "EffectConstantStorage.h"
#include "SpritePipeline.h"
#include "PreparedDrawBinding.h"
#include <vector>
class VulkanDrawContext;
struct CelesteGraphicsPacket;
class VulkanDrawState final
{
  public:
    std::shared_ptr<Celeste::Graphics::Vulkan::DrawLogicalState> logical;
    std::shared_ptr<Celeste::Graphics::Vulkan::EffectConstantStorage> constants;
    std::vector<Celeste::Graphics::Vulkan::EffectSnapshot> effects;
    std::shared_ptr<Celeste::Graphics::Vulkan::TransferBuffer> uniformPage;
    bool uploaded = false;
    std::array<bool, 3> nullInitializationQueued{};
    std::vector<Celeste::Graphics::Vulkan::PreparedDrawBinding> bindings;
    explicit VulkanDrawState(VulkanDrawContext& context);
    Celeste::Graphics::Vulkan::DrawLogicalState& Edit(VulkanDrawContext& context);
    void PrepareUniforms(VulkanDrawContext& context);
};
