using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Display
{
    // MTexture.Draw snapshots the original clip, draw offset and SpriteBatch arguments at Draw.
    public readonly struct AtlasTextureDraw
    {
        public readonly AtlasEntry Texture;
        public readonly SourceTexture2DResource Resource;
        public readonly string Page;
        public readonly IntRect Clip;
        public readonly IntRect? DestinationRectangle;
        public readonly Vector2 DrawOffset, Position, Origin, Scale;
        public readonly PackedColor Color;
        public readonly float Rotation;

        public readonly bool FlipX, FlipY;

        // The source caller has already evaluated its clip/origin/scale arguments.
        public AtlasTextureDraw(AtlasEntry texture, SourceTexture2DResource resource,
            IntRect sourceRectangle, Vector2 position, Vector2 origin, PackedColor color,
            Vector2 scale, float rotation = 0f, bool flipX = false, bool flipY = false)
        {
            Texture = texture;
            Resource = resource;
            Page = texture.Page;
            Clip = sourceRectangle;
            DestinationRectangle = null;
            DrawOffset = Vector2.Zero;
            Position = position;
            Origin = origin;
            Color = color;
            Scale = scale;
            Rotation = rotation;
            FlipX = flipX;
            FlipY = flipY;
        }

        // SpriteBatch.Draw of the underlying texture takes a raw source rectangle, not MTexture trim coordinates.
        public AtlasTextureDraw(AtlasEntry texture, IntRect sourceRectangle, Vector2 position, PackedColor color)
            : this(texture, sourceRectangle, position, Vector2.Zero, color, Vector2.One)
        {
        }

        // This is SpriteBatch's integer destination rectangle overload, not MTexture.Draw.
        public AtlasTextureDraw(AtlasEntry texture, IntRect destinationRectangle,
            IntRect sourceRectangle, PackedColor color)
        {
            Texture = texture;
            Resource = texture.Texture.TextureSafe;
            Page = texture.Page;
            Clip = sourceRectangle;
            DestinationRectangle = destinationRectangle;
            DrawOffset = Position = Origin = Vector2.Zero;
            Scale = Vector2.One;
            Color = color;
            Rotation = 0f;
            FlipX = FlipY = false;
        }

        // Direct SpriteBatch.Draw bypasses MTexture.DrawOffset and its draw-scale policy.
        public AtlasTextureDraw(AtlasEntry texture, IntRect sourceRectangle, Vector2 position, Vector2 origin,
            PackedColor color, Vector2 scale, float rotation = 0, bool flipX = false, bool flipY = false)
        {
            DestinationRectangle = null;
            Texture = texture;
            Resource = texture.Texture.TextureSafe;
            Page = texture.Page;
            Clip = sourceRectangle;
            DrawOffset = Vector2.Zero;
            Position = position;
            Origin = origin;
            Color = color;
            Scale = scale;
            Rotation = rotation;
            FlipX = flipX;
            FlipY = flipY;
        }

        public AtlasTextureDraw(AtlasEntry texture, Vector2 position, Vector2 origin, PackedColor color,
            Vector2 scale, float rotation = 0, bool flipX = false, bool flipY = false)
        {
            DestinationRectangle = null;
            Texture = texture;
            var sourceDrawScale = texture.SourceDrawScale;
            Resource = texture.Texture.TextureSafe;
            Page = texture.Page;
            Clip = new(texture.X, texture.Y, texture.Width, texture.Height);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (sourceDrawScale == 1f)
            {
                DrawOffset = new(texture.OffsetX, texture.OffsetY);
                Origin = origin;
                Scale = scale;
            }
            else
            {
                DrawOffset = Vector2.Zero;
                Origin = (origin - texture.DrawOffset) / sourceDrawScale;
                Scale = scale * sourceDrawScale;
            }

            Position = position;
            Color = color;
            Rotation = rotation;
            FlipX = flipX;
            FlipY = flipY;
        }
    }
}
