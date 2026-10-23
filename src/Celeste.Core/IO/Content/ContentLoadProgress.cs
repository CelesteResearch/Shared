namespace Celeste.Core.IO.Content
{
    // Logical payload bytes; Ready means validation and publication have completed, not GPU preparation.
    public readonly struct ContentLoadProgress(
        long totalBytes,
        long receivedBytes,
        long readyBytes,
        int totalFiles,
        int readyFiles,
        long cachedBytes)
    {
        public long TotalBytes { get; } = totalBytes;
        public long ReceivedBytes { get; } = receivedBytes;
        public long ReadyBytes { get; } = readyBytes;
        public long CachedBytes { get; } = cachedBytes;
        public int TotalFiles { get; } = totalFiles;
        public int ReadyFiles { get; } = readyFiles;

        public ContentLoadProgress(long totalBytes, long receivedBytes, long readyBytes, int totalFiles, int readyFiles)
            : this(totalBytes, receivedBytes, readyBytes, totalFiles, readyFiles, 0)
        {
        }
    }
}
