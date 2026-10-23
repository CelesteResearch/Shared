namespace FFmpeg
{
    public struct AVOption
    {
        public unsafe byte* name;

        public unsafe byte* help;

        public int offset;

        public AVOptionType type;

        public AVOption_default_val default_val;

        public double min;

        public double max;

        public int flags;

        public unsafe byte* unit;
    }
}
