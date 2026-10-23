#include "VulkanDevicePackets.h"
#include "CelesteGraphicsDevice.h"
#include "VulkanPacketStorage.h"
#include "ResourceContext.h"
#include "TransferBufferPool.h"
#include <stdexcept>

void VulkanDevicePackets::Retire(uint64_t serial) noexcept
{
    if (hasCompletedHost && serial < completedHostSerial)
        return;
    hasCompletedHost = true;
    completedHostSerial = serial;
    while (!hostSubmissions.empty() && hostSubmissions.front().serial <= serial)
    {
        hostSubmissions.front().storage->completion->hostResult = VK_SUCCESS;
        hostSubmissions.pop_front();
    }
}
VulkanDevicePackets& CelesteGraphicsDevice::Packets()
{
    if (!packetState)
        packetState = std::make_shared<VulkanDevicePackets>();
    return *packetState;
}
std::shared_ptr<Celeste::Graphics::Vulkan::ResourceContext> CelesteGraphicsDevice::Resources()
{
    if (!resourceContext)
        resourceContext = std::make_shared<Celeste::Graphics::Vulkan::ResourceContext>(native);
    return resourceContext;
}
const VkFormatProperties& VulkanDevicePackets::Format(CelesteGraphicsDevice& device, VkFormat format)
{
    auto existing = formats.find(format);
    if (existing != formats.end())
        return existing->second;
    auto query = reinterpret_cast<PFN_vkGetPhysicalDeviceFormatProperties>(
        device.native.getInstanceProcAddr(device.native.instance, "vkGetPhysicalDeviceFormatProperties"));
    if (!query)
        throw std::runtime_error("Missing vkGetPhysicalDeviceFormatProperties");
    VkFormatProperties properties{};
    query(device.native.physicalDevice, format, &properties);
    return formats.emplace(format, properties).first->second;
}
std::shared_ptr<Celeste::Graphics::Vulkan::TransferBufferPool> CelesteGraphicsDevice::StagingBuffers()
{
    if (!stagingPool)
        stagingPool = std::make_shared<Celeste::Graphics::Vulkan::TransferBufferPool>(Resources());
    return stagingPool;
}
