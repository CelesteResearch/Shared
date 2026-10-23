#pragma once
#include "CelesteGraphicsDirect3D12.h"
struct CelesteDirect3D12Window;
struct CelesteDirect3D12WindowInfo
{
    HWND window;
    uint32_t width, height, interval;
};
extern "C"
{
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CreateWindow(const CelesteDirect3D12WindowInfo*,
                                                                CelesteDirect3D12Window**, CelesteGraphicsDevice**);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12DestroyWindow(CelesteDirect3D12Window*);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12ResizeWindow(CelesteDirect3D12Window*, uint32_t, uint32_t, uint32_t);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12AcquireWindowOutput(CelesteDirect3D12Window*,
                                                                       CelesteGraphicsOutput**);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12SubmitWindowPacket(CelesteDirect3D12Window*, CelesteGraphicsPacket*,
                                                                      uint32_t);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12PresentWindow(CelesteDirect3D12Window*, uint32_t enabled,
                                                                 uint32_t* presented);
}
