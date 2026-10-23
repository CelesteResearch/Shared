#include "EffectFrontend.h"
#include <array>
#include <algorithm>
#include <stdexcept>
#include <utility>

namespace Celeste::Graphics::Effects
{
    // Same register capacities as the pinned Mojo D3D11 implementation.
    struct RegisterFile
    {
        std::array<float, 8192 * 4> floats{};
        std::array<int, 2047 * 4> ints{};
        std::array<unsigned char, 2047> bools{};
    };

    struct CpuShader
    {
        unsigned int references = 1;
        ShaderDescription description;
    };

    struct EffectContext
    {
        std::string profile;
        std::string error;
        CpuShader* vertex = nullptr;
        CpuShader* pixel = nullptr;
        RegisterFile vertexRegisters, pixelRegisters;
        Effect* active = nullptr;
        ~EffectContext();
    };

    ShaderDescription::~ShaderDescription()
    {
        if (parsed)
            MOJOSHADER_freeParseData(parsed);
    }

    static void MOJOSHADERCALL AddReference(void* handle)
    {
        if (handle)
            ++static_cast<CpuShader*>(handle)->references;
    }

    static void MOJOSHADERCALL DeleteShader(const void*, void* handle)
    {
        auto shader = static_cast<CpuShader*>(handle);
        if (shader && --shader->references == 0)
            delete shader;
    }

    EffectContext::~EffectContext()
    {
        DeleteShader(nullptr, vertex);
        DeleteShader(nullptr, pixel);
    }

    static void* MOJOSHADERCALL CompileShader(const void* opaque, const char* entry, const unsigned char* tokens,
                                              unsigned int length, const MOJOSHADER_swizzle* swizzles,
                                              unsigned int swizzleCount, const MOJOSHADER_samplerMap* samplerMap,
                                              unsigned int samplerCount)
    {
        auto& context = *const_cast<EffectContext*>(static_cast<const EffectContext*>(opaque));
        try
        {
            auto shader = std::make_unique<CpuShader>();
            auto& desc = shader->description;
            desc.profile = context.profile;
            desc.entryPoint = entry;
            desc.tokens.assign(tokens, tokens + length);
            if (swizzleCount)
                desc.swizzles.assign(swizzles, swizzles + swizzleCount);
            if (samplerCount)
                desc.samplerMap.assign(samplerMap, samplerMap + samplerCount);
            desc.parsed = MOJOSHADER_parse(desc.profile.c_str(), desc.entryPoint.c_str(), desc.tokens.data(), length,
                                           desc.swizzles.data(), swizzleCount, desc.samplerMap.data(), samplerCount,
                                           nullptr, nullptr, nullptr);
            if (!desc.parsed || desc.parsed->error_count)
            {
                context.error = desc.parsed && desc.parsed->error_count ? desc.parsed->errors[0].error
                                                                        : "Shader parse allocation failed";
                return nullptr;
            }
            // A malformed register mapping must not write past the CPU arrays.
            for (int i = 0; i < desc.parsed->uniform_count; ++i)
            {
                const auto& uniform = desc.parsed->uniforms[i];
                const int limit = uniform.type == MOJOSHADER_UNIFORM_FLOAT ? 8192 : 2047;
                if (uniform.index < 0 || uniform.index > limit - std::max(1, uniform.array_count))
                {
                    context.error = "Shader uniform exceeds Mojo register capacity";
                    return nullptr;
                }
                if (!uniform.constant)
                {
                    desc.packing.push_back(
                        {uniform.type, uniform.index, std::max(1, uniform.array_count), desc.constantBufferBytes});
                    desc.constantBufferBytes += std::max(1, uniform.array_count) * 16;
                    const int end = uniform.index + std::max(1, uniform.array_count);
                    if (uniform.type == MOJOSHADER_UNIFORM_FLOAT)
                        desc.floatCount = std::max(desc.floatCount, end * 4);
                    else if (uniform.type == MOJOSHADER_UNIFORM_INT)
                        desc.intCount = std::max(desc.intCount, end * 4);
                    else
                        desc.boolCount = std::max(desc.boolCount, end);
                }
            }
            return shader.release();
        }
        catch (const std::exception& error)
        {
            context.error = error.what();
            return nullptr;
        }
    }

