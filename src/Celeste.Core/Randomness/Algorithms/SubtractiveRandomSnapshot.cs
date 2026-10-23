namespace Celeste.Core.Randomness.Algorithms
{
    public sealed class SubtractiveRandomSnapshot : ISourceRandomSnapshot
    {
        internal int[] SeedArray { get; }
        internal int Inext { get; }
        internal int Inextp { get; }

        internal SubtractiveRandomSnapshot(int[] seedArray, int inext, int inextp)
        {
            SeedArray = seedArray;
            Inext = inext;
            Inextp = inextp;
        }
    }
}
