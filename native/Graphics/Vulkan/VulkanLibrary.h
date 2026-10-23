#pragma once
#include <vulkan/vulkan_core.h>

class VulkanLibrary final
{
  public:
    VulkanLibrary() = default;
    ~VulkanLibrary();
    VulkanLibrary(const VulkanLibrary&) = delete;
    VulkanLibrary& operator=(const VulkanLibrary&) = delete;
    PFN_vkGetInstanceProcAddr Open();

  private:
    void* handle_ = nullptr;
};
