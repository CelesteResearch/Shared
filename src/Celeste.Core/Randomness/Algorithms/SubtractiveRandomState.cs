using System;

namespace Celeste.Core.Randomness.Algorithms
{
    // Framework Random and installed Random(seed) share this subtractive state.
    public sealed class SubtractiveRandomState : ISourceRandom
    {
        private readonly ISourceRandomArgumentPolicy arguments;
        private readonly int[] seedArray = new int[56];
        private int inext;
        private int inextp = 21;

        public SubtractiveRandomState(int seed, ISourceRandomArgumentPolicy arguments)
        {
            this.arguments = arguments;
            unchecked
            {
                int subtraction = seed == int.MinValue ? int.MaxValue : Math.Abs(seed);
                int mj = 161803398 - subtraction;
                seedArray[55] = mj;
                int mk = 1;
                for (int i = 1; i < 55; i++)
                {
                    int ii = 21 * i % 55;
                    seedArray[ii] = mk;
                    mk = mj - mk;
                    if (mk < 0) mk += int.MaxValue;
                    mj = seedArray[ii];
                }

                for (int k = 1; k < 5; k++)
                for (int i = 1; i < 56; i++)
                {
                    seedArray[i] -= seedArray[1 + (i + 30) % 55];
                    if (seedArray[i] < 0) seedArray[i] += int.MaxValue;
                }
            }
        }

        private int InternalSample()
        {
            int next = inext;
            if (++next >= 56) next = 1;
            int nextp = inextp;
            if (++nextp >= 56) nextp = 1;
            int value = unchecked(seedArray[next] - seedArray[nextp]);
            if (value == int.MaxValue) value--;
            if (value < 0) value = unchecked(value + int.MaxValue);
            seedArray[next] = value;
            inext = next;
            inextp = nextp;
            return value;
        }

        private double Sample() => InternalSample() * (1.0 / int.MaxValue);
        public int Next() => InternalSample();

        public int Next(int maxValue)
        {
            if (maxValue < 0) throw arguments.NegativeMaximum(maxValue);
            return (int)(Sample() * maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue) throw arguments.SwappedRange();
            long range = (long)maxValue - minValue;
            return range <= int.MaxValue
                ? unchecked((int)(Sample() * range) + minValue)
                : unchecked((int)((long)(SampleLargeRange() * range) + minValue));
        }

        private double SampleLargeRange()
        {
            int value = InternalSample();
            if (InternalSample() % 2 == 0) value = -value;
            double result = value;
            result += int.MaxValue - 1;
            result /= 2u * int.MaxValue - 1;
            return result;
        }

        public double NextDouble() => Sample();

        public void NextBytes(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            for (int i = 0; i < buffer.Length; i++) buffer[i] = (byte)(InternalSample() % 256);
        }

        public void NextBytes(Span<byte> buffer)
        {
            for (int i = 0; i < buffer.Length; i++) buffer[i] = unchecked((byte)InternalSample());
        }

        public float NextSingle()
        {
            while (true)
            {
                float value = (float)Sample();
                if (value < 1.0f) return value;
            }
        }

        private ulong NextUInt64() =>
            (ulong)(uint)Next(1 << 22) |
            ((ulong)(uint)Next(1 << 22) << 22) |
            ((ulong)(uint)Next(1 << 20) << 44);

        public long NextInt64()
        {
            while (true)
            {
                ulong result = NextUInt64() >> 1;
                if (result != long.MaxValue) return (long)result;
            }
        }

        public long NextInt64(long maxValue)
        {
            if (maxValue < 0) throw arguments.NegativeMaximum(maxValue);
            return NextInt64(0, maxValue);
        }

        public long NextInt64(long minValue, long maxValue)
        {
            if (minValue > maxValue) throw arguments.SwappedRange();
            ulong range = unchecked((ulong)(maxValue - minValue));
            if (range > 1)
            {
                int bits = 0;
                ulong remaining = range - 1;
                while (remaining != 0)
                {
                    remaining >>= 1;
                    bits++;
                }

                while (true)
                {
                    ulong result = NextUInt64() >> (64 - bits);
                    if (result < range) return unchecked((long)result + minValue);
                }
            }

            return minValue;
        }

        public ISourceRandomSnapshot CaptureState() =>
            new SubtractiveRandomSnapshot((int[])seedArray.Clone(), inext, inextp);

        public void RestoreState(ISourceRandomSnapshot snapshot)
        {
            var state = (SubtractiveRandomSnapshot)snapshot;
            Array.Copy(state.SeedArray, seedArray, 56);
            inext = state.Inext;
            inextp = state.Inextp;
        }
    }
}
