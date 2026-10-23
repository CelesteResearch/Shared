namespace FFmpeg
{
    public struct AVClass
    {
        public unsafe byte* class_name;

        public AVClass_item_name_func item_name;

        public unsafe AVOption* option;

        public int version;

        public int log_level_offset_offset;

        public int parent_log_context_offset;

        public AVClassCategory category;

        public AVClass_get_category_func get_category;

        public AVClass_query_ranges_func query_ranges;

        public AVClass_child_next_func child_next;

        public AVClass_child_class_iterate_func child_class_iterate;
    }
}
