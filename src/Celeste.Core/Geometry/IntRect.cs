namespace Celeste.Core.Geometry
{
    public struct IntRect(int x, int y, int width, int height)
    {
        public int X = x, Y = y, Width = width, Height = height;
        public int Left => X;
        public int Top => Y;
        public int Right => unchecked(X + Width);
        public int Bottom => unchecked(Y + Height);
        public IntPoint Center => new(unchecked(X + Width / 2), unchecked(Y + Height / 2));
        public static IntRect Empty => default;

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

        public bool Intersects(IntRect value)
        {
            return value.Left < Right && Left < value.Right && value.Top < Bottom && Top < value.Bottom;
        }

        public bool Contains(int x, int y)
        {
            return x >= X && y >= Y && x < Right && y < Bottom;
        }

        // Value equality without boxing. Without the typed overload, `!Bounds.Equals(LastSize)` in
        // LightingRendererPresentation.OcclusionChanged (:56) resolves to ValueType.Equals(object) and
        // boxes BOTH operands on every read - twice per occluder per frame (RoomLightSources.cs:111 and
        // LightingRendererPresentation.cs:61), so ~454 boxes/frame in 3-CelestialResort/lvl_09-b
        // (Artifacts/PerFrameAudit/FINDING.md 4.6). The original compares XNA Rectangles with `!=`
        // (Original/Celeste/LightOcclude.cs:90), which is a plain value comparison.
        public bool Equals(IntRect other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            return obj is IntRect other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (((X * 397) ^ Y) * 397) ^ (Width * 397) ^ Height;
        }
    }
}
