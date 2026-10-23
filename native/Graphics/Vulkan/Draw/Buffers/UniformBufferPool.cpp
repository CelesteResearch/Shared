#include "UniformBufferPool.h"
#include <algorithm>

namespace Celeste::Graphics::Vulkan
{
    std::shared_ptr<TransferBuffer> UniformBufferPool::Upload(const std::vector<uint8_t>& bytes)
    {
        if (bytes.empty())
            return {};
        for (const auto& page : pages)
            if (page.use_count() == 1 && page->size >= bytes.size())
            {
                page->Write(bytes.data(), bytes.size());
                return page;
            }
        auto page = std::make_shared<TransferBuffer>(context, std::max<size_t>(65536, bytes.size()),
                                                     VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT);
        page->Write(bytes.data(), bytes.size());
        pages.push_back(page);
        return page;
    }
}
