#pragma once
#include "PresentationBinding.h"
#include <unordered_map>
#include <unordered_set>
#include <vector>
namespace Celeste::Graphics::Direct3D12
{
    class PresentationContext
    {
        std::shared_ptr<DeviceContext> context;
        Microsoft::WRL::ComPtr<ID3D12RootSignature> roots[2];
        std::unordered_map<uint64_t, std::shared_ptr<PresentationPipeline>> pipelines;
        std::vector<std::shared_ptr<PresentationDescriptors>> descriptors;
        std::unordered_set<int> filterableFormats;
        std::shared_ptr<PresentationPipeline> Pipeline(DXGI_FORMAT, bool linear = false, bool arraySource = false);
        std::shared_ptr<PresentationBinding> Binding(DXGI_FORMAT, bool linear, bool arraySource);

      public:
        explicit PresentationContext(std::shared_ptr<DeviceContext>);
        std::shared_ptr<PresentationBinding> Prepare(std::shared_ptr<TextureResource>,
                                                     const CelesteDirect3D12OutputInfo&, const CelesteGraphicsRect&,
                                                     const CelesteGraphicsRect&);
        std::shared_ptr<PresentationBinding> PrepareSample(std::shared_ptr<TextureResource> source, uint32_t sourceMip,
                                                           uint32_t sourceLayer,
                                                           std::shared_ptr<TextureResource> target, uint32_t targetMip,
                                                           uint32_t targetLayer, bool linear = true);
    };
}
