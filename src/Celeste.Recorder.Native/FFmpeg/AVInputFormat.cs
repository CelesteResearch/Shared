namespace FFmpeg
{
    public struct AVInputFormat
    {
        public unsafe byte* name;

        public unsafe byte* long_name;

        public int flags;

        public unsafe byte* extensions;

        public unsafe AVCodecTag** codec_tag;

        public unsafe AVClass* priv_class;

        public unsafe byte* mime_type;

        public int raw_codec_id;

        public int priv_data_size;

        public int flags_internal;

        public AVInputFormat_read_probe_func read_probe;

        public AVInputFormat_read_header_func read_header;

        public AVInputFormat_read_packet_func read_packet;

        public AVInputFormat_read_close_func read_close;

        public AVInputFormat_read_seek_func read_seek;

        public AVInputFormat_read_timestamp_func read_timestamp;

        public AVInputFormat_read_play_func read_play;

        public AVInputFormat_read_pause_func read_pause;

        public AVInputFormat_read_seek2_func read_seek2;

        public AVInputFormat_get_device_list_func get_device_list;
    }
}
