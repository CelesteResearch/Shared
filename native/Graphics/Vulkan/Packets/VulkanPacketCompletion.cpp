#include "VulkanPacketCompletion.h"
#include "CelesteGraphicsDevice.h"
#include "VulkanSubmissionQueue.h"
VkResult VulkanPacketCompletion::Poll()
{
    if (!queued.load(std::memory_order_acquire))
        return VK_NOT_READY;
    return submission ? device->Submissions().Poll(submission) : hostResult.load(std::memory_order_acquire);
}
VkResult VulkanPacketCompletion::Wait()
{
    if (!queued.load(std::memory_order_acquire))
        return VK_NOT_READY;
    // Host-owned work is only retired by the host's actual safe serial.
    return submission ? device->Submissions().Wait(submission) : hostResult.load(std::memory_order_acquire);
}
