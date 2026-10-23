namespace FFmpeg
{
    public struct AVD3D11FrameDescriptor
    {
        public unsafe ID3D11Texture2D* texture;

        public long index;
    }
}
