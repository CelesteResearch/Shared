namespace FFmpeg
{
    public struct AVFilterParams
    {
        public unsafe AVFilterContext* filter;

        public unsafe byte* filter_name;

        public unsafe byte* instance_name;

        public unsafe AVDictionary* opts;

        public unsafe AVFilterPadParams** inputs;

        public uint nb_inputs;

        public unsafe AVFilterPadParams** outputs;

        public uint nb_outputs;
    }
}
