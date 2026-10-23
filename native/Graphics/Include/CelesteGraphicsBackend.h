#pragma once
#include <stdint.h>
#include "CelesteGraphicsSourceTypes.h"
#define CELESTE_GRAPHICS_DEVICE_ABI_VERSION 3u

#if defined(_WIN32)
#define CELESTE_GRAPHICS_CALL __cdecl
#else
#define CELESTE_GRAPHICS_CALL
#endif

#ifdef __cplusplus
extern "C"
{
#endif

    typedef struct CelesteGraphicsDevice CelesteGraphicsDevice;
    typedef struct CelesteGraphicsTexture CelesteGraphicsTexture;
    typedef struct CelesteGraphicsBuffer CelesteGraphicsBuffer;
    typedef struct CelesteGraphicsPacket CelesteGraphicsPacket;
    typedef struct CelesteGraphicsSubmission CelesteGraphicsSubmission;
    typedef struct CelesteGraphicsOutput CelesteGraphicsOutput;
    typedef struct CelesteGraphicsRenderbuffer CelesteGraphicsRenderbuffer;
    typedef struct CelesteGraphicsReadback CelesteGraphicsReadback;

    typedef enum CelesteGraphicsTextureDimension
    {
        CelesteGraphicsTexture2D = 0,
        CelesteGraphicsTexture3D = 1,
        CelesteGraphicsTextureCube = 2
    } CelesteGraphicsTextureDimension;

    typedef struct CelesteGraphicsTextureInfo
    {
        // Exact SourceSurfaceFormat value; never a DXGI_FORMAT or VkFormat.
        int32_t sourceFormat;
        uint32_t dimension;
        uint32_t width, height, depth, levels;
        uint32_t renderTarget;
    } CelesteGraphicsTextureInfo;

    typedef struct CelesteGraphicsTextureRegion
    {
        uint32_t level, layer;
        uint32_t x, y, z, width, height, depth;
    } CelesteGraphicsTextureRegion;

    typedef struct CelesteGraphicsRect
    {
        int32_t x, y, width, height;
    } CelesteGraphicsRect;

    typedef struct CelesteGraphicsCapabilities
    {
        uint8_t noOverwrite, hardwareInstancing, srgbRenderTargets, dxt1, s3tc;
        int32_t fragmentTextureSlots, vertexTextureSlots;
    } CelesteGraphicsCapabilities;

    typedef struct CelesteGraphicsBackbufferInfo
    {
        int32_t width, height;
        SourceSurfaceFormat format;
        SourceDepthFormat depthFormat;
        int32_t multiSampleCount;
    } CelesteGraphicsBackbufferInfo;

    // Complete source IO contract. Declarations do not claim backend implementation.
    // Module-specific creation returns this same table once its operations are ready.
    // Success is 1, failure 0, matching the existing managed RequireSuccess contract.
    typedef struct CelesteGraphicsDeviceApi
    {
        uint32_t abiVersion;
        // Returns thread-local UTF-8, copied by the caller before its next API call.
        const char*(CELESTE_GRAPHICS_CALL* GetLastError)(void);
        // All caller-owned resource/packet/submission/output handles are released first.
        // Drains backend-submitted work, not unrelated borrowed-host work. The host
        // first retires all work recorded into its own command buffers.
        // Failure keeps the device and its pending work alive for a later retry.
        int32_t(CELESTE_GRAPHICS_CALL* DestroyDevice)(CelesteGraphicsDevice* device);
        int32_t(CELESTE_GRAPHICS_CALL* CreateTexture)(CelesteGraphicsDevice* device,
                                                      const CelesteGraphicsTextureInfo* info,
                                                      CelesteGraphicsTexture** texture);
        // Drops the caller loan. Queued/submitted uses retain the resource until done.
        void(CELESTE_GRAPHICS_CALL* ReleaseTexture)(CelesteGraphicsTexture* texture);
        int32_t(CELESTE_GRAPHICS_CALL* BeginPacket)(CelesteGraphicsDevice* device, CelesteGraphicsPacket** packet);
        // Explicit packet ownership, not a second implicit global/TLS graphics device.
        int32_t(CELESTE_GRAPHICS_CALL* WriteTexture)(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* texture,
                                                     const CelesteGraphicsTextureRegion* region, const void* bytes,
                                                     uint32_t byteCount);
        int32_t(CELESTE_GRAPHICS_CALL* CopyTexture)(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* source,
                                                    CelesteGraphicsTexture* destination);
        int32_t(CELESTE_GRAPHICS_CALL* Present)(CelesteGraphicsPacket* packet, CelesteGraphicsTexture* source,
                                                CelesteGraphicsOutput* output, const CelesteGraphicsRect* sourceRect,
                                                const CelesteGraphicsRect* destinationRect);
        // Success seals the packet. It submits ordered work without waiting for GPU idle.
        // Failure does not publish a submission handle. A packet is submitted at most once.
        int32_t(CELESTE_GRAPHICS_CALL* Submit)(CelesteGraphicsPacket* packet, CelesteGraphicsSubmission** submission);
        void(CELESTE_GRAPHICS_CALL* ReleasePacket)(CelesteGraphicsPacket* packet);
        // Pending 0, completed 1, failed -1. Completion means actual GPU completion.
        int32_t(CELESTE_GRAPHICS_CALL* GetCompletion)(CelesteGraphicsSubmission* submission);
        int32_t(CELESTE_GRAPHICS_CALL* Wait)(CelesteGraphicsSubmission* submission);
        // Releasing an observer never destroys in-flight resources or forces a wait.
        void(CELESTE_GRAPHICS_CALL* ReleaseSubmission)(CelesteGraphicsSubmission* submission);
        void(CELESTE_GRAPHICS_CALL* ReleaseOutput)(CelesteGraphicsOutput* output);

        // Full source-IO boundary below; declarations do not grant implementation.
        // Unsupported operations fail with an error, never return a successful noop.
        int32_t(CELESTE_GRAPHICS_CALL* GetCapabilities)(CelesteGraphicsDevice*, CelesteGraphicsCapabilities*);
        int32_t(CELESTE_GRAPHICS_CALL* GetMaxMultiSampleCount)(CelesteGraphicsDevice*, SourceSurfaceFormat,
                                                               int32_t preferredCount, int32_t* actualCount);
        int32_t(CELESTE_GRAPHICS_CALL* ConfigureBackbuffer)(CelesteGraphicsPacket*,
                                                            const SourceNativePresentationParameters*);
        int32_t(CELESTE_GRAPHICS_CALL* GetBackbufferInfo)(CelesteGraphicsDevice*, CelesteGraphicsBackbufferInfo*);
        int32_t(CELESTE_GRAPHICS_CALL* PresentBackbuffer)(CelesteGraphicsPacket*, CelesteGraphicsOutput*,
                                                          const CelesteGraphicsRect* source,
                                                          const CelesteGraphicsRect* destination);
        int32_t(CELESTE_GRAPHICS_CALL* SetViewport)(CelesteGraphicsPacket*, const SourceCameraViewport*);
        int32_t(CELESTE_GRAPHICS_CALL* SetScissorRect)(CelesteGraphicsPacket*, const CelesteGraphicsRect*);
        int32_t(CELESTE_GRAPHICS_CALL* Clear)(CelesteGraphicsPacket*, SourceClearOptions, const float* rgba,
                                              float depth, int32_t stencil);
        int32_t(CELESTE_GRAPHICS_CALL* SetBlendState)(CelesteGraphicsPacket*, const SourceNativeBlendState*);
        int32_t(CELESTE_GRAPHICS_CALL* SetDepthStencilState)(CelesteGraphicsPacket*,
                                                             const SourceNativeDepthStencilState*);
        int32_t(CELESTE_GRAPHICS_CALL* SetRasterizerState)(CelesteGraphicsPacket*, const SourceNativeRasterizerState*);
        int32_t(CELESTE_GRAPHICS_CALL* SetSampler)(CelesteGraphicsPacket*, uint32_t slot, uint8_t vertexStage,
                                                   CelesteGraphicsTexture*, const SourceNativeSamplerState*);
        int32_t(CELESTE_GRAPHICS_CALL* GetBlendFactor)(CelesteGraphicsDevice*, uint32_t* rgba);
        int32_t(CELESTE_GRAPHICS_CALL* SetBlendFactor)(CelesteGraphicsPacket*, uint32_t rgba);
        int32_t(CELESTE_GRAPHICS_CALL* GetSampleMask)(CelesteGraphicsDevice*, int32_t*);
        int32_t(CELESTE_GRAPHICS_CALL* SetSampleMask)(CelesteGraphicsPacket*, int32_t);
        int32_t(CELESTE_GRAPHICS_CALL* GetStencilReference)(CelesteGraphicsDevice*, int32_t*);
        int32_t(CELESTE_GRAPHICS_CALL* SetStencilReference)(CelesteGraphicsPacket*, int32_t);
        int32_t(CELESTE_GRAPHICS_CALL* SetRenderTargets)(CelesteGraphicsPacket*, const SourceNativeRenderTargetBinding*,
                                                         int32_t count, CelesteGraphicsRenderbuffer* depth,
                                                         SourceDepthFormat, uint8_t preserve);
        int32_t(CELESTE_GRAPHICS_CALL* ResolveTarget)(CelesteGraphicsPacket*, const SourceNativeRenderTargetBinding*);
        int32_t(CELESTE_GRAPHICS_CALL* CreateColorRenderbuffer)(CelesteGraphicsDevice*, int32_t width, int32_t height,
                                                                SourceSurfaceFormat, int32_t samples,
                                                                CelesteGraphicsTexture*, CelesteGraphicsRenderbuffer**);
        int32_t(CELESTE_GRAPHICS_CALL* CreateDepthRenderbuffer)(CelesteGraphicsDevice*, int32_t width, int32_t height,
                                                                SourceDepthFormat, int32_t samples,
                                                                CelesteGraphicsRenderbuffer**);
        void(CELESTE_GRAPHICS_CALL* ReleaseRenderbuffer)(CelesteGraphicsRenderbuffer*);
        int32_t(CELESTE_GRAPHICS_CALL* SetTextureName)(CelesteGraphicsTexture*, const char* utf8, uint32_t length);
        int32_t(CELESTE_GRAPHICS_CALL* ReadTexture)(CelesteGraphicsPacket*, CelesteGraphicsTexture*,
                                                    const CelesteGraphicsTextureRegion*, CelesteGraphicsReadback**);
        int32_t(CELESTE_GRAPHICS_CALL* ReadBackbuffer)(CelesteGraphicsPacket*, const CelesteGraphicsRect*,
                                                       CelesteGraphicsReadback**);
        // indexBuffer distinguishes the existing two source resource kinds; not native bind flags.
        int32_t(CELESTE_GRAPHICS_CALL* CreateBuffer)(CelesteGraphicsDevice*, uint8_t indexBuffer, uint8_t dynamic,
                                                     SourceBufferUsage, int32_t byteCount, CelesteGraphicsBuffer**);
        void(CELESTE_GRAPHICS_CALL* ReleaseBuffer)(CelesteGraphicsBuffer*);
        int32_t(CELESTE_GRAPHICS_CALL* WriteBuffer)(CelesteGraphicsPacket*, CelesteGraphicsBuffer*, int32_t offset,
                                                    const void* data, int32_t elementCount, int32_t elementSize,
                                                    int32_t stride, SourceSetDataOptions);
        int32_t(CELESTE_GRAPHICS_CALL* ReadBuffer)(CelesteGraphicsPacket*, CelesteGraphicsBuffer*, int32_t offset,
                                                   int32_t elementCount, int32_t elementSize, int32_t stride,
                                                   CelesteGraphicsReadback**);
        // Deep-copy declaration/element bytes, retain buffers before returning.
        int32_t(CELESTE_GRAPHICS_CALL* SetVertexBindings)(CelesteGraphicsPacket*,
                                                          const SourceNativeVertexBufferBinding*, int32_t count,
                                                          uint8_t updated, int32_t baseVertex);
        int32_t(CELESTE_GRAPHICS_CALL* Draw)(CelesteGraphicsPacket*, SourcePrimitiveType, int32_t startVertex,
                                             int32_t primitiveCount);
        int32_t(CELESTE_GRAPHICS_CALL* DrawIndexed)(CelesteGraphicsPacket*, SourcePrimitiveType, int32_t baseVertex,
                                                    int32_t minVertexIndex, int32_t numVertices, int32_t startIndex,
                                                    int32_t primitiveCount, int32_t instanceCount,
                                                    CelesteGraphicsBuffer*, SourceIndexElementSize);
        // Uses the existing CelesteEffectFrontend effect handle, not a second effect object.
        // Apply frontend synchronously, snapshot selected shaders/registers at this call.
        int32_t(CELESTE_GRAPHICS_CALL* ApplyEffect)(CelesteGraphicsPacket*, void* effect, uint32_t pass,
                                                    void* stateChanges);
        // Pending 0, CPU bytes ready 1, original compressed-read log/unchanged result 2,
        // failure -1. Status 2 is legal only when the original operation has that behavior.
        int32_t(CELESTE_GRAPHICS_CALL* GetReadbackStatus)(CelesteGraphicsReadback*);
        int32_t(CELESTE_GRAPHICS_CALL* GetReadbackBytes)(CelesteGraphicsReadback*, const void** bytes,
                                                         uint32_t* length);
        void(CELESTE_GRAPHICS_CALL* ReleaseReadback)(CelesteGraphicsReadback*);
        // Paired CPU allocation used by source IO, not a GPU resource or host window.
        int32_t(CELESTE_GRAPHICS_CALL* Allocate)(uint32_t byteCount, void** bytes);
        void(CELESTE_GRAPHICS_CALL* Free)(void* bytes);
    } CelesteGraphicsDeviceApi;

    // WriteTexture owns a byte snapshot before returning; no deferred caller pointers.
    // Packets preserve call order and retain referenced resources. Backend-private
    // subresource state drives barriers; hosts do not mirror source resource state.
    // One recorder owns a packet. Host scheduling serializes shared physical queues;
    // this ABI does not impose a lock per draw or a GPU wait per frame.

#ifdef __cplusplus
}
#endif
