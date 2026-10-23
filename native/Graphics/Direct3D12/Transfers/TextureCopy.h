#pragma once
#include "TextureResource.h"
#include "ResourceStateTransaction.h"
namespace Celeste::Graphics::Direct3D12
{
    void CopyTexture(CommandLease&, ResourceStateTransaction&, TextureResource& source, TextureResource& destination);
    void ResolveTexture(CommandLease&, ResourceStateTransaction&, TextureResource& source, TextureResource& destination,
                        uint32_t destinationLevel = 0, uint32_t destinationLayer = 0);
    uint32_t SupportedSampleCount(const DeviceContext&, DXGI_FORMAT, uint32_t preferred);
}
