namespace Celeste.Core.Diagnostics.Runtime
{
    public readonly struct SourceRuntimeGcMemorySnapshot(
        long heapSizeBytes,
        long totalCommittedBytes,
        long totalAvailableMemoryBytes)
    {
        public readonly long HeapSizeBytes = heapSizeBytes;
        public readonly long TotalCommittedBytes = totalCommittedBytes;
        public readonly long TotalAvailableMemoryBytes = totalAvailableMemoryBytes;
    }
}
