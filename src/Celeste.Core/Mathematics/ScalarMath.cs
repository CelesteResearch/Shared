using System.Runtime.CompilerServices;
using System;

namespace Celeste.Core.Mathematics
{
    public static class ScalarMath
    {
        public static float WrapAngle(float radians)
            => ((radians * (float)Math.Sign(radians) + (float)Math.PI)
                % ((float)Math.PI * 2f) - (float)Math.PI) * (float)Math.Sign(radians);

        public static float Percent(float value, float zeroAt, float oneAt)
            => Clamp((value - zeroAt) / (oneAt - zeroAt), 0f, 1f);

        public static int Clamp(int value, int min, int max) => Math.Min(Math.Max(value, min), max);

        // The caller supplies the source arithmetic profile.
        public static float Lerp(float first, float second, float amount, ISourceScalarArithmetic arithmetic)
            => arithmetic.Lerp(first, second, amount);

        public static float Approach(float value, float target, float amount)
            => value > target ? Math.Max(value - amount, target) : Math.Min(value + amount, target);

        public static float LerpSnap(float first, float second, float amount, float snapThreshold,
            ISourceScalarArithmetic arithmetic)
        {
            float value = arithmetic.Lerp(first, second, amount);
            return Math.Abs(value - second) < snapThreshold ? second : value;
        }

        public static float LerpClamp(float first, float second, float amount, ISourceScalarArithmetic arithmetic)
            => arithmetic.Lerp(first, second, Clamp(amount, 0f, 1f));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Approach(float value, float target, float amount,
            global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic arithmetic)
            => value > target ? arithmetic.Max(value - amount, target) : arithmetic.Min(value + amount, target);

        public static float Clamp(float value, float minimum, float maximum,
            global::Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic arithmetic)
            => arithmetic.Min(arithmetic.Max(value, minimum), maximum);

        public static float Clamp(float value, float minimum, float maximum)
        {
            value = value > maximum ? maximum : value;
            value = value < minimum ? minimum : value;
            return value;
        }

        public static float Map(float value, float minimum, float maximum, float newMinimum = 0f, float newMaximum = 1f)
            => (value - minimum) / (maximum - minimum) * (newMaximum - newMinimum) + newMinimum;

        public static float ClampedMap(float value, float minimum, float maximum, float newMinimum = 0f,
            float newMaximum = 1f)
            => Clamp((value - minimum) / (maximum - minimum), 0f, 1f) * (newMaximum - newMinimum) + newMinimum;

        public static float AngleDiff(float radiansA, float radiansB)
        {
            float difference = radiansB - radiansA;
            while (difference > (float)Math.PI) difference -= (float)Math.PI * 2f;
            while (difference <= -(float)Math.PI) difference += (float)Math.PI * 2f;
            return difference;
        }

        public static float AngleApproach(float angle, float target, float amount)
        {
            float difference = AngleDiff(angle, target);
            if (Math.Abs(difference) < amount) return target;
            return angle + Clamp(difference, -amount, amount);
        }

        public static float AngleLerp(float startAngle, float endAngle, float percent)
            => startAngle + AngleDiff(startAngle, endAngle) * percent;

        public static float AbsAngleDiff(float radiansA, float radiansB)
            => Math.Abs(AngleDiff(radiansA, radiansB));

        public static float YoYo(float value)
            => value <= .5f ? value * 2f : 1f - (value - .5f) * 2f;

        public static int Mod(int value, int modulus)
            => (value % modulus + modulus) % modulus;

        public static float Mod(float value, float modulus)
            => (value % modulus + modulus) % modulus;
    }
}
