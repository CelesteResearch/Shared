using System.Numerics;

namespace Celeste.Core.Geometry
{
    /// <summary>XNA `Point` (Classic.room).</summary>
    public struct IntPoint(int x, int y)
    {
        public int X = x, Y = y;

        public Vector2 ToVector2()
        {
            return new(X, Y);
        }
    }
}
