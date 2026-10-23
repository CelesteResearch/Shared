using System;
using System.Buffers.Binary;
using Celeste.Core.Randomness;
using Celeste.Core.Randomness.Algorithms;

namespace Celeste.Everest.Runtime.Randomness
{
    public sealed class InstalledRandomFactory(ISourceRandomSeedDevice device) : ISourceRandomFactory
    {
        private readonly ISourceRandomArgumentPolicy arguments = new InstalledRandomArgumentPolicy();

        public ISourceRandom CreateUnseeded()
        {
            Span<byte> bytes = stackalloc byte[32];
            Xoshiro256RandomSnapshot state;
            do
            {
                device.FillEntropy(bytes);
                state = new(
                    BinaryPrimitives.ReadUInt64LittleEndian(bytes),
                    BinaryPrimitives.ReadUInt64LittleEndian(bytes.Slice(8)),
                    BinaryPrimitives.ReadUInt64LittleEndian(bytes.Slice(16)),
                    BinaryPrimitives.ReadUInt64LittleEndian(bytes.Slice(24)));
            } while ((state.S0 | state.S1 | state.S2 | state.S3) == 0);

            return new Xoshiro256RandomState(state, arguments);
        }

        public ISourceRandom CreateSeeded(int seed)
        {
            return new SubtractiveRandomState(seed, arguments);
        }
    }
}
