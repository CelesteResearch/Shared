#pragma once
#include "CelesteGraphicsBackend.h"
#include <d3d12.h>
#include <dxgi.h>

#ifdef __cplusplus
extern "C"
{
#endif

    typedef struct CelesteDirect3D12OwnedDeviceInfo
    {
        IDXGIAdapter* adapter;                 // Optional; borrowed for this call only.
        D3D_FEATURE_LEVEL minimumFeatureLevel; // Zero selects 11_0.
    } CelesteDirect3D12OwnedDeviceInfo;
    typedef struct CelesteDirect3D12BorrowedDeviceInfo
    {
        ID3D12Device* device; // AddRef retained; host submits the prepared DIRECT list.
    } CelesteDirect3D12BorrowedDeviceInfo;
    typedef struct CelesteDirect3D12OutputInfo
    {
        ID3D12Resource* resource;
        uint32_t subresource;
        uint32_t width, height;
        DXGI_FORMAT format;
        // Resource-wide states: output barriers cover ALL_SUBRESOURCES; only the selected subresource is drawn.
        D3D12_RESOURCE_STATES incomingState, outgoingState;
    } CelesteDirect3D12OutputInfo;
    typedef struct CelesteDirect3D12HostResourceState
    {
        ID3D12Resource* resource;
        D3D12_RESOURCE_STATES expectedState, currentState;
    } CelesteDirect3D12HostResourceState;
    typedef struct CelesteDirect3D12HostRecording
    {
        ID3D12GraphicsCommandList* commands;
        const CelesteDirect3D12HostResourceState* resourceStates;
        uint32_t resourceStateCount;
    } CelesteDirect3D12HostRecording;

    // Header is the agreed implementation contract; exports are qualified only after their implementations are linked.
    const char* CELESTE_GRAPHICS_CALL CelesteDirect3D12GetLastError(void);
    const CelesteGraphicsDeviceApi* CELESTE_GRAPHICS_CALL CelesteDirect3D12GetDeviceApi(void);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CreateOwnedDevice(const CelesteDirect3D12OwnedDeviceInfo*,
                                                                     CelesteGraphicsDevice**);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CreateBorrowedDevice(const CelesteDirect3D12BorrowedDeviceInfo*,
                                                                        CelesteGraphicsDevice**);
    // Returned pointer is borrowed from the device handle.
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12GetNativeDevice(CelesteGraphicsDevice*, ID3D12Device**);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12AcquireOutput(CelesteGraphicsDevice*,
                                                                 const CelesteDirect3D12OutputInfo*,
                                                                 CelesteGraphicsOutput**);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12AcquireTextureOutput(CelesteGraphicsDevice*, CelesteGraphicsTexture*,
                                                                        CelesteGraphicsOutput**);
    // Prepare allocates, records and closes the private DIRECT list. Returned views live until commit/cancel.
    // The host must retain the packet throughout its render-thread handoff.
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12PrepareHostPacket(CelesteGraphicsPacket*,
                                                                     CelesteDirect3D12HostRecording*);
    // Called only after host submission; fence/value must follow this list on its actual execution queue.
    // Adds a reference to the real fence; never substitutes a frame counter. Does not allocate GPU objects.
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CommitHostPacket(CelesteGraphicsPacket*, ID3D12Fence*, uint64_t,
                                                                    CelesteGraphicsSubmission**);
    // Allowed only when the host has NOT executed the prepared list.
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12CancelPreparedHostPacket(CelesteGraphicsPacket*);
    int32_t CELESTE_GRAPHICS_CALL CelesteDirect3D12RetainPacket(CelesteGraphicsPacket*);
#ifdef __cplusplus
}
#endif
