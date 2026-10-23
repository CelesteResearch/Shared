#pragma once
#include "CelesteGraphicsVulkan.h"
#include "VulkanLibrary.h"
#include <memory>
class VulkanSubmissionQueue;
class VulkanDevicePackets;
class VulkanDrawContext;
namespace Celeste::Graphics::Vulkan
{
    struct ResourceContext;
    class TransferBufferPool;
}

struct CelesteGraphicsDevice final
{
    VulkanLibrary library;
    std::shared_ptr<VulkanDevicePackets> packetState;
    std::shared_ptr<VulkanDrawContext> drawContext;
    std::shared_ptr<Celeste::Graphics::Vulkan::ResourceContext> resourceContext;
    std::shared_ptr<Celeste::Graphics::Vulkan::TransferBufferPool> stagingPool;
    std::shared_ptr<Celeste::Graphics::Vulkan::TransferBufferPool> StagingBuffers();
    VulkanDevicePackets& Packets();
    VulkanDrawContext& Draws();
    std::shared_ptr<Celeste::Graphics::Vulkan::ResourceContext> Resources();
    std::unique_ptr<VulkanSubmissionQueue> submissions;
    VkResult shutdownResult = VK_SUCCESS;
    VulkanSubmissionQueue& Submissions();
    CelesteVulkanNativeDevice native{};
    void* queueContext = nullptr;
    void(CELESTE_GRAPHICS_CALL* enterQueue)(void*) = nullptr;
    void(CELESTE_GRAPHICS_CALL* leaveQueue)(void*) = nullptr;
    bool ownsInstance = false;
    bool ownsDevice = false;
    PFN_vkDestroyInstance destroyInstance = nullptr;
    PFN_vkDestroyDevice destroyDevice = nullptr;

    CelesteGraphicsDevice();
    ~CelesteGraphicsDevice();
    void CreateOwned(const CelesteVulkanOwnedDeviceInfo& info);
    void CreateBorrowed(const CelesteVulkanBorrowedDeviceInfo& info);
};
