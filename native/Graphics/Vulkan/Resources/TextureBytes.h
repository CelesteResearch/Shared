#pragma once
#include "CelesteGraphicsSourceEnums.h"
#include <cstddef>
#include <cstdint>
namespace Celeste::Graphics::Vulkan
{
    // Only Bgra4444 differs physically: ARGB4444 source bytes vs core Vulkan BGRA4444.
    // Rotate all sixteen bits without float conversion or quantization changes.
    void EncodeTextureBytes(SourceSurfaceFormat format, uint8_t* destination, const uint8_t* source, size_t bytes);
    size_t DecodeTextureBytes(SourceSurfaceFormat format, uint8_t* bytes, size_t length);
}
