namespace FFmpeg
{
    public struct AVFilter
    {
        public unsafe byte* name;

        public unsafe byte* description;

        public unsafe AVFilterPad* inputs;

        public unsafe AVFilterPad* outputs;

        public unsafe AVClass* priv_class;

        public int flags;

        public byte nb_inputs;

        public byte nb_outputs;

        public byte formats_state;

        public AVFilter_preinit_func preinit;

        public AVFilter_init_func init;

        public AVFilter_uninit_func uninit;

        public AVFilter_formats formats;

        public int priv_size;

        public int flags_internal;

        public AVFilter_process_command_func process_command;

        public AVFilter_activate_func activate;
    }
}
