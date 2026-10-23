#include "VulkanDrawContext.h"
#include "CelesteGraphicsDevice.h"
#include <stdexcept>
using namespace Celeste::Graphics::Vulkan;
VulkanDrawContext::VulkanDrawContext(CelesteGraphicsDevice& device)
    : resources(device.Resources()), logical(std::make_shared<DrawLogicalState>()), uniforms(resources),
      pipelines(resources), nullTextures(resources)
{
    auto properties = reinterpret_cast<PFN_vkGetPhysicalDeviceProperties>(
        device.native.getInstanceProcAddr(device.native.instance, "vkGetPhysicalDeviceProperties"));
    if (!properties)
        throw std::runtime_error("Missing vkGetPhysicalDeviceProperties");
    VkPhysicalDeviceProperties limits{};
    properties(device.native.physicalDevice, &limits);
    deviceLimits = limits.limits;
    uniformAlignment = static_cast<uint32_t>(limits.limits.minUniformBufferOffsetAlignment);
}
VulkanDrawContext& CelesteGraphicsDevice::Draws()
{
    if (!drawContext)
        drawContext = std::make_shared<VulkanDrawContext>(*this);
    return *drawContext;
}
