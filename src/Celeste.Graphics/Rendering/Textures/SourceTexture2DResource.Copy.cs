using System;

namespace Celeste.Graphics.Rendering.Textures
{
    public partial class SourceTexture2DResource
    {
        public void CopyTo(SourceTexture2DResource destination)
        {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (ReferenceEquals(this, destination)) return;
            if (IsDisposed || destination.IsDisposed)
                throw new ObjectDisposedException(nameof(SourceTexture2DResource));
            if (!ReferenceEquals(GraphicsDevice, destination.GraphicsDevice) || Width != destination.Width ||
                Height != destination.Height || Format != destination.Format || LevelCount != destination.LevelCount ||
                (this is SourceRenderTarget2DResource sourceTarget && sourceTarget.MultiSampleCount != 0) ||
                (destination is SourceRenderTarget2DResource destinationTarget &&
                 destinationTarget.MultiSampleCount != 0))
                throw new ArgumentException(
                    "Texture copies require matching resources on the same device without multisampling.",
                    nameof(destination));
            TextureDevice.TextureIO.CopyTexture2D(texture, destination.texture);
            destination.MarkContentWritten();
        }
    }
}
