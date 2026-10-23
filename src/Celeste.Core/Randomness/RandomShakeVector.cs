using System.Numerics;

namespace Celeste.Core.Randomness
{
    public static class RandomShakeVector
    {
        private static readonly int[] Offsets = [-1, -1, 0, 1, 1];

        public static Vector2 Next(ISourceRandom random)
        {
            return new(Offsets[random.Next(Offsets.Length)], Offsets[random.Next(Offsets.Length)]);
        }
    }
}
