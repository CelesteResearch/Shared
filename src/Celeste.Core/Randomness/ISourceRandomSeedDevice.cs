using System;

namespace Celeste.Core.Randomness
{
    public interface ISourceRandomSeedDevice
    {
        int TickCount { get; }
        void FillEntropy(Span<byte> destination);
    }
}
