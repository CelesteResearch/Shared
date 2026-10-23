using Celeste.Core.Display;
using Celeste.Core.Rendering;

namespace Celeste.Graphics.Rendering.Primitives
{
    public static class WaterDisplacementGridDrawing
    {
        public static void Draw(ISourceRenderContext context, object owner, bool[,] grid, float x, float y,
            PackedColor color)
        {
            var width = grid.GetLength(0);
            var height = grid.GetLength(1);
            for (var i = 0; i < width; i++)
            {
                if (height > 0 && grid[i, 0])
                    SourcePrimitiveDrawing.Rect(context, owner, x + i * 8, y + 3, 8, 5, color);
                for (var j = 1; j < height; j++)
                {
                    if (!grid[i, j]) continue;
                    var count = 1;
                    while (j + count < height && grid[i, j + count]) count++;
                    SourcePrimitiveDrawing.Rect(context, owner, x + i * 8, y + j * 8, 8, count * 8, color);
                    j += count - 1;
                }
            }
        }
    }
}
