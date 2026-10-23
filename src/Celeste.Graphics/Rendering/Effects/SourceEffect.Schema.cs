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

        private enum MOJOSHADER_symbolClass
        {
            MOJOSHADER_SYMCLASS_SCALAR,
            MOJOSHADER_SYMCLASS_VECTOR,
            MOJOSHADER_SYMCLASS_MATRIX_ROWS,
            MOJOSHADER_SYMCLASS_MATRIX_COLUMNS,
            MOJOSHADER_SYMCLASS_OBJECT,
            MOJOSHADER_SYMCLASS_STRUCT,
            MOJOSHADER_SYMCLASS_TOTAL
        }

        private enum MOJOSHADER_symbolType
        {
            MOJOSHADER_SYMTYPE_VOID,
            MOJOSHADER_SYMTYPE_BOOL,
            MOJOSHADER_SYMTYPE_INT,
            MOJOSHADER_SYMTYPE_FLOAT,
            MOJOSHADER_SYMTYPE_STRING,
            MOJOSHADER_SYMTYPE_TEXTURE,
            MOJOSHADER_SYMTYPE_TEXTURE1D,
            MOJOSHADER_SYMTYPE_TEXTURE2D,
            MOJOSHADER_SYMTYPE_TEXTURE3D,
            MOJOSHADER_SYMTYPE_TEXTURECUBE,
            MOJOSHADER_SYMTYPE_SAMPLER,
            MOJOSHADER_SYMTYPE_SAMPLER1D,
            MOJOSHADER_SYMTYPE_SAMPLER2D,
            MOJOSHADER_SYMTYPE_SAMPLER3D,
            MOJOSHADER_SYMTYPE_SAMPLERCUBE,
            MOJOSHADER_SYMTYPE_PIXELSHADER,
            MOJOSHADER_SYMTYPE_VERTEXSHADER,
            MOJOSHADER_SYMTYPE_PIXELFRAGMENT,
            MOJOSHADER_SYMTYPE_VERTEXFRAGMENT,
            MOJOSHADER_SYMTYPE_UNSUPPORTED,
            MOJOSHADER_SYMTYPE_TOTAL
        }

        private struct MOJOSHADER_symbolTypeInfo
        {
#pragma warning disable CS0649 // Native MojoShader writes these fields through the unmanaged schema.
            public MOJOSHADER_symbolClass parameter_class;

            public MOJOSHADER_symbolType parameter_type;

            public uint rows;

            public uint columns;

            public uint elements;

            public uint member_count;

            public IntPtr members;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_symbolStructMember
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_symbolTypeInfo info;
#pragma warning restore CS0649
        }

        private enum MOJOSHADER_renderStateType
        {
            MOJOSHADER_RS_ZENABLE = 0,
            MOJOSHADER_RS_FILLMODE = 1,
            MOJOSHADER_RS_SHADEMODE = 2,
            MOJOSHADER_RS_ZWRITEENABLE = 3,
            MOJOSHADER_RS_ALPHATESTENABLE = 4,
            MOJOSHADER_RS_LASTPIXEL = 5,
            MOJOSHADER_RS_SRCBLEND = 6,
            MOJOSHADER_RS_DESTBLEND = 7,
            MOJOSHADER_RS_CULLMODE = 8,
            MOJOSHADER_RS_ZFUNC = 9,
            MOJOSHADER_RS_ALPHAREF = 10,
            MOJOSHADER_RS_ALPHAFUNC = 11,
            MOJOSHADER_RS_DITHERENABLE = 12,
            MOJOSHADER_RS_ALPHABLENDENABLE = 13,
            MOJOSHADER_RS_FOGENABLE = 14,
            MOJOSHADER_RS_SPECULARENABLE = 15,
            MOJOSHADER_RS_FOGCOLOR = 16,
            MOJOSHADER_RS_FOGTABLEMODE = 17,
            MOJOSHADER_RS_FOGSTART = 18,
            MOJOSHADER_RS_FOGEND = 19,
            MOJOSHADER_RS_FOGDENSITY = 20,
            MOJOSHADER_RS_RANGEFOGENABLE = 21,
            MOJOSHADER_RS_STENCILENABLE = 22,
            MOJOSHADER_RS_STENCILFAIL = 23,
            MOJOSHADER_RS_STENCILZFAIL = 24,
            MOJOSHADER_RS_STENCILPASS = 25,
            MOJOSHADER_RS_STENCILFUNC = 26,
            MOJOSHADER_RS_STENCILREF = 27,
            MOJOSHADER_RS_STENCILMASK = 28,
            MOJOSHADER_RS_STENCILWRITEMASK = 29,
            MOJOSHADER_RS_TEXTUREFACTOR = 30,
            MOJOSHADER_RS_WRAP0 = 31,
            MOJOSHADER_RS_WRAP1 = 32,
            MOJOSHADER_RS_WRAP2 = 33,
            MOJOSHADER_RS_WRAP3 = 34,
            MOJOSHADER_RS_WRAP4 = 35,
            MOJOSHADER_RS_WRAP5 = 36,
            MOJOSHADER_RS_WRAP6 = 37,
            MOJOSHADER_RS_WRAP7 = 38,
            MOJOSHADER_RS_WRAP8 = 39,
            MOJOSHADER_RS_WRAP9 = 40,
            MOJOSHADER_RS_WRAP10 = 41,
            MOJOSHADER_RS_WRAP11 = 42,
            MOJOSHADER_RS_WRAP12 = 43,
            MOJOSHADER_RS_WRAP13 = 44,
            MOJOSHADER_RS_WRAP14 = 45,
            MOJOSHADER_RS_WRAP15 = 46,
            MOJOSHADER_RS_CLIPPING = 47,
            MOJOSHADER_RS_LIGHTING = 48,
            MOJOSHADER_RS_AMBIENT = 49,
            MOJOSHADER_RS_FOGVERTEXMODE = 50,
            MOJOSHADER_RS_COLORVERTEX = 51,
            MOJOSHADER_RS_LOCALVIEWER = 52,
            MOJOSHADER_RS_NORMALIZENORMALS = 53,
            MOJOSHADER_RS_DIFFUSEMATERIALSOURCE = 54,
            MOJOSHADER_RS_SPECULARMATERIALSOURCE = 55,
            MOJOSHADER_RS_AMBIENTMATERIALSOURCE = 56,
            MOJOSHADER_RS_EMISSIVEMATERIALSOURCE = 57,
            MOJOSHADER_RS_VERTEXBLEND = 58,
            MOJOSHADER_RS_CLIPPLANEENABLE = 59,
            MOJOSHADER_RS_POINTSIZE = 60,
            MOJOSHADER_RS_POINTSIZE_MIN = 61,
            MOJOSHADER_RS_POINTSPRITEENABLE = 62,
            MOJOSHADER_RS_POINTSCALEENABLE = 63,
            MOJOSHADER_RS_POINTSCALE_A = 64,
            MOJOSHADER_RS_POINTSCALE_B = 65,
            MOJOSHADER_RS_POINTSCALE_C = 66,
            MOJOSHADER_RS_MULTISAMPLEANTIALIAS = 67,
            MOJOSHADER_RS_MULTISAMPLEMASK = 68,
            MOJOSHADER_RS_PATCHEDGESTYLE = 69,
            MOJOSHADER_RS_DEBUGMONITORTOKEN = 70,
            MOJOSHADER_RS_POINTSIZE_MAX = 71,
            MOJOSHADER_RS_INDEXEDVERTEXBLENDENABLE = 72,
            MOJOSHADER_RS_COLORWRITEENABLE = 73,
            MOJOSHADER_RS_TWEENFACTOR = 74,
            MOJOSHADER_RS_BLENDOP = 75,
            MOJOSHADER_RS_POSITIONDEGREE = 76,
            MOJOSHADER_RS_NORMALDEGREE = 77,
            MOJOSHADER_RS_SCISSORTESTENABLE = 78,
            MOJOSHADER_RS_SLOPESCALEDEPTHBIAS = 79,
            MOJOSHADER_RS_ANTIALIASEDLINEENABLE = 80,
            MOJOSHADER_RS_MINTESSELLATIONLEVEL = 81,
            MOJOSHADER_RS_MAXTESSELLATIONLEVEL = 82,
            MOJOSHADER_RS_ADAPTIVETESS_X = 83,
            MOJOSHADER_RS_ADAPTIVETESS_Y = 84,
            MOJOSHADER_RS_ADAPTIVETESS_Z = 85,
            MOJOSHADER_RS_ADAPTIVETESS_W = 86,
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
            MOJOSHADER_RS_SRGBWRITEENABLE = 97,
            MOJOSHADER_RS_DEPTHBIAS = 98,
            MOJOSHADER_RS_SEPARATEALPHABLENDENABLE = 99,
            MOJOSHADER_RS_SRCBLENDALPHA = 100,
            MOJOSHADER_RS_DESTBLENDALPHA = 101,
            MOJOSHADER_RS_BLENDOPALPHA = 102,
            MOJOSHADER_RS_VERTEXSHADER = 146,
            MOJOSHADER_RS_PIXELSHADER = 147
        }

        private enum MOJOSHADER_zBufferType
        {
            MOJOSHADER_ZB_FALSE,
            MOJOSHADER_ZB_TRUE,
            MOJOSHADER_ZB_USEW
        }

        private enum MOJOSHADER_fillMode
        {
            MOJOSHADER_FILL_POINT = 1,
            MOJOSHADER_FILL_WIREFRAME,
            MOJOSHADER_FILL_SOLID
        }

        private enum MOJOSHADER_blendMode
        {
            MOJOSHADER_BLEND_ZERO = 1,
            MOJOSHADER_BLEND_ONE,
            MOJOSHADER_BLEND_SRCCOLOR,
            MOJOSHADER_BLEND_INVSRCCOLOR,
            MOJOSHADER_BLEND_SRCALPHA,
            MOJOSHADER_BLEND_INVSRCALPHA,
            MOJOSHADER_BLEND_DESTALPHA,
            MOJOSHADER_BLEND_INVDESTALPHA,
            MOJOSHADER_BLEND_DESTCOLOR,
            MOJOSHADER_BLEND_INVDESTCOLOR,
            MOJOSHADER_BLEND_SRCALPHASAT,
            MOJOSHADER_BLEND_BOTHSRCALPHA,
            MOJOSHADER_BLEND_BOTHINVSRCALPHA,
            MOJOSHADER_BLEND_BLENDFACTOR,
            MOJOSHADER_BLEND_INVBLENDFACTOR,
            MOJOSHADER_BLEND_SRCCOLOR2,
            MOJOSHADER_BLEND_INVSRCCOLOR2
        }

        private enum MOJOSHADER_cullMode
        {
            MOJOSHADER_CULL_NONE = 1,
            MOJOSHADER_CULL_CW,
            MOJOSHADER_CULL_CCW
        }

        private enum MOJOSHADER_compareFunc
        {
            MOJOSHADER_CMP_NEVER = 1,
            MOJOSHADER_CMP_LESS,
            MOJOSHADER_CMP_EQUAL,
            MOJOSHADER_CMP_LESSEQUAL,
            MOJOSHADER_CMP_GREATER,
            MOJOSHADER_CMP_NOTEQUAL,
            MOJOSHADER_CMP_GREATEREQUAL,
            MOJOSHADER_CMP_ALWAYS
        }

        private enum MOJOSHADER_stencilOp
        {
            MOJOSHADER_STENCILOP_KEEP = 1,
            MOJOSHADER_STENCILOP_ZERO,
            MOJOSHADER_STENCILOP_REPLACE,
            MOJOSHADER_STENCILOP_INCRSAT,
            MOJOSHADER_STENCILOP_DECRSAT,
            MOJOSHADER_STENCILOP_INVERT,
            MOJOSHADER_STENCILOP_INCR,
            MOJOSHADER_STENCILOP_DECR
        }

        private enum MOJOSHADER_blendOp
        {
            MOJOSHADER_BLENDOP_ADD = 1,
            MOJOSHADER_BLENDOP_SUBTRACT,
            MOJOSHADER_BLENDOP_REVSUBTRACT,
            MOJOSHADER_BLENDOP_MIN,
            MOJOSHADER_BLENDOP_MAX
        }

        private enum MOJOSHADER_samplerStateType
        {
            MOJOSHADER_SAMP_UNKNOWN0,
            MOJOSHADER_SAMP_UNKNOWN1,
            MOJOSHADER_SAMP_UNKNOWN2,
            MOJOSHADER_SAMP_UNKNOWN3,
            MOJOSHADER_SAMP_TEXTURE,
            MOJOSHADER_SAMP_ADDRESSU,
            MOJOSHADER_SAMP_ADDRESSV,
            MOJOSHADER_SAMP_ADDRESSW,
            MOJOSHADER_SAMP_BORDERCOLOR,
            MOJOSHADER_SAMP_MAGFILTER,
            MOJOSHADER_SAMP_MINFILTER,
            MOJOSHADER_SAMP_MIPFILTER,
            MOJOSHADER_SAMP_MIPMAPLODBIAS,
            MOJOSHADER_SAMP_MAXMIPLEVEL,
            MOJOSHADER_SAMP_MAXANISOTROPY,
            MOJOSHADER_SAMP_SRGBTEXTURE,
            MOJOSHADER_SAMP_ELEMENTINDEX,
            MOJOSHADER_SAMP_DMAPOFFSET
        }

        private enum MOJOSHADER_textureAddress
        {
            MOJOSHADER_TADDRESS_WRAP = 1,
            MOJOSHADER_TADDRESS_MIRROR,
            MOJOSHADER_TADDRESS_CLAMP,
            MOJOSHADER_TADDRESS_BORDER,
            MOJOSHADER_TADDRESS_MIRRORONCE
        }

        private enum MOJOSHADER_textureFilterType
        {
            MOJOSHADER_TEXTUREFILTER_NONE,
            MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_TEXTUREFILTER_ANISOTROPIC,
            MOJOSHADER_TEXTUREFILTER_PYRAMIDALQUAD,
            MOJOSHADER_TEXTUREFILTER_GAUSSIANQUAD,
            MOJOSHADER_TEXTUREFILTER_CONVOLUTIONMONO
        }

        private struct MOJOSHADER_effectValue
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr semantic;
#pragma warning restore CS0649

            public MOJOSHADER_symbolTypeInfo type;

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint value_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr values;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectState
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_renderStateType type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_effectValue value;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectSamplerState
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_samplerStateType type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_effectValue value;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectAnnotation
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr semantic;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_symbolTypeInfo type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint value_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr values;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectParam
        {
            public MOJOSHADER_effectValue value;

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint annotation_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr annotations;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectPass
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint state_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr states;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint annotation_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr annotations;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectTechnique
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint pass_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr passes;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint annotation_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr annotations;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectShader
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_symbolType type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint technique;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint pass;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint is_preshader;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint preshader_param_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr preshader_params;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint param_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr parameters;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint sampler_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr samplers;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr shader;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectSamplerMap
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_symbolType type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr name;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectString
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_symbolType type;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr stringvalue;
#pragma warning restore CS0649
        }

        private struct MOJOSHADER_effectTexture
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public MOJOSHADER_symbolType type;
#pragma warning restore CS0649
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct MOJOSHADER_effectObject
        {
            [FieldOffset(0)] public MOJOSHADER_symbolType type;

            [FieldOffset(0)] public MOJOSHADER_effectShader shader;

            [FieldOffset(0)] public MOJOSHADER_effectSamplerMap mapping;

            [FieldOffset(0)] public MOJOSHADER_effectString stringvalue;

            [FieldOffset(0)] public MOJOSHADER_effectTexture texture;
        }

        private struct MOJOSHADER_samplerStateRegister
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr sampler_name;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint sampler_register;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public uint sampler_state_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr sampler_states;
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

        private struct MOJOSHADER_effect
        {
#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public int error_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr errors;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public int param_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr parameters;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public int technique_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr techniques;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public int object_count;
#pragma warning restore CS0649

#pragma warning disable CS0649 // Native MojoShader writes this field through the unmanaged schema.
            public IntPtr objects;
#pragma warning restore CS0649
        }
    }
}
