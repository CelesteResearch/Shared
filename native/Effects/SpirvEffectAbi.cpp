#include "SpirvEffectAbi.h"
#include "LinkedSpirvProgram.h"
#include "SpirvConstants.h"
#include <memory>
#include <stdexcept>
#include <string>
using namespace Celeste::Graphics::Effects;
namespace
{
    thread_local std::string error;
    thread_local const char* fallbackError = nullptr;
    void SetError(const char* message) noexcept
    {
        fallbackError = "SPIR-V frontend failed; error text unavailable";
        try
        {
            error = message ? message : "Unknown SPIR-V frontend error";
            fallbackError = nullptr;
        }
        catch (...)
        {
        }
    }
    struct Program
    {
        LinkedSpirvProgram binary;
        std::string vertexEntry, pixelEntry;
        struct VertexSemantic
        {
            int32_t usage, index;
        };
        std::vector<VertexSemantic> vertexSemantics;
    };
    template <class T> int Run(T&& action) noexcept
    {
        try
        {
            action();
            error.clear();
            fallbackError = nullptr;
            return 1;
        }
        catch (const std::exception& e)
        {
            SetError(e.what());
            return 0;
        }
        catch (...)
        {
            SetError("Unknown SPIR-V frontend error");
            return 0;
        }
    }
    void Require(int success)
    {
        if (!success)
            throw std::runtime_error(CelesteEffectGetError());
    }
}
const char* CE_CALL CelesteSpirvGetError()
{
    return fallbackError ? fallbackError : error.c_str();
}
int CE_CALL CelesteSpirvCreateProgram(void* vertexShader, void* pixelShader,
                                      const CelesteSpirvVertexAttribute* attributes, int32_t count, void** program)
{
    return Run([&] {
        if (!program)
            throw std::invalid_argument("Program output required");
        *program = nullptr;
        if (count < 0 || (count && !attributes))
            throw std::invalid_argument("Attributes required");
        CelesteEffectShaderDescription vertex{}, pixel{};
        Require(CelesteEffectGetShaderDescription(vertexShader, &vertex));
        Require(CelesteEffectGetShaderDescription(pixelShader, &pixel));
        std::vector<MOJOSHADER_vertexAttribute> layout;
        layout.reserve(count);
        for (int i = 0; i < count; ++i)
            layout.push_back({static_cast<MOJOSHADER_usage>(attributes[i].usage),
                              static_cast<MOJOSHADER_vertexElementFormat>(attributes[i].format),
                              attributes[i].usageIndex});
        auto result = std::make_unique<Program>();
        result->binary =
            LinkedSpirvProgram::Create(*static_cast<const ShaderDescription*>(vertex.identity),
                                       *static_cast<const ShaderDescription*>(pixel.identity), layout.data(), count);
        // SPIR-V locations are the parseData attribute order, not the caller's declaration order.
        const auto* inputs = static_cast<const MOJOSHADER_attribute*>(vertex.attributes);
        result->vertexSemantics.reserve(vertex.attributeCount);
        for (int i = 0; i < vertex.attributeCount; ++i)
            result->vertexSemantics.push_back({static_cast<int32_t>(inputs[i].usage), inputs[i].index});
        result->vertexEntry = vertex.outputEntryPoint;
        result->pixelEntry = pixel.outputEntryPoint;
        *program = result.release();
    });
}
int CE_CALL CelesteSpirvGetBinary(void* program, int vertex, CelesteSpirvBinaryView* view)
{
    return Run([&] {
        if (!program || !view)
            throw std::invalid_argument("Program and binary view required");
        const auto& owner = *static_cast<const Program*>(program);
        const auto& words = vertex ? owner.binary.vertex : owner.binary.pixel;
        *view = {words.data(), static_cast<uint32_t>(words.size() * sizeof(uint32_t)),
                 (vertex ? owner.vertexEntry : owner.pixelEntry).c_str()};
    });
}
void CE_CALL CelesteSpirvDestroyProgram(void* program)
{
    delete static_cast<Program*>(program);
}
int CE_CALL CelesteSpirvCopyConstants(void* effect, int vertex, void* destination, uint32_t capacityBytes)
{
    return Run([&] {
        CelesteEffectRegisterView source{};
        Require(CelesteEffectBorrowRegisters(effect, &source));
        auto shader = static_cast<const ShaderDescription*>(vertex ? source.vertexIdentity : source.pixelIdentity);
        if (!shader)
            return;
        RegisterView view{static_cast<const ShaderDescription*>(source.vertexIdentity),
                          static_cast<const ShaderDescription*>(source.pixelIdentity),
                          source.vertexFloat,
                          source.pixelFloat,
                          source.vertexInt,
                          source.pixelInt,
                          source.vertexBool,
                          source.pixelBool};
        CopySpirvConstants(*shader, view, vertex != 0, destination, capacityBytes);
    });
}

int CE_CALL CelesteSpirvGetVertexLocation(void* program, int32_t usage, int32_t usageIndex, int32_t* location)
{
    return Run([&] {
        if (!program || !location)
            throw std::invalid_argument("Program and location output required");
        *location = -1;
        const auto& semantics = static_cast<const Program*>(program)->vertexSemantics;
        for (size_t i = 0; i < semantics.size(); ++i)
            if (semantics[i].usage == usage && semantics[i].index == usageIndex)
            {
                *location = static_cast<int32_t>(i);
                return;
            }
    });
}
