#include "CelesteVulkanWindow.h"
#include "VulkanApiErrors.h"
extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanCreateWindow(const CelesteVulkanWindowInfo* info,
                                                                   CelesteVulkanWindow** window,
                                                                   CelesteGraphicsDevice** device)
{
    if (window)
        *window = nullptr;
    if (device)
        *device = nullptr;
    return VulkanInvoke([&] {
        if (!info || !window || !device)
            throw std::invalid_argument("Window creation requires info and output pointers");
        auto value = std::make_unique<CelesteVulkanWindow>();
        CelesteVulkanSurfaceWindowInfo portable{};
        portable.surfaceKind = CelesteVulkanWindowSurfaceWin32;
        portable.windowHandle = info->windowHandle;
        portable.displayHandle = info->instanceHandle;
        portable.apiVersion = info->apiVersion;
        portable.physicalDeviceIndex = info->physicalDeviceIndex;
        portable.width = info->width;
        portable.height = info->height;
        portable.synchronized = info->synchronized;
        value->Initialize(portable);
        *device = value->backend;
        *window = value.release();
    });
}
extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanResizeWindow(CelesteVulkanWindow* window, uint32_t width,
                                                                   uint32_t height, uint32_t synchronized)
{
    return VulkanInvoke([&] {
        if (!window)
            throw std::invalid_argument("Window is null");
        window->Resize(width, height, synchronized);
    });
}
extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanAcquireWindowOutput(CelesteVulkanWindow* window,
                                                                          CelesteGraphicsOutput** output)
{
    if (output)
        *output = nullptr;
    return VulkanInvoke([&] {
        if (!window)
            throw std::invalid_argument("Window is null");
        window->Acquire(output);
    });
}
extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanSubmitWindowPacket(CelesteVulkanWindow* window,
                                                                         CelesteGraphicsPacket* packet, uint32_t wait)
{
    return VulkanInvoke([&] {
        if (!window)
            throw std::invalid_argument("Window is null");
        window->Submit(packet, wait != 0);
    });
}
extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanPresentWindow(CelesteVulkanWindow* window)
{
    return VulkanInvoke([&] {
        if (!window)
            throw std::invalid_argument("Window is null");
        window->Present();
    });
}
extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanDestroyWindow(CelesteVulkanWindow* window)
{
    return VulkanInvoke([&] {
        if (window)
        {
            window->Close();
            delete window;
        }
    });
}

extern "C" int32_t CELESTE_GRAPHICS_CALL CelesteVulkanCreateSurfaceWindow(const CelesteVulkanSurfaceWindowInfo* info,
                                                                          CelesteVulkanWindow** window,
                                                                          CelesteGraphicsDevice** device)
{
    if (window)
        *window = nullptr;
    if (device)
        *device = nullptr;
    return VulkanInvoke([&] {
        if (!info || !window || !device)
            throw std::invalid_argument("Window creation requires info and output pointers");
        if (info->reserved)
            throw std::invalid_argument("Reserved surface fields must be zero");
        auto value = std::make_unique<CelesteVulkanWindow>();
        value->Initialize(*info);
        *device = value->backend;
        *window = value.release();
    });
}
