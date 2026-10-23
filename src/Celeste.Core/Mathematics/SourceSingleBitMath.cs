using System;

namespace Celeste.Core.Mathematics
{
    public static class SourceSingleBitMath
    {
        public static float BitIncrement(float value)
        {
            int bits = BitConverter.SingleToInt32Bits(value);
            if ((bits & 0x7fffffff) >= 0x7f800000)
                return bits == unchecked((int)0xff800000) ? -float.MaxValue : value;
            if (bits == unchecked((int)0x80000000)) return float.Epsilon;
            bits = unchecked(bits + (bits < 0 ? -1 : 1));
            return BitConverter.Int32BitsToSingle(bits);
        }

        public static float BitDecrement(float value)
        {
            int bits = BitConverter.SingleToInt32Bits(value);
            if ((bits & 0x7fffffff) >= 0x7f800000)
                return bits == 0x7f800000 ? float.MaxValue : value;
            if (bits == 0) return -float.Epsilon;
            bits = unchecked(bits + (bits < 0 ? 1 : -1));
            return BitConverter.Int32BitsToSingle(bits);
        }
    }
}
