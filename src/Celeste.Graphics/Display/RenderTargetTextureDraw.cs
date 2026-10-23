using Celeste.Core.Display;
using Celeste.Graphics.Rendering.Textures;
using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Display
{
    public readonly struct RenderTargetTextureDraw
    {
        public readonly SourceTexture2DResource Texture;
        public readonly bool WholeTexture;
        public readonly IntRect Source;
        public readonly IntRect? DestinationRectangle;
        public readonly Vector2 Position, Origin, Scale;
        public readonly PackedColor Color;
        public readonly float Rotation;
        public readonly bool FlipX, FlipY;

        public RenderTargetTextureDraw(SourceTexture2DResource texture, Vector2 position, PackedColor color)
            : this(texture, position, default, Vector2.Zero, color, Vector2.One)
        {
            WholeTexture = true;
        }

        public RenderTargetTextureDraw(SourceTexture2DResource texture, IntRect destinationRectangle, PackedColor color)
            : this(texture, Vector2.Zero, color)
        {
            DestinationRectangle = destinationRectangle;
        }

        public RenderTargetTextureDraw(SourceTexture2DResource texture, Vector2 position, IntRect source,
            PackedColor color)
            : this(texture, position, source, Vector2.Zero, color, Vector2.One)
        {
        }

        public RenderTargetTextureDraw(SourceTexture2DResource texture, Vector2 position, IntRect source,
            Vector2 origin,
            PackedColor color, Vector2 scale, float rotation = 0, bool flipX = false, bool flipY = false)
        {
            WholeTexture = false;
            DestinationRectangle = null;
            Texture = texture;
            Position = position;
            Source = source;
            Origin = origin;
            Color = color;
            Scale = scale;
            Rotation = rotation;
            FlipX = flipX;
            FlipY = flipY;
        }
    }
}
