#include "VulkanResourceApi.h"
#include "CelesteGraphicsReadback.h"
#include "TextureBytes.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    int32_t GetReadbackStatus(CelesteGraphicsReadback* readback)
    {
        if (!readback || !readback->state)
            throw std::invalid_argument("Missing readback");
        auto& state = *readback->state;
        if (state.unchanged)
            return 2;
        if (state.copied)
            return 1;
        const VkResult result = state.completion->Poll();
        if (result == VK_NOT_READY)
            return 0;
        if (result != VK_SUCCESS)
            throw std::runtime_error("Vulkan readback submission failed");
        state.staging->Read(state.bytes.data(), state.bytes.size());
        state.bytes.resize(DecodeTextureBytes(state.sourceFormat, state.bytes.data(), state.bytes.size()));
        state.staging.reset();
        state.copied = true;
        return 1;
    }
    void GetReadbackBytes(CelesteGraphicsReadback* readback, const void** bytes, uint32_t* length)
    {
        if (bytes)
            *bytes = nullptr;
        if (length)
            *length = 0;
        if (!bytes || !length)
            throw std::invalid_argument("Readback requires byte and length outputs");
        const auto status = GetReadbackStatus(readback);
        if (status == 2)
            return;
        if (status != 1)
            throw std::logic_error("Readback is not complete");
        *bytes = readback->state->bytes.data();
        *length = static_cast<uint32_t>(readback->state->bytes.size());
    }
    void ReleaseReadback(CelesteGraphicsReadback* readback) noexcept
    {
        delete readback;
    }
}
