#pragma once
#include "CelesteGraphicsVulkan.h"
#include <vulkan/vulkan_beta.h>
#include <stdexcept>

inline bool EnableVulkanPortabilityFeatures(const CelesteVulkanNativeDevice& native, const void* next,
                                            VkPhysicalDevicePortabilitySubsetFeaturesKHR& enabled)
{
    for (auto entry = static_cast<const VkBaseInStructure*>(next); entry; entry = entry->pNext)
        if (entry->sType == VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PORTABILITY_SUBSET_FEATURES_KHR)
        {
            enabled = *reinterpret_cast<const VkPhysicalDevicePortabilitySubsetFeaturesKHR*>(entry);
            return false;
        }
    auto query = reinterpret_cast<PFN_vkGetPhysicalDeviceFeatures2>(
        native.getInstanceProcAddr(native.instance, "vkGetPhysicalDeviceFeatures2"));
    if (!query)
        throw std::runtime_error("Vulkan portability requires physical device feature queries");
    VkPhysicalDevicePortabilitySubsetFeaturesKHR supported{
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PORTABILITY_SUBSET_FEATURES_KHR};
    VkPhysicalDeviceFeatures2 features{VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2};
    features.pNext = &supported;
    query(native.physicalDevice, &features);
    enabled = {VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PORTABILITY_SUBSET_FEATURES_KHR};
    enabled.constantAlphaColorBlendFactors = supported.constantAlphaColorBlendFactors;
    enabled.imageViewFormatSwizzle = supported.imageViewFormatSwizzle;
    enabled.samplerMipLodBias = supported.samplerMipLodBias;
    enabled.separateStencilMaskRef = supported.separateStencilMaskRef;
    enabled.vertexAttributeAccessBeyondStride = supported.vertexAttributeAccessBeyondStride;
    enabled.pNext = const_cast<void*>(next);
    return true;
}

inline uint32_t VulkanPortabilityFeatureFlags(const VkPhysicalDevicePortabilitySubsetFeaturesKHR& enabled)
{
    uint32_t flags = CelesteVulkanPortabilitySubset;
    if (enabled.imageViewFormatSwizzle)
        flags |= CelesteVulkanPortabilityImageViewSwizzle;
    if (enabled.samplerMipLodBias)
        flags |= CelesteVulkanPortabilitySamplerMipLodBias;
    if (enabled.separateStencilMaskRef)
        flags |= CelesteVulkanPortabilitySeparateStencilMaskReference;
    if (enabled.constantAlphaColorBlendFactors)
        flags |= CelesteVulkanPortabilityConstantAlphaColorBlendFactors;
    if (enabled.vertexAttributeAccessBeyondStride)
        flags |= CelesteVulkanPortabilityVertexAttributeAccessBeyondStride;
    return flags;
}
