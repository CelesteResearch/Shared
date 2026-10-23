namespace FFmpeg
{
    public struct AVPacketSideData
    {
        public unsafe byte* data;

        public ulong size;

        public AVPacketSideDataType type;
    }
}
