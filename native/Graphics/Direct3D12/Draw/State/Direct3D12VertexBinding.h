#pragma once
#include "BufferResource.h"
#include "CelesteGraphicsBackend.h"
struct Direct3D12VertexBinding
{
    std::shared_ptr<Celeste::Graphics::Direct3D12::BufferResource> buffer;
    uint32_t stride = 0, offset = 0, frequency = 0;
    std::vector<SourceVertexElement> elements;
};
