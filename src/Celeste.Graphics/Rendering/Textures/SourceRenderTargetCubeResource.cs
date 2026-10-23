using System;
using System.Threading;
using Celeste.Core.Rendering;

namespace Celeste.Graphics.Rendering.Textures
{
    public class SourceRenderTargetCubeResource : SourceTextureCubeResource, ISourceRenderTarget
    {
        private IntPtr glDepthStencilBuffer;

        private IntPtr glColorBuffer;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceDepthFormat DepthStencilFormat { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int MultiSampleCount { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SourceRenderTargetUsage RenderTargetUsage { get; private set; }

        public bool IsContentLost => false;

        int ISourceRenderTarget.Width => Size;

        int ISourceRenderTarget.Height => Size;

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
            MultiSampleCount = TextureDevice.TextureIO.GetMaxMultiSampleCount(Format,
                SourceMultisampleMath.ClosestMSAAPower(preferredMultiSampleCount));
            RenderTargetUsage = usage;
            if (MultiSampleCount > 0)
                glColorBuffer =
                    TextureDevice.TextureIO.GenColorRenderbuffer(Size, Size, Format, MultiSampleCount,
                        texture);

            if (DepthStencilFormat != SourceDepthFormat.None)
                glDepthStencilBuffer =
                    TextureDevice.TextureIO.GenDepthStencilRenderbuffer(Size, Size, DepthStencilFormat,
                        MultiSampleCount);
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                var intPtr = Interlocked.Exchange(ref glColorBuffer, IntPtr.Zero);
                if (intPtr != IntPtr.Zero) TextureDevice.TextureIO.AddDisposeRenderbuffer(intPtr);

                intPtr = Interlocked.Exchange(ref glDepthStencilBuffer, IntPtr.Zero);
                if (intPtr != IntPtr.Zero) TextureDevice.TextureIO.AddDisposeRenderbuffer(intPtr);
            }

            base.Dispose(disposing);
        }
    }
}
