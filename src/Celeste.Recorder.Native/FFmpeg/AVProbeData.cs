namespace FFmpeg
{
    public struct AVProbeData
    {
        public unsafe byte* filename;

        public unsafe byte* buf;

        public int buf_size;

        public unsafe byte* mime_type;
    }
}
