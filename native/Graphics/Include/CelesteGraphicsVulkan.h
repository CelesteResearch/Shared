#pragma once
#include "CelesteGraphicsBackend.h"
#include <vulkan/vulkan_core.h>

#ifdef __cplusplus
extern "C"
{
#endif

    typedef struct CelesteVulkanOwnedDeviceInfo
    {
        uint32_t apiVersion;
        // UINT32_MAX selects the first suitable physical device with a graphics queue.
        uint32_t physicalDeviceIndex;
        uint32_t instanceExtensionCount;
        const char* const* instanceExtensions;
        uint32_t deviceExtensionCount;
        const char* const* deviceExtensions;
        const VkPhysicalDeviceFeatures* deviceFeatures;
        const void* deviceCreateNext;
        const void* instanceCreateNext;
    } CelesteVulkanOwnedDeviceInfo;

    typedef enum CelesteVulkanPortabilityFeature
    {
        CelesteVulkanPortabilitySubset = 1u,
        CelesteVulkanPortabilityImageViewSwizzle = 2u,
        CelesteVulkanPortabilitySamplerMipLodBias = 4u,
        CelesteVulkanPortabilitySeparateStencilMaskReference = 8u,
        CelesteVulkanPortabilityConstantAlphaColorBlendFactors = 16u,
        CelesteVulkanPortabilityVertexAttributeAccessBeyondStride = 32u
    } CelesteVulkanPortabilityFeature;

    typedef struct CelesteVulkanNativeDevice
    {
        VkInstance instance;
        VkPhysicalDevice physicalDevice;
        VkDevice device;
        VkQueue graphicsQueue;
        uint32_t graphicsQueueFamily;
        // Effective enabled instance API bounded by the physical device's supported API.
        // Borrowed hosts report their actual enabled version, not just hardware support.
        uint32_t apiVersion;
        // Actual VkDevice enabled base features, copied from pEnabledFeatures/Features2.
        VkPhysicalDeviceFeatures enabledFeatures;
        PFN_vkGetInstanceProcAddr getInstanceProcAddr;
        PFN_vkGetDeviceProcAddr getDeviceProcAddr;
        // Actual device-enabled portability features; zero denotes a full Vulkan device.
        uint32_t portabilityFeatures;
    } CelesteVulkanNativeDevice;

    typedef struct CelesteVulkanBorrowedDeviceInfo
    {
        CelesteVulkanNativeDevice nativeDevice;
        // Optional host queue exclusion, once per submission rather than per draw.
        // If null, the host invokes submission only in its serialized queue phase.
        void* queueContext;
        void(CELESTE_GRAPHICS_CALL* EnterQueue)(void* queueContext);
        void(CELESTE_GRAPHICS_CALL* LeaveQueue)(void* queueContext);
    } CelesteVulkanBorrowedDeviceInfo;

    // One borrowed output image for one presentation, on the same VkDevice.
    // Only color mip 0/layer 0, single sample, is part of this initial output contract.
    typedef struct CelesteVulkanOutputInfo
    {
        VkImage image;
        VkFormat format;
        VkExtent2D extent;
        VkImageLayout incomingLayout;
        VkImageLayout outgoingLayout;
        VkPipelineStageFlags incomingStage;
        VkAccessFlags incomingAccess;
        VkPipelineStageFlags outgoingStage;
        VkAccessFlags outgoingAccess;
        uint32_t incomingQueueFamily;
        uint32_t outgoingQueueFamily;
        // Optional binary semaphores; these handles remain host-owned.
        VkSemaphore readySemaphore;
        VkSemaphore completeSemaphore;
    } CelesteVulkanOutputInfo;

    // Backend module exports have distinct names so D3D11/Vulkan/D3D12 can coexist.
    // All creation info pointers are borrowed only for the duration of the call.
    const CelesteGraphicsDeviceApi* CELESTE_GRAPHICS_CALL CelesteVulkanGetDeviceApi(void);
    const char* CELESTE_GRAPHICS_CALL CelesteVulkanGetLastError(void);
    // Adds a caller loan for a queued host callback. Release through ReleasePacket.
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanRetainPacket(CelesteGraphicsPacket* packet);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanReleaseDevice(CelesteGraphicsDevice* device);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanCreateOwnedDevice(const CelesteVulkanOwnedDeviceInfo* info,
                                                                 CelesteGraphicsDevice** device);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanCreateBorrowedDevice(const CelesteVulkanBorrowedDeviceInfo* info,
                                                                    CelesteGraphicsDevice** device);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanGetNativeDevice(CelesteGraphicsDevice* device,
                                                               CelesteVulkanNativeDevice* nativeDevice);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanAcquireTextureOutput(CelesteGraphicsDevice*, CelesteGraphicsTexture*,
                                                                    CelesteGraphicsOutput**);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanAcquireOutput(CelesteGraphicsDevice* device,
                                                             const CelesteVulkanOutputInfo* info,
                                                             CelesteGraphicsOutput** output);

    typedef struct CelesteVulkanHostRecording
    {
        VkCommandBuffer commandBuffer;
        // Monotonic host submission identity, not a game/TAS frame counter.
        uint64_t submissionSerial;
    } CelesteVulkanHostRecording;

    // Alternative to Submit for an engine-owned command buffer. The host supplies a
    // recording primary buffer outside any render pass, and ends/submits it itself.
    // This call emits actual Vulkan commands without ending/submitting the buffer.
    // Packet resources remain retained until RetireHostSubmissions covers the serial.
    // The caller keeps native device/image loans alive through that completion point.
    // Resolve fallible allocation/pipeline/descriptor work before the first vkCmd.
    // Ordinary failure returns with no emitted commands; there is no command-buffer
    // rollback API. Device loss is fatal, not a recoverable partial recording.
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanRecordHostPacket(CelesteGraphicsPacket* packet,
                                                                const CelesteVulkanHostRecording* recording);
    void CELESTE_GRAPHICS_CALL CelesteVulkanRetireHostSubmissions(CelesteGraphicsDevice* device,
                                                                  uint64_t completedSerial);

    // The host orders backend recording against all other uses of borrowed images.
    // Output semaphores are null for this path; host submission carries synchronization.
    // Retirement serials cover all prior records, and must report real GPU completion.
    // The final host serial must be retired before ReleaseDevice; no host QueueWaitIdle
    // is inserted by ordinary record/retire operations.

    // Borrowed instance/device/queue/image/semaphores are never destroyed here.
    // Host keeps them alive until submission completes (or until output release if
    // never submitted). Queue-family transfer requires matching host release/acquire
    // barriers. The backend performs its own half and waits/signals the supplied
    // semaphores; an enum change alone does not transfer ownership.
    // Outputs are acquired per presentation, used once, then released by the caller.
    // For the same queue, semaphore handles may be null when host ordering is explicit.
    // AcquireOutput does not itself issue commands, wait, or assume presentation layout.

#ifdef __cplusplus
}
#endif
