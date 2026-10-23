#include "TextureCopy.h"
#include <algorithm>
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    void CopyTexture(CommandLease& lease, ResourceStateTransaction& states, TextureResource& source,
                     TextureResource& destination)
    {
        if (&source == &destination || source.description.Dimension != destination.description.Dimension ||
            source.description.Width != destination.description.Width ||
            source.description.Height != destination.description.Height ||
            source.description.DepthOrArraySize != destination.description.DepthOrArraySize ||
            source.description.MipLevels != destination.description.MipLevels ||
            source.description.Format != destination.description.Format ||
            source.description.SampleDesc.Count != destination.description.SampleDesc.Count)
            throw std::invalid_argument("Texture copy requires distinct matching resources");
        states.TransitionAll(source, D3D12_RESOURCE_STATE_COPY_SOURCE);
        states.TransitionAll(destination, D3D12_RESOURCE_STATE_COPY_DEST);
        lease.List()->CopyResource(destination.resource.Get(), source.resource.Get());
    }
    void ResolveTexture(CommandLease& lease, ResourceStateTransaction& states, TextureResource& source,
                        TextureResource& destination, uint32_t level, uint32_t layer)
    {
        const uint32_t subresource = destination.Subresource(level, layer);
        if (source.description.SampleDesc.Count <= 1 || destination.description.SampleDesc.Count != 1 ||
            source.info.width != std::max(1u, destination.info.width >> level) ||
            source.info.height != std::max(1u, destination.info.height >> level) ||
            source.format.native != destination.format.native || destination.info.dimension == CelesteGraphicsTexture3D)
            throw std::invalid_argument("Invalid multisample resolve");
        states.Transition(source, 0, D3D12_RESOURCE_STATE_RESOLVE_SOURCE);
        states.Transition(destination, subresource, D3D12_RESOURCE_STATE_RESOLVE_DEST);
        lease.List()->ResolveSubresource(destination.resource.Get(), subresource, source.resource.Get(), 0,
                                         source.format.native);
    }
    uint32_t SupportedSampleCount(const DeviceContext& context, DXGI_FORMAT format, uint32_t preferred)
    {
        while (preferred > 1)
        {
            if (preferred & (preferred - 1))
            {
                preferred >>= 1;
                continue;
            }
            D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS support{format, preferred,
                                                                  D3D12_MULTISAMPLE_QUALITY_LEVELS_FLAG_NONE, 0};
            CheckResult(context.device->CheckFeatureSupport(D3D12_FEATURE_MULTISAMPLE_QUALITY_LEVELS, &support,
                                                            sizeof(support)),
                        "Query multisample support");
            if (support.NumQualityLevels)
                return preferred;
            preferred >>= 1;
        }
        return 1;
    }
}
