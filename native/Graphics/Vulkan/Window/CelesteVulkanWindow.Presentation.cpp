#include "CelesteVulkanWindow.h"
#include "CelesteGraphicsDevice.h"
#include <algorithm>

void CelesteVulkanWindow::Resize(uint32_t w, uint32_t h, uint32_t sync)
{
    if (acquired)
        throw std::logic_error("Resize must precede output acquisition");
    if (surfaceKind == CelesteVulkanWindowSurfaceMetalView && w && h)
    {
        const uint32_t previousWidth = width, previousHeight = height;
        RefreshDrawableSize();
        if (width != previousWidth || height != previousHeight)
            rebuild = true;
        w = width;
        h = height;
    }
    if (width != w || height != h || synchronized != sync)
    {
        width = w;
        height = h;
        synchronized = sync;
        rebuild = true;
    }
}
void CelesteVulkanWindow::Drain()
{
    if (acquired && !outputSubmitted && !offscreen)
    {
        // A failed packet preparation leaves the WSI acquire signal unconsumed.
        // Consume it only on this teardown path before releasing its semaphore.
        auto createFence = Device<PFN_vkCreateFence>("vkCreateFence");
        auto destroyFence = Device<PFN_vkDestroyFence>("vkDestroyFence");
        auto queueSubmit = Device<PFN_vkQueueSubmit>("vkQueueSubmit");
        auto waitFences = Device<PFN_vkWaitForFences>("vkWaitForFences");
        VkFenceCreateInfo info{VK_STRUCTURE_TYPE_FENCE_CREATE_INFO};
        VkFence fence = VK_NULL_HANDLE;
        Check(createFence(native.device, &info, nullptr, &fence), "vkCreateFence");
        VkPipelineStageFlags stage = VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
        VkSubmitInfo submit{VK_STRUCTURE_TYPE_SUBMIT_INFO};
        submit.waitSemaphoreCount = 1;
        submit.pWaitSemaphores = &slots[slotIndex].ready;
        submit.pWaitDstStageMask = &stage;
        VkResult status = queueSubmit(native.graphicsQueue, 1, &submit, fence);
        if (status == VK_SUCCESS)
        {
            // Mark the acquire consumed as soon as it is queued, even if device loss
            // makes its wait fail. DeviceWaitIdle below covers subsequent retry.
            acquired = false;
            status = waitFences(native.device, 1, &fence, VK_TRUE, UINT64_MAX);
        }
        destroyFence(native.device, fence, nullptr);
        Check(status, "retire abandoned window acquire");
    }
    for (auto& slot : slots)
    {
        if (!slot.submission)
            continue;
        Backend(api->Wait(slot.submission));
        api->ReleaseSubmission(slot.submission);
        slot.submission = nullptr;
    }
    // Resize/shutdown only. Ordinary frames use per-slot submission completion.
    if (native.device && DeviceWaitIdle)
        Check(DeviceWaitIdle(native.device), "vkDeviceWaitIdle");
}
void CelesteVulkanWindow::ReleaseSwapchain() noexcept
{
    for (auto semaphore : completed)
        if (semaphore)
            DestroySemaphore(native.device, semaphore, nullptr);
    completed.clear();
    images.clear();
    if (swapchain)
        DestroySwapchain(native.device, swapchain, nullptr);
    swapchain = VK_NULL_HANDLE;
}
void CelesteVulkanWindow::Recreate()
{
    if (acquired)
        throw std::logic_error("Cannot replace an acquired swapchain");
    VkSurfaceCapabilitiesKHR caps{};
    Check(GetSurfaceCapabilities(native.physicalDevice, surface, &caps), "vkGetPhysicalDeviceSurfaceCapabilitiesKHR");
    VkExtent2D requested{width, height};
    if (caps.currentExtent.width != UINT32_MAX)
        requested = caps.currentExtent;
    else if (requested.width && requested.height)
    {
        requested.width = std::clamp(requested.width, caps.minImageExtent.width, caps.maxImageExtent.width);
        requested.height = std::clamp(requested.height, caps.minImageExtent.height, caps.maxImageExtent.height);
    }
    if (!width || !height || !requested.width || !requested.height)
    {
        offscreen = true;
        rebuild = false;
        return;
    }
    if (!(caps.supportedUsageFlags & VK_IMAGE_USAGE_TRANSFER_DST_BIT))
        throw std::runtime_error("Surface no longer supports image transfer output");
    uint32_t modeCount = 0;
    Check(GetPresentModes(native.physicalDevice, surface, &modeCount, nullptr),
          "vkGetPhysicalDeviceSurfacePresentModesKHR");
    std::vector<VkPresentModeKHR> modes(modeCount);
    Check(GetPresentModes(native.physicalDevice, surface, &modeCount, modes.data()),
          "vkGetPhysicalDeviceSurfacePresentModesKHR");
    VkPresentModeKHR mode = VK_PRESENT_MODE_FIFO_KHR;
    if (!synchronized)
    {
        if (std::find(modes.begin(), modes.end(), VK_PRESENT_MODE_IMMEDIATE_KHR) != modes.end())
            mode = VK_PRESENT_MODE_IMMEDIATE_KHR;
        else if (std::find(modes.begin(), modes.end(), VK_PRESENT_MODE_MAILBOX_KHR) != modes.end())
            mode = VK_PRESENT_MODE_MAILBOX_KHR;
    }
    uint32_t imageCount = std::max(caps.minImageCount, 3u);
    if (caps.maxImageCount)
        imageCount = std::min(imageCount, caps.maxImageCount);
    VkCompositeAlphaFlagBitsKHR alpha = VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR;
    for (auto candidate : {VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR, VK_COMPOSITE_ALPHA_PRE_MULTIPLIED_BIT_KHR,
                           VK_COMPOSITE_ALPHA_POST_MULTIPLIED_BIT_KHR, VK_COMPOSITE_ALPHA_INHERIT_BIT_KHR})
    {
        if (caps.supportedCompositeAlpha & candidate)
        {
            alpha = candidate;
            break;
        }
    }
    Drain();
    hiddenOutput.reset();
    VkSwapchainCreateInfoKHR creation{VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR};
    creation.surface = surface;
    creation.minImageCount = imageCount;
    creation.imageFormat = format.format;
    creation.imageColorSpace = format.colorSpace;
    creation.imageExtent = requested;
    creation.imageArrayLayers = 1;
    creation.imageUsage = VK_IMAGE_USAGE_TRANSFER_DST_BIT;
    const uint32_t families[]{native.graphicsQueueFamily, presentFamily};
    creation.imageSharingMode = families[0] == families[1] ? VK_SHARING_MODE_EXCLUSIVE : VK_SHARING_MODE_CONCURRENT;
    if (families[0] != families[1])
    {
        creation.queueFamilyIndexCount = 2;
        creation.pQueueFamilyIndices = families;
    }
    creation.preTransform = caps.currentTransform;
    creation.compositeAlpha = alpha;
    creation.presentMode = mode;
    creation.clipped = VK_TRUE;
    creation.oldSwapchain = swapchain;
    VkSwapchainKHR next = VK_NULL_HANDLE;
    Check(CreateSwapchain(native.device, &creation, nullptr, &next), "vkCreateSwapchainKHR");
    ReleaseSwapchain();
    swapchain = next;
    extent = requested;
    Check(GetSwapchainImages(native.device, swapchain, &imageCount, nullptr), "vkGetSwapchainImagesKHR");
    images.resize(imageCount);
    Check(GetSwapchainImages(native.device, swapchain, &imageCount, images.data()), "vkGetSwapchainImagesKHR");
    images.resize(imageCount);
    completed.resize(imageCount, VK_NULL_HANDLE);
    VkSemaphoreCreateInfo semaphoreInfo{VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO};
    for (auto& semaphore : completed)
        Check(CreateSemaphore(native.device, &semaphoreInfo, nullptr, &semaphore), "vkCreateSemaphore");
    offscreen = false;
    rebuild = false;
}
void CelesteVulkanWindow::Acquire(CelesteGraphicsOutput** result)
{
    if (failed)
        throw std::runtime_error("Vulkan window is in a failed state; close this session");
    if (!result)
        throw std::invalid_argument("Output pointer is required");
    *result = nullptr;
    if (acquired)
        throw std::logic_error("The preceding window output has not been presented");
    auto& slot = slots[slotIndex];
    if (slot.submission)
    {
        const int completion = api->GetCompletion(slot.submission);
        if (completion < 0)
            Backend(0);
        if (completion == 0)
            Backend(api->Wait(slot.submission));
        api->ReleaseSubmission(slot.submission);
        slot.submission = nullptr;
    }
    if (rebuild)
        Recreate();
    if (!offscreen)
    {
        VkResult status =
            AcquireNextImage(native.device, swapchain, UINT64_MAX, slot.ready, VK_NULL_HANDLE, &imageIndex);
        uint32_t resizeAttempts = 0;
        while (status == VK_ERROR_OUT_OF_DATE_KHR && resizeAttempts++ < 4)
        {
            // The host refreshes drawable dimensions before acquisition. Native
            // Win32/Metal sizes can also change while the WSI acquire is pending.
            RefreshDrawableSize();
            rebuild = true;
            Recreate();
            if (!offscreen)
                status =
                    AcquireNextImage(native.device, swapchain, UINT64_MAX, slot.ready, VK_NULL_HANDLE, &imageIndex);
            else
                status = VK_SUCCESS;
        }
        if (status == VK_SUBOPTIMAL_KHR)
            rebuild = true;
        else
            Check(status, "vkAcquireNextImageKHR");
    }
    if (offscreen)
    {
        CelesteGraphicsBackbufferInfo backbuffer{};
        Backend(api->GetBackbufferInfo(backend, &backbuffer));
        const uint32_t hiddenWidth = std::max(extent.width, static_cast<uint32_t>(backbuffer.width));
        const uint32_t hiddenHeight = std::max(extent.height, static_cast<uint32_t>(backbuffer.height));
        if (!hiddenOutput || hiddenOutput->extent.width != hiddenWidth || hiddenOutput->extent.height != hiddenHeight)
        {
            if (hiddenOutput)
                Drain();
            CelesteGraphicsTextureInfo info{};
            info.sourceFormat = SourceSurfaceFormat_Color;
            info.dimension = CelesteGraphicsTexture2D;
            info.width = hiddenWidth;
            info.height = hiddenHeight;
            info.depth = info.levels = 1;
            auto replacement = std::make_unique<Celeste::Graphics::Vulkan::TextureImage>(backend->Resources(), info);
            hiddenOutput = std::move(replacement);
        }
    }
    acquired = true;
    outputSubmitted = false;
    CelesteVulkanOutputInfo output{};
    output.image = offscreen ? hiddenOutput->image : images[imageIndex];
    output.format = offscreen ? VK_FORMAT_R8G8B8A8_UNORM : format.format;
    output.extent = offscreen ? hiddenOutput->extent : extent;
    // Full destination is overwritten. Discard avoids lying about first-acquire layout.
    output.incomingLayout = offscreen ? hiddenOutput->states[0].layout : VK_IMAGE_LAYOUT_UNDEFINED;
    output.outgoingLayout = offscreen ? VK_IMAGE_LAYOUT_GENERAL : VK_IMAGE_LAYOUT_PRESENT_SRC_KHR;
    output.incomingStage = offscreen ? hiddenOutput->states[0].stage : VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
    output.incomingAccess = offscreen ? hiddenOutput->states[0].access : 0;
    output.outgoingStage = VK_PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT;
    output.incomingQueueFamily = output.outgoingQueueFamily = VK_QUEUE_FAMILY_IGNORED;
    if (!offscreen)
    {
        output.readySemaphore = slot.ready;
        output.completeSemaphore = completed[imageIndex];
    }
    Backend(CelesteVulkanAcquireOutput(backend, &output, result));
}
void CelesteVulkanWindow::Submit(CelesteGraphicsPacket* packet, bool wait)
{
    if (failed)
        throw std::runtime_error("Vulkan window is in a failed state; close this session");
    if (acquired && outputSubmitted)
        throw std::logic_error("Window output already submitted");
    CelesteGraphicsSubmission* submission = nullptr;
    Backend(api->Submit(packet, &submission));
    // AcquireOutput is called only immediately before the presentation packet.
    if (acquired)
    {
        slots[slotIndex].submission = submission;
        outputSubmitted = true;
        if (offscreen)
        {
            hiddenOutput->states[0].layout = VK_IMAGE_LAYOUT_GENERAL;
            hiddenOutput->states[0].stage = VK_PIPELINE_STAGE_TRANSFER_BIT;
            hiddenOutput->states[0].access = VK_ACCESS_TRANSFER_WRITE_BIT;
        }
        if (wait)
            Backend(api->Wait(submission));
    }
    else
    {
        try
        {
            if (wait)
                Backend(api->Wait(submission));
        }
        catch (...)
        {
            api->ReleaseSubmission(submission);
            throw;
        }
        api->ReleaseSubmission(submission);
    }
}
void CelesteVulkanWindow::Present()
{
    if (!acquired || !outputSubmitted)
        throw std::logic_error("Presentation requires a submitted window output");
    VkResult status = VK_SUCCESS;
    if (!offscreen)
    {
        VkPresentInfoKHR present{VK_STRUCTURE_TYPE_PRESENT_INFO_KHR};
        present.waitSemaphoreCount = 1;
        present.pWaitSemaphores = &completed[imageIndex];
        present.swapchainCount = 1;
        present.pSwapchains = &swapchain;
        present.pImageIndices = &imageIndex;
        status = QueuePresent(presentQueue, &present);
    }
    acquired = false;
    outputSubmitted = false;
    slotIndex = (slotIndex + 1) % static_cast<uint32_t>(slots.size());
    if (status == VK_ERROR_OUT_OF_DATE_KHR || status == VK_SUBOPTIMAL_KHR)
        rebuild = true;
    else if (status != VK_SUCCESS)
    {
        failed = true;
        Check(status, "vkQueuePresentKHR");
    }
}
void CelesteVulkanWindow::Close()
{
    Drain();
    hiddenOutput.reset();
    if (backend)
    {
        Backend(api->DestroyDevice(backend));
        backend = nullptr;
    }
    ReleaseSwapchain();
    for (auto& slot : slots)
    {
        if (slot.ready)
            DestroySemaphore(native.device, slot.ready, nullptr);
        slot.ready = VK_NULL_HANDLE;
    }
    if (native.device)
        DestroyDevice(native.device, nullptr);
    native.device = VK_NULL_HANDLE;
    if (surface)
        DestroySurfaceKHR(native.instance, surface, nullptr);
    surface = VK_NULL_HANDLE;
    if (native.instance)
        DestroyInstance(native.instance, nullptr);
    native.instance = VK_NULL_HANDLE;
    ReleasePlatformSurface();
}
CelesteVulkanWindow::~CelesteVulkanWindow()
{
    // Startup unwind, before any packet submission, or already successful Close.
    hiddenOutput.reset();
    if (backend)
        api->DestroyDevice(backend);
    ReleaseSwapchain();
    for (auto& slot : slots)
        if (slot.ready)
            DestroySemaphore(native.device, slot.ready, nullptr);
    if (native.device && DestroyDevice)
        DestroyDevice(native.device, nullptr);
    if (surface && DestroySurfaceKHR)
        DestroySurfaceKHR(native.instance, surface, nullptr);
    if (native.instance && DestroyInstance)
        DestroyInstance(native.instance, nullptr);
    ReleasePlatformSurface();
}
