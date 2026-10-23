namespace FFmpeg
{
    public struct AVPixFmtDescriptor
    {
        public unsafe byte* name;

        public byte nb_components;

        public byte log2_chroma_w;

        public byte log2_chroma_h;

        public ulong flags;

        public AVComponentDescriptor4 comp;

        public unsafe byte* alias;
    }
}
