namespace Celeste.Core.Mathematics
{
    public sealed class OriginalScalarArithmetic : ISourceScalarArithmetic
    {
        public float Multiply(float first, float second, float third)
        {
            float product = first * second;
            return product * third;
        }

        public float AddProduct(float value, float first, float second) => value + first * second;

        public float Lerp(float first, float second, float amount) => EvaluateLerp(first, second, amount);

        public static float EvaluateLerp(float first, float second, float amount)
            => first + (second - first) * amount;
    }
}
