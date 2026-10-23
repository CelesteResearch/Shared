namespace FFmpeg
{
    public struct AVCPBProperties
    {
        public long max_bitrate;

        public long min_bitrate;

        public long avg_bitrate;

        public long buffer_size;

        public ulong vbv_delay;
    }
}