    static MOJOSHADER_parseData* MOJOSHADERCALL ParseData(void* shader)
    {
        return shader ? const_cast<MOJOSHADER_parseData*>(static_cast<CpuShader*>(shader)->description.parsed)
                      : nullptr;
    }

    static void MOJOSHADERCALL Bind(const void* opaque, void* vertex, void* pixel)
    {
        auto& context = *const_cast<EffectContext*>(static_cast<const EffectContext*>(opaque));
        if (vertex)
        {
            AddReference(vertex);
            DeleteShader(nullptr, context.vertex);
            context.vertex = static_cast<CpuShader*>(vertex);
        }
        if (pixel)
        {
            AddReference(pixel);
            DeleteShader(nullptr, context.pixel);
            context.pixel = static_cast<CpuShader*>(pixel);
        }
    }

    static void MOJOSHADERCALL GetBound(const void* opaque, void** vertex, void** pixel)
    {
        const auto& context = *static_cast<const EffectContext*>(opaque);
        *vertex = context.vertex;
        *pixel = context.pixel;
    }

    static void MOJOSHADERCALL Map(const void* opaque, float** vf, int** vi, unsigned char** vb, float** pf, int** pi,
                                   unsigned char** pb)
    {
        auto& context = *const_cast<EffectContext*>(static_cast<const EffectContext*>(opaque));
        *vf = context.vertexRegisters.floats.data();
        *vi = context.vertexRegisters.ints.data();
        *vb = context.vertexRegisters.bools.data();
        *pf = context.pixelRegisters.floats.data();
        *pi = context.pixelRegisters.ints.data();
        *pb = context.pixelRegisters.bools.data();
    }

    static void MOJOSHADERCALL Unmap(const void*)
    {
    }
    static const char* MOJOSHADERCALL GetError(const void* opaque)
    {
        return static_cast<const EffectContext*>(opaque)->error.c_str();
    }

    EffectFrontend::EffectFrontend(std::string profile) : context(std::make_shared<EffectContext>())
    {
        context->profile = std::move(profile);
    }

    std::unique_ptr<Effect> EffectFrontend::Compile(const unsigned char* code, unsigned int length) const
    {
        MOJOSHADER_effectShaderContext callbacks{};
        callbacks.shaderContext = context.get();
        callbacks.compileShader = CompileShader;
        callbacks.shaderAddRef = AddReference;
        callbacks.deleteShader = DeleteShader;
        callbacks.getParseData = ParseData;
        callbacks.bindShaders = Bind;
        callbacks.getBoundShaders = GetBound;
        callbacks.mapUniformBufferMemory = Map;
        callbacks.unmapUniformBufferMemory = Unmap;
        callbacks.getError = GetError;
        auto parsed = MOJOSHADER_compileEffect(code, length, nullptr, 0, nullptr, 0, &callbacks);
        if (!parsed || parsed->error_count)
        {
            const std::string error =
                parsed && parsed->error_count ? parsed->errors[0].error : "Effect allocation failed";
            // Pinned Mojo also returns static error sentinels without an allocator.
            // deleteEffect only exempts its OOM sentinel; do not free the others.
            if (parsed && parsed->ctx.f)
                MOJOSHADER_deleteEffect(parsed);
            throw std::runtime_error(error);
        }
        try
        {
            return std::unique_ptr<Effect>(new Effect(context, parsed));
        }
        catch (...)
        {
            MOJOSHADER_deleteEffect(parsed);
            throw;
        }
    }

    Effect::Effect(std::shared_ptr<EffectContext> context, MOJOSHADER_effect* data)
        : context(std::move(context)), data(data)
    {
    }

    Effect::~Effect()
    {
        End();
        MOJOSHADER_deleteEffect(data);
    }

    std::unique_ptr<Effect> Effect::Clone() const
    {
        auto cloned = MOJOSHADER_cloneEffect(data);
        if (!cloned)
            throw std::runtime_error("Effect clone allocation failed");
        try
        {
            return std::unique_ptr<Effect>(new Effect(context, cloned));
        }
        catch (...)
        {
            MOJOSHADER_deleteEffect(cloned);
            throw;
        }
    }

    void Effect::SetTechnique(unsigned int technique)
    {
        if (technique >= static_cast<unsigned int>(data->technique_count))
            throw std::out_of_range("Effect technique");
        MOJOSHADER_effectSetTechnique(data, &data->techniques[technique]);
    }

