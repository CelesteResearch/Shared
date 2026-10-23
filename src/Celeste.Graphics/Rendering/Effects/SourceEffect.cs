using Celeste.Core.Display;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Core.Interop;
using System.Numerics;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Celeste.Graphics.Rendering.Effects
{
    public partial class SourceEffect : SourceGraphicsResource
    {
        internal ISourceEffectDevice EffectDevice => (ISourceEffectDevice)GraphicsDevice;
        private SourceEffectTechnique INTERNAL_currentTechnique;

        internal IntPtr glEffect;
        public IntPtr NativeEffectHandle => glEffect;

        private Dictionary<IntPtr, SourceEffectParameter> samplerMap =
            new Dictionary<IntPtr, SourceEffectParameter>(new IntPtrBoxlessComparer());

        private IntPtr effectData;

        private static readonly SourceEffectParameterType[] XNAType = new SourceEffectParameterType[10]
        {
            SourceEffectParameterType.Void,
            SourceEffectParameterType.Bool,
            SourceEffectParameterType.Int32,
            SourceEffectParameterType.Single,
            SourceEffectParameterType.String,
            SourceEffectParameterType.Texture,
            SourceEffectParameterType.Texture1D,
            SourceEffectParameterType.Texture2D,
            SourceEffectParameterType.Texture3D,
            SourceEffectParameterType.TextureCube
        };

        private static readonly SourceEffectParameterClass[] XNAClass = new SourceEffectParameterClass[6]
        {
            SourceEffectParameterClass.Scalar,
            SourceEffectParameterClass.Vector,
            SourceEffectParameterClass.Matrix,
            SourceEffectParameterClass.Matrix,
            SourceEffectParameterClass.Object,
            SourceEffectParameterClass.Struct
        };

        private static readonly SourceBlendFactor[] XNABlend = new SourceBlendFactor[16]
        {
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
            SourceBlendFactor.InverseBlendFactor
        };

        private static readonly SourceBlendFunction[] XNABlendOp = new SourceBlendFunction[6]
        {
            (SourceBlendFunction)(-1),
            SourceBlendFunction.Add,
            SourceBlendFunction.Subtract,
            SourceBlendFunction.ReverseSubtract,
            SourceBlendFunction.Min,
            SourceBlendFunction.Max
        };

        private static readonly SourceCompareFunction[] XNACompare = new SourceCompareFunction[9]
        {
            (SourceCompareFunction)(-1),
            SourceCompareFunction.Never,
            SourceCompareFunction.Less,
            SourceCompareFunction.Equal,
            SourceCompareFunction.LessEqual,
            SourceCompareFunction.Greater,
            SourceCompareFunction.NotEqual,
            SourceCompareFunction.GreaterEqual,
            SourceCompareFunction.Always
        };

        private static readonly SourceStencilOperation[] XNAStencilOp = new SourceStencilOperation[9]
        {
            (SourceStencilOperation)(-1),
            SourceStencilOperation.Keep,
            SourceStencilOperation.Zero,
            SourceStencilOperation.Replace,
            SourceStencilOperation.IncrementSaturation,
            SourceStencilOperation.DecrementSaturation,
            SourceStencilOperation.Invert,
            SourceStencilOperation.Increment,
            SourceStencilOperation.Decrement
        };

        private static readonly SourceTextureAddressMode[] XNAAddress = new SourceTextureAddressMode[4]
        {
            (SourceTextureAddressMode)(-1),
            SourceTextureAddressMode.Wrap,
            SourceTextureAddressMode.Mirror,
            SourceTextureAddressMode.Clamp
        };

        private static readonly MOJOSHADER_textureFilterType[] XNAMag = new MOJOSHADER_textureFilterType[9]
        {
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR
        };

        private static readonly MOJOSHADER_textureFilterType[] XNAMin = new MOJOSHADER_textureFilterType[9]
        {
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT
        };

        private static readonly MOJOSHADER_textureFilterType[] XNAMip = new MOJOSHADER_textureFilterType[9]
        {
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR,
            MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT
        };

        public SourceEffectTechnique CurrentTechnique
        {
            get { return INTERNAL_currentTechnique; }
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
            base.GraphicsDevice = graphicsDevice;
            graphicsDevice.CreateEffect(effectCode, effectCode.Length, out glEffect, out var intPtr);
            effectData = intPtr;
            INTERNAL_parseEffectStruct(intPtr);
            CurrentTechnique = Techniques[0];
        }

        protected SourceEffect(SourceEffect cloneSource)
        {
            base.GraphicsDevice = cloneSource.GraphicsDevice;
            EffectDevice.CloneEffect(cloneSource.glEffect, out glEffect, out var intPtr);
            effectData = intPtr;
            INTERNAL_parseEffectStruct(intPtr);
            for (int i = 0; i < cloneSource.Parameters.Count; i++)
            {
                Parameters[i].texture = cloneSource.Parameters[i].texture;
            }

            for (int j = 0; j < cloneSource.Techniques.Count; j++)
            {
                if (cloneSource.Techniques[j] == cloneSource.CurrentTechnique)
                {
                    CurrentTechnique = Techniques[j];
                }
            }
        }

        public virtual SourceEffect Clone()
        {
            return new SourceEffect(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!base.IsDisposed)
            {
                IntPtr intPtr = Interlocked.Exchange(ref glEffect, IntPtr.Zero);
                if (intPtr != IntPtr.Zero)
                {
                    EffectDevice.AddDisposeEffect(intPtr);
                }
            }

            base.Dispose(disposing);
        }

        protected internal virtual void OnApply()
        {
        }

        internal unsafe void INTERNAL_applyEffect(uint pass)
        {
            EffectDevice.ApplyEffect(glEffect, pass, EffectDevice.EffectStateChangesPointer);
            MOJOSHADER_effectStateChanges* ptr =
                (MOJOSHADER_effectStateChanges*)(void*)EffectDevice.EffectStateChangesPointer;
            if (ptr->render_state_change_count != 0)
            {
                SourcePipelineCache pipelineCache = EffectDevice.PipelineCache;
                pipelineCache.BeginApplyBlend();
                pipelineCache.BeginApplyDepthStencil();
                pipelineCache.BeginApplyRasterizer();
                bool flag = false;
                bool flag2 = false;
                bool flag3 = false;
                MOJOSHADER_effectState* ptr2 = (MOJOSHADER_effectState*)(void*)ptr->render_state_changes;
                for (int i = 0; i < ptr->render_state_change_count; i++)
                {
                    MOJOSHADER_renderStateType type = ptr2[i].type;
                    switch (type)
                    {
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_ZENABLE:
                        {
                            MOJOSHADER_zBufferType* ptr32 = (MOJOSHADER_zBufferType*)(void*)ptr2[i].value.values;
                            pipelineCache.DepthBufferEnable = *ptr32 == MOJOSHADER_zBufferType.MOJOSHADER_ZB_TRUE;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_FILLMODE:
                        {
                            MOJOSHADER_fillMode* ptr37 = (MOJOSHADER_fillMode*)(void*)ptr2[i].value.values;
                            if (*ptr37 == MOJOSHADER_fillMode.MOJOSHADER_FILL_SOLID)
                            {
                                pipelineCache.FillMode = SourceFillMode.Solid;
                            }
                            else if (*ptr37 == MOJOSHADER_fillMode.MOJOSHADER_FILL_WIREFRAME)
                            {
                                pipelineCache.FillMode = SourceFillMode.WireFrame;
                            }

                            flag3 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_ZWRITEENABLE:
                        {
                            int* ptr36 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.DepthBufferWriteEnable = *ptr36 == 1;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_SRCBLEND:
                        {
                            MOJOSHADER_blendMode* ptr38 = (MOJOSHADER_blendMode*)(void*)ptr2[i].value.values;
                            pipelineCache.ColorSourceBlend = XNABlend[(int)(*ptr38)];
                            if (!pipelineCache.SeparateAlphaBlend)
                            {
                                pipelineCache.AlphaSourceBlend = XNABlend[(int)(*ptr38)];
                            }

                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_DESTBLEND:
                        {
                            MOJOSHADER_blendMode* ptr35 = (MOJOSHADER_blendMode*)(void*)ptr2[i].value.values;
                            pipelineCache.ColorDestinationBlend = XNABlend[(int)(*ptr35)];
                            if (!pipelineCache.SeparateAlphaBlend)
                            {
                                pipelineCache.AlphaDestinationBlend = XNABlend[(int)(*ptr35)];
                            }

                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_CULLMODE:
                        {
                            MOJOSHADER_cullMode* ptr34 = (MOJOSHADER_cullMode*)(void*)ptr2[i].value.values;
                            if (*ptr34 == MOJOSHADER_cullMode.MOJOSHADER_CULL_NONE)
                            {
                                pipelineCache.CullMode = SourceCullMode.None;
                            }
                            else if (*ptr34 == MOJOSHADER_cullMode.MOJOSHADER_CULL_CW)
                            {
                                pipelineCache.CullMode = SourceCullMode.CullClockwiseFace;
                            }
                            else if (*ptr34 == MOJOSHADER_cullMode.MOJOSHADER_CULL_CCW)
                            {
                                pipelineCache.CullMode = SourceCullMode.CullCounterClockwiseFace;
                            }

                            flag3 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_ZFUNC:
                        {
                            MOJOSHADER_compareFunc* ptr33 = (MOJOSHADER_compareFunc*)(void*)ptr2[i].value.values;
                            pipelineCache.DepthBufferFunction = XNACompare[(int)(*ptr33)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_ALPHABLENDENABLE:
                        {
                            int* ptr31 = (int*)(void*)ptr2[i].value.values;
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
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_STENCILENABLE:
                        {
                            int* ptr30 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.StencilEnable = *ptr30 == 1;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_STENCILFAIL:
                        {
                            MOJOSHADER_stencilOp* ptr29 = (MOJOSHADER_stencilOp*)(void*)ptr2[i].value.values;
                            pipelineCache.StencilFail = XNAStencilOp[(int)(*ptr29)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_STENCILZFAIL:
                        {
                            MOJOSHADER_stencilOp* ptr28 = (MOJOSHADER_stencilOp*)(void*)ptr2[i].value.values;
                            pipelineCache.StencilDepthBufferFail = XNAStencilOp[(int)(*ptr28)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_STENCILPASS:
                        {
                            MOJOSHADER_stencilOp* ptr27 = (MOJOSHADER_stencilOp*)(void*)ptr2[i].value.values;
                            pipelineCache.StencilPass = XNAStencilOp[(int)(*ptr27)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_STENCILFUNC:
                        {
                            MOJOSHADER_compareFunc* ptr26 = (MOJOSHADER_compareFunc*)(void*)ptr2[i].value.values;
                            pipelineCache.StencilFunction = XNACompare[(int)(*ptr26)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_STENCILREF:
                        {
                            int* ptr25 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.ReferenceStencil = *ptr25;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_STENCILMASK:
                        {
                            int* ptr24 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.StencilMask = *ptr24;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_STENCILWRITEMASK:
                        {
                            int* ptr23 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.StencilWriteMask = *ptr23;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_MULTISAMPLEANTIALIAS:
                        {
                            int* ptr22 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.MultiSampleAntiAlias = *ptr22 == 1;
                            flag3 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_MULTISAMPLEMASK:
                        {
                            int* ptr21 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.MultiSampleMask = *ptr21;
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_COLORWRITEENABLE:
                        {
                            int* ptr20 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.ColorWriteChannels = (SourceColorWriteChannels)(*ptr20);
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_BLENDOP:
                        {
                            MOJOSHADER_blendOp* ptr19 = (MOJOSHADER_blendOp*)(void*)ptr2[i].value.values;
                            pipelineCache.ColorBlendFunction = XNABlendOp[(int)(*ptr19)];
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_SCISSORTESTENABLE:
                        {
                            int* ptr18 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.ScissorTestEnable = *ptr18 == 1;
                            flag3 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_SLOPESCALEDEPTHBIAS:
                        {
                            float* ptr17 = (float*)(void*)ptr2[i].value.values;
                            pipelineCache.SlopeScaleDepthBias = *ptr17;
                            flag3 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_TWOSIDEDSTENCILMODE:
                        {
                            int* ptr16 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.TwoSidedStencilMode = *ptr16 == 1;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_CCW_STENCILFAIL:
                        {
                            MOJOSHADER_stencilOp* ptr15 = (MOJOSHADER_stencilOp*)(void*)ptr2[i].value.values;
                            pipelineCache.CCWStencilFail = XNAStencilOp[(int)(*ptr15)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_CCW_STENCILZFAIL:
                        {
                            MOJOSHADER_stencilOp* ptr14 = (MOJOSHADER_stencilOp*)(void*)ptr2[i].value.values;
                            pipelineCache.CCWStencilDepthBufferFail = XNAStencilOp[(int)(*ptr14)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_CCW_STENCILPASS:
                        {
                            MOJOSHADER_stencilOp* ptr13 = (MOJOSHADER_stencilOp*)(void*)ptr2[i].value.values;
                            pipelineCache.CCWStencilPass = XNAStencilOp[(int)(*ptr13)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_CCW_STENCILFUNC:
                        {
                            MOJOSHADER_compareFunc* ptr12 = (MOJOSHADER_compareFunc*)(void*)ptr2[i].value.values;
                            pipelineCache.CCWStencilFunction = XNACompare[(int)(*ptr12)];
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_COLORWRITEENABLE1:
                        {
                            int* ptr11 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.ColorWriteChannels1 = (SourceColorWriteChannels)(*ptr11);
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_COLORWRITEENABLE2:
                        {
                            int* ptr10 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.ColorWriteChannels2 = (SourceColorWriteChannels)(*ptr10);
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_COLORWRITEENABLE3:
                        {
                            int* ptr9 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.ColorWriteChannels3 = (SourceColorWriteChannels)(*ptr9);
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_BLENDFACTOR:
                        {
                            int* ptr8 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.BlendFactor = new PackedColor((*ptr8 >> 24) & 0xFF, (*ptr8 >> 16) & 0xFF,
                                (*ptr8 >> 8) & 0xFF, *ptr8 & 0xFF);
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_DEPTHBIAS:
                        {
                            float* ptr7 = (float*)(void*)ptr2[i].value.values;
                            pipelineCache.DepthBias = *ptr7;
                            flag3 = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_SEPARATEALPHABLENDENABLE:
                        {
                            int* ptr6 = (int*)(void*)ptr2[i].value.values;
                            pipelineCache.SeparateAlphaBlend = *ptr6 == 1;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_SRCBLENDALPHA:
                        {
                            MOJOSHADER_blendMode* ptr5 = (MOJOSHADER_blendMode*)(void*)ptr2[i].value.values;
                            pipelineCache.AlphaSourceBlend = XNABlend[(int)(*ptr5)];
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_DESTBLENDALPHA:
                        {
                            MOJOSHADER_blendMode* ptr4 = (MOJOSHADER_blendMode*)(void*)ptr2[i].value.values;
                            pipelineCache.AlphaDestinationBlend = XNABlend[(int)(*ptr4)];
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_BLENDOPALPHA:
                        {
                            MOJOSHADER_blendOp* ptr3 = (MOJOSHADER_blendOp*)(void*)ptr2[i].value.values;
                            pipelineCache.AlphaBlendFunction = XNABlendOp[(int)(*ptr3)];
                            flag = true;
                            break;
                        }
                        default:
                            throw new NotImplementedException("Unhandled render state! " + type);
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_VERTEXSHADER:
                        case MOJOSHADER_renderStateType.MOJOSHADER_RS_PIXELSHADER:
                        case (MOJOSHADER_renderStateType)178:
                            break;
                    }
                }

                if (flag)
                {
                    pipelineCache.EndApplyBlend();
                }

                if (flag2)
                {
                    pipelineCache.EndApplyDepthStencil();
                }

                if (flag3)
                {
                    pipelineCache.EndApplyRasterizer();
                }
            }

            if (ptr->sampler_state_change_count != 0)
            {
                INTERNAL_updateSamplers(ptr->sampler_state_change_count,
                    (MOJOSHADER_samplerStateRegister*)(void*)ptr->sampler_state_changes, EffectDevice.Textures,
                    EffectDevice.SamplerStates);
            }

            if (ptr->vertex_sampler_state_change_count != 0)
            {
                INTERNAL_updateSamplers(ptr->vertex_sampler_state_change_count,
                    (MOJOSHADER_samplerStateRegister*)(void*)ptr->vertex_sampler_state_changes,
                    EffectDevice.VertexTextures,
                    EffectDevice.VertexSamplerStates);
            }
        }

        private unsafe void INTERNAL_updateSamplers(uint changeCount, MOJOSHADER_samplerStateRegister* registers,
            SourceTextureCollection textures, SourceSamplerStateCollection samplers)
        {
            for (int i = 0; i < changeCount; i++)
            {
                if (registers[i].sampler_state_count == 0)
                {
                    continue;
                }

                int sampler_register = (int)registers[i].sampler_register;
                SourcePipelineCache pipelineCache = EffectDevice.PipelineCache;
                pipelineCache.BeginApplySampler(samplers, sampler_register);
                bool flag = false;
                bool flag2 = false;
                SourceTextureFilter filter = pipelineCache.Filter;
                MOJOSHADER_textureFilterType mOJOSHADER_textureFilterType = XNAMag[(int)filter];
                MOJOSHADER_textureFilterType mOJOSHADER_textureFilterType2 = XNAMin[(int)filter];
                MOJOSHADER_textureFilterType mOJOSHADER_textureFilterType3 = XNAMip[(int)filter];
                MOJOSHADER_effectSamplerState* ptr = (MOJOSHADER_effectSamplerState*)(void*)registers[i].sampler_states;
                for (int j = 0; j < registers[i].sampler_state_count; j++)
                {
                    MOJOSHADER_samplerStateType type = ptr[j].type;
                    switch (type)
                    {
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_TEXTURE:
                        {
                            if (samplerMap.TryGetValue(registers[i].sampler_name, out var value))
                            {
                                SourceTextureResource texture = value.texture;
                                if (texture != null)
                                {
                                    textures[sampler_register] = texture;
                                }
                            }

                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_ADDRESSU:
                        {
                            MOJOSHADER_textureAddress* ptr10 = (MOJOSHADER_textureAddress*)(void*)ptr[j].value.values;
                            pipelineCache.AddressU = XNAAddress[(int)(*ptr10)];
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_ADDRESSV:
                        {
                            MOJOSHADER_textureAddress* ptr9 = (MOJOSHADER_textureAddress*)(void*)ptr[j].value.values;
                            pipelineCache.AddressV = XNAAddress[(int)(*ptr9)];
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_ADDRESSW:
                        {
                            MOJOSHADER_textureAddress* ptr8 = (MOJOSHADER_textureAddress*)(void*)ptr[j].value.values;
                            pipelineCache.AddressW = XNAAddress[(int)(*ptr8)];
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_MAGFILTER:
                        {
                            MOJOSHADER_textureFilterType* ptr7 =
                                (MOJOSHADER_textureFilterType*)(void*)ptr[j].value.values;
                            mOJOSHADER_textureFilterType = *ptr7;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_MINFILTER:
                        {
                            MOJOSHADER_textureFilterType* ptr6 =
                                (MOJOSHADER_textureFilterType*)(void*)ptr[j].value.values;
                            mOJOSHADER_textureFilterType2 = *ptr6;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_MIPFILTER:
                        {
                            MOJOSHADER_textureFilterType* ptr5 =
                                (MOJOSHADER_textureFilterType*)(void*)ptr[j].value.values;
                            mOJOSHADER_textureFilterType3 = *ptr5;
                            flag2 = true;
                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_MIPMAPLODBIAS:
                        {
                            float* ptr4 = (float*)(void*)ptr[j].value.values;
                            pipelineCache.MipMapLODBias = *ptr4;
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_MAXMIPLEVEL:
                        {
                            int* ptr3 = (int*)(void*)ptr[j].value.values;
                            pipelineCache.MaxMipLevel = *ptr3;
                            flag = true;
                            break;
                        }
                        case MOJOSHADER_samplerStateType.MOJOSHADER_SAMP_MAXANISOTROPY:
                        {
                            int* ptr2 = (int*)(void*)ptr[j].value.values;
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
                    switch (mOJOSHADER_textureFilterType)
                    {
                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                            switch (mOJOSHADER_textureFilterType2)
                            {
                                case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                    switch (mOJOSHADER_textureFilterType3)
                                    {
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_NONE:
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                            pipelineCache.Filter = SourceTextureFilter.Point;
                                            break;
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                            pipelineCache.Filter = SourceTextureFilter.PointMipLinear;
                                            break;
                                        default:
                                            throw new NotImplementedException("Unhandled mipfilter type! " +
                                                                              mOJOSHADER_textureFilterType3);
                                    }

                                    break;
                                case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                    switch (mOJOSHADER_textureFilterType3)
                                    {
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_NONE:
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                            pipelineCache.Filter = SourceTextureFilter.MinLinearMagPointMipPoint;
                                            break;
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                            pipelineCache.Filter = SourceTextureFilter.MinLinearMagPointMipLinear;
                                            break;
                                        default:
                                            throw new NotImplementedException("Unhandled mipfilter type! " +
                                                                              mOJOSHADER_textureFilterType3);
                                    }

                                    break;
                                default:
                                    throw new NotImplementedException("Unhandled minfilter type! " +
                                                                      mOJOSHADER_textureFilterType2);
                            }

                            break;
                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                            switch (mOJOSHADER_textureFilterType2)
                            {
                                case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                    switch (mOJOSHADER_textureFilterType3)
                                    {
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_NONE:
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                            pipelineCache.Filter = SourceTextureFilter.MinPointMagLinearMipPoint;
                                            break;
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                            pipelineCache.Filter = SourceTextureFilter.MinPointMagLinearMipLinear;
                                            break;
                                        default:
                                            throw new NotImplementedException("Unhandled mipfilter type! " +
                                                                              mOJOSHADER_textureFilterType3);
                                    }

                                    break;
                                case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                    switch (mOJOSHADER_textureFilterType3)
                                    {
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_NONE:
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_POINT:
                                            pipelineCache.Filter = SourceTextureFilter.LinearMipPoint;
                                            break;
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_LINEAR:
                                        case MOJOSHADER_textureFilterType.MOJOSHADER_TEXTUREFILTER_ANISOTROPIC:
                                            pipelineCache.Filter = SourceTextureFilter.Linear;
                                            break;
                                        default:
                                            throw new NotImplementedException("Unhandled mipfilter type! " +
                                                                              mOJOSHADER_textureFilterType3);
                                    }

                                    break;
                                default:
                                    throw new NotImplementedException("Unhandled minfilter type! " +
                                                                      mOJOSHADER_textureFilterType2);
                            }

                            break;
                        default:
                            throw new NotImplementedException("Unhandled magfilter type! " +
                                                              mOJOSHADER_textureFilterType);
                    }

                    flag = true;
                }

                if (flag)
                {
                    pipelineCache.EndApplySampler(samplers, sampler_register);
                }
            }
        }

        private unsafe void INTERNAL_parseEffectStruct(IntPtr effectData)
        {
            MOJOSHADER_effect* ptr = (MOJOSHADER_effect*)(void*)effectData;
            MOJOSHADER_effectParam* ptr2 = (MOJOSHADER_effectParam*)(void*)ptr->parameters;
            List<SourceEffectParameter> list = new List<SourceEffectParameter>();
            for (int i = 0; i < ptr->param_count; i++)
            {
                MOJOSHADER_effectParam mOJOSHADER_effectParam = ptr2[i];
                if (mOJOSHADER_effectParam.value.type.parameter_type ==
                    MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_VERTEXSHADER ||
                    mOJOSHADER_effectParam.value.type.parameter_type ==
                    MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_PIXELSHADER)
                {
                    continue;
                }

                if (mOJOSHADER_effectParam.value.type.parameter_type >=
                    MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_SAMPLER &&
                    mOJOSHADER_effectParam.value.type.parameter_type <=
                    MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_SAMPLERCUBE)
                {
                    string text = string.Empty;
                    MOJOSHADER_effectSamplerState* ptr3 =
                        (MOJOSHADER_effectSamplerState*)(void*)mOJOSHADER_effectParam.value.values;
                    for (int j = 0; j < mOJOSHADER_effectParam.value.value_count; j++)
                    {
                        if (ptr3[j].value.type.parameter_type >= MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_TEXTURE &&
                            ptr3[j].value.type.parameter_type <= MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_TEXTURECUBE)
                        {
                            MOJOSHADER_effectObject* ptr4 = (MOJOSHADER_effectObject*)(void*)ptr->objects;
                            int* ptr5 = (int*)(void*)ptr3[j].value.values;
                            text = Marshal.PtrToStringAnsi(ptr4[*ptr5].mapping.name);
                            break;
                        }
                    }

                    for (int k = 0; k < list.Count; k++)
                    {
                        if (text.Equals(list[k].Name))
                        {
                            samplerMap[mOJOSHADER_effectParam.value.name] = list[k];
                            break;
                        }
                    }
                }
                else
                {
                    SourceEffectParameter effectParameter = new SourceEffectParameter(
                        SourceMarshalHelper.PtrToInternedStringAnsi(mOJOSHADER_effectParam.value.name),
                        SourceMarshalHelper.PtrToInternedStringAnsi(mOJOSHADER_effectParam.value.semantic),
                        (int)mOJOSHADER_effectParam.value.type.rows, (int)mOJOSHADER_effectParam.value.type.columns,
                        (int)mOJOSHADER_effectParam.value.type.elements,
                        XNAClass[(int)mOJOSHADER_effectParam.value.type.parameter_class],
                        XNAType[(int)mOJOSHADER_effectParam.value.type.parameter_type], new IntPtr(&ptr2[i].value.type),
                        INTERNAL_readAnnotations(mOJOSHADER_effectParam.annotations,
                            mOJOSHADER_effectParam.annotation_count), mOJOSHADER_effectParam.value.values,
                        mOJOSHADER_effectParam.value.value_count * 4, this);
                    if (mOJOSHADER_effectParam.value.type.parameter_type ==
                        MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_STRING)
                    {
                        int* ptr6 = (int*)(void*)mOJOSHADER_effectParam.value.values;
                        effectParameter.cachedString = INTERNAL_GetStringFromObjectTable(*ptr6);
                    }

                    list.Add(effectParameter);
                }
            }

            Parameters = new SourceEffectParameterCollection(list);
            MOJOSHADER_effectTechnique* ptr7 = (MOJOSHADER_effectTechnique*)(void*)ptr->techniques;
            List<SourceEffectTechnique> list2 = new List<SourceEffectTechnique>(ptr->technique_count);
            int num = 0;
            while (num < list2.Capacity)
            {
                MOJOSHADER_effectPass* ptr8 = (MOJOSHADER_effectPass*)(void*)ptr7->passes;
                SourceEffectPassCollection passes;
                if (ptr7->pass_count == 1)
                {
                    passes = new SourceEffectPassCollection(INTERNAL_readPass(ref *ptr8, (IntPtr)ptr7, 0u));
                }
                else
                {
                    List<SourceEffectPass> list3 = new List<SourceEffectPass>((int)ptr7->pass_count);
                    for (int l = 0; l < list3.Capacity; l++)
                    {
                        list3.Add(INTERNAL_readPass(ref ptr8[l], (IntPtr)ptr7, (uint)l));
                    }

                    passes = new SourceEffectPassCollection(list3);
                }

                list2.Add(new SourceEffectTechnique(SourceMarshalHelper.PtrToInternedStringAnsi(ptr7->name),
                    (IntPtr)ptr7,
                    passes, INTERNAL_readAnnotations(ptr7->annotations, ptr7->annotation_count)));
                num++;
                ptr7++;
            }

            Techniques = new SourceEffectTechniqueCollection(list2);
        }

        internal unsafe static SourceEffectParameterCollection INTERNAL_readEffectParameterStructureMembers(
            SourceEffectParameter parameter, IntPtr _type, SourceEffect outer)
        {
            if (_type == IntPtr.Zero)
            {
                return null;
            }

            MOJOSHADER_symbolTypeInfo mOJOSHADER_symbolTypeInfo = *(MOJOSHADER_symbolTypeInfo*)(void*)_type;
            SourceEffectParameterCollection result = null;
            if (mOJOSHADER_symbolTypeInfo.member_count != 0)
            {
                List<SourceEffectParameter> list = new List<SourceEffectParameter>();
                MOJOSHADER_symbolStructMember* ptr =
                    (MOJOSHADER_symbolStructMember*)(void*)mOJOSHADER_symbolTypeInfo.members;
                IntPtr zero = IntPtr.Zero;
                for (int i = 0; i < mOJOSHADER_symbolTypeInfo.member_count; i++)
                {
                    uint num = ptr[i].info.rows * ptr[i].info.columns;
                    if (ptr[i].info.elements != 0)
                    {
                        num *= ptr[i].info.elements;
                    }

                    SourceEffectParameter effectParameter = new SourceEffectParameter(
                        SourceMarshalHelper.PtrToInternedStringAnsi(ptr[i].name), null, (int)ptr[i].info.rows,
                        (int)ptr[i].info.columns, (int)ptr[i].info.elements, XNAClass[(int)ptr[i].info.parameter_class],
                        XNAType[(int)ptr[i].info.parameter_type], null, null, parameter.values + zero.ToInt32(),
                        num * 4,
                        outer);
                    if (ptr[i].info.parameter_type == MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_STRING)
                    {
                        int* ptr2 = (int*)(void*)(parameter.values + zero.ToInt32());
                        effectParameter.cachedString = outer.INTERNAL_GetStringFromObjectTable(*ptr2);
                    }

                    list.Add(effectParameter);
                    zero += (int)(num * 4);
                }

                result = new SourceEffectParameterCollection(list);
            }

            return result;
        }

        private unsafe string INTERNAL_GetStringFromObjectTable(int index)
        {
            MOJOSHADER_effect* ptr = (MOJOSHADER_effect*)(void*)effectData;
            MOJOSHADER_effectObject* ptr2 = (MOJOSHADER_effectObject*)(void*)ptr->objects;
            if (index < ptr->object_count)
            {
                return Marshal.PtrToStringAnsi(ptr2[index].stringvalue.stringvalue);
            }

            throw new InvalidOperationException("Invalid effect object index");
        }

        private SourceEffectPass INTERNAL_readPass(ref MOJOSHADER_effectPass pass, IntPtr techPtr, uint index)
        {
            return new SourceEffectPass(SourceMarshalHelper.PtrToInternedStringAnsi(pass.name),
                INTERNAL_readAnnotations(pass.annotations, pass.annotation_count), this, techPtr, index);
        }

        private unsafe SourceEffectAnnotationCollection INTERNAL_readAnnotations(IntPtr rawAnnotations,
            uint numAnnotations)
        {
            if (numAnnotations == 0)
            {
                return SourceEffectAnnotationCollection.Empty;
            }

            MOJOSHADER_effectAnnotation* ptr = (MOJOSHADER_effectAnnotation*)(void*)rawAnnotations;
            List<SourceEffectAnnotation> list = new List<SourceEffectAnnotation>((int)numAnnotations);
            for (int i = 0; i < numAnnotations; i++)
            {
                MOJOSHADER_effectAnnotation mOJOSHADER_effectAnnotation = ptr[i];
                SourceEffectAnnotation effectAnnotation = new SourceEffectAnnotation(
                    SourceMarshalHelper.PtrToInternedStringAnsi(mOJOSHADER_effectAnnotation.name),
                    SourceMarshalHelper.PtrToInternedStringAnsi(mOJOSHADER_effectAnnotation.semantic),
                    (int)mOJOSHADER_effectAnnotation.type.rows, (int)mOJOSHADER_effectAnnotation.type.columns,
                    XNAClass[(int)mOJOSHADER_effectAnnotation.type.parameter_class],
                    XNAType[(int)mOJOSHADER_effectAnnotation.type.parameter_type], mOJOSHADER_effectAnnotation.values);
                if (mOJOSHADER_effectAnnotation.type.parameter_type == MOJOSHADER_symbolType.MOJOSHADER_SYMTYPE_STRING)
                {
                    int* ptr2 = (int*)(void*)mOJOSHADER_effectAnnotation.values;
                    effectAnnotation.cachedString = INTERNAL_GetStringFromObjectTable(*ptr2);
                }

                list.Add(effectAnnotation);
            }

            return new SourceEffectAnnotationCollection(list);
        }
    }
}
