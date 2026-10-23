namespace FFmpeg
{
    public struct AVChannelLayout
    {
        public AVChannelOrder order;

        // ReSharper disable once UnassignedField.Global
        public int nb_channels;

        public AVChannelLayout_u u;

        public unsafe void* opaque;
    }
}
