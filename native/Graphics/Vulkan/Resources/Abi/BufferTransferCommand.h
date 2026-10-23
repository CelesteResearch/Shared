#pragma once
#include <cstdint>
namespace Celeste::Graphics::Vulkan
{
    struct BufferTransferCommand
    {
        uint32_t buffer, staging;
        uint32_t offset, count, size, stride;
        bool read;
    };
}
