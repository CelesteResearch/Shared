using System;
using System.Collections.Generic;

namespace Celeste.Core.Randomness
{
    public sealed class SourceRandomProcessState
    {
        public ISourceRandomFactory Factory { get; }
        private readonly Stack<ISourceRandom> randomStack;
        public ISourceRandom Random;
        public ISourceRandom Proxy { get; }

        public SourceRandomProcessState(ISourceRandomFactory factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
            Random = Factory.CreateUnseeded();
            randomStack = new Stack<ISourceRandom>();
            Proxy = new CurrentRandomProxy(this);
        }

        private sealed class CurrentRandomProxy : ISourceRandom
        {
            private readonly SourceRandomProcessState owner;
            public CurrentRandomProxy(SourceRandomProcessState owner) => this.owner = owner;
            public int Next() => owner.Random.Next();
            public int Next(int maxValue) => owner.Random.Next(maxValue);
            public int Next(int minValue, int maxValue) => owner.Random.Next(minValue, maxValue);
            public double NextDouble() => owner.Random.NextDouble();
            public float NextSingle() => owner.Random.NextSingle();
            public long NextInt64() => owner.Random.NextInt64();
            public long NextInt64(long maxValue) => owner.Random.NextInt64(maxValue);
            public long NextInt64(long minValue, long maxValue) => owner.Random.NextInt64(minValue, maxValue);
            public void NextBytes(byte[] buffer) => owner.Random.NextBytes(buffer);
            public void NextBytes(Span<byte> buffer) => owner.Random.NextBytes(buffer);
            public ISourceRandomSnapshot CaptureState() => owner.Random.CaptureState();
            public void RestoreState(ISourceRandomSnapshot state) => owner.Random.RestoreState(state);
        }

        public void PushRandom(int newSeed)
        {
            randomStack.Push(Random);
            Random = Factory.CreateSeeded(newSeed);
        }

        public void PushRandom(ISourceRandom random)
        {
            randomStack.Push(Random);
            Random = random;
        }

        public void PushRandom()
        {
            randomStack.Push(Random);
            Random = Factory.CreateUnseeded();
        }

        public void PopRandom()
        {
            Random = randomStack.Pop();
        }
    }
}
