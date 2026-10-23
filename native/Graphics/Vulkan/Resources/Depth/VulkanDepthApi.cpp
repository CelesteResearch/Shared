#include "VulkanDepthApi.h"
#include "CelesteGraphicsRenderbuffer.h"
#include "CelesteGraphicsDevice.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    void CreateDepthRenderbuffer(CelesteGraphicsDevice* device, int32_t width, int32_t height, SourceDepthFormat format,
                                 int32_t samples, CelesteGraphicsRenderbuffer** output)
    {
        if (output)
            *output = nullptr;
        if (!device || !output || width <= 0 || height <= 0)
            throw std::invalid_argument("Invalid depth renderbuffer creation");
        auto result = std::make_unique<CelesteGraphicsRenderbuffer>();
        result->device = device;
        result->depth = std::make_shared<DepthStencilAttachment>(device->Resources(), width, height, format, samples);
        *output = result.release();
    }
    void ReleaseRenderbuffer(CelesteGraphicsRenderbuffer* buffer) noexcept
    {
        delete buffer;
    }
}