    const MOJOSHADER_effectStateChanges& Effect::Apply(unsigned int pass)
    {
        if (pass >= data->current_technique->pass_count)
            throw std::out_of_range("Effect pass");
        if (context->active != this)
        {
            if (context->active)
                context->active->End();
            unsigned int passes;
            MOJOSHADER_effectBegin(data, &passes, 0, &changes);
            context->active = this;
            MOJOSHADER_effectBeginPass(data, pass);
        }
        else if (appliedTechnique != data->current_technique || data->current_pass != static_cast<int>(pass))
        {
            MOJOSHADER_effectEndPass(data);
            MOJOSHADER_effectBeginPass(data, pass);
        }
        else
            MOJOSHADER_effectCommitChanges(data);
        appliedTechnique = data->current_technique;
        return changes;
    }

    void Effect::End()
    {
        if (context->active != this)
            return;
        MOJOSHADER_effectEndPass(data);
        MOJOSHADER_effectEnd(data);
        context->active = nullptr;
        appliedTechnique = nullptr;
    }

    static std::shared_ptr<const ShaderDescription> Lease(CpuShader* shader)
    {
        if (!shader)
            return {};
        AddReference(shader);
        return std::shared_ptr<const ShaderDescription>(
            &shader->description, [shader](const ShaderDescription*) { DeleteShader(nullptr, shader); });
    }

    std::vector<std::shared_ptr<const ShaderDescription>> Effect::Shaders() const
    {
        std::vector<std::shared_ptr<const ShaderDescription>> result;
        for (int i = 0; i < data->object_count; ++i)
        {
            const auto& object = data->objects[i];
            if ((object.type == MOJOSHADER_SYMTYPE_VERTEXSHADER || object.type == MOJOSHADER_SYMTYPE_PIXELSHADER) &&
                !object.shader.is_preshader && object.shader.shader)
                result.push_back(Lease(static_cast<CpuShader*>(object.shader.shader)));
        }
        return result;
    }

    static void CaptureStage(CpuShader* shader, const RegisterFile& file, std::vector<float>& floats,
                             std::vector<int>& ints, std::vector<unsigned char>& bools)
    {
        if (!shader)
            return;
        int floatCount = 0, intCount = 0, boolCount = 0;
        const auto parsed = shader->description.parsed;
        for (int i = 0; i < parsed->uniform_count; ++i)
        {
            const auto& uniform = parsed->uniforms[i];
            if (uniform.constant)
                continue;
            const int end = uniform.index + std::max(1, uniform.array_count);
            if (uniform.type == MOJOSHADER_UNIFORM_FLOAT)
                floatCount = std::max(floatCount, end * 4);
            else if (uniform.type == MOJOSHADER_UNIFORM_INT)
                intCount = std::max(intCount, end * 4);
            else
                boolCount = std::max(boolCount, end);
        }
        floats.assign(file.floats.begin(), file.floats.begin() + floatCount);
        ints.assign(file.ints.begin(), file.ints.begin() + intCount);
        bools.assign(file.bools.begin(), file.bools.begin() + boolCount);
    }

    RegisterSnapshot Effect::Capture() const
    {
        if (context->active != this)
            throw std::logic_error("Effect is not applied");
        RegisterSnapshot result;
        result.vertex = Lease(context->vertex);
        result.pixel = Lease(context->pixel);
        CaptureStage(context->vertex, context->vertexRegisters, result.vertexFloat, result.vertexInt,
                     result.vertexBool);
        CaptureStage(context->pixel, context->pixelRegisters, result.pixelFloat, result.pixelInt, result.pixelBool);
        return result;
    }

    RegisterView Effect::BorrowRegisters() const
    {
        if (context->active != this)
            throw std::logic_error("Effect is not applied");
        return {context->vertex ? &context->vertex->description : nullptr,
                context->pixel ? &context->pixel->description : nullptr,
                context->vertexRegisters.floats.data(),
                context->pixelRegisters.floats.data(),
                context->vertexRegisters.ints.data(),
                context->pixelRegisters.ints.data(),
                context->vertexRegisters.bools.data(),
                context->pixelRegisters.bools.data()};
    }

    std::shared_ptr<const ShaderDescription> Effect::RetainBoundShader(bool vertex) const
    {
        if (context->active != this)
            throw std::logic_error("Effect is not applied");
        return Lease(vertex ? context->vertex : context->pixel);
    }
}
