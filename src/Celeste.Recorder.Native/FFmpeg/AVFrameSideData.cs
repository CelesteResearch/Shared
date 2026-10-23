namespace FFmpeg
{
    public struct AVFrameSideData
    {
        public AVFrameSideDataType type;

        public unsafe byte* data;

        public ulong size;

        public unsafe AVDictionary* metadata;

        public unsafe AVBufferRef* buf;
    }
}
