#include "TextureResource.h"
#include <algorithm>
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    static D3D12_RESOURCE_DESC Describe(const CelesteGraphicsTextureInfo& info, uint32_t samples)
    {
        if (!info.width || !info.height || !info.depth || !info.levels || info.levels > UINT16_MAX ||
            info.dimension > CelesteGraphicsTextureCube || !samples || (samples & (samples - 1)))
            throw std::invalid_argument("Invalid texture dimensions or sample count");
        if (info.dimension != CelesteGraphicsTexture3D && info.depth != 1)
            throw std::invalid_argument("Only volume textures have depth");
        if (info.dimension == CelesteGraphicsTextureCube && info.width != info.height)
            throw std::invalid_argument("Cube faces must be square");
        uint32_t maximum = std::max({info.width, info.height, info.depth}), levels = 1;
        while (maximum > 1)
        {
            maximum >>= 1;
            ++levels;
        }
        if (info.levels > levels || info.depth > UINT16_MAX)
            throw std::invalid_argument("Texture mip or depth range invalid");
        if (samples > 1 && (!info.renderTarget || info.dimension != CelesteGraphicsTexture2D || info.levels != 1))
            throw std::invalid_argument("Multisample texture requires one 2D render-target level");
        const auto format = ResourceFormat::FromSource(info.sourceFormat);
        D3D12_RESOURCE_DESC result{};
        result.Dimension = info.dimension == CelesteGraphicsTexture3D ? D3D12_RESOURCE_DIMENSION_TEXTURE3D
                                                                      : D3D12_RESOURCE_DIMENSION_TEXTURE2D;
        result.Width = info.width;
        result.Height = info.height;
        result.DepthOrArraySize = static_cast<UINT16>(info.dimension == CelesteGraphicsTextureCube ? 6 : info.depth);
        result.MipLevels = static_cast<UINT16>(info.levels);
        result.Format = format.native;
        result.SampleDesc.Count = samples;
        result.Layout = D3D12_TEXTURE_LAYOUT_UNKNOWN;
        result.Flags = info.renderTarget ? D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET : D3D12_RESOURCE_FLAG_NONE;
        return result;
    }
    TextureResource::TextureResource(std::shared_ptr<DeviceContext> owner, const CelesteGraphicsTextureInfo& source,
                                     uint32_t samples)
        : GpuResource(std::move(owner), Describe(source, samples), D3D12_HEAP_TYPE_DEFAULT,
                      D3D12_RESOURCE_STATE_COMMON),
          info(source), format(ResourceFormat::FromSource(source.sourceFormat))
    {
    }
    uint32_t TextureResource::Subresource(uint32_t level, uint32_t layer) const
    {
        if (level >= info.levels || layer >= (info.dimension == CelesteGraphicsTextureCube ? 6u : 1u))
            throw std::out_of_range("Texture subresource outside texture");
        return level + layer * info.levels;
    }
    CelesteGraphicsTextureRegion TextureResource::Region(const CelesteGraphicsTextureRegion* requested) const
    {
        auto r =
            requested ? *requested : CelesteGraphicsTextureRegion{0, 0, 0, 0, 0, info.width, info.height, info.depth};
        Subresource(r.level, r.layer);
        const uint32_t w = std::max(1u, info.width >> r.level), h = std::max(1u, info.height >> r.level),
                       d = std::max(1u, info.depth >> r.level);
        if (!r.width || !r.height || !r.depth || r.x >= w || r.y >= h || r.z >= d || r.width > w - r.x ||
            r.height > h - r.y || r.depth > d - r.z)
            throw std::out_of_range("Texture region outside mip");
        if (r.x % format.blockWidth || r.y % format.blockHeight ||
            (r.width % format.blockWidth && r.x + r.width != w) ||
            (r.height % format.blockHeight && r.y + r.height != h))
            throw std::invalid_argument("Compressed region must align blocks except at mip edges");
        return r;
    }
    void TextureResource::CreateShaderView(D3D12_CPU_DESCRIPTOR_HANDLE destination) const
    {
        D3D12_SHADER_RESOURCE_VIEW_DESC view{};
        view.Format = format.native;
        view.Shader4ComponentMapping = D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING;
        if (description.SampleDesc.Count > 1)
            view.ViewDimension = D3D12_SRV_DIMENSION_TEXTURE2DMS;
        else if (info.dimension == CelesteGraphicsTextureCube)
        {
            view.ViewDimension = D3D12_SRV_DIMENSION_TEXTURECUBE;
            view.TextureCube.MipLevels = info.levels;
        }
        else if (info.dimension == CelesteGraphicsTexture3D)
        {
            view.ViewDimension = D3D12_SRV_DIMENSION_TEXTURE3D;
            view.Texture3D.MipLevels = info.levels;
        }
        else
        {
            view.ViewDimension = D3D12_SRV_DIMENSION_TEXTURE2D;
            view.Texture2D.MipLevels = info.levels;
        }
        context->device->CreateShaderResourceView(resource.Get(), &view, destination);
    }
    void TextureResource::CreateRenderView(D3D12_CPU_DESCRIPTOR_HANDLE destination, uint32_t level,
                                           uint32_t layer) const
    {
        Subresource(level, layer);
        if (!info.renderTarget)
            throw std::invalid_argument("Texture was not created as a render target");
        D3D12_RENDER_TARGET_VIEW_DESC view{};
        view.Format = format.native;
        if (description.SampleDesc.Count > 1)
            view.ViewDimension = D3D12_RTV_DIMENSION_TEXTURE2DMS;
        else if (info.dimension == CelesteGraphicsTextureCube)
        {
            view.ViewDimension = D3D12_RTV_DIMENSION_TEXTURE2DARRAY;
            view.Texture2DArray = {level, layer, 1, 0};
        }
        else if (info.dimension == CelesteGraphicsTexture3D)
        {
            view.ViewDimension = D3D12_RTV_DIMENSION_TEXTURE3D;
            view.Texture3D = {level, 0, std::max(1u, info.depth >> level)};
        }
        else
        {
            view.ViewDimension = D3D12_RTV_DIMENSION_TEXTURE2D;
            view.Texture2D.MipSlice = level;
        }
        context->device->CreateRenderTargetView(resource.Get(), &view, destination);
    }
}
