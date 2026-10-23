namespace FFmpeg
{
    public struct AVCodecDescriptor
    {
        public AVCodecID id;

        public AVMediaType type;

        public unsafe byte* name;

        public unsafe byte* long_name;

        public int props;

        public unsafe byte** mime_types;

        public unsafe AVProfile* profiles;
    }
}
