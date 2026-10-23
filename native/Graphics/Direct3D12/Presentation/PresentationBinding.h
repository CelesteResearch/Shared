#pragma once
#include "PresentationPipeline.h"
#include "PresentationDescriptors.h"
#include "TextureResource.h"
#include "CelesteGraphicsDirect3D12.h"
namespace Celeste::Graphics::Direct3D12
{
    struct PresentationBinding
    {
        std::shared_ptr<PresentationDescriptors> descriptors;
        std::shared_ptr<PresentationPipeline> pipeline;
        std::shared_ptr<TextureResource> source;
        Microsoft::WRL::ComPtr<ID3D12Resource> output;
        CelesteDirect3D12OutputInfo info{};
        D3D12_VIEWPORT viewport{};
        D3D12_RECT scissor{};
        float uv[4]{};
        void Record(ID3D12GraphicsCommandList*) const noexcept;
        // Caller owns resource transitions. Used by mip generation as well as presentation.
        void Draw(ID3D12GraphicsCommandList*) const noexcept;
    };
}
