namespace FFmpeg
{
    public struct AVPacket
    {
        public unsafe AVBufferRef* buf;

        public long pts;

        public long dts;

        public unsafe byte* data;

        public int size;

        public int stream_index;

        public int flags;

        public unsafe AVPacketSideData* side_data;

        public int side_data_elems;

        public long duration;

        public long pos;

        public unsafe void* opaque;

        public unsafe AVBufferRef* opaque_ref;

        public AVRational time_base;
    }
}
