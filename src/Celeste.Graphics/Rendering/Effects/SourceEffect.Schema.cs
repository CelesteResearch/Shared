using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Effects
{
    public partial class SourceEffect
    {
        private class IntPtrBoxlessComparer : IEqualityComparer<IntPtr>
        {
            public bool Equals(IntPtr x, IntPtr y)
            {
                return x == y;
            }

            public int GetHashCode(IntPtr obj)
            {
                return obj.GetHashCode();
            }
        }

        private enum MojoshaderSymbolClass
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderSymclassScalar,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymclassVector,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymclassMatrixRows,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymclassMatrixColumns,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymclassObject,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymclassStruct,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymclassTotal,
        }

        private enum MojoshaderSymbolType
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeVoid,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeBool,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeInt,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeFloat,
            MojoshaderSymtypeString,
            MojoshaderSymtypeTexture,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeTexture1D,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeTexture2D,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeTexture3D,
            MojoshaderSymtypeTexturecube,
            MojoshaderSymtypeSampler,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeSampler1D,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeSampler2D,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeSampler3D,
            MojoshaderSymtypeSamplercube,
            MojoshaderSymtypePixelshader,
            MojoshaderSymtypeVertexshader,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypePixelfragment,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeVertexfragment,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeUnsupported,

            // ReSharper disable once UnusedMember.Local
            MojoshaderSymtypeTotal,
        }

        private struct MojoshaderSymbolTypeInfo
        {
#pragma warning disable CS0649 // Native MojoShader writes these fields through the unmanaged schema.
            public MojoshaderSymbolClass ParameterClass;

            public MojoshaderSymbolType ParameterType;

            public uint Rows;

            public uint Columns;

            public uint Elements;

            public uint MemberCount;

            public IntPtr Members;
#pragma warning restore CS0649
        }

        private struct MojoshaderSymbolStructMember
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderSymbolTypeInfo Info;
#pragma warning restore CS0649
        }

        private enum MojoshaderRenderStateType
        {
            MOJOSHADER_RS_ZENABLE = 0,

            MOJOSHADER_RS_FILLMODE = 1,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_SHADEMODE = 2,

            MOJOSHADER_RS_ZWRITEENABLE = 3,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ALPHATESTENABLE = 4,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_LASTPIXEL = 5,

            MOJOSHADER_RS_SRCBLEND = 6,

            MOJOSHADER_RS_DESTBLEND = 7,

            MOJOSHADER_RS_CULLMODE = 8,

            MOJOSHADER_RS_ZFUNC = 9,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ALPHAREF = 10,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ALPHAFUNC = 11,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_DITHERENABLE = 12,

            MOJOSHADER_RS_ALPHABLENDENABLE = 13,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_FOGENABLE = 14,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_SPECULARENABLE = 15,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_FOGCOLOR = 16,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_FOGTABLEMODE = 17,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_FOGSTART = 18,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_FOGEND = 19,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_FOGDENSITY = 20,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_RANGEFOGENABLE = 21,

            MOJOSHADER_RS_STENCILENABLE = 22,

            MOJOSHADER_RS_STENCILFAIL = 23,

            MOJOSHADER_RS_STENCILZFAIL = 24,

            MOJOSHADER_RS_STENCILPASS = 25,

            MOJOSHADER_RS_STENCILFUNC = 26,

            MOJOSHADER_RS_STENCILREF = 27,

            MOJOSHADER_RS_STENCILMASK = 28,

            MOJOSHADER_RS_STENCILWRITEMASK = 29,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_TEXTUREFACTOR = 30,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP0 = 31,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP1 = 32,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP2 = 33,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP3 = 34,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP4 = 35,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP5 = 36,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP6 = 37,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP7 = 38,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP8 = 39,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP9 = 40,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP10 = 41,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP11 = 42,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP12 = 43,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP13 = 44,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP14 = 45,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_WRAP15 = 46,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_CLIPPING = 47,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_LIGHTING = 48,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_AMBIENT = 49,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_FOGVERTEXMODE = 50,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_COLORVERTEX = 51,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_LOCALVIEWER = 52,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_NORMALIZENORMALS = 53,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_DIFFUSEMATERIALSOURCE = 54,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_SPECULARMATERIALSOURCE = 55,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_AMBIENTMATERIALSOURCE = 56,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_EMISSIVEMATERIALSOURCE = 57,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_VERTEXBLEND = 58,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_CLIPPLANEENABLE = 59,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POINTSIZE = 60,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POINTSIZE_MIN = 61,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POINTSPRITEENABLE = 62,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POINTSCALEENABLE = 63,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POINTSCALE_A = 64,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POINTSCALE_B = 65,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POINTSCALE_C = 66,

            MOJOSHADER_RS_MULTISAMPLEANTIALIAS = 67,

            MOJOSHADER_RS_MULTISAMPLEMASK = 68,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_PATCHEDGESTYLE = 69,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_DEBUGMONITORTOKEN = 70,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POINTSIZE_MAX = 71,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_INDEXEDVERTEXBLENDENABLE = 72,

            MOJOSHADER_RS_COLORWRITEENABLE = 73,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_TWEENFACTOR = 74,

            MOJOSHADER_RS_BLENDOP = 75,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_POSITIONDEGREE = 76,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_NORMALDEGREE = 77,

            MOJOSHADER_RS_SCISSORTESTENABLE = 78,

            MOJOSHADER_RS_SLOPESCALEDEPTHBIAS = 79,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ANTIALIASEDLINEENABLE = 80,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_MINTESSELLATIONLEVEL = 81,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_MAXTESSELLATIONLEVEL = 82,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ADAPTIVETESS_X = 83,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ADAPTIVETESS_Y = 84,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ADAPTIVETESS_Z = 85,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ADAPTIVETESS_W = 86,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_ENABLEADAPTIVETESSELLATION = 87,

            MOJOSHADER_RS_TWOSIDEDSTENCILMODE = 88,

            MOJOSHADER_RS_CCW_STENCILFAIL = 89,

            MOJOSHADER_RS_CCW_STENCILZFAIL = 90,

            MOJOSHADER_RS_CCW_STENCILPASS = 91,

            MOJOSHADER_RS_CCW_STENCILFUNC = 92,

            MOJOSHADER_RS_COLORWRITEENABLE1 = 93,

            MOJOSHADER_RS_COLORWRITEENABLE2 = 94,

            MOJOSHADER_RS_COLORWRITEENABLE3 = 95,

            MOJOSHADER_RS_BLENDFACTOR = 96,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_RS_SRGBWRITEENABLE = 97,

            MOJOSHADER_RS_DEPTHBIAS = 98,

            MOJOSHADER_RS_SEPARATEALPHABLENDENABLE = 99,

            MOJOSHADER_RS_SRCBLENDALPHA = 100,

            MOJOSHADER_RS_DESTBLENDALPHA = 101,

            MOJOSHADER_RS_BLENDOPALPHA = 102,

            MOJOSHADER_RS_VERTEXSHADER = 146,

            MOJOSHADER_RS_PIXELSHADER = 147,
        }

        private enum MojoshaderZBufferType
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderZbFalse,
            MojoshaderZbTrue,

            // ReSharper disable once UnusedMember.Local
            MojoshaderZbUsew,
        }

        private enum MojoshaderFillMode
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderFillPoint = 1,
            MojoshaderFillWireframe,
            MojoshaderFillSolid,
        }

        private enum MojoshaderBlendMode
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendZero = 1,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendOne,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendSrccolor,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendInvsrccolor,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendSrcalpha,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendInvsrcalpha,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendDestalpha,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendInvdestalpha,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendDestcolor,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendInvdestcolor,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendSrcalphasat,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendBothsrcalpha,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendBothinvsrcalpha,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendBlendfactor,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendInvblendfactor,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendSrccolor2,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendInvsrccolor2,
        }

        private enum MojoshaderCullMode
        {
            MojoshaderCullNone = 1,
            MojoshaderCullCw,
            MojoshaderCullCcw,
        }

        private enum MojoshaderCompareFunc
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderCmpNever = 1,

            // ReSharper disable once UnusedMember.Local
            MojoshaderCmpLess,

            // ReSharper disable once UnusedMember.Local
            MojoshaderCmpEqual,

            // ReSharper disable once UnusedMember.Local
            MojoshaderCmpLessequal,

            // ReSharper disable once UnusedMember.Local
            MojoshaderCmpGreater,

            // ReSharper disable once UnusedMember.Local
            MojoshaderCmpNotequal,

            // ReSharper disable once UnusedMember.Local
            MojoshaderCmpGreaterequal,

            // ReSharper disable once UnusedMember.Local
            MojoshaderCmpAlways,
        }

        private enum MojoshaderStencilOp
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderStencilopKeep = 1,

            // ReSharper disable once UnusedMember.Local
            MojoshaderStencilopZero,

            // ReSharper disable once UnusedMember.Local
            MojoshaderStencilopReplace,

            // ReSharper disable once UnusedMember.Local
            MojoshaderStencilopIncrsat,

            // ReSharper disable once UnusedMember.Local
            MojoshaderStencilopDecrsat,

            // ReSharper disable once UnusedMember.Local
            MojoshaderStencilopInvert,

            // ReSharper disable once UnusedMember.Local
            MojoshaderStencilopIncr,

            // ReSharper disable once UnusedMember.Local
            MojoshaderStencilopDecr,
        }

        private enum MojoshaderBlendOp
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendopAdd = 1,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendopSubtract,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendopRevsubtract,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendopMin,

            // ReSharper disable once UnusedMember.Local
            MojoshaderBlendopMax,
        }

        private enum MojoshaderSamplerStateType
        {
            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_SAMP_UNKNOWN0,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_SAMP_UNKNOWN1,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_SAMP_UNKNOWN2,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_SAMP_UNKNOWN3,

            MOJOSHADER_SAMP_TEXTURE,

            MOJOSHADER_SAMP_ADDRESSU,

            MOJOSHADER_SAMP_ADDRESSV,

            MOJOSHADER_SAMP_ADDRESSW,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_SAMP_BORDERCOLOR,

            MOJOSHADER_SAMP_MAGFILTER,

            MOJOSHADER_SAMP_MINFILTER,

            MOJOSHADER_SAMP_MIPFILTER,

            MOJOSHADER_SAMP_MIPMAPLODBIAS,

            MOJOSHADER_SAMP_MAXMIPLEVEL,

            MOJOSHADER_SAMP_MAXANISOTROPY,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_SAMP_SRGBTEXTURE,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_SAMP_ELEMENTINDEX,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_SAMP_DMAPOFFSET,
        }

        private enum MojoshaderTextureAddress
        {
            // ReSharper disable once UnusedMember.Local
            MojoshaderTaddressWrap = 1,

            // ReSharper disable once UnusedMember.Local
            MojoshaderTaddressMirror,

            // ReSharper disable once UnusedMember.Local
            MojoshaderTaddressClamp,

            // ReSharper disable once UnusedMember.Local
            MojoshaderTaddressBorder,

            // ReSharper disable once UnusedMember.Local
            MojoshaderTaddressMirroronce,
        }

        private enum MojoshaderTextureFilterType
        {
            MOJOSHADER_TEXTUREFILTER_NONE,

            MOJOSHADER_TEXTUREFILTER_POINT,

            MOJOSHADER_TEXTUREFILTER_LINEAR,

            MOJOSHADER_TEXTUREFILTER_ANISOTROPIC,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_TEXTUREFILTER_PYRAMIDALQUAD,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_TEXTUREFILTER_GAUSSIANQUAD,

            // ReSharper disable once UnusedMember.Local
            MOJOSHADER_TEXTUREFILTER_CONVOLUTIONMONO,
        }

        private struct MojoshaderEffectValue
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Semantic;
#pragma warning restore CS0649

            public MojoshaderSymbolTypeInfo Type;

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint ValueCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Values;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectState
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderRenderStateType Type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderEffectValue Value;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectSamplerState
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderSamplerStateType Type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderEffectValue Value;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectAnnotation
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Semantic;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderSymbolTypeInfo Type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint ValueCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Values;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectParam
        {
            public MojoshaderEffectValue Value;

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint AnnotationCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Annotations;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectPass
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint StateCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr States;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint AnnotationCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Annotations;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectTechnique
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint PassCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Passes;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint AnnotationCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Annotations;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectShader
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderSymbolType Type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint Technique;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint Pass;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint IsPreshader;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint PreshaderParamCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr PreshaderParams;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint ParamCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Parameters;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint SamplerCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Samplers;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Shader;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectSamplerMap
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderSymbolType Type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Name;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectString
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderSymbolType Type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Stringvalue;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffectTexture
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MojoshaderSymbolType Type;
#pragma warning restore CS0649
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct MojoshaderEffectObject
        {
            [FieldOffset(0)] public MojoshaderSymbolType type;

            [FieldOffset(0)] public MojoshaderEffectShader shader;

            [FieldOffset(0)] public MojoshaderEffectSamplerMap mapping;

            [FieldOffset(0)] public MojoshaderEffectString stringvalue;

            [FieldOffset(0)] public MojoshaderEffectTexture texture;
        }

        private struct MojoshaderSamplerStateRegister
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr SamplerName;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint SamplerRegister;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint SamplerStateCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr SamplerStates;
#pragma warning restore CS0649
        }

        internal struct MOJOSHADER_effectStateChanges
        {
            public uint render_state_change_count;

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr render_state_changes;
#pragma warning restore CS0649

            public uint sampler_state_change_count;

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr sampler_state_changes;
#pragma warning restore CS0649

            public uint vertex_sampler_state_change_count;

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr vertex_sampler_state_changes;
#pragma warning restore CS0649
        }

        private struct MojoshaderEffect
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public int ErrorCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Errors;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public int ParamCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Parameters;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public int TechniqueCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Techniques;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public int ObjectCount;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr Objects;
#pragma warning restore CS0649
        }
    }
}
