using System;

namespace FFmpeg
{
    public struct AVBufferSrcParameters
    {
        public int format;

        public AVRational time_base;

        public int width;

        public int height;

        public AVRational sample_aspect_ratio;

        public AVRational frame_rate;

        public unsafe AVBufferRef* hw_frames_ctx;

        public int sample_rate;

        [Obsolete("use ch_layout")] public ulong channel_layout;

        public AVChannelLayout ch_layout;
    }
}
