#pragma once
#include "GpuResource.h"
#include "CelesteGraphicsBackend.h"
namespace Celeste::Graphics::Direct3D12
{
    class DepthResource final : public GpuResource
    {
      public:
        DepthResource(std::shared_ptr<DeviceContext>, uint32_t width, uint32_t height, SourceDepthFormat,
                      uint32_t samples = 1);
        void CreateDepthView(D3D12_CPU_DESCRIPTOR_HANDLE destination) const;
    };
}
