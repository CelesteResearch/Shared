namespace Celeste.Core.Mathematics.Extrema
{
    public interface ISourceExtremaArithmetic
    {
        float Min(float first, float second);
        float Max(float first, float second);
        double Min(double first, double second);
        double Max(double first, double second);
    }
}
