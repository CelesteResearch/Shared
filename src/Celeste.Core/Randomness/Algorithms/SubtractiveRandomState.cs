using System;

namespace Celeste.Core.Randomness.Algorithms
{
    // Framework Random and installed Random(seed) share this subtractive state.
    public sealed class SubtractiveRandomState : ISourceRandom
    {
        private readonly ISourceRandomArgumentPolicy _arguments;
        private readonly int[] _seedArray = new int[56];
        private int _inext;
        private int _inextp = 21;

        public SubtractiveRandomState(int seed, ISourceRandomArgumentPolicy arguments)
        {
            _arguments = arguments;
            unchecked
            {
                var subtraction = seed == int.MinValue ? int.MaxValue : Math.Abs(seed);
                var mj = 161803398 - subtraction;
                _seedArray[55] = mj;
                var mk = 1;
                for (var i = 1; i < 55; i++)
                {
                    var ii = 21 * i % 55;
                    _seedArray[ii] = mk;
                    mk = mj - mk;
                    if (mk < 0) mk += int.MaxValue;
                    mj = _seedArray[ii];
                }

                for (var k = 1; k < 5; k++)
                for (var i = 1; i < 56; i++)
                {
                    _seedArray[i] -= _seedArray[1 + (i + 30) % 55];
                    if (_seedArray[i] < 0) _seedArray[i] += int.MaxValue;
                }
            }
        }

        private int InternalSample()
        {
            var next = _inext;
            if (++next >= 56) next = 1;
            var nextp = _inextp;
            if (++nextp >= 56) nextp = 1;
            var value = unchecked(_seedArray[next] - _seedArray[nextp]);
            if (value == int.MaxValue) value--;
            if (value < 0) value = unchecked(value + int.MaxValue);
            _seedArray[next] = value;
            _inext = next;
            _inextp = nextp;
            return value;
        }

        private double Sample()
        {
            return InternalSample() * (1.0 / int.MaxValue);
        }

        public int Next()
        {
            return InternalSample();
        }

        public int Next(int maxValue)
        {
            if (maxValue < 0) throw _arguments.NegativeMaximum(maxValue);
            return (int)(Sample() * maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue) throw _arguments.SwappedRange();
            var range = (long)maxValue - minValue;
            return range <= int.MaxValue
                ? unchecked((int)(Sample() * range) + minValue)
                : unchecked((int)((long)(SampleLargeRange() * range) + minValue));
        }

        private double SampleLargeRange()
        {
            var value = InternalSample();
            if (InternalSample() % 2 == 0) value = -value;
            double result = value;
            result += int.MaxValue - 1;
            result /= 2u * int.MaxValue - 1;
            return result;
        }

        public double NextDouble()
        {
            return Sample();
        }

        public void NextBytes(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            for (var i = 0; i < buffer.Length; i++) buffer[i] = (byte)(InternalSample() % 256);
        }

        public void NextBytes(Span<byte> buffer)
        {
            for (var i = 0; i < buffer.Length; i++) buffer[i] = unchecked((byte)InternalSample());
        }

        public float NextSingle()
        {
            while (true)
            {
                var value = (float)Sample();
                if (value < 1.0f) return value;
            }
        }

        private ulong NextUInt64()
        {
            return (uint)Next(1 << 22) |
                   ((ulong)(uint)Next(1 << 22) << 22) |
                   ((ulong)(uint)Next(1 << 20) << 44);
        }

        public long NextInt64()
        {
            while (true)
            {
                var result = NextUInt64() >> 1;
                if (result != long.MaxValue) return (long)result;
            }
        }

        public long NextInt64(long maxValue)
        {
            if (maxValue < 0) throw _arguments.NegativeMaximum(maxValue);
            return NextInt64(0, maxValue);
        }

        public long NextInt64(long minValue, long maxValue)
        {
            if (minValue > maxValue) throw _arguments.SwappedRange();
            var range = unchecked((ulong)(maxValue - minValue));
            if (range > 1)
            {
                var bits = 0;
                var remaining = range - 1;
                while (remaining != 0)
                {
                    remaining >>= 1;
                    bits++;
                }

                while (true)
                {
                    var result = NextUInt64() >> (64 - bits);
                    if (result < range) return unchecked((long)result + minValue);
                }
            }

            return minValue;
        }

        public ISourceRandomSnapshot CaptureState()
        {
            return new SubtractiveRandomSnapshot((int[])_seedArray.Clone(), _inext, _inextp);
        }

        public void RestoreState(ISourceRandomSnapshot snapshot)
        {
            var state = (SubtractiveRandomSnapshot)snapshot;
            Array.Copy(state.SeedArray, _seedArray, 56);
            _inext = state.Inext;
            _inextp = state.Inextp;
        }
    }
}
