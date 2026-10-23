namespace FFmpeg
{
    public struct AVMasteringDisplayMetadata
    {
        public AVRational3x2 display_primaries;

        public AVRational2 white_point;

        public AVRational min_luminance;

        public AVRational max_luminance;

        public int has_primaries;

        public int has_luminance;
    }
}
