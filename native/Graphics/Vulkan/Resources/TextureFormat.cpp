#include "TextureFormat.h"
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    TextureFormat TextureFormat::FromSource(SourceSurfaceFormat source)
    {
        static constexpr VkFormat formats[] = {VK_FORMAT_R8G8B8A8_UNORM,
                                               VK_FORMAT_R5G6B5_UNORM_PACK16,
                                               VK_FORMAT_A1R5G5B5_UNORM_PACK16,
                                               VK_FORMAT_B4G4R4A4_UNORM_PACK16,
                                               VK_FORMAT_BC1_RGBA_UNORM_BLOCK,
                                               VK_FORMAT_BC2_UNORM_BLOCK,
                                               VK_FORMAT_BC3_UNORM_BLOCK,
                                               VK_FORMAT_R8G8_SNORM,
                                               VK_FORMAT_R8G8B8A8_SNORM,
                                               VK_FORMAT_A2B10G10R10_UNORM_PACK32,
                                               VK_FORMAT_R16G16_UNORM,
                                               VK_FORMAT_R16G16B16A16_UNORM,
                                               VK_FORMAT_R8G8B8A8_UNORM,
                                               VK_FORMAT_R32_SFLOAT,
                                               VK_FORMAT_R32G32_SFLOAT,
                                               VK_FORMAT_R32G32B32A32_SFLOAT,
                                               VK_FORMAT_R16_SFLOAT,
                                               VK_FORMAT_R16G16_SFLOAT,
                                               VK_FORMAT_R16G16B16A16_SFLOAT,
                                               VK_FORMAT_R16G16B16A16_SFLOAT,
                                               VK_FORMAT_B8G8R8A8_UNORM,
                                               VK_FORMAT_R8G8B8A8_SRGB,
                                               VK_FORMAT_BC3_SRGB_BLOCK,
                                               VK_FORMAT_BC7_UNORM_BLOCK,
                                               VK_FORMAT_BC7_SRGB_BLOCK};
        static constexpr uint8_t bytes[] = {4, 2, 2,  2, 8, 16, 16, 2, 4, 4,  4,  8, 1,
                                            4, 8, 16, 2, 4, 8,  8,  4, 4, 16, 16, 16};
        if (source < 0 || source >= 25)
            throw std::invalid_argument("Unknown source texture format");
        const bool compressed = (source >= SourceSurfaceFormat_Dxt1 && source <= SourceSurfaceFormat_Dxt5) ||
                                source >= SourceSurfaceFormat_Dxt5SrgbEXT;
        TextureFormat result{formats[source],
                             uint8_t(compressed ? 4 : 1),
                             uint8_t(compressed ? 4 : 1),
                             bytes[source],
                             uint8_t(source == SourceSurfaceFormat_Alpha8 ? 4 : bytes[source]),
                             {}};
        if (source == SourceSurfaceFormat_Alpha8)
            result.swizzle = {VK_COMPONENT_SWIZZLE_ZERO, VK_COMPONENT_SWIZZLE_ZERO, VK_COMPONENT_SWIZZLE_ZERO,
                              VK_COMPONENT_SWIZZLE_A};
        return result;
    }
    uint64_t TextureFormat::StorageByteSize(uint32_t width, uint32_t height, uint32_t depth) const
    {
        return ((uint64_t(width) + blockWidth - 1) / blockWidth) *
               ((uint64_t(height) + blockHeight - 1) / blockHeight) * depth * storageBlockBytes;
    }
    uint64_t TextureFormat::ByteSize(uint32_t width, uint32_t height, uint32_t depth) const
    {
        return ((uint64_t(width) + blockWidth - 1) / blockWidth) *
               ((uint64_t(height) + blockHeight - 1) / blockHeight) * depth * blockBytes;
    }
}
