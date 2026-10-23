using System;

namespace Celeste.Core.Randomness
{
    public interface ISourceRandom
    {
        int Next();
        int Next(int maxValue);
        int Next(int minValue, int maxValue);
        double NextDouble();
        float NextSingle();
        long NextInt64();
        long NextInt64(long maxValue);
        long NextInt64(long minValue, long maxValue);
        void NextBytes(byte[] buffer);
        void NextBytes(Span<byte> buffer);
        ISourceRandomSnapshot CaptureState();
        void RestoreState(ISourceRandomSnapshot state);
    }
}
