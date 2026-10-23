#include "Direct3D12Shaders.h"
#include <mojoshader.h>
#include <cstring>
#include <stdexcept>
#include <cctype>
namespace Celeste::Graphics::Direct3D12
{
    static const char* IntegerType(DXGI_FORMAT format)
    {
        switch (format)
        {
#define FORMATS(suffix, result) \
        case DXGI_FORMAT_R32G32B32A32_##suffix: case DXGI_FORMAT_R32G32B32_##suffix: \
        case DXGI_FORMAT_R16G16B16A16_##suffix: case DXGI_FORMAT_R32G32_##suffix: \
        case DXGI_FORMAT_R8G8B8A8_##suffix: case DXGI_FORMAT_R16G16_##suffix: \
        case DXGI_FORMAT_R32_##suffix: case DXGI_FORMAT_R8G8_##suffix: \
        case DXGI_FORMAT_R16_##suffix: case DXGI_FORMAT_R8_##suffix: return result;
            FORMATS(UINT, "uint4")
            FORMATS(SINT, "int4")
#undef FORMATS
        case DXGI_FORMAT_R10G10B10A2_UINT:
            return "uint4";
        default:
            return nullptr;
        }
    }
    // Pinned Mojo HLSL emits flat Input/Output structs. Accept its CRLF and LF output.
    static std::pair<size_t, size_t> Body(const std::string& source, const char* suffix)
    {
        auto name = source.find(suffix);
        if (name == std::string::npos)
            throw std::runtime_error("Missing Mojo HLSL interface struct");
        auto begin = source.find('{', name), end = source.find('}', begin);
        if (begin == std::string::npos || end == std::string::npos)
            throw std::runtime_error("Incomplete Mojo HLSL interface struct");
        return {begin + 1, end};
    }
    static bool Identifier(char c)
    {
        return std::isalnum(static_cast<unsigned char>(c)) || c == '_';
    }
    static void Rename(std::string& text, const std::string& from, const std::string& to)
    {
        for (size_t at = 0; (at = text.find(from, at)) != std::string::npos;)
        {
            auto end = at + from.size();
            if ((at == 0 || !std::isalnum(static_cast<unsigned char>(text[at - 1]))) &&
                (end == text.size() || !std::isalnum(static_cast<unsigned char>(text[end]))))
            {
                text.replace(at, from.size(), to);
                at += to.size();
            }
            else
                at = end;
        }
    }
    static const MOJOSHADER_parseData& Parsed(const CelesteEffectShaderDescription& shader, int stage)
    {
        if (!shader.profile || std::strcmp(shader.profile, "hlsl") || !shader.parsed || shader.stage != stage)
            throw std::invalid_argument("A matching stage from an HLSL Effects frontend is required");
        return *static_cast<const MOJOSHADER_parseData*>(shader.parsed);
    }
    PreparedShaders PrepareShaders(const CelesteEffectShaderDescription& vertex,
                                   const CelesteEffectShaderDescription& pixel,
                                   const D3D12_INPUT_ELEMENT_DESC* elements, size_t count)
    {
        const auto& vs = Parsed(vertex, MOJOSHADER_TYPE_VERTEX);
        const auto& ps = Parsed(pixel, MOJOSHADER_TYPE_PIXEL);
        PreparedShaders result;
        result.vertexSource.assign(vs.output, vs.output_len);
        result.pixelSource.assign(ps.output, ps.output_len);
        result.vertexEntry = vs.mainfn;
        result.pixelEntry = ps.mainfn;
        if (count)
        {
            auto input = Body(result.vertexSource, "_Input");
            std::string fields = result.vertexSource.substr(input.first, input.second - input.first);
            for (size_t i = 0; i < count; i++)
            {
                auto type = IntegerType(elements[i].Format);
                if (!type)
                    continue;
                std::string semantic = elements[i].SemanticName;
                if (semantic != "POSITIONT")
                    semantic += std::to_string(elements[i].SemanticIndex);
                size_t at = 0;
                for (;;)
                {
                    at = fields.find(semantic, at);
                    if (at == std::string::npos)
                        throw std::runtime_error("Integer vertex semantic missing in Mojo HLSL input");
                    auto end = at + semantic.size();
                    if ((at == 0 || !Identifier(fields[at - 1])) && (end == fields.size() || !Identifier(fields[end])))
                        break;
                    at = end;
                }
                auto line = fields.rfind(';', at);
                line = line == std::string::npos ? 0 : line + 1;
                auto scalar = fields.find("float4", line);
                if (scalar == std::string::npos || scalar > at)
                    throw std::runtime_error("Unexpected Mojo integer input signature");
                fields.replace(scalar, 6, type);
            }
            result.vertexSource.replace(input.first, input.second - input.first, fields);
        }
        if (ps.attribute_count > 0)
        {
            auto output = Body(result.vertexSource, "_Output");
            auto pin = Body(result.pixelSource, "_Input");
            auto tail = result.pixelSource.substr(pin.second);
            bool face = false;
            // Same semantic link as pinned mojoshader_d3d11.c; no effect/pass reevaluation.
            for (int i = 0; i < ps.attribute_count; i++)
            {
                const auto& attribute = ps.attributes[i];
                if (std::strcmp(attribute.name, "vFace") == 0)
                {
                    face = true;
                    continue;
                }
                const char* name = nullptr;
                for (int j = 0; j < vs.output_count; j++)
                    if ((attribute.usage == vs.outputs[j].usage && attribute.index == vs.outputs[j].index) ||
                        (std::strcmp(attribute.name, "vPos") == 0 && vs.outputs[j].usage == MOJOSHADER_USAGE_POSITION &&
                         vs.outputs[j].index == 0))
                    {
                        name = vs.outputs[j].name;
                        break;
                    }
                if (!name)
                    throw std::runtime_error("Pixel input has no matching vertex output");
                if (std::strcmp(attribute.name, name))
                    Rename(tail, attribute.name, name);
            }
            result.pixelSource = result.pixelSource.substr(0, pin.first) +
                                 result.vertexSource.substr(output.first, output.second - output.first) +
                                 (face ? "\n bool m_vFace : SV_IsFrontFace;\n" : "") + tail;
        }
        // Full owning content key: shader/declaration identity cannot collide or outlive a lease.
        for (const auto* part : {&result.vertexSource, &result.pixelSource, &result.vertexEntry, &result.pixelEntry})
        {
            result.cacheKey += std::to_string(part->size());
            result.cacheKey += ':';
            result.cacheKey += *part;
        }
        return result;
    }
    static Microsoft::WRL::ComPtr<ID3DBlob> Compile(const std::string& source, const std::string& entry,
                                                    const char* profile)
    {
        Microsoft::WRL::ComPtr<ID3DBlob> code, error;
        // Pinned D3D11 disables optimization because optimized Mojo HLSL can render incorrectly.
        auto status = D3DCompile(source.data(), source.size(), nullptr, nullptr, nullptr, entry.c_str(), profile,
                                 D3DCOMPILE_SKIP_OPTIMIZATION, 0, &code, &error);
        if (FAILED(status))
            throw std::runtime_error(
                error ? std::string(static_cast<const char*>(error->GetBufferPointer()), error->GetBufferSize())
                      : "D3DCompile failed");
        return code;
    }
    CompiledShaders CompileShaders(const PreparedShaders& shaders)
    {
        return {Compile(shaders.vertexSource, shaders.vertexEntry, "vs_5_1"),
                Compile(shaders.pixelSource, shaders.pixelEntry, "ps_5_1")};
    }
}
