#pragma once
#include "TransferBuffer.h"
#include <memory>
#include <vector>

namespace Celeste::Graphics::Vulkan
{
    // A packet holds its page through GPU retirement. The pool reuses only sole-owned pages.
    class UniformBufferPool final
    {
        std::shared_ptr<ResourceContext> context;
        std::vector<std::shared_ptr<TransferBuffer>> pages;

      public:
        explicit UniformBufferPool(std::shared_ptr<ResourceContext> owner) : context(std::move(owner))
        {
        }
        std::shared_ptr<TransferBuffer> Upload(const std::vector<uint8_t>& bytes);
    };
}
