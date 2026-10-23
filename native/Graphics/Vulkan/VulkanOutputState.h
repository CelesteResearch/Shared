#pragma once
#include "CelesteGraphicsVulkan.h"
#include "TextureImage.h"
#include <memory>
struct VulkanOutputState final
{
    CelesteGraphicsDevice* device;
    CelesteVulkanOutputInfo info;
    std::shared_ptr<Celeste::Graphics::Vulkan::TextureImage> texture;
    bool submitted = false;
};
