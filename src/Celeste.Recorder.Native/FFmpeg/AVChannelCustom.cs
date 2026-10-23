namespace FFmpeg
{
    public struct AVChannelCustom
    {
        public AVChannel id;

        public byte16 name;

        public unsafe void* opaque;
    }
}
