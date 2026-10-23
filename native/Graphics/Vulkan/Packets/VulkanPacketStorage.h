#pragma once
#include "VulkanPacketCommand.h"
#include "VulkanPacketCompletion.h"
#include "DepthStencilAttachment.h"
#include "TextureImage.h"
#include <memory>
#include <vector>
struct VulkanPacketStorage final
{
    std::vector<std::byte> bytes;
    std::vector<VulkanPacketCommand> commands;
    std::vector<std::shared_ptr<void>> resources;
    std::vector<Celeste::Graphics::Vulkan::TextureImage*> images;
    std::vector<Celeste::Graphics::Vulkan::DepthStencilAttachment*> depths;
    std::vector<VkSemaphore> waitSemaphores;
    std::vector<VkPipelineStageFlags> waitStages;
    std::vector<VkSemaphore> signalSemaphores;
    std::vector<const void*> outputs;
    std::shared_ptr<VulkanPacketCompletion> completion;
};
