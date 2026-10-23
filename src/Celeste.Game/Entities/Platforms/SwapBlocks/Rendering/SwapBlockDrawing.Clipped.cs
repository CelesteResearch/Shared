using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Platforms.SwapBlocks.Rendering
{
    public static partial class SwapBlockDrawing
    {
        public static void DrawBlockStyleClipped(ISourceRenderContext context, object entity, IntRect cameraBounds,
            Vector2 pos, float width, float height, AtlasEntry[,] nineSlice, Sprite middle, PackedColor color)
        {
            if (pos.X + width < cameraBounds.Left || pos.Y + height < cameraBounds.Top ||
                pos.X > cameraBounds.Right || pos.Y > cameraBounds.Bottom)
                return;

            cameraBounds.Inflate(nineSlice[0, 0].Width, nineSlice[0, 0].Height);
            var tilesX = (int)(width / 8f);
            var tilesY = (int)(height / 8f);
            DrawInBounds(context, entity, nineSlice[0, 0], cameraBounds, pos + new Vector2(0f, 0f), color);
            DrawInBounds(context, entity, nineSlice[2, 0], cameraBounds, pos + new Vector2(width - 8f, 0f), color);
            DrawInBounds(context, entity, nineSlice[0, 2], cameraBounds, pos + new Vector2(0f, height - 8f), color);
            DrawInBounds(context, entity, nineSlice[2, 2], cameraBounds, pos + new Vector2(width - 8f, height - 8f),
                color);
            for (var i = 1; i < tilesX - 1; i++)
            {
                DrawInBounds(context, entity, nineSlice[1, 0], cameraBounds, pos + new Vector2(i * 8, 0f), color);
                DrawInBounds(context, entity, nineSlice[1, 2], cameraBounds, pos + new Vector2(i * 8, height - 8f),
                    color);
            }

            for (var i = 1; i < tilesY - 1; i++)
            {
                DrawInBounds(context, entity, nineSlice[0, 1], cameraBounds, pos + new Vector2(0f, i * 8), color);
                DrawInBounds(context, entity, nineSlice[2, 1], cameraBounds, pos + new Vector2(width - 8f, i * 8),
                    color);
            }

            for (var i = 1; i < tilesX - 1; i++)
            for (var j = 1; j < tilesY - 1; j++)
                DrawInBounds(context, entity, nineSlice[1, 1], cameraBounds, pos + new Vector2(i, j) * 8f, color);
            if (middle != null)
            {
                middle.Color = color;
                middle.RenderPosition = pos + new Vector2(width / 2f, height / 2f);
                middle.Render(context);
            }
        }

        private static void DrawInBounds(ISourceRenderContext context, object entity, AtlasEntry texture,
            IntRect bounds, Vector2 position, PackedColor color)
        {
            var x = (int)position.X - (int)Vector2.Zero.X;
            var y = (int)position.Y - (int)Vector2.Zero.Y;
            // XNA Rectangle.Contains(Rectangle): full containment, including the right/bottom equality.
            if (bounds.Left <= x && x + texture.Width <= bounds.Right &&
                bounds.Top <= y && y + texture.Height <= bounds.Bottom)
                SourceAtlasDrawing.Draw(context, entity, texture, position, Vector2.Zero, color, Vector2.One);
        }
    }
}
