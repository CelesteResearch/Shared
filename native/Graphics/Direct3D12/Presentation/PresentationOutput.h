#pragma once
#include "CelesteGraphicsDirect3D12.h"
#include "TextureResource.h"
#include <wrl/client.h>
namespace Celeste::Graphics::Direct3D12
{
    struct PresentationOutput
    {
        Microsoft::WRL::ComPtr<ID3D12Resource> resource;
        CelesteDirect3D12OutputInfo info{};
        std::shared_ptr<TextureResource> texture;
    };
}
