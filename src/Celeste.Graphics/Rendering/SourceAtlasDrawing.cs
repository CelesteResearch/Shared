using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering
{
    public static class SourceAtlasDrawing
    {
        [System.Runtime.CompilerServices.MethodImpl(
            System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private static Vector2 DrawOrigin(Vector2 origin, Vector2 drawOffset, float scaleFix)
        {
            Vector2 offsetOrigin = new Vector2(origin.X - drawOffset.X, origin.Y - drawOffset.Y);
            return new Vector2(offsetOrigin.X / scaleFix, offsetOrigin.Y / scaleFix);
        }

        public static void Draw(ISourceRenderContext context, object entity, AtlasEntry texture, Vector2 position)
            => Draw(context, entity, texture, position, Vector2.Zero, PackedColor.White, Vector2.One);

        public static void Draw(ISourceRenderContext context, object entity, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => Draw((ISourceDrawScope)context, texture, position, origin, color, scale, rotation, flipX, flipY);

        public static void Draw(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            float scaleFix = texture.SourceDrawScale;
            scope.Draw.SpriteBatch.Draw(texture.ReadTextureForSpriteBatch(),
                position, new IntRect(texture.X, texture.Y, texture.Width, texture.Height),
                color.PackedValue, rotation, DrawOrigin(origin, texture.DrawOffset, scaleFix),
                scale * scaleFix,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public static void Draw(ISourceRenderContext context, object entity, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => Draw((ISourceDrawScope)context, texture, position, origin, color, scale, rotation, flipX, flipY);

        public static void Draw(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            float scaleFix = texture.SourceDrawScale;
            scope.Draw.SpriteBatch.Draw(texture.ReadTextureForSpriteBatch(),
                position, new IntRect(texture.X, texture.Y, texture.Width, texture.Height),
                color.PackedValue, rotation, DrawOrigin(origin, texture.DrawOffset, scaleFix),
                new Vector2(scale.X * scaleFix, scale.Y * scaleFix),
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public static void DrawCentered(ISourceRenderContext context, object entity, AtlasEntry texture,
            Vector2 position, PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => DrawCentered((ISourceDrawScope)context, texture, position, color, scale, rotation, flipX, flipY);

        public static void DrawCentered(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            float scaleFix = texture.SourceDrawScale;
            scope.Draw.SpriteBatch.Draw(texture.ReadTextureForSpriteBatch(),
                position, new IntRect(texture.X, texture.Y, texture.Width, texture.Height),
                color.PackedValue, rotation, (texture.Center - texture.DrawOffset) / scaleFix,
                scale * scaleFix,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public static void DrawCentered(ISourceRenderContext context, object entity, AtlasEntry texture,
            Vector2 position, PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => DrawCentered((ISourceDrawScope)context, texture, position, color, scale, rotation, flipX, flipY);

        public static void DrawCentered(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            float scaleFix = texture.SourceDrawScale;
            scope.Draw.SpriteBatch.Draw(texture.ReadTextureForSpriteBatch(),
                position, new IntRect(texture.X, texture.Y, texture.Width, texture.Height),
                color.PackedValue, rotation, (texture.Center - texture.DrawOffset) / scaleFix,
                scale * scaleFix,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public static void DrawJustified(ISourceRenderContext context, object entity, AtlasEntry texture,
            Vector2 position, Vector2 justify, PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => DrawJustified((ISourceDrawScope)context, texture, position, justify, color, scale, rotation, flipX,
                flipY);

        public static void DrawJustified(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, Vector2 justify, PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            float scaleFix = texture.SourceDrawScale;
            scope.Draw.SpriteBatch.Draw(texture.ReadTextureForSpriteBatch(),
                position, new IntRect(texture.X, texture.Y, texture.Width, texture.Height),
                color.PackedValue, rotation,
                (new Vector2(texture.FrameWidth * justify.X, texture.FrameHeight * justify.Y) - texture.DrawOffset) /
                scaleFix,
                scale * scaleFix,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public static void DrawJustified(ISourceRenderContext context, object entity, AtlasEntry texture,
            Vector2 position, Vector2 justify, PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => DrawJustified((ISourceDrawScope)context, texture, position, justify, color, scale, rotation, flipX,
                flipY);

        public static void DrawJustified(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, Vector2 justify, PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
        {
            float scaleFix = texture.SourceDrawScale;
            scope.Draw.SpriteBatch.Draw(texture.ReadTextureForSpriteBatch(),
                position, new IntRect(texture.X, texture.Y, texture.Width, texture.Height),
                color.PackedValue, rotation,
                (new Vector2(texture.FrameWidth * justify.X, texture.FrameHeight * justify.Y) - texture.DrawOffset) /
                scaleFix,
                scale * scaleFix,
                (flipX ? SourceSpriteEffects.FlipHorizontally : SourceSpriteEffects.None) |
                (flipY ? SourceSpriteEffects.FlipVertically : SourceSpriteEffects.None), 0f);
        }

        public static void DrawOutline(ISourceRenderContext context, object actualEntity, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => texture.DrawOutline((ISourceDrawScope)context, position, origin, color, scale, rotation, flipX, flipY);

        public static void DrawOutline(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, float scale = 1f, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => texture.DrawOutline(scope, position, origin, color, scale, rotation, flipX, flipY);

        public static void DrawOutline(ISourceRenderContext context, object actualEntity, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => texture.DrawOutline((ISourceDrawScope)context, position, origin, color, scale, rotation, flipX, flipY);

        public static void DrawOutline(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, Vector2 scale, float rotation = 0f,
            bool flipX = false, bool flipY = false)
            => texture.DrawOutline(scope, position, origin, color, scale, rotation, flipX, flipY);

        public static void Draw(ISourceRenderContext context, object entity, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, Vector2 scale, float rotation, IntRect clip)
            => texture.DrawClip((ISourceDrawScope)context, position, origin, color, scale, rotation, clip);

        public static void Draw(ISourceDrawScope scope, AtlasEntry texture,
            Vector2 position, Vector2 origin, PackedColor color, Vector2 scale, float rotation, IntRect clip)
            => texture.DrawClip(scope, position, origin, color, scale, rotation, clip);
    }
}
