#include "CelesteVulkanWindow.h"
#include <algorithm>
#if defined(_WIN32)
#define WIN32_LEAN_AND_MEAN
#define NOMINMAX
#include <windows.h>
#include <vulkan/vulkan_win32.h>
#elif defined(__APPLE__)
#include <vulkan/vulkan_metal.h>
extern void* CelesteCreateMetalSurfaceView(void*, uint32_t, uint32_t);
extern const void* CelesteMetalSurfaceLayer(void*);
extern void CelesteMetalSurfaceDrawableSize(void*, uint32_t*, uint32_t*);
extern void CelesteDestroyMetalSurfaceView(void*) noexcept;
#else
typedef struct _XDisplay Display;
typedef unsigned long Window;
typedef unsigned long VisualID;
#include <vulkan/vulkan_xlib.h>
#include <vulkan/vulkan_wayland.h>
#endif

const char* CelesteVulkanWindow::SurfaceExtension() const
{
#if defined(_WIN32)
    if (surfaceKind == CelesteVulkanWindowSurfaceWin32)
        return "VK_KHR_win32_surface";
#elif defined(__APPLE__)
    if (surfaceKind == CelesteVulkanWindowSurfaceMetalView)
        return "VK_EXT_metal_surface";
#else
    if (surfaceKind == CelesteVulkanWindowSurfaceXlib)
        return "VK_KHR_xlib_surface";
    if (surfaceKind == CelesteVulkanWindowSurfaceWayland)
        return "VK_KHR_wayland_surface";
#endif
    throw std::invalid_argument("The requested Vulkan surface does not belong to this operating system");
}

void CelesteVulkanWindow::CreateSurface()
{
#if defined(_WIN32)
    VkWin32SurfaceCreateInfoKHR info{VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR};
    info.hwnd = static_cast<HWND>(windowHandle);
    info.hinstance = displayHandle ? static_cast<HINSTANCE>(displayHandle) : GetModuleHandleW(nullptr);
    Check(Instance<PFN_vkCreateWin32SurfaceKHR>("vkCreateWin32SurfaceKHR")(native.instance, &info, nullptr, &surface),
          "vkCreateWin32SurfaceKHR");
#elif defined(__APPLE__)
    platformSurface = CelesteCreateMetalSurfaceView(windowHandle, width, height);
    VkMetalSurfaceCreateInfoEXT info{VK_STRUCTURE_TYPE_METAL_SURFACE_CREATE_INFO_EXT};
    info.pLayer = static_cast<const CAMetalLayer*>(CelesteMetalSurfaceLayer(platformSurface));
    Check(Instance<PFN_vkCreateMetalSurfaceEXT>("vkCreateMetalSurfaceEXT")(native.instance, &info, nullptr, &surface),
          "vkCreateMetalSurfaceEXT");
#else
    if (!displayHandle)
        throw std::invalid_argument("An Xlib or Wayland display is required");
    if (surfaceKind == CelesteVulkanWindowSurfaceXlib)
    {
        VkXlibSurfaceCreateInfoKHR info{VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR};
        info.dpy = static_cast<Display*>(displayHandle);
        info.window = reinterpret_cast<uintptr_t>(windowHandle);
        Check(Instance<PFN_vkCreateXlibSurfaceKHR>("vkCreateXlibSurfaceKHR")(native.instance, &info, nullptr, &surface),
              "vkCreateXlibSurfaceKHR");
    }
    else
    {
        VkWaylandSurfaceCreateInfoKHR info{VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR};
        info.display = static_cast<wl_display*>(displayHandle);
        info.surface = static_cast<wl_surface*>(windowHandle);
        Check(Instance<PFN_vkCreateWaylandSurfaceKHR>("vkCreateWaylandSurfaceKHR")(native.instance, &info, nullptr,
                                                                                   &surface),
              "vkCreateWaylandSurfaceKHR");
    }
#endif
}

void CelesteVulkanWindow::RefreshDrawableSize()
{
#if defined(_WIN32)
    RECT client{};
    if (!GetClientRect(static_cast<HWND>(windowHandle), &client))
        throw std::runtime_error("GetClientRect failed during swapchain resize");
    width = static_cast<uint32_t>(std::max<LONG>(0, client.right - client.left));
    height = static_cast<uint32_t>(std::max<LONG>(0, client.bottom - client.top));
#elif defined(__APPLE__)
    CelesteMetalSurfaceDrawableSize(platformSurface, &width, &height);
#endif
    // Xlib/Wayland dimensions come from the host's drawable-size notification.
    // Surface capabilities additionally clamp the swapchain to the compositor size.
}

void CelesteVulkanWindow::ReleasePlatformSurface() noexcept
{
#if defined(__APPLE__)
    if (platformSurface)
        CelesteDestroyMetalSurfaceView(platformSurface);
    platformSurface = nullptr;
#endif
}
