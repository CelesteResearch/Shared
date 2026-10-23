namespace FFmpeg
{
    public struct AVPacketList
    {
        public AVPacket pkt;

        public unsafe AVPacketList* next;
    }
}
