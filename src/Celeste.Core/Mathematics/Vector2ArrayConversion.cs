using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public static class Vector2ArrayConversion
    {
        public static Vector2? ToVector2(float[] values)
        {
            if (values == null)
                return null;
            if (values.Length == 1)
                return new Vector2(values[0]);
            if (values.Length != 2)
                return null;
            return new Vector2(values[0], values[1]);
        }
    }
}
