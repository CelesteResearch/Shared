namespace FFmpeg
{
    public struct AVBufferRef
    {
        public unsafe AVBuffer* buffer;

        public unsafe byte* data;

        public ulong size;
    }
}
