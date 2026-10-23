using System;

namespace Celeste.Recorder
{
    public sealed class NullRecordingEncoder : IRecordingEncoder
    {
        public bool HasVideo => true;
        public bool HasAudio => true;
        public string OutputPath { get; }
        public long VideoFrames { get; private set; }
        public long AudioSamples { get; private set; }
        public int QueuedVideoFrames => 0;

        public NullRecordingEncoder(RecorderSettings settings, string name)
        {
            OutputPath = System.IO.Path.Combine(settings.OutputDirectory,
                (name ?? DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")) + "." + settings.ContainerType);
        }

        public void WriteVideo(byte[] rgba, int width, int height, bool bottomUp)
        {
            VideoFrames++;
        }

        public void WriteAudio(float[] pcm, int samples, int channels)
        {
            AudioSamples += samples;
        }

        public void RefreshSettings()
        {
        }

        public void Finish()
        {
        }

        public void Dispose()
        {
        }
    }
}
