namespace Celeste.Core.Diagnostics.Runtime
{
    public readonly struct SourceRuntimeGcMemorySnapshot
    {
        public readonly long HeapSizeBytes;
        public readonly long TotalCommittedBytes;
        public readonly long TotalAvailableMemoryBytes;

        public SourceRuntimeGcMemorySnapshot(long heapSizeBytes, long totalCommittedBytes,
            long totalAvailableMemoryBytes)
        {
            HeapSizeBytes = heapSizeBytes;
            TotalCommittedBytes = totalCommittedBytes;
            TotalAvailableMemoryBytes = totalAvailableMemoryBytes;
        }
    }
}
