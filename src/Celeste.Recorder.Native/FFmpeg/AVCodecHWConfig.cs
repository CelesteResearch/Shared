namespace FFmpeg
{
    // ReSharper disable once InconsistentNaming
    public struct AVCodecHWConfig
    {
        public AVPixelFormat pix_fmt;

        public int methods;

        public AVHWDeviceType device_type;
    }
}
