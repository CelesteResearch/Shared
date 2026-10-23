using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Platforms.SwapBlocks.Rendering
{
    public static partial class SwapBlockDrawing
    {
        public static void DrawBlockStyle(ISourceRenderContext context, object entity, Vector2 pos, float width,
            float height, AtlasEntry[,] ninSlice, Sprite middle, PackedColor color)
        {
            int num = (int)(width / 8f);
            int num2 = (int)(height / 8f);
            SourceAtlasDrawing.Draw(context, entity, ninSlice[0, 0], SourceVector2Math.Add(pos, new Vector2(0f, 0f)),
                Vector2.Zero, color, Vector2.One);
            SourceAtlasDrawing.Draw(context, entity, ninSlice[2, 0],
                SourceVector2Math.Add(pos, new Vector2(width - 8f, 0f)),
                Vector2.Zero, color, Vector2.One);
            SourceAtlasDrawing.Draw(context, entity, ninSlice[0, 2],
                SourceVector2Math.Add(pos, new Vector2(0f, height - 8f)),
                Vector2.Zero, color, Vector2.One);
            SourceAtlasDrawing.Draw(context, entity, ninSlice[2, 2],
                SourceVector2Math.Add(pos, new Vector2(width - 8f, height - 8f)), Vector2.Zero, color, Vector2.One);
            for (int i = 1; i < num - 1; i++)
            {
                SourceAtlasDrawing.Draw(context, entity, ninSlice[1, 0],
                    SourceVector2Math.Add(pos, new Vector2(i * 8, 0f)),
                    Vector2.Zero, color, Vector2.One);
                SourceAtlasDrawing.Draw(context, entity, ninSlice[1, 2],
                    SourceVector2Math.Add(pos, new Vector2(i * 8, height - 8f)), Vector2.Zero, color, Vector2.One);
            }

            for (int j = 1; j < num2 - 1; j++)
            {
                SourceAtlasDrawing.Draw(context, entity, ninSlice[0, 1],
                    SourceVector2Math.Add(pos, new Vector2(0f, j * 8)),
                    Vector2.Zero, color, Vector2.One);
                SourceAtlasDrawing.Draw(context, entity, ninSlice[2, 1],
                    SourceVector2Math.Add(pos, new Vector2(width - 8f, j * 8)), Vector2.Zero, color, Vector2.One);
            }

            for (int k = 1; k < num - 1; k++)
            {
                for (int l = 1; l < num2 - 1; l++)
                {
                    SourceAtlasDrawing.Draw(context, entity, ninSlice[1, 1],
                        SourceVector2Math.Add(pos, SourceVector2Math.Multiply(new Vector2(k, l), 8f)), Vector2.Zero,
                        color,
                        Vector2.One);
                }
            }

            if (middle != null)
            {
                middle.Color = color;
                middle.RenderPosition = SourceVector2Math.Add(pos, new Vector2(width / 2f, height / 2f));
                middle.Render(context);
            }
        }
    }
}
