namespace FFmpeg
{
    public struct AVHWFramesConstraints
    {
        public unsafe AVPixelFormat* valid_hw_formats;

        public unsafe AVPixelFormat* valid_sw_formats;

        public int min_width;

        public int min_height;

        public int max_width;

        public int max_height;
    }
}
