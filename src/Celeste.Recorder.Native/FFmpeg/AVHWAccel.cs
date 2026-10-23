namespace FFmpeg
{
    public struct AVHWAccel
    {
        public unsafe byte* name;

        public AVMediaType type;

        public AVCodecID id;

        public AVPixelFormat pix_fmt;

        public int capabilities;

        public AVHWAccel_alloc_frame_func alloc_frame;

        public AVHWAccel_start_frame_func start_frame;

        public AVHWAccel_decode_params_func decode_params;

        public AVHWAccel_decode_slice_func decode_slice;

        public AVHWAccel_end_frame_func end_frame;

        public int frame_priv_data_size;

        public AVHWAccel_init_func init;

        public AVHWAccel_uninit_func uninit;

        public int priv_data_size;

        public int caps_internal;

        public AVHWAccel_frame_params_func frame_params;
    }
}
