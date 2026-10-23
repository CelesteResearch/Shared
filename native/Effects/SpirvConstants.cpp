#include "SpirvConstants.h"
#include <cstring>
#include <stdexcept>
namespace Celeste::Graphics::Effects
{
    void CopySpirvConstants(const ShaderDescription& shader, const RegisterView& registers, bool vertex,
                            void* destination, size_t capacityBytes)
    {
        if (shader.profile != "spirv" || (vertex ? registers.vertex : registers.pixel) != &shader)
            throw std::invalid_argument("SPIR-V registers must belong to the bound shader");
        if (capacityBytes < static_cast<size_t>(shader.constantBufferBytes) ||
            (shader.constantBufferBytes && !destination))
            throw std::invalid_argument("SPIR-V uniform buffer is too small");
        auto floats = vertex ? registers.vertexFloat : registers.pixelFloat;
        auto ints = vertex ? registers.vertexInt : registers.pixelInt;
        auto bools = vertex ? registers.vertexBool : registers.pixelBool;
        auto bytes = static_cast<unsigned char*>(destination);
        for (const auto& item : shader.packing)
        {
            auto target = bytes + item.byteOffset;
            size_t length = static_cast<size_t>(item.registerCount) * 16;
            if (item.type == MOJOSHADER_UNIFORM_FLOAT)
                std::memcpy(target, floats + item.registerIndex * 4, length);
            else if (item.type == MOJOSHADER_UNIFORM_INT)
                std::memcpy(target, ints + item.registerIndex * 4, length);
            else
                for (int i = 0; i < item.registerCount; ++i)
                {
                    const int32_t value[4] = {bools[item.registerIndex + i], 0, 0, 0};
                    std::memcpy(target + i * 16, value, sizeof(value));
                }
        }
    }
}
