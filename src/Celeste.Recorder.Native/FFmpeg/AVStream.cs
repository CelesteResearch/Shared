namespace FFmpeg
{
    public struct AVStream
    {
        public unsafe AVClass* av_class;

        public int index;

        public int id;

        public unsafe AVCodecParameters* codecpar;

        public unsafe void* priv_data;

        public AVRational time_base;

        public long start_time;

        public long duration;

        public long nb_frames;

        public int disposition;

        public AVDiscard discard;

        public AVRational sample_aspect_ratio;

        public unsafe AVDictionary* metadata;

        public AVRational avg_frame_rate;

        public AVPacket attached_pic;

        public unsafe AVPacketSideData* side_data;

        public int nb_side_data;

        public int event_flags;

        public AVRational r_frame_rate;

        public int pts_wrap_bits;
    }
}
