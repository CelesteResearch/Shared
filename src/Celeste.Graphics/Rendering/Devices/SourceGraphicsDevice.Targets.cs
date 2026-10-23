using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        private readonly ISourceGraphicsDeviceTargetIO targetIO;
        private IntRect deviceScissorRectangle;
        private CameraViewport deviceViewport;
        private static Vector4 DiscardColor = new Vector4(0f, 0f, 0f, 1f);
        internal readonly SourceRenderTargetBinding[] renderTargetBindings = new SourceRenderTargetBinding[4];
        private SourceNativeRenderTargetBinding[] nativeTargetBindings = new SourceNativeRenderTargetBinding[4];
        private SourceNativeRenderTargetBinding[] nativeTargetBindingsNext = new SourceNativeRenderTargetBinding[4];
        internal int renderTargetCount;

        public SourceTextureResource CurrentRenderTarget =>
            renderTargetCount == 0 ? null : renderTargetBindings[0].RenderTarget;

        private readonly SourceRenderTargetBinding[] singleTargetCache = new SourceRenderTargetBinding[1];

        public SourcePresentationParameters PresentationParameters { get; private set; }

        public CameraViewport Viewport
        {
            get => deviceViewport;
            set
            {
                deviceViewport = value;
                targetIO.SetViewport(ref value);
            }
        }

        public IntRect ScissorRectangle
        {
            get => deviceScissorRectangle;
            set
            {
                deviceScissorRectangle = value;
                targetIO.SetScissorRect(ref value);
            }
        }

        public void Clear(PackedColor color)
        {
            Clear(SourceClearOptions.Target | SourceClearOptions.DepthBuffer | SourceClearOptions.Stencil,
                color.ToVector4(), Viewport.MaxDepth, 0);
        }

        public void Clear(SourceClearOptions options, PackedColor color, float depth, int stencil)
        {
            Clear(options, color.ToVector4(), depth, stencil);
        }

        public void Clear(SourceClearOptions options, Vector4 color, float depth, int stencil)
        {
            switch ((renderTargetCount != 0)
                        ? (renderTargetBindings[0].RenderTarget as ISourceRenderTarget).DepthStencilFormat
                        : targetIO.GetBackbufferDepthFormat())
            {
                case SourceDepthFormat.None:
                    options &= SourceClearOptions.Target;
                    break;
                default:
                    options &= ~SourceClearOptions.Stencil;
                    break;
                case SourceDepthFormat.Depth24Stencil8:
                    break;
            }

            targetIO.Clear(options, ref color, depth, stencil);
        }

        public void SetRenderTarget(SourceRenderTarget2DResource renderTarget)
        {
            if (renderTarget == null)
            {
                SetRenderTargets((SourceRenderTargetBinding[])null);
                return;
            }

            singleTargetCache[0] = new SourceRenderTargetBinding(renderTarget);
            SetRenderTargets(singleTargetCache);
        }

        public void SetRenderTarget(SourceRenderTargetCubeResource renderTarget, SourceCubeMapFace cubeMapFace)
        {
            if (renderTarget == null)
            {
                SetRenderTargets((SourceRenderTargetBinding[])null);
                return;
            }

            singleTargetCache[0] = new SourceRenderTargetBinding(renderTarget, cubeMapFace);
            SetRenderTargets(singleTargetCache);
        }

        public unsafe void SetRenderTargets(params SourceRenderTargetBinding[] renderTargets)
        {
            ApplySamplers();
            if (renderTargets == null && renderTargetCount == 0)
            {
                return;
            }

            if (renderTargets != null && renderTargets.Length == renderTargetCount)
            {
                bool flag = true;
                for (int i = 0; i < renderTargets.Length; i++)
                {
                    if (renderTargets[i].RenderTarget != renderTargetBindings[i].RenderTarget ||
                        renderTargets[i].CubeMapFace != renderTargetBindings[i].CubeMapFace)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    return;
                }
            }

            int width;
            int height;
            SourceRenderTargetUsage renderTargetUsage;
            if (renderTargets == null || renderTargets.Length == 0)
            {
                targetIO.SetRenderTargets(IntPtr.Zero, 0, IntPtr.Zero, SourceDepthFormat.None,
                    (PresentationParameters.RenderTargetUsage != SourceRenderTargetUsage.DiscardContents)
                        ? ((byte)1)
                        : ((byte)0));
                width = PresentationParameters.BackBufferWidth;
                height = PresentationParameters.BackBufferHeight;
                renderTargetUsage = PresentationParameters.RenderTargetUsage;
                for (int j = 0; j < renderTargetCount; j++)
                {
                    targetIO.ResolveTarget(ref nativeTargetBindings[j]);
                }

                Array.Clear(renderTargetBindings, 0, renderTargetBindings.Length);
                Array.Clear(nativeTargetBindings, 0, nativeTargetBindings.Length);
                renderTargetCount = 0;
            }
            else
            {
                ISourceRenderTarget renderTarget = renderTargets[0].RenderTarget as ISourceRenderTarget;
                fixed (SourceNativeRenderTargetBinding* ptr = &nativeTargetBindingsNext[0])
                {
                    PrepareRenderTargetBindings(ptr, renderTargets);
                    targetIO.SetRenderTargets(ptr, renderTargets.Length, renderTarget.DepthStencilBuffer,
                        renderTarget.DepthStencilFormat,
                        (renderTarget.RenderTargetUsage != SourceRenderTargetUsage.DiscardContents)
                            ? ((byte)1)
                            : ((byte)0));
                }

                width = renderTarget.Width;
                height = renderTarget.Height;
                renderTargetUsage = renderTarget.RenderTargetUsage;
                for (int k = 0; k < renderTargetCount; k++)
                {
                    bool flag2 = false;
                    for (int l = 0; l < renderTargets.Length; l++)
                    {
                        if (renderTargetBindings[k].RenderTarget == renderTargets[l].RenderTarget)
                        {
                            flag2 = true;
                            break;
                        }
                    }

                    if (!flag2)
                    {
                        targetIO.ResolveTarget(ref nativeTargetBindings[k]);
                    }
                }

                Array.Clear(renderTargetBindings, 0, renderTargetBindings.Length);
                Array.Copy(renderTargets, renderTargetBindings, renderTargets.Length);
                Array.Clear(nativeTargetBindings, 0, nativeTargetBindings.Length);
                Array.Copy(nativeTargetBindingsNext, nativeTargetBindings, renderTargets.Length);
                renderTargetCount = renderTargets.Length;
            }

            Viewport = new CameraViewport(0, 0, width, height);
            ScissorRectangle = new IntRect(0, 0, width, height);
            if (renderTargetUsage == SourceRenderTargetUsage.DiscardContents)
            {
                Clear(SourceClearOptions.Target | SourceClearOptions.DepthBuffer | SourceClearOptions.Stencil,
                    DiscardColor,
                    Viewport.MaxDepth, 0);
            }
        }

        public SourceRenderTargetBinding[] GetRenderTargets()
        {
            SourceRenderTargetBinding[] array = new SourceRenderTargetBinding[renderTargetCount];
            Array.Copy(renderTargetBindings, array, renderTargetCount);
            return array;
        }

        public int GetRenderTargetsNoAllocEXT(SourceRenderTargetBinding[] output)
        {
            if (output == null)
            {
                return renderTargetCount;
            }

            if (output.Length != renderTargetCount)
            {
                throw new ArgumentException("Output buffer size incorrect");
            }

            Array.Copy(renderTargetBindings, output, renderTargetCount);
            return renderTargetCount;
        }

        internal unsafe static void PrepareRenderTargetBindings(SourceNativeRenderTargetBinding* b,
            SourceRenderTargetBinding[] bindings)
        {
            int num = 0;
            while (num < bindings.Length)
            {
                SourceTextureResource renderTarget = bindings[num].RenderTarget;
                ISourceRenderTarget renderTarget2 = renderTarget as ISourceRenderTarget;
                if (renderTarget is SourceRenderTargetCubeResource)
                {
                    b->type = 1;
                    b->data1 = renderTarget2.Width;
                    b->data2 = (int)bindings[num].CubeMapFace;
                }
                else
                {
                    b->type = 0;
                    b->data1 = renderTarget2.Width;
                    b->data2 = renderTarget2.Height;
                }

                b->levelCount = renderTarget2.LevelCount;
                b->multiSampleCount = renderTarget2.MultiSampleCount;
                b->texture = renderTarget.texture;
                b->colorBuffer = renderTarget2.ColorBuffer;
                num++;
                b++;
            }
        }
    }
}
