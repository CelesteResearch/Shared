using System;

namespace Celeste.Recorder.Native
{
    public sealed class NativeEncoderSettings
    {
        public int FPS = 60, VideoWidth = 1920, VideoHeight = 1080, VideoBitrate = 6500000, AudioBitrate = 128000;
        public int VideoCodecOverwrite = -1, AudioCodecOverwrite = -1, H264Quality = 21;
        public string H264Preset = "faster", ContainerType = "mp4", OutputDirectory;
        public Action<string> Log;
    }
}
