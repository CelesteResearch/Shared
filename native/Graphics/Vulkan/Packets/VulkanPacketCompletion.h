#pragma once
#include <vulkan/vulkan_core.h>
struct CelesteGraphicsDevice;
struct VulkanSubmissionState;
#include <memory>
#include <atomic>

struct VulkanPacketCompletion final
{
    CelesteGraphicsDevice* device;
    std::shared_ptr<VulkanSubmissionState> submission;
    std::atomic<VkResult> hostResult{VK_NOT_READY};
    std::atomic<bool> queued{false};
    explicit VulkanPacketCompletion(CelesteGraphicsDevice& owner) : device(&owner)
    {
    }
    VkResult Poll();
    VkResult Wait();
};
