namespace Celeste.Simulation.Diagnostics.Frames
{
    public readonly struct RngStreamEvidence
    {
        public readonly RngEvidenceKind Kind;
        public readonly uint AlgorithmId;
        public readonly ulong Value;

        public RngStreamEvidence(RngEvidenceKind kind, uint algorithmId, ulong value)
        {
            Kind = kind;
            AlgorithmId = algorithmId;
            Value = value;
        }

        public static RngStreamEvidence CloneNext(uint algorithmId, int next)
        {
            return new(RngEvidenceKind.CloneNextInt32, algorithmId, unchecked((uint)next));
        }
    }
}
