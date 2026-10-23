using System;

namespace Celeste.Core.Randomness.Algorithms
{
    // Installed 64-bit .NET 8 Random() CPU algorithm and little-endian byte output.
    public sealed class Xoshiro256RandomState : ISourceRandom
    {
        private readonly ISourceRandomArgumentPolicy arguments;
        private ulong s0, s1, s2, s3;

        public Xoshiro256RandomState(Xoshiro256RandomSnapshot state, ISourceRandomArgumentPolicy arguments)
        {
            this.arguments = arguments;
            RestoreState(state);
        }

        private static ulong RotateLeft(ulong value, int count) => value << count | value >> (64 - count);

        private ulong NextUInt64()
        {
            unchecked
            {
                ulong a = s0, b = s1, c = s2, d = s3;
                ulong result = RotateLeft(b * 5, 7) * 9;
                ulong t = b << 17;
                c ^= a;
                d ^= b;
                b ^= c;
                a ^= d;
                c ^= t;
                d = RotateLeft(d, 45);
                s0 = a;
                s1 = b;
                s2 = c;
                s3 = d;
                return result;
            }
        }

        private uint NextUInt32() => (uint)(NextUInt64() >> 32);

        private uint NextUInt32(uint maxValue)
        {
            ulong product = (ulong)maxValue * NextUInt32();
            uint low = unchecked((uint)product);
            if (low < maxValue)
            {
                uint remainder = unchecked(0u - maxValue) % maxValue;
                while (low < remainder)
                {
                    product = (ulong)maxValue * NextUInt32();
                    low = unchecked((uint)product);
                }
            }

            return (uint)(product >> 32);
        }

        public int Next()
        {
            while (true)
            {
                ulong result = NextUInt64() >> 33;
                if (result != int.MaxValue) return (int)result;
            }
        }

        public int Next(int maxValue)
        {
            if (maxValue < 0) throw arguments.NegativeMaximum(maxValue);
            return (int)NextUInt32((uint)maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue) throw arguments.SwappedRange();
            return unchecked((int)NextUInt32((uint)(maxValue - minValue)) + minValue);
        }

        public double NextDouble() => (NextUInt64() >> 11) * (1.0 / (1ul << 53));

        public void NextBytes(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            NextBytes(buffer.AsSpan());
        }

        public void NextBytes(Span<byte> buffer)
        {
            int offset = 0;
            while (offset < buffer.Length)
            {
                ulong value = NextUInt64();
                int count = Math.Min(8, buffer.Length - offset);
                for (int i = 0; i < count; i++) buffer[offset + i] = (byte)(value >> (8 * i));
                offset += count;
            }
        }

        public float NextSingle() => (NextUInt64() >> 40) * (1.0f / (1u << 24));

        public long NextInt64()
        {
            while (true)
            {
                ulong result = NextUInt64() >> 1;
                if (result != long.MaxValue) return (long)result;
            }
        }

        private static ulong MultiplyHigh(ulong first, ulong second, out ulong low)
        {
            unchecked
            {
                ulong firstLow = (uint)first, firstHigh = first >> 32;
                ulong secondLow = (uint)second, secondHigh = second >> 32;
                ulong lowProduct = firstLow * secondLow;
                ulong middle = firstHigh * secondLow + (lowProduct >> 32);
                ulong carry = middle >> 32;
                middle = firstLow * secondHigh + (uint)middle;
                low = (middle << 32) + (uint)lowProduct;
                return firstHigh * secondHigh + carry + (middle >> 32);
            }
        }

        private ulong NextUInt64(ulong maxValue)
        {
            ulong product = MultiplyHigh(maxValue, NextUInt64(), out ulong low);
            if (low < maxValue)
            {
                ulong remainder = unchecked(0ul - maxValue) % maxValue;
                while (low < remainder) product = MultiplyHigh(maxValue, NextUInt64(), out low);
            }

            return product;
        }

        public long NextInt64(long maxValue)
        {
            if (maxValue < 0) throw arguments.NegativeMaximum(maxValue);
            return (long)NextUInt64((ulong)maxValue);
        }

        public long NextInt64(long minValue, long maxValue)
        {
            if (minValue > maxValue) throw arguments.SwappedRange();
            return unchecked((long)NextUInt64((ulong)(maxValue - minValue)) + minValue);
        }

        public ISourceRandomSnapshot CaptureState() => new Xoshiro256RandomSnapshot(s0, s1, s2, s3);

        public void RestoreState(ISourceRandomSnapshot snapshot)
        {
            var state = (Xoshiro256RandomSnapshot)snapshot;
            s0 = state.S0;
            s1 = state.S1;
            s2 = state.S2;
            s3 = state.S3;
        }
    }
}
