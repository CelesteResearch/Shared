#include "VulkanLibrary.h"
#include <stdexcept>
#include <initializer_list>
#include <string>
#include <cstdlib>
#if defined(_WIN32)
#define WIN32_LEAN_AND_MEAN
#define NOMINMAX
#include <windows.h>
#else
#include <dlfcn.h>
#if defined(__APPLE__)
namespace
{
    void* OpenBundledVulkanLoader()
    {
        Dl_info location{};
        if (!dladdr(reinterpret_cast<const void*>(&OpenBundledVulkanLoader), &location) || !location.dli_fname)
            return nullptr;
        const std::string owner(location.dli_fname);
        const auto slash = owner.find_last_of('/');
        if (slash == std::string::npos)
            return nullptr;
        for (const char* candidate : {"libvulkan.1.dylib", "libvulkan.dylib", "libMoltenVK.dylib"})
        {
            const std::string path = owner.substr(0, slash + 1) + candidate;
            if (void* handle = dlopen(path.c_str(), RTLD_NOW | RTLD_LOCAL))
                return handle;
        }
        return nullptr;
    }
}
#endif
#endif

VulkanLibrary::~VulkanLibrary()
{
    if (!handle_)
        return;
#if defined(_WIN32)
    FreeLibrary(static_cast<HMODULE>(handle_));
#else
    dlclose(handle_);
#endif
}

PFN_vkGetInstanceProcAddr VulkanLibrary::Open()
{
#if defined(_WIN32)
    if (!handle_)
        handle_ = LoadLibraryExW(L"vulkan-1.dll", nullptr, LOAD_LIBRARY_SEARCH_SYSTEM32);
    auto address = handle_ ? reinterpret_cast<PFN_vkGetInstanceProcAddr>(
                                 GetProcAddress(static_cast<HMODULE>(handle_), "vkGetInstanceProcAddr"))
                           : nullptr;
#else
    if (!handle_)
    {
#if defined(__APPLE__)
        // Older MoltenVK versions need shader swizzles for Alpha8 views on
        // devices without native texture swizzles. Preserve explicit overrides.
        if (setenv("MVK_CONFIG_FULL_IMAGE_VIEW_SWIZZLE", "1", 0) != 0)
            throw std::runtime_error("Unable to configure MoltenVK image view swizzles");
        handle_ = OpenBundledVulkanLoader();
        if (!handle_)
            for (const char* candidate : {"libvulkan.1.dylib", "libvulkan.dylib", "libMoltenVK.dylib"})
            {
                handle_ = dlopen(candidate, RTLD_NOW | RTLD_LOCAL);
                if (handle_)
                    break;
            }
#else
        handle_ = dlopen("libvulkan.so.1", RTLD_NOW | RTLD_LOCAL);
#endif
    }
    auto address =
        handle_ ? reinterpret_cast<PFN_vkGetInstanceProcAddr>(dlsym(handle_, "vkGetInstanceProcAddr")) : nullptr;
#endif
    if (!address)
        throw std::runtime_error("Unable to load Vulkan loader vkGetInstanceProcAddr");
    return address;
}
