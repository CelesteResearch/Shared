#pragma once
#include <d3d11.h>
#include <cstdint>

#if defined(CELESTE_D3D11_BUILD)
#define CELESTE_D3D11_API __declspec(dllexport)
#else
#define CELESTE_D3D11_API __declspec(dllimport)
#endif

struct Direct3D11Device;
struct Direct3D11PhysicalPacket;

extern "C"
{
    CELESTE_D3D11_API Direct3D11Device* __cdecl SourceGpuCreateDeviceContext();
    CELESTE_D3D11_API void __cdecl SourceGpuRetainDeviceContext(Direct3D11Device* device);
    CELESTE_D3D11_API void __cdecl SourceGpuReleaseDeviceContext(Direct3D11Device* device);
    CELESTE_D3D11_API void __cdecl SourceGpuDestroySourceDevice(Direct3D11Device* device);
    CELESTE_D3D11_API uint64_t __cdecl SourceGpuDeviceGeneration(Direct3D11Device* device);
    CELESTE_D3D11_API Direct3D11Device* __cdecl SourceGpuAttachD3D11Device(Direct3D11Device* device,
                                                                           ID3D11Device* borrowedDevice);
    CELESTE_D3D11_API int __cdecl SourceGpuExecuteBorrowedPacket(Direct3D11PhysicalPacket* packet);
    CELESTE_D3D11_API void __cdecl SourceGpuReleasePacket(Direct3D11PhysicalPacket* packet);
}
