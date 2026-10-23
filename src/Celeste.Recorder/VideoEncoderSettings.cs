namespace Celeste.Recorder
{
    public sealed class VideoEncoderSettings
    {
        public string FFmpegPath;
        public string OutputDirectory;
        public int Width = 1920, Height = 1080, FramesPerSecond = 60;
        public int SampleRate = 48000, AudioChannels = 2, AudioBitrate = 128000;
        public int Quality = 21;
        public int VideoBitrate = 6500000;
        public string H264Preset = "faster", Container = "mp4";
    }
}
