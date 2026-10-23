using System;

namespace FFmpeg
{
    public struct AVCodecContext
    {
        public unsafe AVClass* av_class;

        public int log_level_offset;

        public AVMediaType codec_type;

        public unsafe AVCodec* codec;

        public AVCodecID codec_id;

        public uint codec_tag;

        public unsafe void* priv_data;

        public unsafe AVCodecInternal* @internal;

        public unsafe void* opaque;

        public long bit_rate;

        public int bit_rate_tolerance;

        public int global_quality;

        public int compression_level;

        public int flags;

        public int flags2;

        public unsafe byte* extradata;

        public int extradata_size;

        public AVRational time_base;

        public int ticks_per_frame;

        public int delay;

        public int width;

        public int height;

        public int coded_width;

        public int coded_height;

        public int gop_size;

        public AVPixelFormat pix_fmt;

        public AVCodecContext_draw_horiz_band_func draw_horiz_band;

        public AVCodecContext_get_format_func get_format;

        public int max_b_frames;

        public float b_quant_factor;

        public float b_quant_offset;

        public int has_b_frames;

        public float i_quant_factor;

        public float i_quant_offset;

        public float lumi_masking;

        public float temporal_cplx_masking;

        public float spatial_cplx_masking;

        public float p_masking;

        public float dark_masking;

        public int slice_count;

        public unsafe int* slice_offset;

        public AVRational sample_aspect_ratio;

        public int me_cmp;

        public int me_sub_cmp;

        public int mb_cmp;

        public int ildct_cmp;

        public int dia_size;

        public int last_predictor_count;

        public int me_pre_cmp;

        public int pre_dia_size;

        public int me_subpel_quality;

        public int me_range;

        public int slice_flags;

        public int mb_decision;

        public unsafe ushort* intra_matrix;

        public unsafe ushort* inter_matrix;

        public int intra_dc_precision;

        public int skip_top;

        public int skip_bottom;

        public int mb_lmin;

        public int mb_lmax;

        public int bidir_refine;

        public int keyint_min;

        public int refs;

        public int mv0_threshold;

        public AVColorPrimaries color_primaries;

        public AVColorTransferCharacteristic color_trc;

        public AVColorSpace colorspace;

        public AVColorRange color_range;

        public AVChromaLocation chroma_sample_location;

        public int slices;

        public AVFieldOrder field_order;

        public int sample_rate;

        [Obsolete("use ch_layout.nb_channels")]
        public int channels;

        public AVSampleFormat sample_fmt;

        // ReSharper disable once UnassignedField.Global
        public int frame_size;

        [Obsolete("use frame_num instead")] public int frame_number;

        public int block_align;

        public int cutoff;

        [Obsolete("use ch_layout")] public ulong channel_layout;

        [Obsolete("use \"downmix\" codec private option")]
        public ulong request_channel_layout;

        public AVAudioServiceType audio_service_type;

        public AVSampleFormat request_sample_fmt;

        public AVCodecContext_get_buffer2_func get_buffer2;

        public float qcompress;

        public float qblur;

        public int qmin;

        public int qmax;

        public int max_qdiff;

        public int rc_buffer_size;

        public int rc_override_count;

        public unsafe RcOverride* rc_override;

        public long rc_max_rate;

        public long rc_min_rate;

        public float rc_max_available_vbv_use;

        public float rc_min_vbv_overflow_use;

        public int rc_initial_buffer_occupancy;

        public int trellis;

        public unsafe byte* stats_out;

        public unsafe byte* stats_in;

        public int workaround_bugs;

        public int strict_std_compliance;

        public int error_concealment;

        public int debug;

        public int err_recognition;

        [Obsolete("Use AV_CODEC_FLAG_COPY_OPAQUE instead")]
        public long reordered_opaque;

        public unsafe AVHWAccel* hwaccel;

        public unsafe void* hwaccel_context;

        public ulong8 error;

        public int dct_algo;

        public int idct_algo;

        public int bits_per_coded_sample;

        public int bits_per_raw_sample;

        public int lowres;

        public int thread_count;

        public int thread_type;

        public int active_thread_type;

        public AVCodecContext_execute_func execute;

        public AVCodecContext_execute2_func execute2;

        public int nsse_weight;

        public int profile;

        public int level;

        public AVDiscard skip_loop_filter;

        public AVDiscard skip_idct;

        public AVDiscard skip_frame;

        public unsafe byte* subtitle_header;

        public int subtitle_header_size;

        public int initial_padding;

        public AVRational framerate;

        public AVPixelFormat sw_pix_fmt;

        public AVRational pkt_timebase;

        public unsafe AVCodecDescriptor* codec_descriptor;

        public long pts_correction_num_faulty_pts;

        public long pts_correction_num_faulty_dts;

        public long pts_correction_last_pts;

        public long pts_correction_last_dts;

        public unsafe byte* sub_charenc;

        public int sub_charenc_mode;

        public int skip_alpha;

        public int seek_preroll;

        public unsafe ushort* chroma_intra_matrix;

        public unsafe byte* dump_separator;

        public unsafe byte* codec_whitelist;

        public uint properties;

        public unsafe AVPacketSideData* coded_side_data;

        public int nb_coded_side_data;

        public unsafe AVBufferRef* hw_frames_ctx;

        public int trailing_padding;

        public long max_pixels;

        public unsafe AVBufferRef* hw_device_ctx;

        public int hwaccel_flags;

        public int apply_cropping;

        public int extra_hw_frames;

        public int discard_damaged_percentage;

        public long max_samples;

        public int export_side_data;

        public AVCodecContext_get_encode_buffer_func get_encode_buffer;

        public AVChannelLayout ch_layout;

        public long frame_num;
    }
}
