namespace FFmpeg
{
    public struct AVSubtitleRect
    {
        public int x;

        public int y;

        public int w;

        public int h;

        public int nb_colors;

        public byte_ptr4 data;

        public int4 linesize;

        public AVSubtitleType type;

        public unsafe byte* text;

        public unsafe byte* ass;

        public int flags;
    }
}
