using System;
using System.Security.Cryptography;
using Celeste.Core.Randomness;

namespace Celeste.Platform.Native.Randomness
{
    public sealed class NativeSourceRandomSeeds : ISourceRandomSeedDevice
    {
        public int TickCount => Environment.TickCount;

        public void FillEntropy(Span<byte> destination)
        {
            RandomNumberGenerator.Fill(destination);
        }
    }
}
