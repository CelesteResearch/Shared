#pragma once
#include "Direct3D11Resources.h"
#include "Direct3D11Transport.h"

struct SourceGpuVertexBinding
{
    ID3D11Buffer* buffer;
    uint32_t stride;
    uint32_t offset;
};
static_assert(sizeof(SourceGpuVertexBinding) == 16);

// Windows x64, cdecl. IntPtr values are opaque pointers of the named type;
// no managed resource map and no per-call creation of a source device.
SOURCE_GPU_EXPORT int __cdecl SourceGpuApplyEffect(Direct3D11Effect*, uint32_t, MOJOSHADER_effectStateChanges*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateTexture(Direct3D11Device*, DXGI_FORMAT, uint32_t, uint32_t, uint32_t,
                                                     uint32_t, uint32_t, D3D11_RESOURCE_DIMENSION, uint32_t, uint32_t,
                                                     uint32_t, uint32_t, SourceGpuTexture**);
SOURCE_GPU_EXPORT void __cdecl SourceGpuDisposeTexture(SourceGpuTexture*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordTextureData(SourceGpuTexture*, uint32_t, uint32_t, uint32_t, uint32_t,
                                                         uint32_t, uint32_t, uint32_t, uint32_t, const void*, uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordTextureCopy(SourceGpuTexture*, SourceGpuTexture*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordTextureBinding(Direct3D11Device*, uint32_t, uint32_t, SourceGpuTexture*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceSampler(Direct3D11Device*, uint32_t, SourceGpuTexture*,
                                                           const D3D11_SAMPLER_DESC*, uint32_t);
SOURCE_GPU_EXPORT SourceGpuReadback* __cdecl SourceGpuRecordTextureRead(SourceGpuTexture*, uint32_t, uint32_t, uint32_t,
                                                                        uint32_t, uint32_t, uint32_t, uint32_t,
                                                                        uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuReadbackCompletion(SourceGpuReadback*);
SOURCE_GPU_EXPORT const uint8_t* __cdecl SourceGpuReadbackBytes(SourceGpuReadback*, uint32_t*);
SOURCE_GPU_EXPORT void __cdecl SourceGpuReleaseReadback(SourceGpuReadback*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordVertexBufferWrite(Direct3D11Device*, ID3D11Buffer*, uint32_t, const void*,
                                                               uint32_t, uint32_t, uint32_t, D3D11_MAP);
SOURCE_GPU_EXPORT int __cdecl SourceGpuTryReuseVertexBindings(Direct3D11Device*, uint32_t*, uint32_t*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuSetVertexBindings(Direct3D11Device*, const SourceGpuVertexBinding*, uint32_t,
                                                         const D3D11_INPUT_ELEMENT_DESC*, uint32_t, uint64_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordBoundDraw(Direct3D11Device*, D3D11_PRIMITIVE_TOPOLOGY, uint32_t, uint32_t,
                                                       int32_t, uint32_t, int);
using SourceGpuLogFunction = void(__cdecl*)(const char*);
SOURCE_GPU_EXPORT void __cdecl SourceGpuHookLogFunctions(SourceGpuLogFunction, SourceGpuLogFunction,
                                                         SourceGpuLogFunction);
SOURCE_GPU_EXPORT int __cdecl SourceGpuCreateRenderbuffer(Direct3D11Device*, uint32_t, uint32_t, DXGI_FORMAT, uint32_t,
                                                          int32_t, SourceGpuTexture*, uint32_t,
                                                          SourceGpuRenderbuffer**);
SOURCE_GPU_EXPORT void __cdecl SourceGpuDisposeRenderbuffer(SourceGpuRenderbuffer*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordRenderTargets(Direct3D11Device*, SourceGpuRenderbuffer* const*, uint32_t,
                                                           SourceGpuRenderbuffer*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuGetCurrentDepthFormat(Direct3D11Device*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordResolve(SourceGpuRenderbuffer*, SourceGpuTexture*, uint32_t, uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuGetFormatSupport(Direct3D11Device*, DXGI_FORMAT, uint32_t*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuGetMultisampleQuality(Direct3D11Device*, DXGI_FORMAT, uint32_t, uint32_t*);
SOURCE_GPU_EXPORT SourceGpuReadback* __cdecl SourceGpuRecordVertexBufferRead(Direct3D11Device*, ID3D11Buffer*, uint32_t,
                                                                             uint32_t, uint32_t, uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordClearRenderbuffer(SourceGpuRenderbuffer*, const float*, uint32_t, uint32_t,
                                                               uint32_t, float, uint8_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuGetBackbufferDescription(Direct3D11Device*, uint32_t*, uint32_t*, DXGI_FORMAT*,
                                                                uint32_t*, int32_t*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordBackbufferTargets(Direct3D11Device*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordClearBackbuffer(Direct3D11Device*, const float*, uint32_t, uint32_t,
                                                             uint32_t, float, uint8_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordClearCurrent(Direct3D11Device*, const float*, uint32_t, uint32_t, uint32_t,
                                                          float, uint8_t);
SOURCE_GPU_EXPORT uint32_t __cdecl SourceGpuGetBlendFactor(Direct3D11Device*);
SOURCE_GPU_EXPORT int32_t __cdecl SourceGpuGetSampleMask(Direct3D11Device*);
SOURCE_GPU_EXPORT int32_t __cdecl SourceGpuGetStencilReference(Direct3D11Device*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordBlendFactor(Direct3D11Device*, uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSampleMask(Direct3D11Device*, int32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordStencilReference(Direct3D11Device*, int32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceBlend(Direct3D11Device*, const D3D11_BLEND_DESC*, uint32_t, int32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceDepthStencil(Direct3D11Device*, const D3D11_DEPTH_STENCIL_DESC*,
                                                                int32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceTargets(Direct3D11Device*, const SourceGpuTargetBinding*, uint32_t,
                                                           SourceGpuRenderbuffer*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceResolve(const SourceGpuTargetBinding*);

SOURCE_GPU_EXPORT Direct3D11PhysicalPacket* __cdecl SourceGpuBeginPhysicalPacket(Direct3D11Device*);
SOURCE_GPU_EXPORT Direct3D11PhysicalPacket* __cdecl SourceGpuBorrowOrBeginPhysicalPacket(Direct3D11Device*, uint32_t*);
SOURCE_GPU_EXPORT Direct3D11PhysicalPacket* __cdecl SourceGpuSealPhysicalPacket();

SOURCE_GPU_EXPORT int __cdecl SourceGpuInitializeBackbuffer(Direct3D11Device*, uint32_t, uint32_t, DXGI_FORMAT,
                                                            uint32_t, uint32_t, DXGI_FORMAT, int32_t, int32_t,
                                                            uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuResetBackbuffer(Direct3D11Device*, uint32_t, uint32_t, DXGI_FORMAT, uint32_t,
                                                       uint32_t, DXGI_FORMAT, int32_t, int32_t);
SOURCE_GPU_EXPORT SourceGpuReadback* __cdecl SourceGpuReadBackbuffer(Direct3D11Device*, uint32_t, uint32_t, uint32_t,
                                                                     uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordPresent(Direct3D11Device*, const SourceGpuRect*, const SourceGpuRect*);

SOURCE_GPU_EXPORT int __cdecl SourceGpuDisposeVertexBuffer(Direct3D11Device*, ID3D11Buffer*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuDisposeIndexBuffer(Direct3D11Device*, ID3D11Buffer*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuSetTextureName(SourceGpuTexture*, const char*, uint32_t);
SOURCE_GPU_EXPORT void* __cdecl SourceGpuAllocate(uint32_t);
SOURCE_GPU_EXPORT void __cdecl SourceGpuFree(void*);
SOURCE_GPU_EXPORT void __cdecl SourceGpuDestroySourceDevice(Direct3D11Device*);
SOURCE_GPU_EXPORT Direct3D11Device* __cdecl SourceGpuEnsureSourceDevice(Direct3D11Device*);

SOURCE_GPU_EXPORT int32_t __cdecl SourceGpuGetBackbufferSurfaceFormat(Direct3D11Device*);

struct SourceGpuRawVertexElement
{
    int32_t offset, format, usage, index;
};
struct SourceGpuRawVertexDeclaration
{
    int32_t stride, count;
    const SourceGpuRawVertexElement* elements;
};
struct SourceGpuRawVertexBufferBinding
{
    ID3D11Buffer* buffer;
    SourceGpuRawVertexDeclaration declaration;
    int32_t vertexOffset, instanceFrequency;
};
static_assert(sizeof(SourceGpuRawVertexElement) == 16);
static_assert(sizeof(SourceGpuRawVertexDeclaration) == 16);
static_assert(sizeof(SourceGpuRawVertexBufferBinding) == 32);
SOURCE_GPU_EXPORT uint32_t __cdecl SourceGpuHashSourceVertexBindings(const SourceGpuRawVertexBufferBinding*, int32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSourceBoundDraw(Direct3D11Device*, int32_t, int32_t, uint32_t, int32_t,
                                                             uint32_t, int32_t);

SOURCE_GPU_EXPORT int32_t __cdecl SourceGpuSetPresentationInterval(Direct3D11Device*, int32_t);

SOURCE_GPU_EXPORT void __cdecl SourceGpuAddDisposeTexture(SourceGpuTexture*);
SOURCE_GPU_EXPORT void __cdecl SourceGpuAddDisposeRenderbuffer(SourceGpuRenderbuffer*);

// Independent hardware D3D11 host ABI (Windows x64/cdecl).
// Execute does not consume the caller's packet reference; release it normally.
SOURCE_GPU_EXPORT int __cdecl SourceGpuExecutePhysicalPacket(Direct3D11Device*, Direct3D11PhysicalPacket*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuConfigureFrameOutput(Direct3D11Device*, uint32_t, uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuConfigureWindowOutput(Direct3D11Device*, HWND, uint32_t, uint32_t);
SOURCE_GPU_EXPORT int __cdecl SourceGpuPresentWindowOutput(Direct3D11Device*);
// RGBA8, tightly packed rows, first row is physical texture's top row.
SOURCE_GPU_EXPORT int __cdecl SourceGpuReadFrameRgba(Direct3D11Device*, uint8_t*, uint32_t, uint32_t*);

// One existing SpriteBatch upload chunk. Source ordering and native state calls remain explicit.
struct SourceGpuSpriteTextureGroup
{
    SourceGpuTexture* texture;
    int32_t firstSprite, spriteCount;
};
struct SourceGpuSpriteGroupProgress
{
    int32_t attemptedGroup, samplerConsumed, writeScopeCount;
};
static_assert(sizeof(SourceGpuSpriteTextureGroup) == 16);
static_assert(sizeof(SourceGpuSpriteGroupProgress) == 12);
SOURCE_GPU_EXPORT Direct3D11PhysicalPacket* __cdecl SourceGpuGetSpriteGroupPacket(Direct3D11Device*);
SOURCE_GPU_EXPORT int __cdecl SourceGpuRecordSpriteGroups(Direct3D11Device*, Direct3D11PhysicalPacket*,
                                                          const SourceGpuSpriteTextureGroup*, int32_t, int32_t,
                                                          ID3D11Buffer*, DXGI_FORMAT, const D3D11_RASTERIZER_DESC*,
                                                          const D3D11_SAMPLER_DESC*, SourceGpuSpriteGroupProgress*);
