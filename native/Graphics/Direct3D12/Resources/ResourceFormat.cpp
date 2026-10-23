#include "ResourceFormat.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    ResourceFormat ResourceFormat::FromSource(SourceSurfaceFormat source)
    {
        static constexpr DXGI_FORMAT formats[] = {DXGI_FORMAT_R8G8B8A8_UNORM,     DXGI_FORMAT_B5G6R5_UNORM,
                                                  DXGI_FORMAT_B5G5R5A1_UNORM,     DXGI_FORMAT_B4G4R4A4_UNORM,
                                                  DXGI_FORMAT_BC1_UNORM,          DXGI_FORMAT_BC2_UNORM,
                                                  DXGI_FORMAT_BC3_UNORM,          DXGI_FORMAT_R8G8_SNORM,
                                                  DXGI_FORMAT_R8G8B8A8_SNORM,     DXGI_FORMAT_R10G10B10A2_UNORM,
                                                  DXGI_FORMAT_R16G16_UNORM,       DXGI_FORMAT_R16G16B16A16_UNORM,
                                                  DXGI_FORMAT_A8_UNORM,           DXGI_FORMAT_R32_FLOAT,
                                                  DXGI_FORMAT_R32G32_FLOAT,       DXGI_FORMAT_R32G32B32A32_FLOAT,
                                                  DXGI_FORMAT_R16_FLOAT,          DXGI_FORMAT_R16G16_FLOAT,
                                                  DXGI_FORMAT_R16G16B16A16_FLOAT, DXGI_FORMAT_R16G16B16A16_FLOAT,
                                                  DXGI_FORMAT_B8G8R8A8_UNORM,     DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,
                                                  DXGI_FORMAT_BC3_UNORM_SRGB,     DXGI_FORMAT_BC7_UNORM,
                                                  DXGI_FORMAT_BC7_UNORM_SRGB};
        static constexpr uint32_t sizes[] = {4, 2, 2,  2, 8, 16, 16, 2, 4, 4,  4,  8, 1,
                                             4, 8, 16, 2, 4, 8,  8,  4, 4, 16, 16, 16};
        if (source < 0 || source >= 25)
            throw std::invalid_argument("Unknown SourceSurfaceFormat");
        const bool bc = (source >= 4 && source <= 6) || source >= 22;
        return {formats[source], bc ? 4u : 1u, bc ? 4u : 1u, sizes[source]};
    }
    uint64_t ResourceFormat::RowBytes(uint32_t width) const
    {
        return ((uint64_t(width) + blockWidth - 1) / blockWidth) * blockBytes;
    }
    uint32_t ResourceFormat::Rows(uint32_t height) const
    {
        return uint32_t((uint64_t(height) + blockHeight - 1) / blockHeight);
    }
    uint64_t ResourceFormat::ByteSize(uint32_t width, uint32_t height, uint32_t depth) const
    {
        return RowBytes(width) * Rows(height) * depth;
    }
}
