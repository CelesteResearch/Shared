#pragma once
#include "CelesteGraphicsBackend.h"
#include "TransferBuffer.h"
#include <memory>
struct CelesteGraphicsBuffer final
{
    CelesteGraphicsDevice* device;
    std::shared_ptr<Celeste::Graphics::Vulkan::TransferBuffer> buffer;
    bool index;
    bool dynamic;
    SourceBufferUsage usage;
};
