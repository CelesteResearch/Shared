using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Celeste.Recorder.Native
{
    public abstract class Encoder
    {
        protected readonly NativeEncoderSettings settings;
        public readonly string FilePath;
        public unsafe byte* VideoData;
        public unsafe byte* AudioData;
        public int VideoRowStride;
        public bool HasVideo { get; protected set; }
        public bool HasAudio { get; protected set; }

        protected Encoder(NativeEncoderSettings settings, string fileName)
        {
            this.settings = settings;
            FilePath = Path.GetFullPath(Path.Combine(settings.OutputDirectory,
                (fileName ?? DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")) + "." + settings.ContainerType));
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
        }

        public abstract void End();
        public abstract void PrepareVideo(int width, int height);
        public abstract void PrepareAudio(uint channels, uint samples);
        public abstract void FinishVideo();
        public abstract void FinishAudio();
        private readonly object gate = new();

        public unsafe void WriteVideo(byte[] rgba, int width, int height, bool bottomUp)
        {
            if (!HasVideo) return;
            if (rgba.Length != checked(width * height * 4))
                throw new ArgumentException("Frame dimensions", nameof(rgba));
            lock (gate)
            {
                PrepareVideo(width, height);
                for (var y = 0; y < height; y++)
                    Marshal.Copy(rgba, (bottomUp ? height - 1 - y : y) * width * 4,
                        (IntPtr)(VideoData + y * VideoRowStride), width * 4);
                FinishVideo();
            }
        }

        public unsafe void WriteAudio(float[] pcm, int samples, int channels)
        {
            if (!HasAudio) return;
            lock (gate)
            {
                PrepareAudio((uint)channels, (uint)samples);
                Marshal.Copy(pcm, 0, (IntPtr)AudioData, checked(samples * channels));
                FinishAudio();
            }
        }

        public void Finish()
        {
            lock (gate)
            {
                End();
            }
        }
    }
}
