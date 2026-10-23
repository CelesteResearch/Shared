namespace FFmpeg
{
    public struct AVFilterChain
    {
        public unsafe AVFilterParams** filters;

        public ulong nb_filters;
    }
}
