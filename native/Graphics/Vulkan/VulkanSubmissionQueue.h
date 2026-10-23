#pragma once
#include "CelesteGraphicsVulkan.h"
#include <cstddef>
#include <memory>
#include <vector>

class VulkanSubmissionQueue;
struct VulkanSubmissionState
{
    const VulkanSubmissionQueue* owner = nullptr;
    VkResult result = VK_NOT_READY;
    size_t slot = 0;
};

// One serialized recording/submission owner per device. Queue exclusion is
// borrowed from the host once per vkQueueSubmit, never per draw.
class VulkanSubmissionQueue final
{
  public:
    explicit VulkanSubmissionQueue(CelesteGraphicsDevice& device);
    ~VulkanSubmissionQueue();
    VulkanSubmissionQueue(const VulkanSubmissionQueue&) = delete;
    VulkanSubmissionQueue& operator=(const VulkanSubmissionQueue&) = delete;

    size_t Begin();
    VkCommandBuffer GetCommandBuffer(size_t slot) const;
    void Abandon(size_t slot);
    std::shared_ptr<VulkanSubmissionState> Submit(size_t slot,
                                                  std::vector<std::shared_ptr<void>> retainedResources = {},
                                                  VkSemaphore ready = VK_NULL_HANDLE,
                                                  VkPipelineStageFlags readyStage = VK_PIPELINE_STAGE_ALL_COMMANDS_BIT,
                                                  VkSemaphore complete = VK_NULL_HANDLE);
    std::shared_ptr<VulkanSubmissionState> SubmitMany(size_t slot, std::vector<std::shared_ptr<void>> retainedResources,
                                                      uint32_t waitCount, const VkSemaphore* waits,
                                                      const VkPipelineStageFlags* stages, uint32_t signalCount,
                                                      const VkSemaphore* signals);
    VkResult Poll(const std::shared_ptr<VulkanSubmissionState>& state);
    VkResult Wait(const std::shared_ptr<VulkanSubmissionState>& state, uint64_t timeout = UINT64_MAX);
    VkResult Collect();
    VkResult Drain();

  private:
    struct Slot
    {
        VkCommandPool pool = VK_NULL_HANDLE;
        VkCommandBuffer buffer = VK_NULL_HANDLE;
        VkFence fence = VK_NULL_HANDLE;
        bool recording = false;
        std::shared_ptr<VulkanSubmissionState> state;
        std::vector<std::shared_ptr<void>> retainedResources;
    };
    CelesteGraphicsDevice& device_;
    std::vector<Slot> slots_;
    PFN_vkCreateCommandPool createPool_;
    PFN_vkDestroyCommandPool destroyPool_;
    PFN_vkResetCommandPool resetPool_;
    PFN_vkAllocateCommandBuffers allocateBuffers_;
    PFN_vkBeginCommandBuffer beginBuffer_;
    PFN_vkEndCommandBuffer endBuffer_;
    PFN_vkCreateFence createFence_;
    PFN_vkDestroyFence destroyFence_;
    PFN_vkResetFences resetFences_;
    PFN_vkGetFenceStatus getStatus_;
    PFN_vkWaitForFences waitFences_;
    PFN_vkQueueSubmit queueSubmit_;
    VkResult Finish(Slot& slot, VkResult result);
    void DestroySlot(Slot& slot) noexcept;
};
