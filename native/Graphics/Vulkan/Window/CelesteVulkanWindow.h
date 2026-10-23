#pragma once
#include "CelesteGraphicsVulkanWindow.h"
#include "VulkanLibrary.h"
#include "TextureImage.h"
#include <array>
#include <vector>
#include <memory>
#include <stdexcept>
#include <string>

struct CelesteVulkanWindow final
{
    VulkanLibrary library;
    CelesteVulkanNativeDevice native{};
    const CelesteGraphicsDeviceApi* api = nullptr;
    CelesteGraphicsDevice* backend = nullptr;
    VkSurfaceKHR surface = VK_NULL_HANDLE;
    VkSwapchainKHR swapchain = VK_NULL_HANDLE;
    VkQueue presentQueue = VK_NULL_HANDLE;
    uint32_t presentFamily = UINT32_MAX;
    VkSurfaceFormatKHR format{};
    VkExtent2D extent{};
    uint32_t width = 0, height = 0, synchronized = 1;
    uint32_t surfaceKind = CelesteVulkanWindowSurfaceWin32;
    void* windowHandle = nullptr;
    void* displayHandle = nullptr;
    void* platformSurface = nullptr;
    std::vector<const char*> enabledDeviceExtensions;
    bool rebuild = true, acquired = false, outputSubmitted = false, offscreen = false, failed = false;
    uint32_t imageIndex = 0, slotIndex = 0;
    struct Slot
    {
        VkSemaphore ready = VK_NULL_HANDLE;
        CelesteGraphicsSubmission* submission = nullptr;
    };
    std::array<Slot, 3> slots{};
    std::vector<VkImage> images;
    std::vector<VkSemaphore> completed;
    std::unique_ptr<Celeste::Graphics::Vulkan::TextureImage> hiddenOutput;
    PFN_vkDestroyInstance DestroyInstance = nullptr;
    PFN_vkDestroySurfaceKHR DestroySurfaceKHR = nullptr;
    PFN_vkDestroyDevice DestroyDevice = nullptr;
    PFN_vkDeviceWaitIdle DeviceWaitIdle = nullptr;
    PFN_vkGetPhysicalDeviceSurfaceCapabilitiesKHR GetSurfaceCapabilities = nullptr;
    PFN_vkGetPhysicalDeviceSurfaceFormatsKHR GetSurfaceFormats = nullptr;
    PFN_vkGetPhysicalDeviceSurfacePresentModesKHR GetPresentModes = nullptr;
    PFN_vkCreateSwapchainKHR CreateSwapchain = nullptr;
    PFN_vkDestroySwapchainKHR DestroySwapchain = nullptr;
    PFN_vkGetSwapchainImagesKHR GetSwapchainImages = nullptr;
    PFN_vkAcquireNextImageKHR AcquireNextImage = nullptr;
    PFN_vkQueuePresentKHR QueuePresent = nullptr;
    PFN_vkCreateSemaphore CreateSemaphore = nullptr;
    PFN_vkDestroySemaphore DestroySemaphore = nullptr;

    template <class T> T Instance(const char* name)
    {
        auto result = reinterpret_cast<T>(native.getInstanceProcAddr(native.instance, name));
        if (!result)
            throw std::runtime_error(std::string("Missing ") + name);
        return result;
    }
    template <class T> T Device(const char* name)
    {
        auto result = reinterpret_cast<T>(native.getDeviceProcAddr(native.device, name));
        if (!result)
            throw std::runtime_error(std::string("Missing ") + name);
        return result;
    }
    static void Check(VkResult result, const char* operation)
    {
        if (result != VK_SUCCESS)
            throw std::runtime_error(std::string(operation) + ": VkResult " + std::to_string(result));
    }
    static void Backend(int result)
    {
        if (result != 1)
            throw std::runtime_error(CelesteVulkanGetLastError());
    }
    void Initialize(const CelesteVulkanSurfaceWindowInfo&);
    const char* SurfaceExtension() const;
    void CreateSurface();
    void RefreshDrawableSize();
    void ReleasePlatformSurface() noexcept;
    void Resize(uint32_t w, uint32_t h, uint32_t sync);
    void Recreate();
    void Acquire(CelesteGraphicsOutput**);
    void Submit(CelesteGraphicsPacket*, bool);
    void Present();
    void Drain();
    void ReleaseSwapchain() noexcept;
    void Close();
    ~CelesteVulkanWindow();
};
