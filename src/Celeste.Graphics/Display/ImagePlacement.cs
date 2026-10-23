using System.Numerics;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Graphics.Display
{
    public readonly struct ImagePlacement
    {
        public readonly TileRegion Region;
        public readonly float X, Y, ScaleX, ScaleY;
        public readonly float Rotation, OriginX, OriginY;
        public readonly Vector4 Color;
        public readonly int Depth;
        public readonly double SortDepth;

        // ReSharper disable once ConvertToPrimaryConstructor
        public ImagePlacement(TileRegion region, float x, float y, int depth, float scaleX = 1, float scaleY = 1,
            float rotation = 0, float originX = 0, float originY = 0, Vector4? color = null, double? sceneDepth = null)
        {
            Region = region;
            X = x;
            Y = y;
            Depth = depth;
            ScaleX = scaleX;
            ScaleY = scaleY;
            Rotation = rotation;
            OriginX = originX;
            OriginY = originY;
            Color = color ?? Vector4.One;
            SortDepth = sceneDepth ?? depth;
        }

        public ImagePlacement WithSceneDepth(double sceneDepth)
        {
            return new(Region, X, Y, Depth, ScaleX, ScaleY, Rotation, OriginX, OriginY, Color, sceneDepth);
        }
    }
}
