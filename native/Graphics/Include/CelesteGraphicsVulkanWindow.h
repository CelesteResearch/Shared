#pragma once
#include "CelesteGraphicsVulkan.h"
#ifdef __cplusplus
extern "C"
{
#endif
    typedef struct CelesteVulkanWindow CelesteVulkanWindow;
    typedef struct CelesteVulkanWindowInfo
    {
        void* windowHandle;
        void* instanceHandle;
        uint32_t apiVersion;
        uint32_t physicalDeviceIndex;
        uint32_t width, height;
        // Zero selects immediate when supported, otherwise FIFO; nonzero selects FIFO.
        uint32_t synchronized;
    } CelesteVulkanWindowInfo;
    typedef enum CelesteVulkanWindowSurfaceKind
    {
        CelesteVulkanWindowSurfaceWin32 = 0,
        CelesteVulkanWindowSurfaceXlib = 1,
        CelesteVulkanWindowSurfaceWayland = 2,
        CelesteVulkanWindowSurfaceMetalView = 3
    } CelesteVulkanWindowSurfaceKind;
    typedef struct CelesteVulkanSurfaceWindowInfo
    {
        uint32_t surfaceKind;
        uint32_t reserved;
        void* windowHandle;
        void* displayHandle;
        uint32_t apiVersion, physicalDeviceIndex, width, height, synchronized;
    } CelesteVulkanSurfaceWindowInfo;
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanCreateSurfaceWindow(const CelesteVulkanSurfaceWindowInfo*,
                                                                   CelesteVulkanWindow**, CelesteGraphicsDevice**);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanCreateWindow(const CelesteVulkanWindowInfo*, CelesteVulkanWindow**,
                                                            CelesteGraphicsDevice**);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanResizeWindow(CelesteVulkanWindow*, uint32_t width, uint32_t height,
                                                            uint32_t synchronized);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanAcquireWindowOutput(CelesteVulkanWindow*, CelesteGraphicsOutput**);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanSubmitWindowPacket(CelesteVulkanWindow*, CelesteGraphicsPacket*,
                                                                  uint32_t waitForCompletion);
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanPresentWindow(CelesteVulkanWindow*);
    // Caller has released all source resources and output/packet loans first.
    // Drains window work and destroys the borrowed backend wrapper, device and surface.
    int32_t CELESTE_GRAPHICS_CALL CelesteVulkanDestroyWindow(CelesteVulkanWindow*);
#ifdef __cplusplus
}
#endif
#ifdef __cplusplus
#if UINTPTR_MAX == UINT64_MAX
static_assert(sizeof(CelesteVulkanWindowInfo) == 40);
static_assert(sizeof(CelesteVulkanSurfaceWindowInfo) == 48);
static_assert(offsetof(CelesteVulkanWindowInfo, apiVersion) == 16);
#endif
#endif
