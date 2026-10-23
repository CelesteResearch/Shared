namespace FFmpeg
{
    public struct AVIOContext
    {
        public unsafe AVClass* av_class;

        public unsafe byte* buffer;

        public int buffer_size;

        public unsafe byte* buf_ptr;

        public unsafe byte* buf_end;

        public unsafe void* opaque;

        public AVIOContext_read_packet_func read_packet;

        public AVIOContext_write_packet_func write_packet;

        public AVIOContext_seek_func seek;

        public long pos;

        public int eof_reached;

        public int error;

        public int write_flag;

        public int max_packet_size;

        public int min_packet_size;

        public ulong checksum;

        public unsafe byte* checksum_ptr;

        public AVIOContext_update_checksum_func update_checksum;

        public AVIOContext_read_pause_func read_pause;

        public AVIOContext_read_seek_func read_seek;

        public int seekable;

        public int direct;

        public unsafe byte* protocol_whitelist;

        public unsafe byte* protocol_blacklist;

        public AVIOContext_write_data_type_func write_data_type;

        public int ignore_boundary_point;

        public unsafe byte* buf_ptr_max;

        public long bytes_read;

        public long bytes_written;
    }
}
