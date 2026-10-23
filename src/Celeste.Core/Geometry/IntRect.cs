using System;
using System.Collections.Generic;
using System.Xml;

namespace Celeste.Core.Geometry
{
    public struct IntRect
    {
        public int X, Y, Width, Height;
        public int Left => X;
        public int Top => Y;
        public int Right => unchecked(X + Width);
        public int Bottom => unchecked(Y + Height);
        public IntPoint Center => new IntPoint(unchecked(X + Width / 2), unchecked(Y + Height / 2));
        public static global::Celeste.Core.Geometry.IntRect Empty => default;

        public IntRect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            unchecked
            {
                X -= horizontalAmount;
                Y -= verticalAmount;
                Width += horizontalAmount * 2;
                Height += verticalAmount * 2;
            }
        }

        public bool Intersects(IntRect value) =>
            value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;

        public bool Contains(int x, int y) => x >= X && y >= Y && x < Right && y < Bottom;

        // Value equality without boxing. Without the typed overload, `!Bounds.Equals(LastSize)` in
        // LightingRendererPresentation.OcclusionChanged (:56) resolves to ValueType.Equals(object) and
        // boxes BOTH operands on every read - twice per occluder per frame (RoomLightSources.cs:111 and
        // LightingRendererPresentation.cs:61), so ~454 boxes/frame in 3-CelestialResort/lvl_09-b
        // (Artifacts/PerFrameAudit/FINDING.md 4.6). The original compares XNA Rectangles with `!=`
        // (Original/Celeste/LightOcclude.cs:90), which is a plain value comparison.
        public bool Equals(global::Celeste.Core.Geometry.IntRect other) =>
            X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;

        public override bool Equals(object obj) => obj is global::Celeste.Core.Geometry.IntRect other && Equals(other);
        public override int GetHashCode() => ((X * 397) ^ Y) * 397 ^ Width * 397 ^ Height;
    }
}
