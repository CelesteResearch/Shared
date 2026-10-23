using System;
using Celeste.Recorder.Native;

namespace Celeste.Recorder
{
    public sealed class NativeRecordingEncoder : IRecordingEncoder
    {
        private readonly RecorderSettings settings;
        private readonly NativeEncoderSettings nativeSettings;
        private readonly NativeVideoEncoder encoder;
        private bool finished;
        public bool HasVideo => encoder.HasVideo;
        public bool HasAudio => encoder.HasAudio;
        public string OutputPath => encoder.FilePath;
        public long VideoFrames { get; private set; }
        public long AudioSamples { get; private set; }
        public int QueuedVideoFrames => 0;

        public NativeRecordingEncoder(RecorderSettings settings, string name)
        {
            this.settings = settings;
            FFmpeg.NativeBindings.LibraryDirectory = settings.NativeLibraryDirectory;
            nativeSettings = new NativeEncoderSettings
            {
                FPS = settings.FPS, VideoWidth = settings.VideoWidth, VideoHeight = settings.VideoHeight,
                VideoBitrate = settings.VideoBitrate, AudioBitrate = settings.AudioBitrate,
                OutputDirectory = settings.OutputDirectory, ContainerType = settings.ContainerType,
                VideoCodecOverwrite = settings.VideoCodecOverwrite, AudioCodecOverwrite = settings.AudioCodecOverwrite,
                H264Preset = settings.H264Preset, H264Quality = settings.H264Quality, Log = settings.Warn
            };
            encoder = new NativeVideoEncoder(nativeSettings, name);
        }

        public void WriteVideo(byte[] rgba, int width, int height, bool bottomUp)
        {
            encoder.WriteVideo(rgba, width, height, bottomUp);
            VideoFrames++;
        }

        public void WriteAudio(float[] pcm, int samples, int channels)
        {
            encoder.WriteAudio(pcm, samples, channels);
            AudioSamples += samples;
        }

        public void RefreshSettings()
        {
            nativeSettings.FPS = settings.FPS;
            encoder.RefreshSettings();
        }

        public void Finish()
        {
            if (finished) return;
            finished = true;
            encoder.Finish();
        }

        public void Dispose() => Finish();
    }
}
