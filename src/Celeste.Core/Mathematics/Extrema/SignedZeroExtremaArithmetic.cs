using System;

namespace Celeste.Core.Mathematics.Extrema
{
    // .NET 8 Math.Min/Max use the sign bit to distinguish equal signed zeros.
    public sealed class SignedZeroExtremaArithmetic : ISourceExtremaArithmetic
    {
        public float Min(float first, float second)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (first != second)
            {
                if (float.IsNaN(first)) return first;
                return first < second ? first : second;
            }

            return BitConverter.SingleToInt32Bits(first) < 0 ? first : second;
        }

        public float Max(float first, float second)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (first != second)
            {
                if (float.IsNaN(first)) return first;
                return second < first ? first : second;
            }

            return BitConverter.SingleToInt32Bits(second) < 0 ? first : second;
        }

        public double Min(double first, double second)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (first != second)
            {
                if (double.IsNaN(first)) return first;
                return first < second ? first : second;
            }

            return BitConverter.DoubleToInt64Bits(first) < 0 ? first : second;
        }

        public double Max(double first, double second)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (first != second)
            {
                if (double.IsNaN(first)) return first;
                return second < first ? first : second;
            }

            return BitConverter.DoubleToInt64Bits(second) < 0 ? first : second;
        }
    }
}
