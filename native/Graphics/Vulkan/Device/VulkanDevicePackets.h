#pragma once
#include <vulkan/vulkan_core.h>
#include <memory>
struct CelesteGraphicsDevice;
struct VulkanPacketStorage;
#include <deque>
#include <unordered_map>

class VulkanDevicePackets final
{
  public:
    struct HostSubmission
    {
        uint64_t serial;
        std::shared_ptr<VulkanPacketStorage> storage;
    };
    std::unordered_map<VkFormat, VkFormatProperties> formats;
    const VkFormatProperties& Format(CelesteGraphicsDevice& device, VkFormat format);
    std::deque<HostSubmission> hostSubmissions;
    uint64_t lastHostSerial = 0;
    uint64_t completedHostSerial = 0;
    bool hasRecordedHost = false;
    bool hasCompletedHost = false;
    void Retire(uint64_t serial) noexcept;
};
