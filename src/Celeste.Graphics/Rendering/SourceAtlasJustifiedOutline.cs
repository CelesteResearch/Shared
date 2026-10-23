using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Rendering
{
    public static class SourceAtlasJustifiedOutline
    {
        public static void Draw(ISourceRenderContext context, object entity, AtlasEntry texture,
            Vector2 position, Vector2 justify, PackedColor color, float scale)
        {
            for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
                if (x != 0 || y != 0)
                    SourceAtlasDrawing.DrawJustified(context, entity, texture,
                        SourceVector2Math.Add(position, new Vector2(x, y)), justify, PackedColor.Black, scale);
            SourceAtlasDrawing.DrawJustified(context, entity, texture, position, justify, color, scale);
        }
    }
}
