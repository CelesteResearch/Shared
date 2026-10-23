using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;

namespace Celeste.Graphics.Display
{
    public readonly struct ImagePlacement
    {
        public readonly global::Celeste.Graphics.Content.Tiles.TileRegion Region;
        public readonly float X, Y, ScaleX, ScaleY;
        public readonly float Rotation, OriginX, OriginY;
        public readonly System.Numerics.Vector4 Color;
        public readonly int Depth;
        public readonly double SortDepth;

        public ImagePlacement(global::Celeste.Graphics.Content.Tiles.TileRegion region, float x, float y, int depth,
            float scaleX = 1, float scaleY = 1,
            float rotation = 0, float originX = 0, float originY = 0, System.Numerics.Vector4? color = null,
            double? sceneDepth = null)
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
            Color = color ?? System.Numerics.Vector4.One;
            SortDepth = sceneDepth ?? depth;
        }

        public global::Celeste.Graphics.Display.ImagePlacement WithSceneDepth(double sceneDepth) =>
            new global::Celeste.Graphics.Display.ImagePlacement(Region, X, Y, Depth, ScaleX,
                ScaleY, Rotation, OriginX, OriginY, Color, sceneDepth);
    }
}
