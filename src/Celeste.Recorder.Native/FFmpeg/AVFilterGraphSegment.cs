namespace FFmpeg
{
    public struct AVFilterGraphSegment
    {
        public unsafe AVFilterGraph* graph;

        public unsafe AVFilterChain** chains;

        public ulong nb_chains;

        public unsafe byte* scale_sws_opts;
    }
}
