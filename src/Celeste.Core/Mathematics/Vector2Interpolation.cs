using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public static class Vector2Interpolation
    {
        public static Vector2 Lerp(Vector2 first, Vector2 second, float amount, ISourceScalarArithmetic arithmetic)
            => new Vector2(arithmetic.Lerp(first.X, second.X, amount), arithmetic.Lerp(first.Y, second.Y, amount));
    }
}
