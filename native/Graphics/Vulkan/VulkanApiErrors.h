#pragma once
#include <cstdint>
#include <exception>

void VulkanSetError(const char* error) noexcept;
void VulkanClearError() noexcept;
const char* VulkanGetError() noexcept;
template <class T> int32_t VulkanInvoke(T&& action) noexcept
{
    try
    {
        action();
        VulkanClearError();
        return 1;
    }
    catch (const std::exception& error)
    {
        VulkanSetError(error.what());
        return 0;
    }
    catch (...)
    {
        VulkanSetError("Unknown native Vulkan exception");
        return 0;
    }
}
