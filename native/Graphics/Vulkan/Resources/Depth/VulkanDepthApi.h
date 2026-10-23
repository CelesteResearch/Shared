#pragma once
#include "CelesteGraphicsBackend.h"
namespace Celeste::Graphics::Vulkan
{
    void CreateDepthRenderbuffer(CelesteGraphicsDevice*, int32_t width, int32_t height, SourceDepthFormat,
                                 int32_t samples, CelesteGraphicsRenderbuffer**);
    void ReleaseRenderbuffer(CelesteGraphicsRenderbuffer*) noexcept;
}
