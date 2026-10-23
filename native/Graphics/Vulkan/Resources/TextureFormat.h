#pragma once
#include "CelesteGraphicsSourceEnums.h"
#include <vulkan/vulkan_core.h>
#include <cstddef>
#include <cstdint>
namespace Celeste::Graphics::Vulkan
{
    struct TextureFormat final
    {
        VkFormat native;
        uint8_t blockWidth;
        uint8_t blockHeight;
        uint8_t blockBytes;
        uint8_t storageBlockBytes;
        VkComponentMapping swizzle;
        static TextureFormat FromSource(SourceSurfaceFormat source);
        uint64_t ByteSize(uint32_t width, uint32_t height, uint32_t depth) const;
        uint64_t StorageByteSize(uint32_t width, uint32_t height, uint32_t depth) const;
        bool Compressed() const noexcept
        {
            return blockWidth != 1;
        }
    };
}
