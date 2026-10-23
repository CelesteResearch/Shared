namespace Celeste.Core.Mathematics
{
    public sealed class InstalledScalarArithmetic : ISourceScalarArithmetic
    {
        public float Multiply(float first, float second, float third)
        {
            return (float)(first * (double)second * third);
        }

        public float AddProduct(float value, float first, float second)
        {
            return (float)(value + (double)first * second);
        }

        public float Lerp(float first, float second, float amount)
        {
            return EvaluateLerp(first, second, amount);
        }

        public static float EvaluateLerp(float first, float second, float amount)
        {
            return (float)(first + ((double)second - first) * amount);
        }
    }
}
