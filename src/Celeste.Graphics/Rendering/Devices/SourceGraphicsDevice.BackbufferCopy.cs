using System;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices
{
    public partial class SourceGraphicsDevice
    {
        // An independent GPU render target, never the mutable backbuffer or a CPU readback texture.
        public bool TryCaptureBackbuffer(out SourceRenderTarget2DResource snapshot)
        {
            if (IsDisposed) throw new ObjectDisposedException(nameof(SourceGraphicsDevice));
            snapshot = null;
            if (deviceIO is not ISourceGraphicsBackbufferCopyIO { HasPresentedBackbuffer: true } copy) return false;
            deviceIO.GetBackbufferSize(out var width, out var height);
            var captured = new SourceRenderTarget2DResource(this, width, height, false,
                deviceIO.GetBackbufferSurfaceFormat(), SourceDepthFormat.None, 0,
                SourceRenderTargetUsage.PreserveContents);
            try
            {
                copy.CopyBackbufferTo(captured.texture);
                snapshot = captured;
                return true;
            }
            catch
            {
                captured.Dispose();
                throw;
            }
        }

        public bool TryRestoreBackbuffer(SourceRenderTarget2DResource snapshot)
        {
            if (IsDisposed) throw new ObjectDisposedException(nameof(SourceGraphicsDevice));
            if (snapshot == null) throw new ArgumentNullException(nameof(snapshot));
            if (snapshot.IsDisposed) throw new ObjectDisposedException(nameof(snapshot));
            if (!ReferenceEquals(snapshot.GraphicsDevice, this))
                throw new ArgumentException("The backbuffer snapshot must belong to this device.", nameof(snapshot));
            if (deviceIO is not ISourceGraphicsBackbufferCopyIO copy) return false;
            deviceIO.GetBackbufferSize(out var width, out var height);
            if (snapshot.Width != width || snapshot.Height != height) return false;
            copy.RestoreBackbufferFrom(snapshot.texture);
            return true;
        }
    }
}
