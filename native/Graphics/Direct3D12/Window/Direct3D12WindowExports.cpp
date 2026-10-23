#include "CelesteDirect3D12Window.h"
#include "Direct3D12ApiErrors.h"
#include <stdexcept>
using namespace Celeste::Graphics::Direct3D12;
static CelesteDirect3D12Window& Window(CelesteDirect3D12Window* window)
{
    if (!window)
        throw std::invalid_argument("Missing window presenter");
    return *window;
}
extern "C"
{
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CreateWindow(const CelesteDirect3D12WindowInfo* info,
                                                                CelesteDirect3D12Window** result,
                                                                CelesteGraphicsDevice** device)
    {
        return Invoke([&] {
            if (!info || !result || !device)
                throw std::invalid_argument("Missing window creation arguments");
            *result = nullptr;
            *device = nullptr;
            auto created = std::make_unique<CelesteDirect3D12Window>(*info);
            *device = created->device;
            *result = created.release();
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12DestroyWindow(CelesteDirect3D12Window* window)
    {
        return Invoke([&] {
            if (!window)
                return;
            window->Drain();
            if (CelesteDirect3D12GetDeviceApi()->DestroyDevice(window->device) != 1)
                throw std::runtime_error(CelesteDirect3D12GetLastError());
            window->device = nullptr;
            delete window;
        });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12ResizeWindow(CelesteDirect3D12Window* window, uint32_t width,
                                                                uint32_t height, uint32_t interval)
    {
        return Invoke([&] { Window(window).Resize(width, height, interval); });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12AcquireWindowOutput(CelesteDirect3D12Window* window,
                                                                       CelesteGraphicsOutput** output)
    {
        return Invoke([&] { Window(window).Acquire(output); });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12SubmitWindowPacket(CelesteDirect3D12Window* window,
                                                                      CelesteGraphicsPacket* packet, uint32_t wait)
    {
        return Invoke([&] { Window(window).Submit(packet, wait != 0); });
    }
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12PresentWindow(CelesteDirect3D12Window* window, uint32_t enabled,
                                                                 uint32_t* presented)
    {
        return Invoke([&] {
            if (!presented)
                throw std::invalid_argument("Missing presentation result");
            *presented = Window(window).Present(enabled != 0) ? 1u : 0u;
        });
    }
}
