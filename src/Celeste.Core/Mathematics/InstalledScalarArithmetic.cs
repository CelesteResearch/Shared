namespace Celeste.Core.Mathematics
{
    public sealed class InstalledScalarArithmetic : ISourceScalarArithmetic
    {
        public float Multiply(float first, float second, float third)
            => (float)((double)first * (double)second * (double)third);

        public float AddProduct(float value, float first, float second)
            => (float)((double)value + (double)first * second);

        public float Lerp(float first, float second, float amount) => EvaluateLerp(first, second, amount);

        public static float EvaluateLerp(float first, float second, float amount)
            => (float)((double)first + ((double)second - first) * amount);
    }
}
