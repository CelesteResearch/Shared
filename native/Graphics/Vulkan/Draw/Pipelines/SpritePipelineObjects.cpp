#include "SpritePipelineObjects.h"
namespace Celeste::Graphics::Vulkan
{
    SpritePipelineObjects::~SpritePipelineObjects()
    {
        const auto device = context->native.device;
#define DESTROY(name, handle) if (handle) reinterpret_cast<PFN_vk##name>(context->native.getDeviceProcAddr(device, "vk" #name))(device, handle, nullptr)
        DESTROY(DestroyPipeline, pipeline);
        DESTROY(DestroyRenderPass, renderPass);
        DESTROY(DestroyPipelineLayout, layout);
        for (auto value : setLayouts)
        {
            DESTROY(DestroyDescriptorSetLayout, value);
        }
        for (auto value : shaders)
        {
            DESTROY(DestroyShaderModule, value);
        }
#undef DESTROY
    }
}
