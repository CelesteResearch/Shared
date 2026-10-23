#pragma once
#include "CelesteGraphicsSourceTypes.h"
#include "ResourceContext.h"
namespace Celeste::Graphics::Vulkan
{
    VkPipelineDepthStencilStateCreateInfo ConvertDepthStencil(const SourceNativeDepthStencilState& value);
}
