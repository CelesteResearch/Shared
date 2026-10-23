namespace FFmpeg
{
    public struct AVOutputFormat
    {
        public unsafe byte* name;

        public unsafe byte* long_name;

        public unsafe byte* mime_type;

        public unsafe byte* extensions;

        public AVCodecID audio_codec;

        public AVCodecID video_codec;

        public AVCodecID subtitle_codec;

        public int flags;

        public unsafe AVCodecTag** codec_tag;

        public unsafe AVClass* priv_class;
    }
}
