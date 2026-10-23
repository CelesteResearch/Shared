#include "VulkanSubmissionQueue.h"
#include "CelesteGraphicsDevice.h"
#include <stdexcept>
#include <string>

namespace
{
    void CheckResult(VkResult result, const char* operation)
    {
        if (result != VK_SUCCESS)
            throw std::runtime_error(std::string(operation) + " failed: VkResult " + std::to_string(result));
    }
    template <class T> T Function(CelesteGraphicsDevice& device, const char* name)
    {
        auto function = reinterpret_cast<T>(device.native.getDeviceProcAddr(device.native.device, name));
        if (!function)
            throw std::runtime_error(std::string("Missing Vulkan device function: ") + name);
        return function;
    }
    struct QueueScope
    {
        CelesteGraphicsDevice& device;
        explicit QueueScope(CelesteGraphicsDevice& value) : device(value)
        {
            if (device.enterQueue)
                device.enterQueue(device.queueContext);
        }
        ~QueueScope()
        {
            if (device.leaveQueue)
                device.leaveQueue(device.queueContext);
        }
    };
}

VulkanSubmissionQueue::VulkanSubmissionQueue(CelesteGraphicsDevice& device)
    : device_(device), createPool_(Function<PFN_vkCreateCommandPool>(device, "vkCreateCommandPool")),
      destroyPool_(Function<PFN_vkDestroyCommandPool>(device, "vkDestroyCommandPool")),
      resetPool_(Function<PFN_vkResetCommandPool>(device, "vkResetCommandPool")),
      allocateBuffers_(Function<PFN_vkAllocateCommandBuffers>(device, "vkAllocateCommandBuffers")),
      beginBuffer_(Function<PFN_vkBeginCommandBuffer>(device, "vkBeginCommandBuffer")),
      endBuffer_(Function<PFN_vkEndCommandBuffer>(device, "vkEndCommandBuffer")),
      createFence_(Function<PFN_vkCreateFence>(device, "vkCreateFence")),
      destroyFence_(Function<PFN_vkDestroyFence>(device, "vkDestroyFence")),
      resetFences_(Function<PFN_vkResetFences>(device, "vkResetFences")),
      getStatus_(Function<PFN_vkGetFenceStatus>(device, "vkGetFenceStatus")),
      waitFences_(Function<PFN_vkWaitForFences>(device, "vkWaitForFences")),
      queueSubmit_(Function<PFN_vkQueueSubmit>(device, "vkQueueSubmit"))
{
}

VulkanSubmissionQueue::~VulkanSubmissionQueue()
{
    // Only our fences are waited. VkDeviceLost also permits object destruction.
    device_.shutdownResult = Drain();
    for (auto& slot : slots_)
        DestroySlot(slot);
}

void VulkanSubmissionQueue::DestroySlot(Slot& slot) noexcept
{
    if (slot.fence)
        destroyFence_(device_.native.device, slot.fence, nullptr);
    if (slot.pool)
        destroyPool_(device_.native.device, slot.pool, nullptr);
    slot.fence = VK_NULL_HANDLE;
    slot.pool = VK_NULL_HANDLE;
    slot.buffer = VK_NULL_HANDLE;
}

size_t VulkanSubmissionQueue::Begin()
{
    CheckResult(Collect(), "Vulkan submission retirement");
    size_t index = 0;
    while (index < slots_.size() && (slots_[index].recording || slots_[index].state))
        ++index;
    if (index == slots_.size())
    {
        Slot slot;
        try
        {
            VkCommandPoolCreateInfo poolInfo{VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO};
            poolInfo.flags = VK_COMMAND_POOL_CREATE_TRANSIENT_BIT;
            poolInfo.queueFamilyIndex = device_.native.graphicsQueueFamily;
            CheckResult(createPool_(device_.native.device, &poolInfo, nullptr, &slot.pool), "vkCreateCommandPool");
            VkCommandBufferAllocateInfo bufferInfo{VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO};
            bufferInfo.commandPool = slot.pool;
            bufferInfo.level = VK_COMMAND_BUFFER_LEVEL_PRIMARY;
            bufferInfo.commandBufferCount = 1;
            CheckResult(allocateBuffers_(device_.native.device, &bufferInfo, &slot.buffer), "vkAllocateCommandBuffers");
            VkFenceCreateInfo fenceInfo{VK_STRUCTURE_TYPE_FENCE_CREATE_INFO};
            CheckResult(createFence_(device_.native.device, &fenceInfo, nullptr, &slot.fence), "vkCreateFence");
            slots_.push_back(std::move(slot));
        }
        catch (...)
        {
            DestroySlot(slot);
            throw;
        }
    }
    Slot& slot = slots_[index];
    CheckResult(resetPool_(device_.native.device, slot.pool, 0), "vkResetCommandPool");
    VkCommandBufferBeginInfo beginInfo{VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO};
    beginInfo.flags = VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT;
    CheckResult(beginBuffer_(slot.buffer, &beginInfo), "vkBeginCommandBuffer");
    slot.recording = true;
    return index;
}

