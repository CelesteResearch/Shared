namespace FFmpeg
{
    public struct AVOptionRange
    {
        public unsafe byte* str;

        public double value_min;

        public double value_max;

        public double component_min;

        public double component_max;

        public int is_range;
    }
}
