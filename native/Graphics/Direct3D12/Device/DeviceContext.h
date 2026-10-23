#pragma once
#include <d3d12.h>
#include <dxgi1_6.h>
#include <wrl/client.h>
#include <memory>

namespace Celeste::Graphics::Direct3D12
{
    class DeviceContext
    {
      public:
        Microsoft::WRL::ComPtr<ID3D12Device> device;
        static std::shared_ptr<DeviceContext> CreateOwned(IDXGIAdapter* adapter = nullptr,
                                                          D3D_FEATURE_LEVEL minimum = D3D_FEATURE_LEVEL_11_0);
        static std::shared_ptr<DeviceContext> Borrow(ID3D12Device* device);
        void CheckAlive() const;

      private:
        explicit DeviceContext(ID3D12Device* source) : device(source)
        {
        }
    };
    void CheckResult(HRESULT result, const char* operation);
}
