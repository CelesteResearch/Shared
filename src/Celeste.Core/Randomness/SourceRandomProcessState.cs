using System;
using System.Collections.Generic;

namespace Celeste.Core.Randomness
{
    public sealed class SourceRandomProcessState
    {
        public ISourceRandomFactory Factory { get; }
        private readonly Stack<ISourceRandom> _randomStack;
        public ISourceRandom Random;
        public ISourceRandom Proxy { get; }

        public SourceRandomProcessState(ISourceRandomFactory factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
            Random = Factory.CreateUnseeded();
            _randomStack = new();
            Proxy = new CurrentRandomProxy(this);
        }

        private sealed class CurrentRandomProxy(SourceRandomProcessState owner) : ISourceRandom
        {
            // ReSharper disable once ReplaceWithPrimaryConstructorParameter
            private readonly SourceRandomProcessState _owner = owner;


            public int Next()
            {
                return _owner.Random.Next();
            }

            public int Next(int maxValue)
            {
                return _owner.Random.Next(maxValue);
            }

            public int Next(int minValue, int maxValue)
            {
                return _owner.Random.Next(minValue, maxValue);
            }

            public double NextDouble()
            {
                return _owner.Random.NextDouble();
            }

            public float NextSingle()
            {
                return _owner.Random.NextSingle();
            }

            public long NextInt64()
            {
                return _owner.Random.NextInt64();
            }

            public long NextInt64(long maxValue)
            {
                return _owner.Random.NextInt64(maxValue);
            }

            public long NextInt64(long minValue, long maxValue)
            {
                return _owner.Random.NextInt64(minValue, maxValue);
            }

            public void NextBytes(byte[] buffer)
            {
                _owner.Random.NextBytes(buffer);
            }

            public void NextBytes(Span<byte> buffer)
            {
                _owner.Random.NextBytes(buffer);
            }

            public ISourceRandomSnapshot CaptureState()
            {
                return _owner.Random.CaptureState();
            }

            public void RestoreState(ISourceRandomSnapshot state)
            {
                _owner.Random.RestoreState(state);
            }
        }

        public void PushRandom(int newSeed)
        {
            _randomStack.Push(Random);
            Random = Factory.CreateSeeded(newSeed);
        }

        public void PushRandom(ISourceRandom random)
        {
            _randomStack.Push(Random);
            Random = random;
        }

        public void PushRandom()
        {
            _randomStack.Push(Random);
            Random = Factory.CreateUnseeded();
        }

        public void PopRandom()
        {
            Random = _randomStack.Pop();
        }
    }
}
