#include "EffectConstantStorage.h"
#include "SpirvEffectAbi.h"
#include <limits>
#include <stdexcept>
#include <cstring>

namespace Celeste::Graphics::Vulkan
{
    EffectConstantStorage::EffectConstantStorage(uint32_t uniformAlignment) : alignment(uniformAlignment)
    {
        if (!alignment || (alignment & (alignment - 1)))
            throw std::invalid_argument("Invalid uniform alignment");
    }
    uint32_t EffectConstantStorage::Append(void* effect, bool vertex, uint32_t byteCount)
    {
        if (!byteCount)
            return 0;
        const size_t offset = (bytes.size() + alignment - 1) & ~(static_cast<size_t>(alignment) - 1);
        if (offset > std::numeric_limits<uint32_t>::max() - byteCount)
            throw std::overflow_error("Packet uniform storage exceeds Vulkan dynamic offset range");
        const size_t originalSize = bytes.size();
        bytes.resize(offset + byteCount);
        if (!CelesteSpirvCopyConstants(effect, vertex, bytes.data() + offset, byteCount))
        {
            bytes.resize(originalSize);
            throw std::runtime_error(CelesteSpirvGetError());
        }
        return static_cast<uint32_t>(offset);
    }
    uint32_t EffectConstantStorage::AppendBytes(const void* source, uint32_t byteCount)
    {
        if (!byteCount)
            return 0;
        const size_t offset = (bytes.size() + alignment - 1) & ~(static_cast<size_t>(alignment) - 1);
        if (!source || offset > std::numeric_limits<uint32_t>::max() - byteCount)
            throw std::invalid_argument("Invalid retained effect constants");
        bytes.resize(offset + byteCount);
        std::memcpy(bytes.data() + offset, source, byteCount);
        return static_cast<uint32_t>(offset);
    }
}
