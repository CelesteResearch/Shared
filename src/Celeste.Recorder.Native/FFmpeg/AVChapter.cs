namespace FFmpeg
{
    public struct AVChapter
    {
        public long id;

        public AVRational time_base;

        public long start;

        public long end;

        public unsafe AVDictionary* metadata;
    }
}
