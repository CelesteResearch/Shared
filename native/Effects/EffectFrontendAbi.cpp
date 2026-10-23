#include "EffectFrontendAbi.h"
#include "EffectFrontend.h"
#include <cstring>
#include <stdexcept>

using namespace Celeste::Graphics::Effects;
namespace
{
#if defined(__EMSCRIPTEN__) && !defined(__EMSCRIPTEN_PTHREADS__)
    // A single-thread Wasm module has one error owner and no TLS destructor service.
    static std::string lastError;
#else
    thread_local std::string lastError;
#endif
    struct EffectHandle
    {
        std::unique_ptr<Effect> effect;
        std::vector<std::shared_ptr<const ShaderDescription>> shaders;
        explicit EffectHandle(std::unique_ptr<Effect> source) : effect(std::move(source)), shaders(effect->Shaders())
        {
        }
    };
    using ShaderHandle = std::shared_ptr<const ShaderDescription>;
    struct PassShaders
    {
        bool assigned = false, selector = false, retained = false;
        std::vector<ShaderHandle> shaders;
    };
    PassShaders DescribePassShaders(EffectHandle& owner, uint32_t technique, uint32_t pass, bool vertex)
    {
        const auto meta = owner.effect->Metadata();
        if (technique >= static_cast<uint32_t>(meta->technique_count))
            throw std::out_of_range("Technique index");
        const auto& tech = meta->techniques[technique];
        if (pass >= tech.pass_count)
            throw std::out_of_range("Pass index");
        const auto& source = tech.passes[pass];
        const MOJOSHADER_effectState* selected = nullptr;
        for (uint32_t i = 0; i < source.state_count; i++)
            if (source.states[i].type == (vertex ? MOJOSHADER_RS_VERTEXSHADER : MOJOSHADER_RS_PIXELSHADER))
                selected = &source.states[i]; // BeginPass uses the last assignment.
        PassShaders result;
        if (!selected)
        {
            result.retained = true;
            return result;
        }
        result.assigned = true;
        const auto object = [&](int index) -> const MOJOSHADER_effectShader& {
            if (index < 0 || static_cast<uint32_t>(index) >= static_cast<uint32_t>(meta->object_count))
                throw std::invalid_argument("Pass shader object index");
            const auto& value = meta->objects[index];
            if (value.type != (vertex ? MOJOSHADER_SYMTYPE_VERTEXSHADER : MOJOSHADER_SYMTYPE_PIXELSHADER))
                throw std::invalid_argument("Pass shader stage mismatch");
            return value.shader;
        };
        const auto add = [&](int index) {
            const auto& shader = object(index);
            if (shader.is_preshader)
                throw std::invalid_argument("Nested pass shader selector");
            if (!shader.shader)
            {
                result.retained = true;
                return;
            }
            size_t ordinal = 0;
            for (int i = 0; i < index; i++)
                if ((meta->objects[i].type == MOJOSHADER_SYMTYPE_VERTEXSHADER ||
                     meta->objects[i].type == MOJOSHADER_SYMTYPE_PIXELSHADER) &&
                    !meta->objects[i].shader.is_preshader && meta->objects[i].shader.shader)
                    ++ordinal;
            const auto& description = owner.shaders.at(ordinal);
            for (const auto& existing : result.shaders)
                if (existing == description)
                    return;
            result.shaders.push_back(description);
        };
        if (!selected->value.valuesI)
            throw std::invalid_argument("Pass shader assignment required");
        const auto& raw = object(selected->value.valuesI[0]);
        result.selector = raw.is_preshader != 0;
        if (!result.selector)
            add(selected->value.valuesI[0]);
        else
        {
            // CommitChanges selects from this original object array; do not evaluate default parameters.
            if (!raw.params || raw.param_count == 0 || raw.params[0] >= static_cast<uint32_t>(meta->param_count))
                throw std::invalid_argument("Pass shader selector array parameter");
            const auto& choices = meta->params[raw.params[0]].value;
            if (!choices.valuesI || choices.value_count == 0)
                throw std::invalid_argument("Pass shader selector choices required");
            for (uint32_t i = 0; i < choices.value_count; i++)
                add(choices.valuesI[i]);
        }
        return result;
    }
    template <class F> int Run(F&& operation)
    {
        try
        {
            operation();
            return 1;
        }
        catch (const std::exception& error)
        {
            lastError = error.what();
            return 0;
        }
        catch (...)
        {
            lastError = "Unknown effect frontend failure";
            return 0;
        }
    }
    EffectHandle& Handle(void* handle)
    {
        if (!handle)
            throw std::invalid_argument("Null effect handle");
        return *static_cast<EffectHandle*>(handle);
    }
    void Outputs(void** effect, void** metadata)
    {
        if (!effect || !metadata)
            throw std::invalid_argument("Effect outputs required");
        *effect = *metadata = nullptr;
    }
    CelesteEffectRegisterView View(Effect& effect)
    {
        const auto view = effect.BorrowRegisters();
        return {view.vertex,      view.pixel,
                view.vertexFloat, view.vertex ? static_cast<uint32_t>(view.vertex->floatCount) : 0,
                view.pixelFloat,  view.pixel ? static_cast<uint32_t>(view.pixel->floatCount) : 0,
                view.vertexInt,   view.vertex ? static_cast<uint32_t>(view.vertex->intCount) : 0,
                view.pixelInt,    view.pixel ? static_cast<uint32_t>(view.pixel->intCount) : 0,
                view.vertexBool,  view.vertex ? static_cast<uint32_t>(view.vertex->boolCount) : 0,
                view.pixelBool,   view.pixel ? static_cast<uint32_t>(view.pixel->boolCount) : 0};
    }
    template <class T> void Capacity(const T* pointer, uint32_t capacity, uint32_t needed)
    {
        if (capacity < needed || (needed && !pointer))
            throw std::invalid_argument("Register target capacity");
    }
    template <class T> void Copy(const T* source, const T* target, uint32_t count)
    {
        if (count)
            std::memcpy(const_cast<T*>(target), source, sizeof(T) * count);
    }
}

