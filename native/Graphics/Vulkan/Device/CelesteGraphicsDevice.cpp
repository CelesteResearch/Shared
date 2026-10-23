#include "CelesteGraphicsDevice.h"
#include "VulkanSubmissionQueue.h"
#include "VulkanPortability.h"
#include <stdexcept>
#include <string>
#include <vector>
#include <algorithm>
#include <cstring>

namespace
{
    void Require(VkResult result, const char* operation)
    {
        if (result != VK_SUCCESS)
            throw std::runtime_error(std::string(operation) + " failed: VkResult " + std::to_string(result));
    }

    template <class T> T InstanceFunction(const CelesteVulkanNativeDevice& native, const char* name)
    {
        auto function = reinterpret_cast<T>(native.getInstanceProcAddr(native.instance, name));
        if (!function)
            throw std::runtime_error(std::string("Missing Vulkan function: ") + name);
        return function;
    }
}

CelesteGraphicsDevice::~CelesteGraphicsDevice()
{
    submissions.reset();
    packetState.reset();
    drawContext.reset();
    stagingPool.reset();
    resourceContext.reset();
    // Backend-owned submission fences are drained before native device release.
    // A borrowed host queue/device is never waited or destroyed here.
    if (ownsDevice && native.device && destroyDevice)
        destroyDevice(native.device, nullptr);
    if (ownsInstance && native.instance && destroyInstance)
        destroyInstance(native.instance, nullptr);
}

