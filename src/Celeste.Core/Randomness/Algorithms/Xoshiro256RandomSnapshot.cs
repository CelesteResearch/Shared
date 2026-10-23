namespace Celeste.Core.Randomness.Algorithms
{
    public sealed class Xoshiro256RandomSnapshot : ISourceRandomSnapshot
    {
        public ulong S0 { get; }
        public ulong S1 { get; }
        public ulong S2 { get; }
        public ulong S3 { get; }

        public Xoshiro256RandomSnapshot(ulong s0, ulong s1, ulong s2, ulong s3)
        {
            S0 = s0;
            S1 = s1;
            S2 = s2;
            S3 = s3;
        }
    }
}
