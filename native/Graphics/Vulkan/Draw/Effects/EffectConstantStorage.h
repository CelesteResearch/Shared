#pragma once
#include <cstdint>
#include <vector>

namespace Celeste::Graphics::Vulkan
{
    // Packet-owned CPU snapshots. One prepare-phase upload covers all Apply calls.
    class EffectConstantStorage final
    {
        uint32_t alignment;
        std::vector<uint8_t> bytes;

      public:
        explicit EffectConstantStorage(uint32_t uniformAlignment);
        uint32_t Append(void* effect, bool vertex, uint32_t byteCount);
        uint32_t AppendBytes(const void* source, uint32_t byteCount);
        const std::vector<uint8_t>& Bytes() const noexcept
        {
            return bytes;
        }
    };
}
