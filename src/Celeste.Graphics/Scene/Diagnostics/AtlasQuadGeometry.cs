using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Scene.Diagnostics
{
    public static class AtlasQuadGeometry
    {
        public static SourceSpriteQuad Create(in AtlasTextureDraw draw)
        {
            var texture = draw.Resource;
            var clip = draw.Clip;
            float sx = (float)clip.X / texture.Width, sy = (float)clip.Y / texture.Height;
            var sw = Math.Sign(clip.Width) * Math.Max(Math.Abs(clip.Width), 5.9604645e-8f) / texture.Width;
            var sh = Math.Sign(clip.Height) * Math.Max(Math.Abs(clip.Height), 5.9604645e-8f) / texture.Height;
            var origin = draw.Origin - draw.DrawOffset;
            var effects = (byte)((draw.FlipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                                 (draw.FlipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None));
            var quad = new SourceSpriteQuad();
            SourceSpriteGeometry.Generate(ref quad, sx, sy, sw, sh, draw.Position.X, draw.Position.Y,
                draw.Scale.X * clip.Width, draw.Scale.Y * clip.Height, draw.Color.PackedValue,
                origin.X / sw / texture.Width, origin.Y / sh / texture.Height,
                draw.Rotation == 0f ? draw.Rotation : (float)Math.Sin(draw.Rotation),
                draw.Rotation == 0f ? 1f : (float)Math.Cos(draw.Rotation), 0f, effects);
            return quad;
        }

        public static SourceSpriteQuad Create(AtlasEntry entry, SourceTexture2DResource texture, Vector2 position,
            PackedColor color)
        {
            var fix = entry.SourceDrawScale;
            var origin = (Vector2.Zero - entry.DrawOffset) / fix;
            float sx = (float)entry.X / texture.Width, sy = (float)entry.Y / texture.Height;
            var sw = Math.Sign(entry.Width) * Math.Max(Math.Abs(entry.Width), 5.9604645e-8f) / texture.Width;
            var sh = Math.Sign(entry.Height) * Math.Max(Math.Abs(entry.Height), 5.9604645e-8f) /
                     texture.Height;
            var quad = new SourceSpriteQuad();
            SourceSpriteGeometry.Generate(ref quad, sx, sy, sw, sh, position.X, position.Y, fix * entry.Width,
                fix * entry.Height,
                color.PackedValue, origin.X / sw / texture.Width, origin.Y / sh / texture.Height, 0f, 1f, 0f, 0);
            return quad;
        }
    }
}
