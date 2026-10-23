namespace FFmpeg
{
    public struct AVDXVA2FramesContext
    {
        public ulong surface_type;

        public unsafe IDirect3DSurface9** surfaces;

        public int nb_surfaces;

        public unsafe IDirectXVideoDecoder* decoder_to_release;
    }
}
