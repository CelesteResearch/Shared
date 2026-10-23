using Celeste.Core.Rendering;
using System;
using System.Threading;

namespace Celeste.Graphics.Rendering.Textures
{
    public class SourceRenderTargetCubeResource : SourceTextureCubeResource, ISourceRenderTarget
    {
        private IntPtr glDepthStencilBuffer;

        private IntPtr glColorBuffer;

        public SourceDepthFormat DepthStencilFormat { get; private set; }

        public int MultiSampleCount { get; private set; }

        public SourceRenderTargetUsage RenderTargetUsage { get; private set; }

        public bool IsContentLost => false;

        int ISourceRenderTarget.Width => base.Size;

        int ISourceRenderTarget.Height => base.Size;

        IntPtr ISourceRenderTarget.DepthStencilBuffer => glDepthStencilBuffer;

        IntPtr ISourceRenderTarget.ColorBuffer => glColorBuffer;

#pragma warning disable CS0067 // The source API declares this event without raising it.
        public event EventHandler<EventArgs> ContentLost;
#pragma warning restore CS0067

        public SourceRenderTargetCubeResource(ISourceTextureDevice graphicsDevice, int size, bool mipMap,
            SourceSurfaceFormat preferredFormat, SourceDepthFormat preferredDepthFormat)
            : this(graphicsDevice, size, mipMap, preferredFormat, preferredDepthFormat, 0,
                SourceRenderTargetUsage.DiscardContents)
        {
        }

        public SourceRenderTargetCubeResource(ISourceTextureDevice graphicsDevice, int size, bool mipMap,
            SourceSurfaceFormat preferredFormat, SourceDepthFormat preferredDepthFormat, int preferredMultiSampleCount,
            SourceRenderTargetUsage usage)
            : base(graphicsDevice, size, mipMap, preferredFormat)
        {
            DepthStencilFormat = preferredDepthFormat;
            MultiSampleCount = TextureDevice.TextureIO.GetMaxMultiSampleCount(base.Format,
                SourceMultisampleMath.ClosestMSAAPower(preferredMultiSampleCount));
            RenderTargetUsage = usage;
            if (MultiSampleCount > 0)
            {
                glColorBuffer =
                    TextureDevice.TextureIO.GenColorRenderbuffer(base.Size, base.Size, base.Format, MultiSampleCount,
                        texture);
            }

            if (DepthStencilFormat != SourceDepthFormat.None)
            {
                glDepthStencilBuffer =
                    TextureDevice.TextureIO.GenDepthStencilRenderbuffer(base.Size, base.Size, DepthStencilFormat,
                        MultiSampleCount);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!base.IsDisposed)
            {
                IntPtr intPtr = Interlocked.Exchange(ref glColorBuffer, IntPtr.Zero);
                if (intPtr != IntPtr.Zero)
                {
                    TextureDevice.TextureIO.AddDisposeRenderbuffer(intPtr);
                }

                intPtr = Interlocked.Exchange(ref glDepthStencilBuffer, IntPtr.Zero);
                if (intPtr != IntPtr.Zero)
                {
                    TextureDevice.TextureIO.AddDisposeRenderbuffer(intPtr);
                }
            }

            base.Dispose(disposing);
        }
    }
}
