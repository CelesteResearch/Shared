using System;
using Celeste.Core.Randomness;
using Celeste.Core.Randomness.Algorithms;

namespace Celeste.Game.Execution.Randomness
{
    public sealed class OriginalRandomFactory(ISourceRandomSeedDevice device) : ISourceRandomFactory
    {
        private readonly ISourceRandomArgumentPolicy arguments = new OriginalRandomArgumentPolicy();
        public ISourceRandom CreateUnseeded() => new SubtractiveRandomState(device.TickCount, arguments);
        public ISourceRandom CreateSeeded(int seed) => new SubtractiveRandomState(seed, arguments);
    }
}
