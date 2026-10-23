namespace Celeste.Simulation.Diagnostics.Frames
{
    // This is a diagnostic claim supplied by the host, never produced by
    // advancing a live Random. The same algorithm ID must be used on both hosts.
    public enum RngEvidenceKind : byte
    {
        Unavailable = 0,
        CloneNextInt32 = 1, // weak: equal next values do not prove equal state
        StateDigest64 = 2, // equal digests never prove equal full state
    }
}
