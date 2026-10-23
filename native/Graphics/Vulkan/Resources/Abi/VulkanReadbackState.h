#pragma once
#include "CelesteGraphicsBackend.h"
#include "TransferBuffer.h"
#include "VulkanPacketCompletion.h"
#include <memory>
#include <vector>
struct VulkanReadbackState final
{
    CelesteGraphicsDevice* device = nullptr;
    std::shared_ptr<Celeste::Graphics::Vulkan::TransferBuffer> staging;
    std::shared_ptr<VulkanPacketCompletion> completion;
    std::vector<uint8_t> bytes;
    SourceSurfaceFormat sourceFormat = SourceSurfaceFormat_Color;
    bool unchanged = false;
    bool copied = false;
};
