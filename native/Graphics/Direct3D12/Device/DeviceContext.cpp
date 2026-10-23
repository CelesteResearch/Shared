#include "DeviceContext.h"
#include <stdexcept>
#include <string>
namespace Celeste::Graphics::Direct3D12
{
    void CheckResult(HRESULT result, const char* operation)
    {
        if (FAILED(result))
            throw std::runtime_error(std::string(operation) + ": HRESULT " +
                                     std::to_string(static_cast<uint32_t>(result)));
    }
    std::shared_ptr<DeviceContext> DeviceContext::CreateOwned(IDXGIAdapter* adapter, D3D_FEATURE_LEVEL minimum)
    {
        Microsoft::WRL::ComPtr<ID3D12Device> device;
        CheckResult(D3D12CreateDevice(adapter, minimum, IID_PPV_ARGS(&device)), "D3D12CreateDevice");
        return Borrow(device.Get());
    }
    std::shared_ptr<DeviceContext> DeviceContext::Borrow(ID3D12Device* device)
    {
        if (!device)
            throw std::invalid_argument("Missing D3D12 device");
        auto result = std::shared_ptr<DeviceContext>(new DeviceContext(device));
        result->CheckAlive();
        return result;
    }
    void DeviceContext::CheckAlive() const
    {
        CheckResult(device->GetDeviceRemovedReason(), "D3D12 device removed");
    }
}
