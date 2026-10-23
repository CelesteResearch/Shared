using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Celeste.Core.Interop;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering.Effects
{
    public partial class SourceEffect : SourceGraphicsResource
    {
        internal ISourceEffectDevice EffectDevice => (ISourceEffectDevice)GraphicsDevice;
        private SourceEffectTechnique INTERNAL_currentTechnique;

        internal IntPtr glEffect;
        public IntPtr NativeEffectHandle => glEffect;

        private readonly Dictionary<IntPtr, SourceEffectParameter> samplerMap = new(new IntPtrBoxlessComparer());

        private readonly IntPtr effectData;

        private static readonly SourceEffectParameterType[] XNAType =
        [
            SourceEffectParameterType.Void,
            SourceEffectParameterType.Bool,
            SourceEffectParameterType.Int32,
            SourceEffectParameterType.Single,
            SourceEffectParameterType.String,
            SourceEffectParameterType.Texture,
            SourceEffectParameterType.Texture1D,
            SourceEffectParameterType.Texture2D,
            SourceEffectParameterType.Texture3D,
            SourceEffectParameterType.TextureCube,
        ];

        private static readonly SourceEffectParameterClass[] XNAClass =
        [
            SourceEffectParameterClass.Scalar,
            SourceEffectParameterClass.Vector,
            SourceEffectParameterClass.Matrix,
            SourceEffectParameterClass.Matrix,
            SourceEffectParameterClass.Object,
            SourceEffectParameterClass.Struct,
        ];

        private static readonly SourceBlendFactor[] XNABlend =
        [
            (SourceBlendFactor)(-1),
            SourceBlendFactor.Zero,
            SourceBlendFactor.One,
            SourceBlendFactor.SourceColor,
            SourceBlendFactor.InverseSourceColor,
            SourceBlendFactor.SourceAlpha,
            SourceBlendFactor.InverseSourceAlpha,
            SourceBlendFactor.DestinationAlpha,
            SourceBlendFactor.InverseDestinationAlpha,
            SourceBlendFactor.DestinationColor,
            SourceBlendFactor.InverseDestinationColor,
            SourceBlendFactor.SourceAlphaSaturation,
            (SourceBlendFactor)(-1),
            (SourceBlendFactor)(-1),
            SourceBlendFactor.BlendFactor,
            SourceBlendFactor.InverseBlendFactor,
        ];

        private static readonly SourceBlendFunction[] XNABlendOp =
        [
            (SourceBlendFunction)(-1),
            SourceBlendFunction.Add,
            SourceBlendFunction.Subtract,
            SourceBlendFunction.ReverseSubtract,
            SourceBlendFunction.Min,
            SourceBlendFunction.Max,
        ];

        private static readonly SourceCompareFunction[] XNACompare =
        [
            (SourceCompareFunction)(-1),
            SourceCompareFunction.Never,
            SourceCompareFunction.Less,
            SourceCompareFunction.Equal,
            SourceCompareFunction.LessEqual,
            SourceCompareFunction.Greater,
            SourceCompareFunction.NotEqual,
            SourceCompareFunction.GreaterEqual,
            SourceCompareFunction.Always,
        ];

        private static readonly SourceStencilOperation[] XNAStencilOp =
        [
            (SourceStencilOperation)(-1),
            SourceStencilOperation.Keep,
            SourceStencilOperation.Zero,
            SourceStencilOperation.Replace,
            SourceStencilOperation.IncrementSaturation,
            SourceStencilOperation.DecrementSaturation,
            SourceStencilOperation.Invert,
            SourceStencilOperation.Increment,
            SourceStencilOperation.Decrement,
        ];

        private static readonly SourceTextureAddressMode[] XNAAddress =
        [
            (SourceTextureAddressMode)(-1),
            SourceTextureAddressMode.Wrap,
            SourceTextureAddressMode.Mirror,
            SourceTextureAddressMode.Clamp,
        ];

        private static readonly MojoshaderTextureFilterType[] XNAMag =
        [
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
        ];

        private static readonly MojoshaderTextureFilterType[] XNAMin =
        [
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
        ];

        private static readonly MojoshaderTextureFilterType[] XNAMip =
        [
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
        ];

        public SourceEffectTechnique CurrentTechnique
        {
            get => INTERNAL_currentTechnique;
            set
            {
                EffectDevice.SetEffectTechnique(glEffect, value.TechniquePointer);
                INTERNAL_currentTechnique = value;
            }
        }

        public SourceEffectParameterCollection Parameters { get; private set; }

        public SourceEffectTechniqueCollection Techniques { get; private set; }

        public SourceEffect(ISourceEffectDevice graphicsDevice, byte[] effectCode)
        {
            GraphicsDevice = graphicsDevice;
            graphicsDevice.CreateEffect(effectCode, effectCode.Length, out glEffect, out var intPtr);
            effectData = intPtr;
            INTERNAL_parseEffectStruct(intPtr);
            CurrentTechnique = Techniques[0];
        }

        protected SourceEffect(SourceEffect cloneSource)
        {
            GraphicsDevice = cloneSource.GraphicsDevice;
            EffectDevice.CloneEffect(cloneSource.glEffect, out glEffect, out var intPtr);
            effectData = intPtr;
            INTERNAL_parseEffectStruct(intPtr);
            for (var i = 0; i < cloneSource.Parameters.Count; i++)
                Parameters[i].texture = cloneSource.Parameters[i].texture;

            for (var j = 0; j < cloneSource.Techniques.Count; j++)
                if (cloneSource.Techniques[j] == cloneSource.CurrentTechnique)
                    CurrentTechnique = Techniques[j];
        }

        public virtual SourceEffect Clone()
        {
            return new(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                var intPtr = Interlocked.Exchange(ref glEffect, IntPtr.Zero);
                if (intPtr != IntPtr.Zero) EffectDevice.AddDisposeEffect(intPtr);
            }

            base.Dispose(disposing);
        }

        protected internal virtual void OnApply()
        {
        }

        internal unsafe void INTERNAL_applyEffect(uint pass)
        {
            EffectDevice.ApplyEffect(glEffect, pass, EffectDevice.EffectStateChangesPointer);
            var ptr =
                (MOJOSHADER_effectStateChanges*)(void*)EffectDevice.EffectStateChangesPointer;
            if (ptr->render_state_change_count != 0)
            {
                var pipelineCache = EffectDevice.PipelineCache;
                pipelineCache.BeginApplyBlend();
                pipelineCache.BeginApplyDepthStencil();
                pipelineCache.BeginApplyRasterizer();
                var flag = false;
                var flag2 = false;
                var flag3 = false;
                var ptr2 = (MojoshaderEffectState*)(void*)ptr->render_state_changes;
                for (var i = 0; i < ptr->render_state_change_count; i++)
                {
                    var type = ptr2[i].Type;
                    switch (type)
                    {
                        case MojoshaderRenderStateType.MOJOSHADER_RS_ZENABLE:
                        {
                            var ptr32 = (MojoshaderZBufferType*)(void*)ptr2[i].Value.Values;
                            pipelineCache.DepthBufferEnable = *ptr32 == MojoshaderZBufferType.MojoshaderZbTrue;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_FILLMODE:
                        {
                            var ptr37 = (MojoshaderFillMode*)(void*)ptr2[i].Value.Values;
                            if (*ptr37 == MojoshaderFillMode.MojoshaderFillSolid)
                                pipelineCache.FillMode = SourceFillMode.Solid;
                            else if (*ptr37 == MojoshaderFillMode.MojoshaderFillWireframe)
                                pipelineCache.FillMode = SourceFillMode.WireFrame;

                            flag3 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_ZWRITEENABLE:
                        {
                            var ptr36 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.DepthBufferWriteEnable = *ptr36 == 1;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_SRCBLEND:
                        {
                            var ptr38 = (MojoshaderBlendMode*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ColorSourceBlend = XNABlend[(int)*ptr38];
                            if (!pipelineCache.SeparateAlphaBlend)
                                pipelineCache.AlphaSourceBlend = XNABlend[(int)*ptr38];

                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_DESTBLEND:
                        {
                            var ptr35 = (MojoshaderBlendMode*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ColorDestinationBlend = XNABlend[(int)*ptr35];
                            if (!pipelineCache.SeparateAlphaBlend)
                                pipelineCache.AlphaDestinationBlend = XNABlend[(int)*ptr35];

                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_CULLMODE:
                        {
                            var ptr34 = (MojoshaderCullMode*)(void*)ptr2[i].Value.Values;
                            if (*ptr34 == MojoshaderCullMode.MojoshaderCullNone)
                                pipelineCache.CullMode = SourceCullMode.None;
                            else if (*ptr34 == MojoshaderCullMode.MojoshaderCullCw)
                                pipelineCache.CullMode = SourceCullMode.CullClockwiseFace;
                            else if (*ptr34 == MojoshaderCullMode.MojoshaderCullCcw)
                                pipelineCache.CullMode = SourceCullMode.CullCounterClockwiseFace;

                            flag3 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_ZFUNC:
                        {
                            var ptr33 = (MojoshaderCompareFunc*)(void*)ptr2[i].Value.Values;
                            pipelineCache.DepthBufferFunction = XNACompare[(int)*ptr33];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_ALPHABLENDENABLE:
                        {
                            var ptr31 = (int*)(void*)ptr2[i].Value.Values;
                            if (*ptr31 == 0)
                            {
                                pipelineCache.ColorSourceBlend = SourceBlendFactor.One;
                                pipelineCache.ColorDestinationBlend = SourceBlendFactor.Zero;
                                pipelineCache.AlphaSourceBlend = SourceBlendFactor.One;
                                pipelineCache.AlphaDestinationBlend = SourceBlendFactor.Zero;
                                flag = true;
                            }

                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_STENCILENABLE:
                        {
                            var ptr30 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.StencilEnable = *ptr30 == 1;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_STENCILFAIL:
                        {
                            var ptr29 = (MojoshaderStencilOp*)(void*)ptr2[i].Value.Values;
                            pipelineCache.StencilFail = XNAStencilOp[(int)*ptr29];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_STENCILZFAIL:
                        {
                            var ptr28 = (MojoshaderStencilOp*)(void*)ptr2[i].Value.Values;
                            pipelineCache.StencilDepthBufferFail = XNAStencilOp[(int)*ptr28];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_STENCILPASS:
                        {
                            var ptr27 = (MojoshaderStencilOp*)(void*)ptr2[i].Value.Values;
                            pipelineCache.StencilPass = XNAStencilOp[(int)*ptr27];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_STENCILFUNC:
                        {
                            var ptr26 = (MojoshaderCompareFunc*)(void*)ptr2[i].Value.Values;
                            pipelineCache.StencilFunction = XNACompare[(int)*ptr26];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_STENCILREF:
                        {
                            var ptr25 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ReferenceStencil = *ptr25;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_STENCILMASK:
                        {
                            var ptr24 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.StencilMask = *ptr24;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_STENCILWRITEMASK:
                        {
                            var ptr23 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.StencilWriteMask = *ptr23;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_MULTISAMPLEANTIALIAS:
                        {
                            var ptr22 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.MultiSampleAntiAlias = *ptr22 == 1;
                            flag3 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_MULTISAMPLEMASK:
                        {
                            var ptr21 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.MultiSampleMask = *ptr21;
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_COLORWRITEENABLE:
                        {
                            var ptr20 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ColorWriteChannels = (SourceColorWriteChannels)(*ptr20);
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_BLENDOP:
                        {
                            var ptr19 = (MojoshaderBlendOp*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ColorBlendFunction = XNABlendOp[(int)*ptr19];
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_SCISSORTESTENABLE:
                        {
                            var ptr18 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ScissorTestEnable = *ptr18 == 1;
                            flag3 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_SLOPESCALEDEPTHBIAS:
                        {
                            var ptr17 = (float*)(void*)ptr2[i].Value.Values;
                            pipelineCache.SlopeScaleDepthBias = *ptr17;
                            flag3 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_TWOSIDEDSTENCILMODE:
                        {
                            var ptr16 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.TwoSidedStencilMode = *ptr16 == 1;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_CCW_STENCILFAIL:
                        {
                            var ptr15 = (MojoshaderStencilOp*)(void*)ptr2[i].Value.Values;
                            pipelineCache.CCWStencilFail = XNAStencilOp[(int)*ptr15];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_CCW_STENCILZFAIL:
                        {
                            var ptr14 = (MojoshaderStencilOp*)(void*)ptr2[i].Value.Values;
                            pipelineCache.CCWStencilDepthBufferFail = XNAStencilOp[(int)*ptr14];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_CCW_STENCILPASS:
                        {
                            var ptr13 = (MojoshaderStencilOp*)(void*)ptr2[i].Value.Values;
                            pipelineCache.CCWStencilPass = XNAStencilOp[(int)*ptr13];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_CCW_STENCILFUNC:
                        {
                            var ptr12 = (MojoshaderCompareFunc*)(void*)ptr2[i].Value.Values;
                            pipelineCache.CCWStencilFunction = XNACompare[(int)*ptr12];
                            flag2 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_COLORWRITEENABLE1:
                        {
                            var ptr11 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ColorWriteChannels1 = (SourceColorWriteChannels)(*ptr11);
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_COLORWRITEENABLE2:
                        {
                            var ptr10 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ColorWriteChannels2 = (SourceColorWriteChannels)(*ptr10);
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_COLORWRITEENABLE3:
                        {
                            var ptr9 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.ColorWriteChannels3 = (SourceColorWriteChannels)(*ptr9);
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_BLENDFACTOR:
                        {
                            var ptr8 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.BlendFactor = new((*ptr8 >> 24) & 0xFF, (*ptr8 >> 16) & 0xFF,
                                (*ptr8 >> 8) & 0xFF, *ptr8 & 0xFF);
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_DEPTHBIAS:
                        {
                            var ptr7 = (float*)(void*)ptr2[i].Value.Values;
                            pipelineCache.DepthBias = *ptr7;
                            flag3 = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_SEPARATEALPHABLENDENABLE:
                        {
                            var ptr6 = (int*)(void*)ptr2[i].Value.Values;
                            pipelineCache.SeparateAlphaBlend = *ptr6 == 1;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_SRCBLENDALPHA:
                        {
                            var ptr5 = (MojoshaderBlendMode*)(void*)ptr2[i].Value.Values;
                            pipelineCache.AlphaSourceBlend = XNABlend[(int)*ptr5];
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_DESTBLENDALPHA:
                        {
                            var ptr4 = (MojoshaderBlendMode*)(void*)ptr2[i].Value.Values;
                            pipelineCache.AlphaDestinationBlend = XNABlend[(int)*ptr4];
                            flag = true;
                            break;
                        }
                        case MojoshaderRenderStateType.MOJOSHADER_RS_BLENDOPALPHA:
                        {
                            var ptr3 = (MojoshaderBlendOp*)(void*)ptr2[i].Value.Values;
                            pipelineCache.AlphaBlendFunction = XNABlendOp[(int)*ptr3];
                            flag = true;
                            break;
                        }
                        default:
                            throw new NotImplementedException("Unhandled render state! " + type);
                        case MojoshaderRenderStateType.MOJOSHADER_RS_VERTEXSHADER:
                        case MojoshaderRenderStateType.MOJOSHADER_RS_PIXELSHADER:
                        case (MojoshaderRenderStateType)178:
                            break;
                    }
                }

                if (flag) pipelineCache.EndApplyBlend();

                if (flag2) pipelineCache.EndApplyDepthStencil();

                if (flag3) pipelineCache.EndApplyRasterizer();
            }

            if (ptr->sampler_state_change_count != 0)
                INTERNAL_updateSamplers(ptr->sampler_state_change_count,
                    (MojoshaderSamplerStateRegister*)(void*)ptr->sampler_state_changes, EffectDevice.Textures,
                    EffectDevice.SamplerStates);

            if (ptr->vertex_sampler_state_change_count != 0)
                INTERNAL_updateSamplers(ptr->vertex_sampler_state_change_count,
                    (MojoshaderSamplerStateRegister*)(void*)ptr->vertex_sampler_state_changes,
                    EffectDevice.VertexTextures,
                    EffectDevice.VertexSamplerStates);
        }

        private unsafe void INTERNAL_updateSamplers(uint changeCount, MojoshaderSamplerStateRegister* registers,
            SourceTextureCollection textures, SourceSamplerStateCollection samplers)
        {
            for (var i = 0; i < changeCount; i++)
            {
                if (registers[i].SamplerStateCount == 0) continue;

                var samplerRegister = (int)registers[i].SamplerRegister;
                var pipelineCache = EffectDevice.PipelineCache;
                pipelineCache.BeginApplySampler(samplers, samplerRegister);
                var flag = false;
                var flag2 = false;
                var filter = pipelineCache.Filter;
                var mOjoshaderTextureFilterType = XNAMag[(int)filter];
                var mOjoshaderTextureFilterType2 = XNAMin[(int)filter];
                var mOjoshaderTextureFilterType3 = XNAMip[(int)filter];
                var ptr = (MojoshaderEffectSamplerState*)(void*)registers[i].SamplerStates;
                for (var j = 0; j < registers[i].SamplerStateCount; j++)
                {
                    var type = ptr[j].Type;
                    switch (type)
                    {
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_TEXTURE:
                        {
                            if (samplerMap.TryGetValue(registers[i].SamplerName, out var value))
                            {
                                var texture = value.texture;
                                if (texture != null) textures[samplerRegister] = texture;
                            }

                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_ADDRESSU:
                        {
                            var ptr10 = (MojoshaderTextureAddress*)(void*)ptr[j].Value.Values;
                            pipelineCache.AddressU = XNAAddress[(int)*ptr10];
                            flag = true;
                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_ADDRESSV:
                        {
                            var ptr9 = (MojoshaderTextureAddress*)(void*)ptr[j].Value.Values;
                            pipelineCache.AddressV = XNAAddress[(int)*ptr9];
                            flag = true;
                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_ADDRESSW:
                        {
                            var ptr8 = (MojoshaderTextureAddress*)(void*)ptr[j].Value.Values;
                            pipelineCache.AddressW = XNAAddress[(int)*ptr8];
                            flag = true;
                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_MAGFILTER:
                        {
                            var ptr7 =
                                (MojoshaderTextureFilterType*)(void*)ptr[j].Value.Values;
                            mOjoshaderTextureFilterType = *ptr7;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_MINFILTER:
                        {
                            var ptr6 =
                                (MojoshaderTextureFilterType*)(void*)ptr[j].Value.Values;
                            mOjoshaderTextureFilterType2 = *ptr6;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_MIPFILTER:
                        {
                            var ptr5 =
                                (MojoshaderTextureFilterType*)(void*)ptr[j].Value.Values;
                            mOjoshaderTextureFilterType3 = *ptr5;
                            flag2 = true;
                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_MIPMAPLODBIAS:
                        {
                            var ptr4 = (float*)(void*)ptr[j].Value.Values;
                            pipelineCache.MipMapLODBias = *ptr4;
                            flag = true;
                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_MAXMIPLEVEL:
                        {
                            var ptr3 = (int*)(void*)ptr[j].Value.Values;
                            pipelineCache.MaxMipLevel = *ptr3;
                            flag = true;
                            break;
                        }
                        case MojoshaderSamplerStateType.MOJOSHADER_SAMP_MAXANISOTROPY:
                        {
                            var ptr2 = (int*)(void*)ptr[j].Value.Values;
                            pipelineCache.MaxAnisotropy = *ptr2;
                            flag = true;
                            break;
                        }
                        default:
                            throw new NotImplementedException("Unhandled sampler state! " + type);
                    }
                }

                if (flag2)
                {
                    switch (mOjoshaderTextureFilterType)
                    {
                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                            switch (mOjoshaderTextureFilterType2)
                            {
                                case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                    switch (mOjoshaderTextureFilterType3)
                                    {
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_NONE:
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                            pipelineCache.Filter = SourceTextureFilter.Point;
                                            break;
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                            pipelineCache.Filter = SourceTextureFilter.PointMipLinear;
                                            break;
                                        default:
                                            throw new NotImplementedException("Unhandled mipfilter type! " +
                                                                              mOjoshaderTextureFilterType3);
                                    }

                                    break;
                                case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                    switch (mOjoshaderTextureFilterType3)
                                    {
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_NONE:
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                            pipelineCache.Filter = SourceTextureFilter.MinLinearMagPointMipPoint;
                                            break;
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                            pipelineCache.Filter = SourceTextureFilter.MinLinearMagPointMipLinear;
                                            break;
                                        default:
                                            throw new NotImplementedException("Unhandled mipfilter type! " +
                                                                              mOjoshaderTextureFilterType3);
                                    }

                                    break;
                                default:
                                    throw new NotImplementedException("Unhandled minfilter type! " +
                                                                      mOjoshaderTextureFilterType2);
                            }

                            break;
                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                            switch (mOjoshaderTextureFilterType2)
                            {
                                case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                    switch (mOjoshaderTextureFilterType3)
                                    {
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_NONE:
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                            pipelineCache.Filter = SourceTextureFilter.MinPointMagLinearMipPoint;
                                            break;
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                            pipelineCache.Filter = SourceTextureFilter.MinPointMagLinearMipLinear;
                                            break;
                                        default:
                                            throw new NotImplementedException("Unhandled mipfilter type! " +
                                                                              mOjoshaderTextureFilterType3);
                                    }

                                    break;
                                case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                    switch (mOjoshaderTextureFilterType3)
                                    {
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_NONE:
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                            pipelineCache.Filter = SourceTextureFilter.LinearMipPoint;
                                            break;
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                        case MojoshaderTextureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                            pipelineCache.Filter = SourceTextureFilter.Linear;
                                            break;
                                        default:
                                            throw new NotImplementedException("Unhandled mipfilter type! " +
                                                                              mOjoshaderTextureFilterType3);
                                    }

                                    break;
                                default:
                                    throw new NotImplementedException("Unhandled minfilter type! " +
                                                                      mOjoshaderTextureFilterType2);
                            }

                            break;
                        default:
                            throw new NotImplementedException("Unhandled magfilter type! " +
                                                              mOjoshaderTextureFilterType);
                    }

                    flag = true;
                }

                if (flag) pipelineCache.EndApplySampler(samplers, samplerRegister);
            }
        }

        private unsafe void INTERNAL_parseEffectStruct(IntPtr effectData)
        {
            var ptr = (MojoshaderEffect*)(void*)effectData;
            var ptr2 = (MojoshaderEffectParam*)(void*)ptr->Parameters;
            var list = new List<SourceEffectParameter>();
            for (var i = 0; i < ptr->ParamCount; i++)
            {
                var mOjoshaderEffectParam = ptr2[i];
                if (mOjoshaderEffectParam.Value.Type.ParameterType ==
                    MojoshaderSymbolType.MojoshaderSymtypeVertexshader ||
                    mOjoshaderEffectParam.Value.Type.ParameterType ==
                    MojoshaderSymbolType.MojoshaderSymtypePixelshader)
                    continue;

                if (mOjoshaderEffectParam.Value.Type.ParameterType >=
                    MojoshaderSymbolType.MojoshaderSymtypeSampler &&
                    mOjoshaderEffectParam.Value.Type.ParameterType <=
                    MojoshaderSymbolType.MojoshaderSymtypeSamplercube)
                {
                    var text = string.Empty;
                    var ptr3 =
                        (MojoshaderEffectSamplerState*)(void*)mOjoshaderEffectParam.Value.Values;
                    for (var j = 0; j < mOjoshaderEffectParam.Value.ValueCount; j++)
                        if (ptr3[j].Value.Type.ParameterType >= MojoshaderSymbolType.MojoshaderSymtypeTexture &&
                            ptr3[j].Value.Type.ParameterType <= MojoshaderSymbolType.MojoshaderSymtypeTexturecube)
                        {
                            var ptr4 = (MojoshaderEffectObject*)(void*)ptr->Objects;
                            var ptr5 = (int*)(void*)ptr3[j].Value.Values;
                            text = Marshal.PtrToStringAnsi(ptr4[*ptr5].mapping.Name);
                            break;
                        }

                    for (var k = 0; k < list.Count; k++)
                        if (text.Equals(list[k].Name))
                        {
                            samplerMap[mOjoshaderEffectParam.Value.Name] = list[k];
                            break;
                        }
                }
                else
                {
                    var effectParameter = new SourceEffectParameter(
                        SourceMarshalHelper.PtrToInternedStringAnsi(mOjoshaderEffectParam.Value.Name),
                        SourceMarshalHelper.PtrToInternedStringAnsi(mOjoshaderEffectParam.Value.Semantic),
                        (int)mOjoshaderEffectParam.Value.Type.Rows, (int)mOjoshaderEffectParam.Value.Type.Columns,
                        (int)mOjoshaderEffectParam.Value.Type.Elements,
                        XNAClass[(int)mOjoshaderEffectParam.Value.Type.ParameterClass],
                        XNAType[(int)mOjoshaderEffectParam.Value.Type.ParameterType], new IntPtr(&ptr2[i].Value.Type),
                        INTERNAL_readAnnotations(mOjoshaderEffectParam.Annotations,
                            mOjoshaderEffectParam.AnnotationCount), mOjoshaderEffectParam.Value.Values,
                        mOjoshaderEffectParam.Value.ValueCount * 4, this);
                    if (mOjoshaderEffectParam.Value.Type.ParameterType ==
                        MojoshaderSymbolType.MojoshaderSymtypeString)
                    {
                        var ptr6 = (int*)(void*)mOjoshaderEffectParam.Value.Values;
                        effectParameter.cachedString = INTERNAL_GetStringFromObjectTable(*ptr6);
                    }

                    list.Add(effectParameter);
                }
            }

            Parameters = new(list);
            var ptr7 = (MojoshaderEffectTechnique*)(void*)ptr->Techniques;
            var list2 = new List<SourceEffectTechnique>(ptr->TechniqueCount);
            var num = 0;
            while (num < list2.Capacity)
            {
                var ptr8 = (MojoshaderEffectPass*)(void*)ptr7->Passes;
                SourceEffectPassCollection passes;
                if (ptr7->PassCount == 1)
                {
                    passes = new(INTERNAL_readPass(ref *ptr8, (IntPtr)ptr7, 0u));
                }
                else
                {
                    var list3 = new List<SourceEffectPass>((int)ptr7->PassCount);
                    for (var l = 0; l < list3.Capacity; l++)
                        list3.Add(INTERNAL_readPass(ref ptr8[l], (IntPtr)ptr7, (uint)l));

                    passes = new(list3);
                }

                list2.Add(new(SourceMarshalHelper.PtrToInternedStringAnsi(ptr7->Name),
                    (IntPtr)ptr7,
                    passes, INTERNAL_readAnnotations(ptr7->Annotations, ptr7->AnnotationCount)));
                num++;
                ptr7++;
            }

            Techniques = new(list2);
        }

        internal static unsafe SourceEffectParameterCollection INTERNAL_readEffectParameterStructureMembers(
            SourceEffectParameter parameter, IntPtr _type, SourceEffect outer)
        {
            if (_type == IntPtr.Zero) return null;

            var mOjoshaderSymbolTypeInfo = *(MojoshaderSymbolTypeInfo*)(void*)_type;
            SourceEffectParameterCollection result = null;
            if (mOjoshaderSymbolTypeInfo.MemberCount != 0)
            {
                var list = new List<SourceEffectParameter>();
                var ptr =
                    (MojoshaderSymbolStructMember*)(void*)mOjoshaderSymbolTypeInfo.Members;
                var zero = IntPtr.Zero;
                for (var i = 0; i < mOjoshaderSymbolTypeInfo.MemberCount; i++)
                {
                    var num = ptr[i].Info.Rows * ptr[i].Info.Columns;
                    if (ptr[i].Info.Elements != 0) num *= ptr[i].Info.Elements;

                    var effectParameter = new SourceEffectParameter(
                        SourceMarshalHelper.PtrToInternedStringAnsi(ptr[i].Name), null, (int)ptr[i].Info.Rows,
                        (int)ptr[i].Info.Columns, (int)ptr[i].Info.Elements, XNAClass[(int)ptr[i].Info.ParameterClass],
                        XNAType[(int)ptr[i].Info.ParameterType], null, null, parameter.values + zero.ToInt32(),
                        num * 4,
                        outer);
                    if (ptr[i].Info.ParameterType == MojoshaderSymbolType.MojoshaderSymtypeString)
                    {
                        var ptr2 = (int*)(void*)(parameter.values + zero.ToInt32());
                        effectParameter.cachedString = outer.INTERNAL_GetStringFromObjectTable(*ptr2);
                    }

                    list.Add(effectParameter);
                    zero += (int)(num * 4);
                }

                result = new(list);
            }

            return result;
        }

        private unsafe string INTERNAL_GetStringFromObjectTable(int index)
        {
            var ptr = (MojoshaderEffect*)(void*)effectData;
            var ptr2 = (MojoshaderEffectObject*)(void*)ptr->Objects;
            if (index < ptr->ObjectCount) return Marshal.PtrToStringAnsi(ptr2[index].stringvalue.Stringvalue);

            throw new InvalidOperationException("Invalid effect object index");
        }

        private SourceEffectPass INTERNAL_readPass(ref MojoshaderEffectPass pass, IntPtr techPtr, uint index)
        {
            return new(SourceMarshalHelper.PtrToInternedStringAnsi(pass.Name),
                INTERNAL_readAnnotations(pass.Annotations, pass.AnnotationCount), this, techPtr, index);
        }

        private unsafe SourceEffectAnnotationCollection INTERNAL_readAnnotations(IntPtr rawAnnotations,
            uint numAnnotations)
        {
            if (numAnnotations == 0) return SourceEffectAnnotationCollection.Empty;

            var ptr = (MojoshaderEffectAnnotation*)(void*)rawAnnotations;
            var list = new List<SourceEffectAnnotation>((int)numAnnotations);
            for (var i = 0; i < numAnnotations; i++)
            {
                var mOjoshaderEffectAnnotation = ptr[i];
                var effectAnnotation = new SourceEffectAnnotation(
                    SourceMarshalHelper.PtrToInternedStringAnsi(mOjoshaderEffectAnnotation.Name),
                    SourceMarshalHelper.PtrToInternedStringAnsi(mOjoshaderEffectAnnotation.Semantic),
                    (int)mOjoshaderEffectAnnotation.Type.Rows, (int)mOjoshaderEffectAnnotation.Type.Columns,
                    XNAClass[(int)mOjoshaderEffectAnnotation.Type.ParameterClass],
                    XNAType[(int)mOjoshaderEffectAnnotation.Type.ParameterType], mOjoshaderEffectAnnotation.Values);
                if (mOjoshaderEffectAnnotation.Type.ParameterType == MojoshaderSymbolType.MojoshaderSymtypeString)
                {
                    var ptr2 = (int*)(void*)mOjoshaderEffectAnnotation.Values;
                    effectAnnotation.cachedString = INTERNAL_GetStringFromObjectTable(*ptr2);
                }

                list.Add(effectAnnotation);
            }

            return new(list);
        }
    }
}
