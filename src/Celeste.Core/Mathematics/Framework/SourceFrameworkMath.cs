namespace Celeste.Core.Mathematics.Framework
{
    public static class SourceFrameworkMath
    {
        public static float Clamp(float value, float min, float max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }

        public static int Clamp(int value, int min, int max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }

        public static float Min(float value1, float value2)
        {
            if (!(value1 < value2)) return value2;
            return value1;
        }

        public static float Max(float value1, float value2)
        {
            if (!(value1 > value2)) return value2;
            return value1;
        }
    }
}
