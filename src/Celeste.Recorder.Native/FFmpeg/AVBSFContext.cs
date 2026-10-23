namespace FFmpeg
{
    public struct AVBSFContext
    {
        public unsafe AVClass* av_class;

        public unsafe AVBitStreamFilter* filter;

        public unsafe void* priv_data;

        public unsafe AVCodecParameters* par_in;

        public unsafe AVCodecParameters* par_out;

        public AVRational time_base_in;

        public AVRational time_base_out;
    }
}
