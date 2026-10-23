namespace Celeste.Core.Mathematics.Extrema
{
    // Framework Math.Min/Max retain the second operand on equal comparisons.
    public sealed class FrameworkExtremaArithmetic : ISourceExtremaArithmetic
    {
        public float Min(float first, float second)
        {
            if (first < second) return first;
            if (float.IsNaN(first)) return first;
            return second;
        }

        public float Max(float first, float second)
        {
            if (first > second) return first;
            if (float.IsNaN(first)) return first;
            return second;
        }

        public double Min(double first, double second)
        {
            if (first < second) return first;
            if (double.IsNaN(first)) return first;
            return second;
        }

        public double Max(double first, double second)
        {
            if (first > second) return first;
            if (double.IsNaN(first)) return first;
            return second;
        }
    }
}
