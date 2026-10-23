#pragma once
#include "ImageRecording.h"
#include "DepthStencilRecording.h"
struct VulkanPacketRecordContext final
{
    VkCommandBuffer commandBuffer;
    Celeste::Graphics::Vulkan::ImageRecording& images;
    Celeste::Graphics::Vulkan::DepthStencilRecording& depth;
};
