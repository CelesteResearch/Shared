#pragma once
#include "Direct3D12PreparedTargets.h"
#include "PipelineObjects.h"
#include "DynamicState.h"
struct Direct3D12PreparedDraw
{
    Direct3D12PreparedTargets targets;
    std::shared_ptr<Celeste::Graphics::Direct3D12::PipelineObjects> pipeline;
    std::shared_ptr<Celeste::Graphics::Direct3D12::BindingBatch> bindings;
    std::array<D3D12_VERTEX_BUFFER_VIEW, 32> vertices{};
    std::array<std::shared_ptr<Celeste::Graphics::Direct3D12::BufferResource>, 32> vertexResources;
    uint32_t vertexCount = 0;
    std::array<std::shared_ptr<Celeste::Graphics::Direct3D12::TextureResource>, 32> sampled;
    uint32_t sampledCount = 0;
    std::shared_ptr<Celeste::Graphics::Direct3D12::BufferResource> indexResource;
    D3D12_INDEX_BUFFER_VIEW index{};
    std::array<D3D12_GPU_VIRTUAL_ADDRESS, 2> constants{};
    Celeste::Graphics::Direct3D12::DescriptorRange views, samplers;
    Celeste::Graphics::Direct3D12::DynamicState dynamic;
    D3D12_VIEWPORT viewport{};
    D3D12_RECT scissor{};
};
