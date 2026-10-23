using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public static class Vector2ComponentDivision
    {
        public static Vector2 Divide(Vector2 value, Vector2 divisor)
        {
            value.X /= divisor.X;
            value.Y /= divisor.Y;
            return value;
        }
    }
}