const char* CE_CALL CelesteEffectGetError()
{
    return lastError.c_str();
}
int CE_CALL CelesteEffectFrontendCreate(const char* profile, void** frontend)
{
    return Run([&] {
        if (!profile || !frontend)
            throw std::invalid_argument("Profile/frontend output required");
        *frontend = nullptr;
        *frontend = new EffectFrontend(profile);
    });
}
void CE_CALL CelesteEffectFrontendDestroy(void* frontend)
{
    delete static_cast<EffectFrontend*>(frontend);
}
int CE_CALL CelesteEffectCreate(void* frontend, const unsigned char* code, uint32_t length, void** effect,
                                void** metadata)
{
    return Run([&] {
        Outputs(effect, metadata);
        if (!frontend || !code)
            throw std::invalid_argument("Frontend/code required");
        auto owned = std::make_unique<EffectHandle>(static_cast<EffectFrontend*>(frontend)->Compile(code, length));
        *metadata = owned->effect->Metadata();
        *effect = owned.release();
    });
}
int CE_CALL CelesteEffectClone(void* source, void** effect, void** metadata)
{
    return Run([&] {
        Outputs(effect, metadata);
        auto owned = std::make_unique<EffectHandle>(Handle(source).effect->Clone());
        *metadata = owned->effect->Metadata();
        *effect = owned.release();
    });
}
void CE_CALL CelesteEffectDestroy(void* effect)
{
    delete static_cast<EffectHandle*>(effect);
}
int CE_CALL CelesteEffectSetTechnique(void* effect, const void* technique)
{
    return Run([&] {
        auto& owned = Handle(effect);
        const auto meta = owned.effect->Metadata();
        for (int i = 0; i < meta->technique_count; ++i)
            if (&meta->techniques[i] == technique)
            {
                owned.effect->SetTechnique(i);
                return;
            }
        throw std::invalid_argument("Technique does not belong to effect");
    });
}
int CE_CALL CelesteEffectApply(void* effect, uint32_t pass, void* stateChanges)
{
    return Run([&] {
        if (!stateChanges)
            throw std::invalid_argument("State-change output required");
        *static_cast<MOJOSHADER_effectStateChanges*>(stateChanges) = Handle(effect).effect->Apply(pass);
    });
}
int CE_CALL CelesteEffectGetTechniqueCount(void* effect, uint32_t* count)
{
    return Run([&] {
        if (!count)
            throw std::invalid_argument("Technique count output required");
        *count = Handle(effect).effect->Metadata()->technique_count;
    });
}
int CE_CALL CelesteEffectGetTechnique(void* effect, uint32_t index, const void** technique, uint32_t* passCount)
{
    return Run([&] {
        if (!technique || !passCount)
            throw std::invalid_argument("Technique outputs required");
        const auto meta = Handle(effect).effect->Metadata();
        if (index >= static_cast<uint32_t>(meta->technique_count))
            throw std::out_of_range("Technique index");
        *technique = &meta->techniques[index];
        *passCount = meta->techniques[index].pass_count;
    });
}
int CE_CALL CelesteEffectGetPassStageFlags(void* effect, uint32_t technique, uint32_t pass, uint32_t* flags)
{
    return Run([&] {
        if (!flags)
            throw std::invalid_argument("Pass flags output required");
        auto& owner = Handle(effect);
        const auto vertex = DescribePassShaders(owner, technique, pass, true);
        const auto pixel = DescribePassShaders(owner, technique, pass, false);
        *flags = (vertex.assigned ? 1u : 0u) | (pixel.assigned ? 2u : 0u) | (vertex.selector ? 4u : 0u) |
                 (pixel.selector ? 8u : 0u) | (vertex.retained ? 16u : 0u) | (pixel.retained ? 32u : 0u);
    });
}
int CE_CALL CelesteEffectGetPassShaderCount(void* effect, uint32_t technique, uint32_t pass, int vertex,
                                            uint32_t* count)
{
    return Run([&] {
        if (!count)
            throw std::invalid_argument("Pass shader count output required");
        *count =
            static_cast<uint32_t>(DescribePassShaders(Handle(effect), technique, pass, vertex != 0).shaders.size());
    });
}
int CE_CALL CelesteEffectAcquirePassShader(void* effect, uint32_t technique, uint32_t pass, int vertex, uint32_t index,
                                           void** shader)
{
    return Run([&] {
        if (!shader)
            throw std::invalid_argument("Pass shader lease output required");
        *shader = nullptr;
        const auto choices = DescribePassShaders(Handle(effect), technique, pass, vertex != 0);
        if (index >= choices.shaders.size())
            throw std::out_of_range("Pass shader index");
        *shader = new ShaderHandle(choices.shaders[index]);
    });
}
int CE_CALL CelesteEffectGetShaderCount(void* effect, uint32_t* count)
{
    return Run([&] {
        if (!count)
            throw std::invalid_argument("Shader-count output required");
        *count = static_cast<uint32_t>(Handle(effect).shaders.size());
    });
}
int CE_CALL CelesteEffectAcquireShader(void* effect, uint32_t index, void** shader)
{
    return Run([&] {
        if (!shader)
            throw std::invalid_argument("Shader output required");
        *shader = nullptr;
        *shader = new ShaderHandle(Handle(effect).shaders.at(index));
    });
}
int CE_CALL CelesteEffectAcquireBoundShader(void* effect, int vertex, void** shader)
{
    return Run([&] {
        if (!shader)
            throw std::invalid_argument("Shader output required");
        *shader = nullptr;
        auto owned = Handle(effect).effect->RetainBoundShader(vertex != 0);
        if (owned)
            *shader = new ShaderHandle(std::move(owned));
    });
}
int CE_CALL CelesteEffectGetShaderDescription(void* shader, CelesteEffectShaderDescription* output)
{
    return Run([&] {
        if (!shader || !output)
            throw std::invalid_argument("Shader/description required");
        const auto& desc = **static_cast<ShaderHandle*>(shader);
        *output = {desc.profile.c_str(),
                   desc.entryPoint.c_str(),
                   desc.tokens.data(),
                   static_cast<uint32_t>(desc.tokens.size()),
                   desc.swizzles.data(),
                   static_cast<uint32_t>(desc.swizzles.size()),
                   desc.samplerMap.data(),
                   static_cast<uint32_t>(desc.samplerMap.size()),
                   desc.parsed,
                   desc.floatCount,
                   desc.intCount,
                   desc.boolCount,
                   desc.parsed->shader_type,
                   desc.parsed->output,
                   desc.parsed->output_len,
                   desc.parsed->mainfn,
                   desc.parsed->uniforms,
                   desc.parsed->uniform_count,
                   desc.parsed->samplers,
                   desc.parsed->sampler_count,
                   desc.parsed->attributes,
                   desc.parsed->attribute_count,
                   desc.parsed->outputs,
                   desc.parsed->output_count,
                   &desc,
                   desc.packing.data(),
                   static_cast<int32_t>(desc.packing.size()),
                   desc.constantBufferBytes};
    });
}
void CE_CALL CelesteEffectReleaseShader(void* shader)
{
    delete static_cast<ShaderHandle*>(shader);
}
int CE_CALL CelesteEffectBorrowRegisters(void* effect, CelesteEffectRegisterView* view)
{
    return Run([&] {
        if (!view)
            throw std::invalid_argument("Register view required");
        *view = View(*Handle(effect).effect);
    });
}
int CE_CALL CelesteEffectCopyRegisters(void* effect, const CelesteEffectRegisterView* target)
{
    return Run([&] {
        if (!target)
            throw std::invalid_argument("Register target required");
        const auto source = View(*Handle(effect).effect);
        Capacity(target->vertexFloat, target->vertexFloatCount, source.vertexFloatCount);
        Capacity(target->pixelFloat, target->pixelFloatCount, source.pixelFloatCount);
        Capacity(target->vertexInt, target->vertexIntCount, source.vertexIntCount);
        Capacity(target->pixelInt, target->pixelIntCount, source.pixelIntCount);
        Capacity(target->vertexBool, target->vertexBoolCount, source.vertexBoolCount);
        Capacity(target->pixelBool, target->pixelBoolCount, source.pixelBoolCount);
        Copy(source.vertexFloat, target->vertexFloat, source.vertexFloatCount);
        Copy(source.pixelFloat, target->pixelFloat, source.pixelFloatCount);
        Copy(source.vertexInt, target->vertexInt, source.vertexIntCount);
        Copy(source.pixelInt, target->pixelInt, source.pixelIntCount);
        Copy(source.vertexBool, target->vertexBool, source.vertexBoolCount);
        Copy(source.pixelBool, target->pixelBool, source.pixelBoolCount);
    });
}
int CE_CALL CelesteEffectCopyHlslConstants(void* effect, int vertex, void* target, uint32_t capacityBytes)
{
    return Run([&] {
        const auto view = Handle(effect).effect->BorrowRegisters();
        const auto desc = vertex ? view.vertex : view.pixel;
        if (!desc)
            return;
        if (desc->profile != "hlsl")
            throw std::invalid_argument("HLSL constant packing requires hlsl profile");
        Capacity(static_cast<unsigned char*>(target), capacityBytes, static_cast<uint32_t>(desc->constantBufferBytes));
        const auto floats = vertex ? view.vertexFloat : view.pixelFloat;
        const auto ints = vertex ? view.vertexInt : view.pixelInt;
        const auto bools = vertex ? view.vertexBool : view.pixelBool;
        auto bytes = static_cast<unsigned char*>(target);
        for (const auto& item : desc->packing)
        {
            auto destination = bytes + item.byteOffset;
            const auto length = static_cast<size_t>(item.registerCount) * 16;
            if (item.type == MOJOSHADER_UNIFORM_FLOAT)
                std::memcpy(destination, floats + 4 * item.registerIndex, length);
            else if (item.type == MOJOSHADER_UNIFORM_INT)
                std::memcpy(destination, ints + 4 * item.registerIndex, length);
            else
                for (int j = 0; j < item.registerCount; ++j)
                {
                    const int packed[4] = {bools[item.registerIndex + j], 0, 0, 0};
                    std::memcpy(destination + j * 16, packed, sizeof(packed));
                }
        }
    });
}
