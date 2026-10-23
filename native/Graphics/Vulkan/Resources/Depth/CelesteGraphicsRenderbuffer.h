#pragma once
#include "DepthStencilAttachment.h"
#include "TextureImage.h"
struct CelesteGraphicsDevice;
struct CelesteGraphicsRenderbuffer final
{
    CelesteGraphicsDevice* device;
    std::shared_ptr<Celeste::Graphics::Vulkan::DepthStencilAttachment> depth;
    std::shared_ptr<Celeste::Graphics::Vulkan::TextureImage> color;
};
