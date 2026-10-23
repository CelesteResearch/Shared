using System;
using System.Numerics;

namespace Celeste.Core.Randomness
{
    public static class RandomShakeVector
    {
        private static readonly int[] offsets = { -1, -1, 0, 1, 1 };

        public static Vector2 Next(ISourceRandom random)
            => new Vector2(offsets[random.Next(offsets.Length)], offsets[random.Next(offsets.Length)]);
    }
}
