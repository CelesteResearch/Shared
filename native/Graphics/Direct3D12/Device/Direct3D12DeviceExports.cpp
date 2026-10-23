#include "CelesteGraphicsDevice.h"
#include "CelesteGraphicsOutput.h"
#include "CelesteGraphicsTexture.h"
#include "Direct3D12ApiErrors.h"
#include "DirectQueueExecutor.h"
#include <algorithm>
#include <stdexcept>
using namespace Celeste::Graphics::Direct3D12;
namespace Celeste::Graphics::Direct3D12
{
    thread_local std::string lastError;
}
extern "C"
{
    const char* CELESTE_GRAPHICS_CALL CelesteDirect3D12GetLastError()
    {
        return lastError.c_str();
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CreateOwnedDevice(const CelesteDirect3D12OwnedDeviceInfo* info,
                                                                     CelesteGraphicsDevice** result)
    {
        return Invoke([&] {
            if (!result)
                throw std::invalid_argument("Missing device output");
            *result = nullptr;
            auto device = std::make_unique<CelesteGraphicsDevice>();
            device->context = DeviceContext::CreateOwned(info ? info->adapter : nullptr,
                                                         info && info->minimumFeatureLevel ? info->minimumFeatureLevel
                                                                                           : D3D_FEATURE_LEVEL_11_0);
            auto executor = std::make_shared<DirectQueueExecutor>(device->context);
            device->submissions = SubmissionQueue::Create(device->context, executor);
            *result = device.release();
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CreateBorrowedDevice(const CelesteDirect3D12BorrowedDeviceInfo* info,
                                                                        CelesteGraphicsDevice** result)
    {
        return Invoke([&] {
            if (!result || !info)
                throw std::invalid_argument("Missing borrowed device info");
            *result = nullptr;
            auto device = std::make_unique<CelesteGraphicsDevice>();
            device->context = DeviceContext::Borrow(info->device);
            device->host = true;
            device->submissions = SubmissionQueue::Create(device->context, nullptr);
            *result = device.release();
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12GetNativeDevice(CelesteGraphicsDevice* device, ID3D12Device** result)
    {
        return Invoke([&] {
            if (!device || !result)
                throw std::invalid_argument("Missing native device query");
            *result = device->context->device.Get();
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12AcquireOutput(CelesteGraphicsDevice* device,
                                                                 const CelesteDirect3D12OutputInfo* info,
                                                                 CelesteGraphicsOutput** result)
    {
        return Invoke([&] {
            if (!device || !info || !result || !info->resource)
                throw std::invalid_argument("Missing output info");
            *result = nullptr;
            Microsoft::WRL::ComPtr<ID3D12Device> actual;
            CheckResult(info->resource->GetDevice(IID_PPV_ARGS(&actual)), "Output GetDevice");
            auto desc = info->resource->GetDesc();
            if (actual.Get() != device->context->device.Get() || desc.Dimension != D3D12_RESOURCE_DIMENSION_TEXTURE2D ||
                desc.SampleDesc.Count != 1 || info->format != desc.Format ||
                info->subresource >= uint32_t(desc.MipLevels) * desc.DepthOrArraySize)
                throw std::invalid_argument("Output texture device, format or subresource differs");
            auto mip = info->subresource % desc.MipLevels;
            if (info->width != std::max<uint64_t>(1, desc.Width >> mip) ||
                info->height != std::max<uint32_t>(1, desc.Height >> mip))
                throw std::invalid_argument("Output extent differs");
            auto output = std::make_unique<CelesteGraphicsOutput>();
            output->device = device;
            output->resource = info->resource;
            output->info = *info;
            *result = output.release();
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12AcquireTextureOutput(CelesteGraphicsDevice* device,
                                                                        CelesteGraphicsTexture* texture,
                                                                        CelesteGraphicsOutput** result)
    {
        return Invoke([&] {
            if (result)
                *result = nullptr;
            if (!device || !texture || !result || texture->device != device ||
                texture->image->info.dimension != CelesteGraphicsTexture2D ||
                texture->image->description.SampleDesc.Count != 1 || !texture->image->info.renderTarget)
                throw std::invalid_argument("Offscreen output requires a same-device resolved 2D render texture");
            auto output = std::make_unique<CelesteGraphicsOutput>();
            output->device = device;
            output->texture = texture->image;
            output->resource = texture->image->resource;
            output->info = {output->resource.Get(),        0,
                            texture->image->info.width,    texture->image->info.height,
                            texture->image->format.native, D3D12_RESOURCE_STATE_COMMON,
                            D3D12_RESOURCE_STATE_COMMON};
            *result = output.release();
        });
    }
}
