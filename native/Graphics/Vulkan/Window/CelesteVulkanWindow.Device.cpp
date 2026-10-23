#include "CelesteVulkanWindow.h"
#include "CelesteGraphicsDevice.h"
#include "VulkanPortability.h"
#include <algorithm>
#include <cstring>

void CelesteVulkanWindow::Initialize(const CelesteVulkanSurfaceWindowInfo& info)
{
    if (!info.windowHandle)
        throw std::invalid_argument("A live native window is required");
    surfaceKind = info.surfaceKind;
    windowHandle = info.windowHandle;
    displayHandle = info.displayHandle;
    width = info.width;
    height = info.height;
    synchronized = info.synchronized;
    native.getInstanceProcAddr = library.Open();
    auto createInstance = Instance<PFN_vkCreateInstance>("vkCreateInstance");
    std::vector<const char*> instanceExtensions{"VK_KHR_surface", SurfaceExtension()};
#if defined(__APPLE__)
    instanceExtensions.push_back("VK_KHR_portability_enumeration");
#endif
    VkApplicationInfo application{VK_STRUCTURE_TYPE_APPLICATION_INFO};
    application.pApplicationName = "Celeste";
    application.apiVersion = info.apiVersion ? info.apiVersion : VK_API_VERSION_1_1;
    VkInstanceCreateInfo creation{VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO};
    creation.pApplicationInfo = &application;
    creation.enabledExtensionCount = static_cast<uint32_t>(instanceExtensions.size());
    creation.ppEnabledExtensionNames = instanceExtensions.data();
#if defined(__APPLE__)
    creation.flags |= VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR;
#endif
    Check(createInstance(&creation, nullptr, &native.instance), "vkCreateInstance");
    DestroyInstance = Instance<PFN_vkDestroyInstance>("vkDestroyInstance");
    DestroySurfaceKHR = Instance<PFN_vkDestroySurfaceKHR>("vkDestroySurfaceKHR");
    CreateSurface();
    auto enumerate = Instance<PFN_vkEnumeratePhysicalDevices>("vkEnumeratePhysicalDevices");
    auto queues = Instance<PFN_vkGetPhysicalDeviceQueueFamilyProperties>("vkGetPhysicalDeviceQueueFamilyProperties");
    auto support = Instance<PFN_vkGetPhysicalDeviceSurfaceSupportKHR>("vkGetPhysicalDeviceSurfaceSupportKHR");
    auto extensions = Instance<PFN_vkEnumerateDeviceExtensionProperties>("vkEnumerateDeviceExtensionProperties");
    auto properties = Instance<PFN_vkGetPhysicalDeviceProperties>("vkGetPhysicalDeviceProperties");
    auto features = Instance<PFN_vkGetPhysicalDeviceFeatures>("vkGetPhysicalDeviceFeatures");
    auto formats = Instance<PFN_vkGetPhysicalDeviceFormatProperties>("vkGetPhysicalDeviceFormatProperties");
    GetSurfaceCapabilities =
        Instance<PFN_vkGetPhysicalDeviceSurfaceCapabilitiesKHR>("vkGetPhysicalDeviceSurfaceCapabilitiesKHR");
    GetSurfaceFormats = Instance<PFN_vkGetPhysicalDeviceSurfaceFormatsKHR>("vkGetPhysicalDeviceSurfaceFormatsKHR");
    GetPresentModes =
        Instance<PFN_vkGetPhysicalDeviceSurfacePresentModesKHR>("vkGetPhysicalDeviceSurfacePresentModesKHR");
    uint32_t count = 0;
    Check(enumerate(native.instance, &count, nullptr), "vkEnumeratePhysicalDevices");
    std::vector<VkPhysicalDevice> physical(count);
    Check(enumerate(native.instance, &count, physical.data()), "vkEnumeratePhysicalDevices");
    physical.resize(count);
    for (uint32_t index = 0; index < count; ++index)
    {
        if (info.physicalDeviceIndex != UINT32_MAX && index != info.physicalDeviceIndex)
            continue;
        VkPhysicalDeviceProperties propertiesValue{};
        properties(physical[index], &propertiesValue);
        if (propertiesValue.apiVersion < application.apiVersion)
            continue;
        uint32_t extensionCount = 0;
        Check(extensions(physical[index], nullptr, &extensionCount, nullptr), "vkEnumerateDeviceExtensionProperties");
        std::vector<VkExtensionProperties> names(extensionCount);
        Check(extensions(physical[index], nullptr, &extensionCount, names.data()),
              "vkEnumerateDeviceExtensionProperties");
        if (std::none_of(names.begin(), names.end(),
                         [](const auto& name) { return !std::strcmp(name.extensionName, "VK_KHR_swapchain"); }))
            continue;
        uint32_t familyCount = 0;
        queues(physical[index], &familyCount, nullptr);
        std::vector<VkQueueFamilyProperties> families(familyCount);
        queues(physical[index], &familyCount, families.data());
        uint32_t graphics = UINT32_MAX, present = UINT32_MAX;
        for (uint32_t family = 0; family < familyCount; ++family)
        {
            if (!families[family].queueCount)
                continue;
            VkBool32 canPresent = VK_FALSE;
            Check(support(physical[index], family, surface, &canPresent), "vkGetPhysicalDeviceSurfaceSupportKHR");
            bool canDraw = (families[family].queueFlags & VK_QUEUE_GRAPHICS_BIT) != 0;
            if (canDraw && canPresent)
            {
                graphics = present = family;
                break;
            }
            if (canDraw && graphics == UINT32_MAX)
                graphics = family;
            if (canPresent && present == UINT32_MAX)
                present = family;
        }
        if (graphics == UINT32_MAX || present == UINT32_MAX)
            continue;
        VkSurfaceCapabilitiesKHR caps{};
        Check(GetSurfaceCapabilities(physical[index], surface, &caps), "vkGetPhysicalDeviceSurfaceCapabilitiesKHR");
        if (!(caps.supportedUsageFlags & VK_IMAGE_USAGE_TRANSFER_DST_BIT))
            continue;
        uint32_t formatCount = 0;
        Check(GetSurfaceFormats(physical[index], surface, &formatCount, nullptr),
              "vkGetPhysicalDeviceSurfaceFormatsKHR");
        std::vector<VkSurfaceFormatKHR> available(formatCount);
        Check(GetSurfaceFormats(physical[index], surface, &formatCount, available.data()),
              "vkGetPhysicalDeviceSurfaceFormatsKHR");
        bool foundFormat = false;
        for (auto candidate : available)
        {
            if (candidate.format == VK_FORMAT_UNDEFINED)
                candidate.format = VK_FORMAT_B8G8R8A8_UNORM;
            // Preserve the existing linear source bytes; do not add sRGB encoding in blit.
            if (candidate.format != VK_FORMAT_B8G8R8A8_UNORM && candidate.format != VK_FORMAT_R8G8B8A8_UNORM)
                continue;
            if (candidate.colorSpace != VK_COLOR_SPACE_SRGB_NONLINEAR_KHR)
                continue;
            VkFormatProperties supportFormat{};
            formats(physical[index], candidate.format, &supportFormat);
            if (!(supportFormat.optimalTilingFeatures & VK_FORMAT_FEATURE_BLIT_DST_BIT))
                continue;
            format = candidate;
            foundFormat = true;
            break;
        }
        if (!foundFormat)
            continue;
        enabledDeviceExtensions = {"VK_KHR_swapchain"};
        if (std::any_of(names.begin(), names.end(),
                        [](const auto& name) { return !std::strcmp(name.extensionName, "VK_KHR_portability_subset"); }))
            enabledDeviceExtensions.push_back("VK_KHR_portability_subset");
        native.physicalDevice = physical[index];
        native.graphicsQueueFamily = graphics;
        native.apiVersion = application.apiVersion;
        presentFamily = present;
        VkPhysicalDeviceFeatures supported{};
        features(physical[index], &supported);
        auto& enabled = native.enabledFeatures;
        enabled.independentBlend = supported.independentBlend;
        enabled.fillModeNonSolid = supported.fillModeNonSolid;
        enabled.depthClamp = supported.depthClamp;
        enabled.depthBiasClamp = supported.depthBiasClamp;
        enabled.samplerAnisotropy = supported.samplerAnisotropy;
        enabled.textureCompressionBC = supported.textureCompressionBC;
        break;
    }
    if (!native.physicalDevice)
        throw std::runtime_error(
            "No Vulkan device supports this native surface, source output format and graphics/present queues");
    const float priority = 1.0f;
    VkDeviceQueueCreateInfo queueInfo[2]{};
    for (auto& item : queueInfo)
    {
        item.sType = VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO;
        item.queueCount = 1;
        item.pQueuePriorities = &priority;
    }
    queueInfo[0].queueFamilyIndex = native.graphicsQueueFamily;
    queueInfo[1].queueFamilyIndex = presentFamily;
    VkDeviceCreateInfo deviceInfo{VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO};
    deviceInfo.queueCreateInfoCount = native.graphicsQueueFamily == presentFamily ? 1u : 2u;
    deviceInfo.pQueueCreateInfos = queueInfo;
    deviceInfo.enabledExtensionCount = static_cast<uint32_t>(enabledDeviceExtensions.size());
    deviceInfo.ppEnabledExtensionNames = enabledDeviceExtensions.data();
    deviceInfo.pEnabledFeatures = &native.enabledFeatures;
    VkPhysicalDevicePortabilitySubsetFeaturesKHR portability{};
    if (std::any_of(enabledDeviceExtensions.begin(), enabledDeviceExtensions.end(),
                    [](const char* name) { return !std::strcmp(name, "VK_KHR_portability_subset"); }))
    {
        if (EnableVulkanPortabilityFeatures(native, nullptr, portability))
            deviceInfo.pNext = &portability;
        native.portabilityFeatures = VulkanPortabilityFeatureFlags(portability);
    }
    Check(Instance<PFN_vkCreateDevice>("vkCreateDevice")(native.physicalDevice, &deviceInfo, nullptr, &native.device),
          "vkCreateDevice");
    native.getDeviceProcAddr = Instance<PFN_vkGetDeviceProcAddr>("vkGetDeviceProcAddr");
    DestroyDevice = Device<PFN_vkDestroyDevice>("vkDestroyDevice");
    DeviceWaitIdle = Device<PFN_vkDeviceWaitIdle>("vkDeviceWaitIdle");
    auto getQueue = Device<PFN_vkGetDeviceQueue>("vkGetDeviceQueue");
    getQueue(native.device, native.graphicsQueueFamily, 0, &native.graphicsQueue);
    getQueue(native.device, presentFamily, 0, &presentQueue);
    CreateSwapchain = Device<PFN_vkCreateSwapchainKHR>("vkCreateSwapchainKHR");
    DestroySwapchain = Device<PFN_vkDestroySwapchainKHR>("vkDestroySwapchainKHR");
    GetSwapchainImages = Device<PFN_vkGetSwapchainImagesKHR>("vkGetSwapchainImagesKHR");
    AcquireNextImage = Device<PFN_vkAcquireNextImageKHR>("vkAcquireNextImageKHR");
    QueuePresent = Device<PFN_vkQueuePresentKHR>("vkQueuePresentKHR");
    CreateSemaphore = Device<PFN_vkCreateSemaphore>("vkCreateSemaphore");
    DestroySemaphore = Device<PFN_vkDestroySemaphore>("vkDestroySemaphore");
    api = CelesteVulkanGetDeviceApi();
    if (!api || api->abiVersion != CELESTE_GRAPHICS_DEVICE_ABI_VERSION)
        throw std::runtime_error("Vulkan source API is unavailable or mismatched");
    CelesteVulkanBorrowedDeviceInfo borrowed{};
    borrowed.nativeDevice = native;
    Backend(CelesteVulkanCreateBorrowedDevice(&borrowed, &backend));
    VkSemaphoreCreateInfo semaphoreInfo{VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO};
    for (auto& slot : slots)
        Check(CreateSemaphore(native.device, &semaphoreInfo, nullptr, &slot.ready), "vkCreateSemaphore");
    Recreate();
}
