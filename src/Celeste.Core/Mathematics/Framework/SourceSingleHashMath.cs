using System;
using System.Numerics;

namespace Celeste.Core.Mathematics.Framework
{
    public static class SourceSingleHashMath
    {
        public static int GetHashCodeOriginal(float value)
        {
            if (value == 0f) return 0;
            return BitConverter.SingleToInt32Bits(value);
        }

        public static int GetHashCodeInstalled(float value)
        {
            var bits = BitConverter.SingleToInt32Bits(value);
            if (unchecked((bits - 1) & 0x7fffffff) >= 0x7f800000)
                bits &= 0x7f800000;
            return bits;
        }

        public static int GetVector2HashCodeOriginal(Vector2 value)
        {
            return unchecked(GetHashCodeOriginal(value.X) + GetHashCodeOriginal(value.Y));
        }

        public static int GetVector2HashCodeInstalled(Vector2 value)
        {
            return unchecked(GetHashCodeInstalled(value.X) + GetHashCodeInstalled(value.Y));
        }
    }
}
