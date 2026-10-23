#pragma once
#include "Direct3D12SamplerBinding.h"
#include "Direct3D12TargetBinding.h"
#include "Direct3D12VertexBinding.h"
#include "DepthResource.h"
#include <array>
#include "InputLayout.h"
struct Direct3D12EffectSnapshot;
struct Direct3D12DrawState
{
    SourceNativeBlendState blend{};
    SourceNativeDepthStencilState depthState{};
    SourceNativeRasterizerState raster{};
    SourceCameraViewport viewport{0, 0, 0, 0, 0, 1};
    CelesteGraphicsRect scissor{};
    SourceNativePresentationParameters presentation{};
    std::shared_ptr<Celeste::Graphics::Direct3D12::TextureResource> backbuffer, backbufferMsaa;
    std::shared_ptr<Celeste::Graphics::Direct3D12::DepthResource> backbufferDepth, depth;
    SourceDepthFormat depthFormat = SourceDepthFormat_None;
    std::vector<Direct3D12TargetBinding> targets;
    std::vector<Direct3D12VertexBinding> vertices;
    std::shared_ptr<const Celeste::Graphics::Direct3D12::InputLayout> input =
        std::make_shared<Celeste::Graphics::Direct3D12::InputLayout>();
    std::array<Direct3D12SamplerBinding, 32> samplers;
    std::shared_ptr<Direct3D12EffectSnapshot> effect;
    bool usesBackbuffer = true;
    Direct3D12DrawState();
};
