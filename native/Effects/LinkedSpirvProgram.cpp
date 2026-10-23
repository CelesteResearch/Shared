#include "LinkedSpirvProgram.h"
#include <cstring>
#include <stdexcept>

namespace Celeste::Graphics::Effects
{
    namespace
    {
        std::vector<uint32_t> CopyOutput(const ShaderDescription& shader, MOJOSHADER_shaderType stage)
        {
            if (shader.profile != "spirv" || !shader.parsed || shader.parsed->shader_type != stage ||
                !shader.parsed->output || shader.parsed->output_len <= 0 ||
                shader.parsed->output_len % sizeof(uint32_t) != 0)
                throw std::invalid_argument("A parsed spirv shader of the requested stage is required");
            std::vector<uint32_t> result(shader.parsed->output_len / sizeof(uint32_t));
            std::memcpy(result.data(), shader.parsed->output, shader.parsed->output_len);
            if (result.front() != 0x07230203u)
                throw std::invalid_argument("SPIR-V magic is missing");
            return result;
        }
    }

    LinkedSpirvProgram LinkedSpirvProgram::Create(const ShaderDescription& vertexShader,
                                                  const ShaderDescription& pixelShader,
                                                  const MOJOSHADER_vertexAttribute* attributes, int count)
    {
        if (count < 0 || (count && !attributes))
            throw std::invalid_argument("Vertex attributes are required");
        // The pinned linker indexes usage[MOJOSHADER_USAGE_TOTAL][16] directly.
        for (int i = 0; i < count; ++i)
            if (attributes[i].usage < MOJOSHADER_USAGE_POSITION || attributes[i].usage > MOJOSHADER_USAGE_SAMPLE ||
                attributes[i].usageIndex < 0 || attributes[i].usageIndex >= 16)
                throw std::invalid_argument("Vertex usage is outside the linker patch table");
        LinkedSpirvProgram result{CopyOutput(vertexShader, MOJOSHADER_TYPE_VERTEX),
                                  CopyOutput(pixelShader, MOJOSHADER_TYPE_PIXEL)};
        auto vertex = *vertexShader.parsed;
        auto pixel = *pixelShader.parsed;
        vertex.output = reinterpret_cast<const char*>(result.vertex.data());
        pixel.output = reinterpret_cast<const char*>(result.pixel.data());
        int tableBytes = MOJOSHADER_linkSPIRVShaders(&vertex, &pixel, attributes, count);
        if (tableBytes <= 0 || tableBytes % sizeof(uint32_t) || tableBytes >= vertex.output_len ||
            tableBytes >= pixel.output_len)
            throw std::runtime_error("The SPIR-V linker returned an invalid patch table size");
        result.vertex.resize((vertex.output_len - tableBytes) / sizeof(uint32_t));
        result.pixel.resize((pixel.output_len - tableBytes) / sizeof(uint32_t));
        return result;
    }

}
