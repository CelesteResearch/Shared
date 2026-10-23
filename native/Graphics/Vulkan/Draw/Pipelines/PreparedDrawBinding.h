#pragma once
#include "SpritePipeline.h"
#include "DrawLogicalState.h"
namespace Celeste::Graphics::Vulkan
{
    struct PreparedDrawBinding
    {
        const DrawLogicalState* logical;
        const void* program;
        VkPrimitiveTopology topology;
        std::shared_ptr<SpritePipeline> pipeline;
    };
}
