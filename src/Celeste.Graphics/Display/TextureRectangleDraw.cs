using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Graphics.Display
{
    public readonly struct TextureRectangleDraw(
        TileRegion texture,
        IntRect source,
        Vector2 position,
        Vector4 color,
        int depth = 0)
    {
        public readonly TileRegion Texture = texture;
        public readonly IntRect Source = source;
        public readonly Vector2 Position = position;
        public readonly Vector4 Color = color;
        public readonly int Depth = depth;
    }
}
