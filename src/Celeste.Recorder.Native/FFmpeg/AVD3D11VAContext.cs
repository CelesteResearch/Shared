namespace FFmpeg
{
    public struct AVD3D11VAContext
    {
        public unsafe ID3D11VideoDecoder* decoder;

        public unsafe ID3D11VideoContext* video_context;

        public unsafe D3D11_VIDEO_DECODER_CONFIG* cfg;

        public uint surface_count;

        public unsafe ID3D11VideoDecoderOutputView** surface;

        public ulong workaround;

        public uint report_id;

        public unsafe void* context_mutex;
    }
}
