using System;

namespace FFmpeg
{
    public struct AVFilterLink
    {
        public unsafe AVFilterContext* src;

        public unsafe AVFilterPad* srcpad;

        public unsafe AVFilterContext* dst;

        public unsafe AVFilterPad* dstpad;

        public AVMediaType type;

        public int w;

        public int h;

        public AVRational sample_aspect_ratio;

        [Obsolete("use ch_layout")] public ulong channel_layout;

        public int sample_rate;

        public int format;

        public AVRational time_base;

        public AVChannelLayout ch_layout;

        public AVFilterFormatsConfig incfg;

        public AVFilterFormatsConfig outcfg;

        public AVFilterLink_init_state init_state;

        public unsafe AVFilterGraph* graph;

        public long current_pts;

        public long current_pts_us;

        public int age_index;

        public AVRational frame_rate;

        public int min_samples;

        public int max_samples;

        public long frame_count_in;

        public long frame_count_out;

        public long sample_count_in;

        public long sample_count_out;

        public unsafe void* frame_pool;

        public int frame_wanted_out;

        public unsafe AVBufferRef* hw_frames_ctx;

        public byte61440 reserved;
    }
}