VkCommandBuffer VulkanSubmissionQueue::GetCommandBuffer(size_t slot) const
{
    return slots_.at(slot).buffer;
}

void VulkanSubmissionQueue::Abandon(size_t index)
{
    Slot& slot = slots_.at(index);
    if (slot.state)
        throw std::logic_error("Cannot abandon a submitted Vulkan buffer");
    slot.recording = false;
    slot.retainedResources.clear();
}

std::shared_ptr<VulkanSubmissionState> VulkanSubmissionQueue::Submit(
    size_t index, std::vector<std::shared_ptr<void>> retainedResources, VkSemaphore ready,
    VkPipelineStageFlags readyStage, VkSemaphore complete)
{
    return SubmitMany(index, std::move(retainedResources), ready ? 1u : 0u, &ready, &readyStage, complete ? 1u : 0u,
                      &complete);
}

std::shared_ptr<VulkanSubmissionState> VulkanSubmissionQueue::SubmitMany(
    size_t index, std::vector<std::shared_ptr<void>> retainedResources, uint32_t waitCount, const VkSemaphore* waits,
    const VkPipelineStageFlags* stages, uint32_t signalCount, const VkSemaphore* signals)
{
    Slot& slot = slots_.at(index);
    if (!slot.recording || slot.state)
        throw std::logic_error("Vulkan buffer is not recording");
    auto state = std::make_shared<VulkanSubmissionState>();
    state->owner = this;
    state->slot = index;
    slot.recording = false;
    CheckResult(endBuffer_(slot.buffer), "vkEndCommandBuffer");
    CheckResult(resetFences_(device_.native.device, 1, &slot.fence), "vkResetFences");
    VkSubmitInfo info{VK_STRUCTURE_TYPE_SUBMIT_INFO};
    info.commandBufferCount = 1;
    info.pCommandBuffers = &slot.buffer;
    info.waitSemaphoreCount = waitCount;
    info.pWaitSemaphores = waits;
    info.pWaitDstStageMask = stages;
    info.signalSemaphoreCount = signalCount;
    info.pSignalSemaphores = signals;
    // Allocate state and retain resources before publishing GPU work.
    slot.retainedResources = std::move(retainedResources);
    VkResult result;
    {
        QueueScope scope(device_);
        result = queueSubmit_(device_.native.graphicsQueue, 1, &info, slot.fence);
    }
    if (result != VK_SUCCESS)
    {
        slot.retainedResources.clear();
        CheckResult(result, "vkQueueSubmit");
    }
    slot.state = state;
    return state;
}

VkResult VulkanSubmissionQueue::Finish(Slot& slot, VkResult result)
{
    if (result == VK_SUCCESS || result == VK_ERROR_DEVICE_LOST)
    {
        slot.state->result = result;
        slot.state.reset();
        slot.retainedResources.clear();
    }
    return result;
}

VkResult VulkanSubmissionQueue::Poll(const std::shared_ptr<VulkanSubmissionState>& state)
{
    if (!state || state->owner != this)
        throw std::invalid_argument("Vulkan submission belongs to another queue");
    if (state->result != VK_NOT_READY)
        return state->result;
    auto& slot = slots_.at(state->slot);
    return Finish(slot, getStatus_(device_.native.device, slot.fence));
}

VkResult VulkanSubmissionQueue::Wait(const std::shared_ptr<VulkanSubmissionState>& state, uint64_t timeout)
{
    if (!state || state->owner != this)
        throw std::invalid_argument("Vulkan submission belongs to another queue");
    if (state->result != VK_NOT_READY)
        return state->result;
    auto& slot = slots_.at(state->slot);
    return Finish(slot, waitFences_(device_.native.device, 1, &slot.fence, VK_TRUE, timeout));
}

VkResult VulkanSubmissionQueue::Collect()
{
    for (auto& slot : slots_)
    {
        if (!slot.state)
            continue;
        const VkResult result = Finish(slot, getStatus_(device_.native.device, slot.fence));
        if (result != VK_SUCCESS && result != VK_NOT_READY)
            return result;
    }
    return VK_SUCCESS;
}

VkResult VulkanSubmissionQueue::Drain()
{
    VkResult failure = VK_SUCCESS;
    for (auto& slot : slots_)
    {
        if (!slot.state)
            continue;
        VkResult result = Finish(slot, waitFences_(device_.native.device, 1, &slot.fence, VK_TRUE, UINT64_MAX));
        if (result != VK_SUCCESS)
            failure = result;
    }
    return failure;
}
