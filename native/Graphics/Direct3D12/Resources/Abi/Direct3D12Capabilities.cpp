#include "Direct3D12ResourceApi.h"
#include "CelesteGraphicsDevice.h"
#include "TextureCopy.h"
#include <stdexcept>
namespace Celeste::Graphics::Direct3D12
{
    static D3D12_FORMAT_SUPPORT1 Support(CelesteGraphicsDevice* device, DXGI_FORMAT format)
    {
        D3D12_FEATURE_DATA_FORMAT_SUPPORT support{format, D3D12_FORMAT_SUPPORT1_NONE, D3D12_FORMAT_SUPPORT2_NONE};
        CheckResult(
            device->Resources()->device->CheckFeatureSupport(D3D12_FEATURE_FORMAT_SUPPORT, &support, sizeof(support)),
            "Query format support");
        return support.Support1;
    }
    void GetCapabilities(CelesteGraphicsDevice* device, CelesteGraphicsCapabilities* result)
    {
        if (!device || !result)
            throw std::invalid_argument("Invalid capability query");
        *result = {};
        result->noOverwrite = 1;
        result->hardwareInstancing = 1;
        result->fragmentTextureSlots = 16;
        result->vertexTextureSlots = 4;
        result->dxt1 = (Support(device, DXGI_FORMAT_BC1_UNORM) & D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE) != 0;
        result->s3tc = result->dxt1 && (Support(device, DXGI_FORMAT_BC2_UNORM) & D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE) &&
                       (Support(device, DXGI_FORMAT_BC3_UNORM) & D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE);
        result->srgbRenderTargets =
            (Support(device, DXGI_FORMAT_R8G8B8A8_UNORM_SRGB) & D3D12_FORMAT_SUPPORT1_RENDER_TARGET) != 0;
    }
    void GetMaxMultiSampleCount(CelesteGraphicsDevice* device, SourceSurfaceFormat source, int32_t preferred,
                                int32_t* result)
    {
        if (!device || !result || preferred < 0)
            throw std::invalid_argument("Invalid multisample query");
        *result = 0;
        const auto format = ResourceFormat::FromSource(source);
        if (!preferred || !(Support(device, format.native) & D3D12_FORMAT_SUPPORT1_RENDER_TARGET))
            return;
        *result = static_cast<int32_t>(
            SupportedSampleCount(*device->Resources(), format.native, static_cast<uint32_t>(preferred)));
    }
}