void CelesteGraphicsDevice::CreateOwned(const CelesteVulkanOwnedDeviceInfo& info)
{
    if ((info.instanceExtensionCount && !info.instanceExtensions) ||
        (info.deviceExtensionCount && !info.deviceExtensions))
        throw std::invalid_argument("Vulkan extension count requires names");
    native.getInstanceProcAddr = library.Open();
    auto createInstance = InstanceFunction<PFN_vkCreateInstance>(native, "vkCreateInstance");
    VkApplicationInfo application{VK_STRUCTURE_TYPE_APPLICATION_INFO};
    application.pApplicationName = "Celeste";
#if defined(__APPLE__)
    application.apiVersion = info.apiVersion ? info.apiVersion : VK_API_VERSION_1_1;
#else
    application.apiVersion = info.apiVersion ? info.apiVersion : VK_API_VERSION_1_0;
#endif
    VkInstanceCreateInfo instanceInfo{VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO};
    instanceInfo.pApplicationInfo = &application;
    instanceInfo.pNext = info.instanceCreateNext;
    std::vector<const char*> instanceExtensions;
    if (info.instanceExtensionCount)
        instanceExtensions.assign(info.instanceExtensions, info.instanceExtensions + info.instanceExtensionCount);
#if defined(__APPLE__)
    if (std::none_of(instanceExtensions.begin(), instanceExtensions.end(),
                     [](const char* name) { return !std::strcmp(name, "VK_KHR_portability_enumeration"); }))
        instanceExtensions.push_back("VK_KHR_portability_enumeration");
    instanceInfo.flags |= VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR;
#endif
    instanceInfo.enabledExtensionCount = static_cast<uint32_t>(instanceExtensions.size());
    instanceInfo.ppEnabledExtensionNames = instanceExtensions.data();
    Require(createInstance(&instanceInfo, nullptr, &native.instance), "vkCreateInstance");
    ownsInstance = true;
    destroyInstance = InstanceFunction<PFN_vkDestroyInstance>(native, "vkDestroyInstance");
    auto enumerate = InstanceFunction<PFN_vkEnumeratePhysicalDevices>(native, "vkEnumeratePhysicalDevices");
    auto queueProperties = InstanceFunction<PFN_vkGetPhysicalDeviceQueueFamilyProperties>(
        native, "vkGetPhysicalDeviceQueueFamilyProperties");
    auto physicalProperties =
        InstanceFunction<PFN_vkGetPhysicalDeviceProperties>(native, "vkGetPhysicalDeviceProperties");
    auto createDevice = InstanceFunction<PFN_vkCreateDevice>(native, "vkCreateDevice");
    native.getDeviceProcAddr = InstanceFunction<PFN_vkGetDeviceProcAddr>(native, "vkGetDeviceProcAddr");
    std::vector<VkPhysicalDevice> devices;
    VkResult enumeration;
    do
    {
        uint32_t count = 0;
        Require(enumerate(native.instance, &count, nullptr), "vkEnumeratePhysicalDevices(count)");
        devices.resize(count);
        enumeration = enumerate(native.instance, &count, devices.data());
        devices.resize(count);
    } while (enumeration == VK_INCOMPLETE);
    Require(enumeration, "vkEnumeratePhysicalDevices");
    if (devices.empty())
        throw std::runtime_error("No Vulkan physical device available");
    if (info.physicalDeviceIndex != UINT32_MAX && info.physicalDeviceIndex >= devices.size())
        throw std::runtime_error("Requested Vulkan physical device index is unavailable");
    for (uint32_t index = 0; index < devices.size(); ++index)
    {
        if (info.physicalDeviceIndex != UINT32_MAX && info.physicalDeviceIndex != index)
            continue;
        VkPhysicalDeviceProperties physical{};
        physicalProperties(devices[index], &physical);
        if ((physical.apiVersion >> 12) < (application.apiVersion >> 12))
            continue;
        uint32_t count = 0;
        queueProperties(devices[index], &count, nullptr);
        std::vector<VkQueueFamilyProperties> properties(count);
        queueProperties(devices[index], &count, properties.data());
        for (uint32_t family = 0; family < count; ++family)
        {
            if (!properties[family].queueCount || !(properties[family].queueFlags & VK_QUEUE_GRAPHICS_BIT))
                continue;
            native.physicalDevice = devices[index];
            native.apiVersion =
                application.apiVersion < physical.apiVersion ? application.apiVersion : physical.apiVersion;
            native.graphicsQueueFamily = family;
            break;
        }
        if (native.physicalDevice)
            break;
    }
    if (!native.physicalDevice)
        throw std::runtime_error("No Vulkan graphics device supports the requested API version");
    const float priority = 1.0f;
    VkDeviceQueueCreateInfo queueInfo{VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO};
    queueInfo.queueFamilyIndex = native.graphicsQueueFamily;
    queueInfo.queueCount = 1;
    queueInfo.pQueuePriorities = &priority;
    VkDeviceCreateInfo deviceInfo{VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO};
    deviceInfo.pNext = info.deviceCreateNext;
    deviceInfo.queueCreateInfoCount = 1;
    deviceInfo.pQueueCreateInfos = &queueInfo;
    std::vector<const char*> deviceExtensions;
    if (info.deviceExtensionCount)
        deviceExtensions.assign(info.deviceExtensions, info.deviceExtensions + info.deviceExtensionCount);
    auto enumerateExtensions =
        InstanceFunction<PFN_vkEnumerateDeviceExtensionProperties>(native, "vkEnumerateDeviceExtensionProperties");
    uint32_t extensionCount = 0;
    Require(enumerateExtensions(native.physicalDevice, nullptr, &extensionCount, nullptr),
            "vkEnumerateDeviceExtensionProperties");
    std::vector<VkExtensionProperties> availableExtensions(extensionCount);
    Require(enumerateExtensions(native.physicalDevice, nullptr, &extensionCount, availableExtensions.data()),
            "vkEnumerateDeviceExtensionProperties");
    if (std::any_of(
            availableExtensions.begin(), availableExtensions.end(),
            [](const auto& extension) { return !std::strcmp(extension.extensionName, "VK_KHR_portability_subset"); }) &&
        std::none_of(deviceExtensions.begin(), deviceExtensions.end(),
                     [](const char* name) { return !std::strcmp(name, "VK_KHR_portability_subset"); }))
        deviceExtensions.push_back("VK_KHR_portability_subset");
    deviceInfo.enabledExtensionCount = static_cast<uint32_t>(deviceExtensions.size());
    deviceInfo.ppEnabledExtensionNames = deviceExtensions.data();
    const VkPhysicalDeviceFeatures2* features2 = nullptr;
    for (auto next = static_cast<const VkBaseInStructure*>(info.deviceCreateNext); next; next = next->pNext)
        if (next->sType == VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2)
            features2 = reinterpret_cast<const VkPhysicalDeviceFeatures2*>(next);
    if (features2 && info.deviceFeatures)
        throw std::invalid_argument("Vulkan features must be supplied by either Features2 or pEnabledFeatures");
    VkPhysicalDeviceFeatures defaults{};
    if (!features2 && !info.deviceFeatures)
    {
        VkPhysicalDeviceFeatures supported{};
        InstanceFunction<PFN_vkGetPhysicalDeviceFeatures>(native, "vkGetPhysicalDeviceFeatures")(native.physicalDevice,
                                                                                                 &supported);
        // Enable only source graphics features, avoiding unrelated robustness/compute costs.
        defaults.textureCompressionBC = supported.textureCompressionBC;
        defaults.samplerAnisotropy = supported.samplerAnisotropy;
        defaults.fillModeNonSolid = supported.fillModeNonSolid;
        defaults.depthClamp = supported.depthClamp;
        defaults.depthBiasClamp = supported.depthBiasClamp;
        defaults.independentBlend = supported.independentBlend;
    }
    deviceInfo.pEnabledFeatures = features2 ? nullptr : info.deviceFeatures ? info.deviceFeatures : &defaults;
    native.enabledFeatures = features2 ? features2->features : *deviceInfo.pEnabledFeatures;
    VkPhysicalDevicePortabilitySubsetFeaturesKHR portability{};
    if (std::any_of(deviceExtensions.begin(), deviceExtensions.end(),
                    [](const char* name) { return !std::strcmp(name, "VK_KHR_portability_subset"); }))
    {
        if (EnableVulkanPortabilityFeatures(native, deviceInfo.pNext, portability))
            deviceInfo.pNext = &portability;
        native.portabilityFeatures = VulkanPortabilityFeatureFlags(portability);
    }
    Require(createDevice(native.physicalDevice, &deviceInfo, nullptr, &native.device), "vkCreateDevice");
    ownsDevice = true;
    destroyDevice = reinterpret_cast<PFN_vkDestroyDevice>(native.getDeviceProcAddr(native.device, "vkDestroyDevice"));
    auto getQueue = reinterpret_cast<PFN_vkGetDeviceQueue>(native.getDeviceProcAddr(native.device, "vkGetDeviceQueue"));
    if (!destroyDevice || !getQueue)
        throw std::runtime_error("Vulkan device dispatch is incomplete");
    getQueue(native.device, native.graphicsQueueFamily, 0, &native.graphicsQueue);
}

