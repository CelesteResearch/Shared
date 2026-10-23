#pragma once
#include "CelesteGraphicsSourceEnums.h"
#include <stddef.h>

// Field order and natural alignment match the existing managed SourceNative types.
// Pointer fields are the same backend resource handles held by source resources.
// Do not serialize padding or convert these values to D3D descriptors in managed IO.
typedef struct SourceNativeBlendState
{
    SourceBlendFactor colorSourceBlend, colorDestinationBlend;
    SourceBlendFunction colorBlendFunction;
    SourceBlendFactor alphaSourceBlend, alphaDestinationBlend;
    SourceBlendFunction alphaBlendFunction;
    SourceColorWriteChannels colorWriteEnable, colorWriteEnable1, colorWriteEnable2, colorWriteEnable3;
    uint32_t blendFactor;
    int32_t multiSampleMask;
} SourceNativeBlendState;

typedef struct SourceNativeDepthStencilState
{
    uint8_t depthBufferEnable, depthBufferWriteEnable;
    SourceCompareFunction depthBufferFunction;
    uint8_t stencilEnable;
    int32_t stencilMask, stencilWriteMask;
    uint8_t twoSidedStencilMode;
    SourceStencilOperation stencilFail, stencilDepthBufferFail, stencilPass;
    SourceCompareFunction stencilFunction;
    SourceStencilOperation ccwStencilFail, ccwStencilDepthBufferFail, ccwStencilPass;
    SourceCompareFunction ccwStencilFunction;
    int32_t referenceStencil;
} SourceNativeDepthStencilState;

typedef struct SourceNativeRasterizerState
{
    SourceFillMode fillMode;
    SourceCullMode cullMode;
    float depthBias, slopeScaleDepthBias;
    uint8_t scissorTestEnable, multiSampleAntiAlias;
} SourceNativeRasterizerState;

typedef struct SourceNativeSamplerState
{
    SourceTextureFilter filter;
    SourceTextureAddressMode addressU, addressV, addressW;
    float mipMapLevelOfDetailBias;
    int32_t maxAnisotropy, maxMipLevel;
} SourceNativeSamplerState;

typedef struct SourceNativePresentationParameters
{
    int32_t backBufferWidth, backBufferHeight;
    SourceSurfaceFormat backBufferFormat;
    int32_t multiSampleCount;
    void* deviceWindowHandle;
    uint8_t isFullScreen;
    SourceDepthFormat depthStencilFormat;
    SourcePresentInterval presentationInterval;
    SourceDisplayOrientation displayOrientation;
    SourceRenderTargetUsage renderTargetUsage;
} SourceNativePresentationParameters;

typedef struct SourceVertexElement
{
    int32_t offset;
    SourceVertexElementFormat vertexElementFormat;
    SourceVertexElementUsage vertexElementUsage;
    int32_t usageIndex;
} SourceVertexElement;

typedef struct SourceNativeVertexDeclaration
{
    int32_t vertexStride, elementCount;
    const SourceVertexElement* elements;
} SourceNativeVertexDeclaration;

typedef struct SourceNativeVertexBufferBinding
{
    void* vertexBuffer;
    SourceNativeVertexDeclaration vertexDeclaration;
    int32_t vertexOffset, instanceFrequency;
} SourceNativeVertexBufferBinding;

typedef struct SourceNativeRenderTargetBinding
{
    uint8_t type;
    int32_t data1, data2, levelCount, multiSampleCount;
    void* texture;
    void* colorBuffer;
} SourceNativeRenderTargetBinding;

typedef struct SourceCameraViewport
{
    int32_t x, y, width, height;
    float minDepth, maxDepth;
} SourceCameraViewport;

#ifdef __cplusplus
static_assert(sizeof(SourceNativeBlendState) == 48);
static_assert(sizeof(SourceNativeDepthStencilState) == 60);
static_assert(offsetof(SourceNativeDepthStencilState, referenceStencil) == 56);
static_assert(sizeof(SourceNativeRasterizerState) == 20);
static_assert(sizeof(SourceNativeSamplerState) == 28);
static_assert(sizeof(SourceVertexElement) == 16);
static_assert(sizeof(SourceCameraViewport) == 24);
#if UINTPTR_MAX == UINT64_MAX
static_assert(sizeof(SourceNativePresentationParameters) == 48);
static_assert(offsetof(SourceNativePresentationParameters, depthStencilFormat) == 28);
static_assert(sizeof(SourceNativeVertexDeclaration) == 16);
static_assert(sizeof(SourceNativeVertexBufferBinding) == 32);
static_assert(sizeof(SourceNativeRenderTargetBinding) == 40);
static_assert(offsetof(SourceNativeRenderTargetBinding, texture) == 24);
#endif
#endif
