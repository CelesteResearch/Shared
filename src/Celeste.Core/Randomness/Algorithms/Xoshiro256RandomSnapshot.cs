namespace Celeste.Core.Randomness.Algorithms
{
    public sealed class Xoshiro256RandomSnapshot(ulong s0, ulong s1, ulong s2, ulong s3) : ISourceRandomSnapshot
    {
        public ulong S0 { get; }
            = s0;

        public ulong S1 { get; }
            = s1;

        public ulong S2 { get; }
            = s2;

        public ulong S3 { get; }
            = s3;
    }
}
