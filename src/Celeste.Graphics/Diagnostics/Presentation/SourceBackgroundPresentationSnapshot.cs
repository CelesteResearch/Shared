using System;
using System.Numerics;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Diagnostics.Presentation
{
    public sealed class SourceBackgroundPresentationSnapshot : IDisposable
    {
        public SourceTexture2DResource Texture { get; private set; }
        public string Room { get; private set; }
        public Matrix4x4 CameraTransform { get; private set; }
        public long FrameSequence { get; private set; }

        internal void Capture(SourceRenderTarget2DResource source, string room, in Matrix4x4 camera, long frameSequence)
        {
            if (Texture == null || Texture.IsDisposed ||
                !ReferenceEquals(Texture.GraphicsDevice, source.GraphicsDevice) ||
                Texture.Width != source.Width || Texture.Height != source.Height || Texture.Format != source.Format)
            {
                Dispose();
                Texture = new SourceTexture2DResource((ISourceTextureDevice)source.GraphicsDevice,
                    source.Width, source.Height, false, source.Format);
            }

            source.CopyTo(Texture);
            Room = room;
            CameraTransform = camera;
            FrameSequence = frameSequence;
        }

        public void Dispose()
        {
            Texture?.Dispose();
            Texture = null;
            Room = null;
            CameraTransform = default;
            FrameSequence = 0;
        }
    }
}
