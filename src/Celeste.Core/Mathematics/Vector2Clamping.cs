using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public static class Vector2Clamping
    {
        public static Vector2 Clamp(Vector2 value, float minX, float minY, float maxX, float maxY)
            => new Vector2(ScalarMath.Clamp(value.X, minX, maxX), ScalarMath.Clamp(value.Y, minY, maxY));
    }
}
