using System;

namespace FFmpeg
{
    public struct AVFrame
    {
        public byte_ptr8 data;

        public int8 linesize;

        public unsafe byte** extended_data;

        public int width;

        public int height;

        public int nb_samples;

        public int format;

        public int key_frame;

        public AVPictureType pict_type;

        public AVRational sample_aspect_ratio;

        public long pts;

        public long pkt_dts;

        public AVRational time_base;

        public int coded_picture_number;

        public int display_picture_number;

        public int quality;

        public unsafe void* opaque;

        public int repeat_pict;

        public int interlaced_frame;

        public int top_field_first;

        public int palette_has_changed;

        [Obsolete("Use AV_CODEC_FLAG_COPY_OPAQUE instead")]
        public long reordered_opaque;

        public int sample_rate;

        [Obsolete("use ch_layout instead")] public ulong channel_layout;

        public AVBufferRef_ptr8 buf;

        public unsafe AVBufferRef** extended_buf;

        public int nb_extended_buf;

        public unsafe AVFrameSideData** side_data;

        public int nb_side_data;

        public int flags;

        public AVColorRange color_range;

        public AVColorPrimaries color_primaries;

        public AVColorTransferCharacteristic color_trc;

        public AVColorSpace colorspace;

        public AVChromaLocation chroma_location;

        public long best_effort_timestamp;

        public long pkt_pos;

        [Obsolete("use duration instead")] public long pkt_duration;

        public unsafe AVDictionary* metadata;

        public int decode_error_flags;

        [Obsolete("use ch_layout instead")] public int channels;

        public int pkt_size;

        public unsafe AVBufferRef* hw_frames_ctx;

        public unsafe AVBufferRef* opaque_ref;

        public ulong crop_top;

        public ulong crop_bottom;

        public ulong crop_left;

        public ulong crop_right;

        public unsafe AVBufferRef* private_ref;

        public AVChannelLayout ch_layout;

        public long duration;
    }
}
