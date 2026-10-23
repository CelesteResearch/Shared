namespace FFmpeg
{
    public struct AVFilterInOut
    {
        public unsafe byte* name;

        public unsafe AVFilterContext* filter_ctx;

        public int pad_idx;

        public unsafe AVFilterInOut* next;
    }
}
