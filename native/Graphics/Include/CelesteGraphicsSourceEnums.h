#pragma once
#include <stdint.h>

// Source enum values. ABI storage is explicitly int32_t, independent of compiler enum flags.

// Celeste.Core/Rendering/SourceBlendFactor.cs
typedef int32_t SourceBlendFactor;
enum
{
    SourceBlendFactor_One = 0,
    SourceBlendFactor_Zero = 1,
    SourceBlendFactor_SourceColor = 2,
    SourceBlendFactor_InverseSourceColor = 3,
    SourceBlendFactor_SourceAlpha = 4,
    SourceBlendFactor_InverseSourceAlpha = 5,
    SourceBlendFactor_DestinationColor = 6,
    SourceBlendFactor_InverseDestinationColor = 7,
    SourceBlendFactor_DestinationAlpha = 8,
    SourceBlendFactor_InverseDestinationAlpha = 9,
    SourceBlendFactor_BlendFactor = 10,
    SourceBlendFactor_InverseBlendFactor = 11,
    SourceBlendFactor_SourceAlphaSaturation = 12
};

// Celeste.Core/Rendering/SourceBlendFunction.cs
typedef int32_t SourceBlendFunction;
enum
{
    SourceBlendFunction_Add = 0,
    SourceBlendFunction_Subtract = 1,
    SourceBlendFunction_ReverseSubtract = 2,
    SourceBlendFunction_Min = 3,
    SourceBlendFunction_Max = 4
};

// Celeste.Core/Rendering/States/SourceCompareFunction.cs
typedef int32_t SourceCompareFunction;
enum
{
    SourceCompareFunction_Always = 0,
    SourceCompareFunction_Never = 1,
    SourceCompareFunction_Less = 2,
    SourceCompareFunction_LessEqual = 3,
    SourceCompareFunction_Equal = 4,
    SourceCompareFunction_GreaterEqual = 5,
    SourceCompareFunction_Greater = 6,
    SourceCompareFunction_NotEqual = 7
};

// Celeste.Core/Rendering/States/SourceStencilOperation.cs
typedef int32_t SourceStencilOperation;
enum
{
    SourceStencilOperation_Keep = 0,
    SourceStencilOperation_Zero = 1,
    SourceStencilOperation_Replace = 2,
    SourceStencilOperation_Increment = 3,
    SourceStencilOperation_Decrement = 4,
    SourceStencilOperation_IncrementSaturation = 5,
    SourceStencilOperation_DecrementSaturation = 6,
    SourceStencilOperation_Invert = 7
};

// Celeste.Core/Rendering/States/SourceFillMode.cs
typedef int32_t SourceFillMode;
enum
{
    SourceFillMode_Solid = 0,
    SourceFillMode_WireFrame = 1
};

// Celeste.Core/Rendering/States/SourceCullMode.cs
typedef int32_t SourceCullMode;
enum
{
    SourceCullMode_None = 0,
    SourceCullMode_CullClockwiseFace = 1,
    SourceCullMode_CullCounterClockwiseFace = 2
};

// Celeste.Core/Rendering/States/SourceTextureFilter.cs
typedef int32_t SourceTextureFilter;
enum
{
    SourceTextureFilter_Linear = 0,
    SourceTextureFilter_Point = 1,
    SourceTextureFilter_Anisotropic = 2,
    SourceTextureFilter_LinearMipPoint = 3,
    SourceTextureFilter_PointMipLinear = 4,
    SourceTextureFilter_MinLinearMagPointMipLinear = 5,
    SourceTextureFilter_MinLinearMagPointMipPoint = 6,
    SourceTextureFilter_MinPointMagLinearMipLinear = 7,
    SourceTextureFilter_MinPointMagLinearMipPoint = 8
};

// Celeste.Core/Rendering/States/SourceTextureAddressMode.cs
typedef int32_t SourceTextureAddressMode;
enum
{
    SourceTextureAddressMode_Wrap = 0,
    SourceTextureAddressMode_Clamp = 1,
    SourceTextureAddressMode_Mirror = 2
};

// Celeste.Core/Rendering/States/SourceColorWriteChannels.cs
typedef int32_t SourceColorWriteChannels;
enum
{
    SourceColorWriteChannels_None = 0,
    SourceColorWriteChannels_Red = 1,
    SourceColorWriteChannels_Green = 2,
    SourceColorWriteChannels_Blue = 4,
    SourceColorWriteChannels_Alpha = 8,
    SourceColorWriteChannels_All = 15
};

// Celeste.Graphics/Rendering/Textures/SourceSurfaceFormat.cs
typedef int32_t SourceSurfaceFormat;
enum
{
    SourceSurfaceFormat_Color = 0,
    SourceSurfaceFormat_Bgr565 = 1,
    SourceSurfaceFormat_Bgra5551 = 2,
    SourceSurfaceFormat_Bgra4444 = 3,
    SourceSurfaceFormat_Dxt1 = 4,
    SourceSurfaceFormat_Dxt3 = 5,
    SourceSurfaceFormat_Dxt5 = 6,
    SourceSurfaceFormat_NormalizedByte2 = 7,
    SourceSurfaceFormat_NormalizedByte4 = 8,
    SourceSurfaceFormat_Rgba1010102 = 9,
    SourceSurfaceFormat_Rg32 = 10,
    SourceSurfaceFormat_Rgba64 = 11,
    SourceSurfaceFormat_Alpha8 = 12,
    SourceSurfaceFormat_Single = 13,
    SourceSurfaceFormat_Vector2 = 14,
    SourceSurfaceFormat_Vector4 = 15,
    SourceSurfaceFormat_HalfSingle = 16,
    SourceSurfaceFormat_HalfVector2 = 17,
    SourceSurfaceFormat_HalfVector4 = 18,
    SourceSurfaceFormat_HdrBlendable = 19,
    SourceSurfaceFormat_ColorBgraEXT = 20,
    SourceSurfaceFormat_ColorSrgbEXT = 21,
    SourceSurfaceFormat_Dxt5SrgbEXT = 22,
    SourceSurfaceFormat_Bc7EXT = 23,
    SourceSurfaceFormat_Bc7SrgbEXT = 24
};

