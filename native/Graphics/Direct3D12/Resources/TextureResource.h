#pragma once
#include "GpuResource.h"
#include "ResourceFormat.h"
namespace Celeste::Graphics::Direct3D12
{
    class TextureResource final : public GpuResource
    {
      public:
        const CelesteGraphicsTextureInfo info;
        const ResourceFormat format;
        TextureResource(std::shared_ptr<DeviceContext>, const CelesteGraphicsTextureInfo&, uint32_t samples = 1);
        uint32_t Subresource(uint32_t level, uint32_t layer) const;
        CelesteGraphicsTextureRegion Region(const CelesteGraphicsTextureRegion* region) const;
        void CreateShaderView(D3D12_CPU_DESCRIPTOR_HANDLE destination) const;
        void CreateRenderView(D3D12_CPU_DESCRIPTOR_HANDLE destination, uint32_t level = 0, uint32_t layer = 0) const;
    };
}
