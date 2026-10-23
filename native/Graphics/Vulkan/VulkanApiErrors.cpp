#include "VulkanApiErrors.h"
#include <string>
namespace
{
    thread_local std::string lastError;
    thread_local const char* fallbackError = nullptr;
}
void VulkanSetError(const char* error) noexcept
{
    try
    {
        lastError = error;
        fallbackError = nullptr;
    }
    catch (...)
    {
        fallbackError = "Vulkan error could not be copied: out of host memory";
    }
}
void VulkanClearError() noexcept
{
    lastError.clear();
    fallbackError = nullptr;
}
const char* VulkanGetError() noexcept
{
    return fallbackError ? fallbackError : lastError.c_str();
}
