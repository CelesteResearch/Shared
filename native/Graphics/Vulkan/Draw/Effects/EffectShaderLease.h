#pragma once
#include "EffectFrontendAbi.h"

namespace Celeste::Graphics::Vulkan
{
    class EffectShaderLease final
    {
        void* handle = nullptr;

      public:
        CelesteEffectShaderDescription description{};
        EffectShaderLease(void* effect, bool vertex);
        ~EffectShaderLease();
        EffectShaderLease(const EffectShaderLease&) = delete;
        EffectShaderLease& operator=(const EffectShaderLease&) = delete;
        void* Handle() const noexcept
        {
            return handle;
        }
    };
}
