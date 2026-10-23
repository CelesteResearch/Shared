namespace FFmpeg
{
    public struct AVFilterFormatsConfig
    {
        public unsafe AVFilterFormats* formats;

        public unsafe AVFilterFormats* samplerates;

        public unsafe AVFilterChannelLayouts* channel_layouts;
    }
}
