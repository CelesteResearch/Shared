using Celeste.Core.Geometry;
using System.Numerics;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Graphics.Display
{
    public readonly struct TextureRectangleDraw
    {
        public readonly TileRegion Texture;
        public readonly IntRect Source;
        public readonly Vector2 Position;
        public readonly Vector4 Color;
        public readonly int Depth;

        public TextureRectangleDraw(TileRegion texture, IntRect source, Vector2 position, Vector4 color, int depth = 0)
        {
            Texture = texture;
            Source = source;
            Position = position;
            Color = color;
            Depth = depth;
        }
    }
}
