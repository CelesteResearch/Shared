namespace FFmpeg
{
    public struct AVD3D11VAFramesContext
    {
        public unsafe ID3D11Texture2D* texture;

        public uint BindFlags;

        public uint MiscFlags;

        public unsafe AVD3D11FrameDescriptor* texture_infos;
    }
}
