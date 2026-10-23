namespace Celeste.Core.Mathematics
{
    public interface ISourceScalarArithmetic
    {
        float Multiply(float first, float second, float third);
        float Lerp(float first, float second, float amount);
        float AddProduct(float value, float first, float second);
    }
}
