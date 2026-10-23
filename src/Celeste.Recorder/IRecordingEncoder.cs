using System;

namespace Celeste.Recorder
{
    public interface IRecordingEncoder : IDisposable
    {
        bool HasVideo { get; }
        bool HasAudio { get; }
        string OutputPath { get; }
        long VideoFrames { get; }
        long AudioSamples { get; }
        int QueuedVideoFrames { get; }
        void WriteVideo(byte[] rgba, int width, int height, bool bottomUp);
        void WriteAudio(float[] pcm, int samples, int channels);
        void RefreshSettings();
        void Finish();
    }
}
