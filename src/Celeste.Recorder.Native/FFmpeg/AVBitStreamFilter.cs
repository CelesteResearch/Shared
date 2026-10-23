namespace FFmpeg
{
    public struct AVBitStreamFilter
    {
        public unsafe byte* name;

        public unsafe AVCodecID* codec_ids;

        public unsafe AVClass* priv_class;
    }
}