void CelesteGraphicsDevice::CreateBorrowed(const CelesteVulkanBorrowedDeviceInfo& info)
{
    if ((info.EnterQueue == nullptr) != (info.LeaveQueue == nullptr))
        throw std::invalid_argument("Borrowed queue exclusion requires both callbacks");
    queueContext = info.queueContext;
    enterQueue = info.EnterQueue;
    leaveQueue = info.LeaveQueue;
    native = info.nativeDevice;
    if (!native.instance || !native.physicalDevice || !native.device || !native.graphicsQueue ||
        !native.getInstanceProcAddr || !native.getDeviceProcAddr)
        throw std::runtime_error("Borrowed Vulkan device must provide handles and dispatch functions");
    if (native.apiVersion < VK_API_VERSION_1_0 || VK_API_VERSION_VARIANT(native.apiVersion) != 0)
        throw std::invalid_argument("Borrowed Vulkan device requires its actual enabled API version");
    VkPhysicalDeviceProperties physical{};
    InstanceFunction<PFN_vkGetPhysicalDeviceProperties>(native, "vkGetPhysicalDeviceProperties")(native.physicalDevice,
                                                                                                 &physical);
    if ((native.apiVersion >> 12) > (physical.apiVersion >> 12))
        throw std::invalid_argument("Borrowed Vulkan API version exceeds physical device support");
    auto queueProperties = InstanceFunction<PFN_vkGetPhysicalDeviceQueueFamilyProperties>(
        native, "vkGetPhysicalDeviceQueueFamilyProperties");
    uint32_t count = 0;
    queueProperties(native.physicalDevice, &count, nullptr);
    if (native.graphicsQueueFamily >= count)
        throw std::runtime_error("Borrowed Vulkan graphics queue family is invalid");
    std::vector<VkQueueFamilyProperties> properties(count);
    queueProperties(native.physicalDevice, &count, properties.data());
    if (!properties[native.graphicsQueueFamily].queueCount ||
        !(properties[native.graphicsQueueFamily].queueFlags & VK_QUEUE_GRAPHICS_BIT))
        throw std::runtime_error("Borrowed Vulkan queue does not support graphics");
}

VulkanSubmissionQueue& CelesteGraphicsDevice::Submissions()
{
    if (!submissions)
        submissions = std::make_unique<VulkanSubmissionQueue>(*this);
    return *submissions;
}
CelesteGraphicsDevice::CelesteGraphicsDevice() = default;
