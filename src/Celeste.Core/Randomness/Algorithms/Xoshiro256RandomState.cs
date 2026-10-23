using System;

namespace Celeste.Core.Randomness.Algorithms
{
    // Installed 64-bit .NET 8 Random() CPU algorithm and little-endian byte output.
    public sealed class Xoshiro256RandomState : ISourceRandom
    {
        private readonly ISourceRandomArgumentPolicy _arguments;
        private ulong _s0, _s1, _s2, _s3;

        public Xoshiro256RandomState(Xoshiro256RandomSnapshot state, ISourceRandomArgumentPolicy arguments)
        {
            _arguments = arguments;
            RestoreState(state);
        }

        private static ulong RotateLeft(ulong value, int count)
        {
            return (value << count) | (value >> (64 - count));
        }

        private ulong NextUInt64()
        {
            unchecked
            {
                ulong a = _s0, b = _s1, c = _s2, d = _s3;
                var result = RotateLeft(b * 5, 7) * 9;
                var t = b << 17;
                c ^= a;
                d ^= b;
                b ^= c;
                a ^= d;
                c ^= t;
                d = RotateLeft(d, 45);
                _s0 = a;
                _s1 = b;
                _s2 = c;
                _s3 = d;
                return result;
            }
        }

        private uint NextUInt32()
        {
            return (uint)(NextUInt64() >> 32);
        }

        private uint NextUInt32(uint maxValue)
        {
            var product = (ulong)maxValue * NextUInt32();
            var low = unchecked((uint)product);
            if (low < maxValue)
            {
                var remainder = unchecked(0u - maxValue) % maxValue;
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
                var result = NextUInt64() >> 33;
                if (result != int.MaxValue) return (int)result;
            }
        }

        public int Next(int maxValue)
        {
            if (maxValue < 0) throw _arguments.NegativeMaximum(maxValue);
            return (int)NextUInt32((uint)maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue) throw _arguments.SwappedRange();
            return unchecked((int)NextUInt32((uint)(maxValue - minValue)) + minValue);
        }

        public double NextDouble()
        {
            return (NextUInt64() >> 11) * (1.0 / (1ul << 53));
        }

        public void NextBytes(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            NextBytes(buffer.AsSpan());
        }

        public void NextBytes(Span<byte> buffer)
        {
            var offset = 0;
            while (offset < buffer.Length)
            {
                var value = NextUInt64();
                var count = Math.Min(8, buffer.Length - offset);
                for (var i = 0; i < count; i++) buffer[offset + i] = (byte)(value >> (8 * i));
                offset += count;
            }
        }

        public float NextSingle()
        {
            return (NextUInt64() >> 40) * (1.0f / (1u << 24));
        }

        public long NextInt64()
        {
            while (true)
            {
                var result = NextUInt64() >> 1;
                if (result != long.MaxValue) return (long)result;
            }
        }

        private static ulong MultiplyHigh(ulong first, ulong second, out ulong low)
        {
            unchecked
            {
                ulong firstLow = (uint)first, firstHigh = first >> 32;
                ulong secondLow = (uint)second, secondHigh = second >> 32;
                var lowProduct = firstLow * secondLow;
                var middle = firstHigh * secondLow + (lowProduct >> 32);
                var carry = middle >> 32;
                middle = firstLow * secondHigh + (uint)middle;
                low = (middle << 32) + (uint)lowProduct;
                return firstHigh * secondHigh + carry + (middle >> 32);
            }
        }

        private ulong NextUInt64(ulong maxValue)
        {
            var product = MultiplyHigh(maxValue, NextUInt64(), out var low);
            if (low < maxValue)
            {
                var remainder = unchecked(0ul - maxValue) % maxValue;
                while (low < remainder) product = MultiplyHigh(maxValue, NextUInt64(), out low);
            }

            return product;
        }

        public long NextInt64(long maxValue)
        {
            if (maxValue < 0) throw _arguments.NegativeMaximum(maxValue);
            return (long)NextUInt64((ulong)maxValue);
        }

        public long NextInt64(long minValue, long maxValue)
        {
            if (minValue > maxValue) throw _arguments.SwappedRange();
            return unchecked((long)NextUInt64((ulong)(maxValue - minValue)) + minValue);
        }

        public ISourceRandomSnapshot CaptureState()
        {
            return new Xoshiro256RandomSnapshot(_s0, _s1, _s2, _s3);
        }

        public void RestoreState(ISourceRandomSnapshot snapshot)
        {
            var state = (Xoshiro256RandomSnapshot)snapshot;
            _s0 = state.S0;
            _s1 = state.S1;
            _s2 = state.S2;
            _s3 = state.S3;
        }
    }
}
