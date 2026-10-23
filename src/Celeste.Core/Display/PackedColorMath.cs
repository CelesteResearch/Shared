namespace Celeste.Core.Display
{
    internal static class PackedColorMath
    {
        internal static int Clamp(int value, int min, int max)
        {
            value = value > max ? max : value;
            return value < min ? min : value;
        }

        internal static float Clamp(float value, float min, float max)
        {
            value = value > max ? max : value;
            return value < min ? min : value;
        }

        internal static float Lerp(float a, float b, float amount)
        {
            return (float)(a + ((double)b - a) * amount);
        }
    }
}
