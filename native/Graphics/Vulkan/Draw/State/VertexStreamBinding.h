#pragma once
#include "TransferBuffer.h"
#include <memory>
namespace Celeste::Graphics::Vulkan
{
    struct VertexStreamBinding
    {
        std::shared_ptr<TransferBuffer> buffer;
        uint32_t stride = 0, instanceFrequency = 0;
        VkDeviceSize offset = 0;
    };
}
