#include "DepthResource.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    static D3D12_RESOURCE_DESC DescribeDepth(uint32_t width, uint32_t height, SourceDepthFormat format,
                                             uint32_t samples)
    {
        if (!width || !height || !samples || (samples & (samples - 1)))
            throw std::invalid_argument("Invalid depth extent or samples");
        DXGI_FORMAT native;
        switch (format)
        {
        case SourceDepthFormat_Depth16:
            native = DXGI_FORMAT_D16_UNORM;
            break;
        case SourceDepthFormat_Depth24:
            native = DXGI_FORMAT_D32_FLOAT;
            break;
        case SourceDepthFormat_Depth24Stencil8:
            native = DXGI_FORMAT_D24_UNORM_S8_UINT;
            break;
        default:
            throw std::invalid_argument("Invalid source depth format");
        }
        D3D12_RESOURCE_DESC result{};
        result.Dimension = D3D12_RESOURCE_DIMENSION_TEXTURE2D;
        result.Width = width;
        result.Height = height;
        result.DepthOrArraySize = 1;
        result.MipLevels = 1;
        result.Format = native;
        result.SampleDesc.Count = samples;
        result.Flags = D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL | D3D12_RESOURCE_FLAG_DENY_SHADER_RESOURCE;
        return result;
    }
    DepthResource::DepthResource(std::shared_ptr<DeviceContext> owner, uint32_t width, uint32_t height,
                                 SourceDepthFormat format, uint32_t samples)
        : GpuResource(std::move(owner), DescribeDepth(width, height, format, samples), D3D12_HEAP_TYPE_DEFAULT,
                      D3D12_RESOURCE_STATE_DEPTH_WRITE)
    {
    }
    void DepthResource::CreateDepthView(D3D12_CPU_DESCRIPTOR_HANDLE destination) const
    {
        D3D12_DEPTH_STENCIL_VIEW_DESC view{};
        view.Format = description.Format;
        view.ViewDimension =
            description.SampleDesc.Count > 1 ? D3D12_DSV_DIMENSION_TEXTURE2DMS : D3D12_DSV_DIMENSION_TEXTURE2D;
        context->device->CreateDepthStencilView(resource.Get(), &view, destination);
    }
}
