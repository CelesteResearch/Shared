#include "GpuResource.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    GpuResource::GpuResource(std::shared_ptr<DeviceContext> owner, const D3D12_RESOURCE_DESC& desc,
                             D3D12_HEAP_TYPE heap, D3D12_RESOURCE_STATES initial, const D3D12_CLEAR_VALUE* clear)
        : context(std::move(owner)), description(desc)
    {
        if (!context || !context->device)
            throw std::invalid_argument("Resource requires a device");
        uint32_t count = 1;
        if (desc.Dimension != D3D12_RESOURCE_DIMENSION_BUFFER)
        {
            D3D12_FEATURE_DATA_FORMAT_INFO info{desc.Format, 0};
            CheckResult(context->device->CheckFeatureSupport(D3D12_FEATURE_FORMAT_INFO, &info, sizeof(info)),
                        "Query format planes");
            count = desc.MipLevels *
                    (desc.Dimension == D3D12_RESOURCE_DIMENSION_TEXTURE3D ? 1u : desc.DepthOrArraySize) *
                    info.PlaneCount;
        }
        states.assign(count, initial);
        D3D12_HEAP_PROPERTIES properties{};
        properties.Type = heap;
        properties.CreationNodeMask = properties.VisibleNodeMask = 1;
        CheckResult(context->device->CreateCommittedResource(&properties, D3D12_HEAP_FLAG_NONE, &description, initial,
                                                             clear, IID_PPV_ARGS(&resource)),
                    "CreateCommittedResource");
    }
}
