#pragma once
#include "BufferResource.h"
#include "CelesteGraphicsBackend.h"
struct CelesteGraphicsBuffer
{
    CelesteGraphicsDevice* device;
    std::shared_ptr<Celeste::Graphics::Direct3D12::BufferResource> buffer;
    bool index, dynamic;
    SourceBufferUsage usage;
};
