namespace FFmpeg
{
    public struct AVFilterGraph
    {
        public unsafe AVClass* av_class;

        public unsafe AVFilterContext** filters;

        public uint nb_filters;

        public unsafe byte* scale_sws_opts;

        public int thread_type;

        public int nb_threads;

        public unsafe AVFilterGraphInternal* @internal;

        public unsafe void* opaque;

        public AVFilterGraph_execute_func execute;

        public unsafe byte* aresample_swr_opts;

        public unsafe AVFilterLink** sink_links;

        public int sink_links_count;

        public uint disable_auto_convert;
    }
}
