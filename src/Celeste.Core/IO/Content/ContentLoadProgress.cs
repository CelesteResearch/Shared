namespace Celeste.Core.IO.Content
{
    // Logical payload bytes; Ready means validation and publication have completed, not GPU preparation.
    public readonly struct ContentLoadProgress
    {
        public long TotalBytes { get; }
        public long ReceivedBytes { get; }
        public long ReadyBytes { get; }
        public long CachedBytes { get; }
        public int TotalFiles { get; }
        public int ReadyFiles { get; }

        public ContentLoadProgress(long totalBytes, long receivedBytes, long readyBytes, int totalFiles,
            int readyFiles)
            : this(totalBytes, receivedBytes, readyBytes, totalFiles, readyFiles, 0)
        {
        }

        public ContentLoadProgress(long totalBytes, long receivedBytes, long readyBytes, int totalFiles,
            int readyFiles, long cachedBytes)
        {
            TotalBytes = totalBytes;
            ReceivedBytes = receivedBytes;
            ReadyBytes = readyBytes;
            CachedBytes = cachedBytes;
            TotalFiles = totalFiles;
            ReadyFiles = readyFiles;
        }
    }
}
