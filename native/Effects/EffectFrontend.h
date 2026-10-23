#pragma once
#include <mojoshader.h>
#include <cstdint>
#include <memory>
#include <string>
#include <vector>

namespace Celeste::Graphics::Effects
{
    struct UniformPacking
    {
        int type, registerIndex, registerCount, byteOffset;
    };
    struct ShaderDescription
    {
        std::string profile;
        std::string entryPoint;
        std::vector<unsigned char> tokens;
        std::vector<MOJOSHADER_swizzle> swizzles;
        std::vector<MOJOSHADER_samplerMap> samplerMap;
        const MOJOSHADER_parseData* parsed = nullptr;
        int floatCount = 0, intCount = 0, boolCount = 0;
        std::vector<UniformPacking> packing;
        int constantBufferBytes = 0;
        ~ShaderDescription();
        ShaderDescription() = default;
        ShaderDescription(const ShaderDescription&) = delete;
        ShaderDescription& operator=(const ShaderDescription&) = delete;
    };

    struct RegisterSnapshot
    {
        std::shared_ptr<const ShaderDescription> vertex;
        std::shared_ptr<const ShaderDescription> pixel;
        std::vector<float> vertexFloat, pixelFloat;
        std::vector<int> vertexInt, pixelInt;
        std::vector<unsigned char> vertexBool, pixelBool;
    };

    struct RegisterView
    {
        const ShaderDescription* vertex;
        const ShaderDescription* pixel;
        const float* vertexFloat;
        const float* pixelFloat;
        const int* vertexInt;
        const int* pixelInt;
        const unsigned char* vertexBool;
        const unsigned char* pixelBool;
    };

    struct EffectContext;
    class Effect;

    class EffectFrontend
    {
      public:
        explicit EffectFrontend(std::string profile);
        std::unique_ptr<Effect> Compile(const unsigned char* code, unsigned int length) const;

      private:
        std::shared_ptr<EffectContext> context;
    };

    class Effect
    {
      public:
        ~Effect();
        Effect(const Effect&) = delete;
        Effect& operator=(const Effect&) = delete;
        MOJOSHADER_effect* Metadata() const noexcept
        {
            return data;
        }
        std::vector<std::shared_ptr<const ShaderDescription>> Shaders() const;
        std::unique_ptr<Effect> Clone() const;
        void SetTechnique(unsigned int technique);
        // Borrowed changes/metadata remain owned by this effect. No GPU resources exist.
        const MOJOSHADER_effectStateChanges& Apply(unsigned int pass);
        RegisterSnapshot Capture() const;
        RegisterView BorrowRegisters() const;
        std::shared_ptr<const ShaderDescription> RetainBoundShader(bool vertex) const;
        void End();

      private:
        friend class EffectFrontend;
        Effect(std::shared_ptr<EffectContext> context, MOJOSHADER_effect* data);
        std::shared_ptr<EffectContext> context;
        MOJOSHADER_effect* data;
        MOJOSHADER_effectStateChanges changes{};
        const MOJOSHADER_effectTechnique* appliedTechnique = nullptr;
    };
}