// Celeste.Graphics/Rendering/Textures/SourceDepthFormat.cs
typedef int32_t SourceDepthFormat;
enum
{
    SourceDepthFormat_None = 0,
    SourceDepthFormat_Depth16 = 1,
    SourceDepthFormat_Depth24 = 2,
    SourceDepthFormat_Depth24Stencil8 = 3
};

// Celeste.Graphics/Rendering/Textures/SourceCubeMapFace.cs
typedef int32_t SourceCubeMapFace;
enum
{
    SourceCubeMapFace_PositiveX = 0,
    SourceCubeMapFace_NegativeX = 1,
    SourceCubeMapFace_PositiveY = 2,
    SourceCubeMapFace_NegativeY = 3,
    SourceCubeMapFace_PositiveZ = 4,
    SourceCubeMapFace_NegativeZ = 5
};

// Celeste.Graphics/Rendering/Vertices/SourceSetDataOptions.cs
typedef int32_t SourceSetDataOptions;
enum
{
    SourceSetDataOptions_None = 0,
    SourceSetDataOptions_Discard = 1,
    SourceSetDataOptions_NoOverwrite = 2
};

// Celeste.Graphics/Rendering/Vertices/SourceBufferUsage.cs
typedef int32_t SourceBufferUsage;
enum
{
    SourceBufferUsage_None = 0,
    SourceBufferUsage_WriteOnly = 1
};

// Celeste.Graphics/Rendering/Vertices/SourcePrimitiveType.cs
typedef int32_t SourcePrimitiveType;
enum
{
    SourcePrimitiveType_TriangleList = 0,
    SourcePrimitiveType_TriangleStrip = 1,
    SourcePrimitiveType_LineList = 2,
    SourcePrimitiveType_LineStrip = 3,
    SourcePrimitiveType_PointListEXT = 4
};

// Celeste.Graphics/Rendering/Buffers/SourceIndexElementSize.cs
typedef int32_t SourceIndexElementSize;
enum
{
    SourceIndexElementSize_SixteenBits = 0,
    SourceIndexElementSize_ThirtyTwoBits = 1
};

// Celeste.Graphics/Rendering/Devices/SourceClearOptions.cs
typedef int32_t SourceClearOptions;
enum
{
    SourceClearOptions_Target = 1,
    SourceClearOptions_DepthBuffer = 2,
    SourceClearOptions_Stencil = 4
};

// Celeste.Graphics/Rendering/Devices/SourcePresentInterval.cs
typedef int32_t SourcePresentInterval;
enum
{
    SourcePresentInterval_Default = 0,
    SourcePresentInterval_One = 1,
    SourcePresentInterval_Two = 2,
    SourcePresentInterval_Immediate = 3
};

// Celeste.Core/Display/SourceDisplayOrientation.cs
typedef int32_t SourceDisplayOrientation;
enum
{
    SourceDisplayOrientation_Default = 0,
    SourceDisplayOrientation_LandscapeLeft = 1,
    SourceDisplayOrientation_LandscapeRight = 2,
    SourceDisplayOrientation_Portrait = 4
};

// Celeste.Graphics/Rendering/Textures/SourceRenderTargetUsage.cs
typedef int32_t SourceRenderTargetUsage;
enum
{
    SourceRenderTargetUsage_DiscardContents = 0,
    SourceRenderTargetUsage_PreserveContents = 1,
    SourceRenderTargetUsage_PlatformContents = 2
};

// Celeste.Graphics/Rendering/Vertices/SourceVertexElementFormat.cs
typedef int32_t SourceVertexElementFormat;
enum
{
    SourceVertexElementFormat_Single = 0,
    SourceVertexElementFormat_Vector2 = 1,
    SourceVertexElementFormat_Vector3 = 2,
    SourceVertexElementFormat_Vector4 = 3,
    SourceVertexElementFormat_Color = 4,
    SourceVertexElementFormat_Byte4 = 5,
    SourceVertexElementFormat_Short2 = 6,
    SourceVertexElementFormat_Short4 = 7,
    SourceVertexElementFormat_NormalizedShort2 = 8,
    SourceVertexElementFormat_NormalizedShort4 = 9,
    SourceVertexElementFormat_HalfVector2 = 10,
    SourceVertexElementFormat_HalfVector4 = 11
};

// Celeste.Graphics/Rendering/Vertices/SourceVertexElementUsage.cs
typedef int32_t SourceVertexElementUsage;
enum
{
    SourceVertexElementUsage_Position = 0,
    SourceVertexElementUsage_Color = 1,
    SourceVertexElementUsage_TextureCoordinate = 2,
    SourceVertexElementUsage_Normal = 3,
    SourceVertexElementUsage_Binormal = 4,
    SourceVertexElementUsage_Tangent = 5,
    SourceVertexElementUsage_BlendIndices = 6,
    SourceVertexElementUsage_BlendWeight = 7,
    SourceVertexElementUsage_Depth = 8,
    SourceVertexElementUsage_Fog = 9,
    SourceVertexElementUsage_PointSize = 10,
    SourceVertexElementUsage_Sample = 11,
    SourceVertexElementUsage_TessellateFactor = 12
};
