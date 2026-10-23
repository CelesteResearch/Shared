#pragma once
#include "PresentationBinding.h"
namespace Celeste::Graphics::Direct3D12
{
    struct MipGenerationStep
    {
        uint32_t sourceSubresource, destinationSubresource;
        std::shared_ptr<PresentationBinding> pass;
    };
    struct MipGenerationPlan
    {
        std::shared_ptr<TextureResource> image;
        std::vector<MipGenerationStep> steps;
    };
}
