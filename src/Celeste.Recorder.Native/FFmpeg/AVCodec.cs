namespace FFmpeg
{
    public struct AVCodec
    {
        public unsafe byte* name;

        public unsafe byte* long_name;

        // ReSharper disable once UnassignedField.Global
        public AVMediaType type;

        // ReSharper disable once UnassignedField.Global
        public AVCodecID id;

        public int capabilities;

        public byte max_lowres;

        public unsafe AVRational* supported_framerates;

        // ReSharper disable once UnassignedField.Global
        public unsafe AVPixelFormat* pix_fmts;

        public unsafe int* supported_samplerates;

        // ReSharper disable once UnassignedField.Global
        public unsafe AVSampleFormat* sample_fmts;

        public unsafe ulong* channel_layouts;

        public unsafe AVClass* priv_class;

        public unsafe AVProfile* profiles;

        public unsafe byte* wrapper_name;

        public unsafe AVChannelLayout* ch_layouts;
    }
}
