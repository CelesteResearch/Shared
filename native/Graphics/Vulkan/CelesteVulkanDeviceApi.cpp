#include "CelesteGraphicsDevice.h"
#include "VulkanApiErrors.h"
#include "VulkanDevicePackets.h"
#include "VulkanSubmissionQueue.h"
#include <memory>
#include <string>
#include <exception>
#include <stdexcept>

extern "C" const char* CELESTE_GRAPHICS_CALL CelesteVulkanGetLastError()
{
    return VulkanGetError();
}

extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanCreateOwnedDevice(const CelesteVulkanOwnedDeviceInfo* info,
                                                                        CelesteGraphicsDevice** device)
{
    if (device)
        *device = nullptr;
    return VulkanInvoke([&] {
        if (!info || !device)
            throw std::invalid_argument("Owned device creation requires info and output");
        auto value = std::make_unique<CelesteGraphicsDevice>();
        value->CreateOwned(*info);
        *device = value.release();
    });
}

extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanCreateBorrowedDevice(const CelesteVulkanBorrowedDeviceInfo* info,
                                                                           CelesteGraphicsDevice** device)
{
    if (device)
        *device = nullptr;
    return VulkanInvoke([&] {
        if (!info || !device)
            throw std::invalid_argument("Borrowed device creation requires info and output");
        auto value = std::make_unique<CelesteGraphicsDevice>();
        value->CreateBorrowed(*info);
        *device = value.release();
    });
}

extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanGetNativeDevice(CelesteGraphicsDevice* device,
                                                                      CelesteVulkanNativeDevice* nativeDevice)
{
    return VulkanInvoke([&] {
        if (!device || !nativeDevice)
            throw std::invalid_argument("Native device query requires device and output");
        *nativeDevice = device->native;
    });
}

extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanReleaseDevice(CelesteGraphicsDevice* device)
{
    if (device && device->packetState && !device->packetState->hostSubmissions.empty())
    {
        VulkanSetError("Host Vulkan submissions have not reached their safe retirement serial");
        return 0;
    }
    if (device && device->submissions)
    {
        const VkResult result = device->submissions->Drain();
        if (result != VK_SUCCESS && result != VK_ERROR_DEVICE_LOST)
        {
            VulkanSetError("Unable to retire Vulkan submissions; device remains valid for release retry");
            return 0;
        }
    }
    delete device;
    VulkanClearError();
    return 1;
}
