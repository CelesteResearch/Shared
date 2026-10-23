#include "TextureBytes.h"
#include <cstring>
#include <stdexcept>
namespace Celeste::Graphics::Vulkan
{
    void EncodeTextureBytes(SourceSurfaceFormat format, uint8_t* destination, const uint8_t* source, size_t bytes)
    {
        if (format == SourceSurfaceFormat_Alpha8)
        {
            for (size_t index = 0; index < bytes; ++index)
            {
                destination[index * 4] = destination[index * 4 + 1] = destination[index * 4 + 2] = 0;
                destination[index * 4 + 3] = source[index];
            }
            return;
        }
        if (format != SourceSurfaceFormat_Bgra4444)
        {
            if (destination != source)
                std::memcpy(destination, source, bytes);
            return;
        }
        if (bytes % 2)
            throw std::invalid_argument("4444 transfer byte count");
        for (size_t index = 0; index < bytes; index += 2)
        {
            const uint16_t value = uint16_t(source[index]) | uint16_t(source[index + 1]) << 8;
            const uint16_t encoded = uint16_t(((value & 0xF) << 12) | ((value & 0xF0) << 4) | ((value & 0xF00) >> 4) |
                                              ((value & 0xF000) >> 12));
            destination[index] = uint8_t(encoded);
            destination[index + 1] = uint8_t(encoded >> 8);
        }
    }
    size_t DecodeTextureBytes(SourceSurfaceFormat format, uint8_t* bytes, size_t length)
    {
        if (format == SourceSurfaceFormat_Alpha8)
        {
            if (length % 4)
                throw std::invalid_argument("Alpha8 storage readback byte count");
            for (size_t index = 0; index < length / 4; ++index)
                bytes[index] = bytes[index * 4 + 3];
            return length / 4;
        }
        if (format != SourceSurfaceFormat_Bgra4444)
            return length;
        if (length % 2)
            throw std::invalid_argument("4444 readback byte count");
        for (size_t index = 0; index < length; index += 2)
        {
            const uint16_t value = uint16_t(bytes[index]) | uint16_t(bytes[index + 1]) << 8;
            const uint16_t decoded = uint16_t(((value & 0xF) << 12) | ((value & 0xF0) << 4) | ((value & 0xF00) >> 4) |
                                              ((value & 0xF000) >> 12));
            bytes[index] = uint8_t(decoded);
            bytes[index + 1] = uint8_t(decoded >> 8);
        }
        return length;
    }
}
