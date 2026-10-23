using System;
using Celeste.Audio.Sound;

namespace Celeste.Audio.Capture
{
    public class SourceMicrophone
    {
        public readonly string Name;

        private TimeSpan bufferDuration;

        private readonly uint handle;

        private readonly SourceMicrophoneProcess process;
        internal const int SAMPLERATE = 44100;

        public TimeSpan BufferDuration
        {
            get => bufferDuration;
            set
            {
                if (value.Milliseconds < 100 || value.Milliseconds > 1000 || value.Milliseconds % 10 != 0)
                    throw new ArgumentOutOfRangeException();

                bufferDuration = value;
            }
        }

        public bool IsHeadset => false;

        public int SampleRate => 44100;

        public SourceMicrophoneState State { get; private set; }

        public event EventHandler<EventArgs> BufferReady;

        public SourceMicrophone(SourceMicrophoneProcess process, uint id, string name)
        {
            this.process = process;
            handle = id;
            Name = name;
            bufferDuration = process.TimeSpans.FromSeconds(1.0);
            State = SourceMicrophoneState.Stopped;
        }

        public int GetData(byte[] buffer)
        {
            return GetData(buffer, 0, buffer.Length);
        }

        public int GetData(byte[] buffer, int offset, int count)
        {
            if (buffer == null) throw new ArgumentException("buffer is null!");

            if (offset < 0 || offset > buffer.Length) throw new ArgumentException("offset");

            if (count <= 0 || offset + count > buffer.Length) throw new ArgumentException("count");

            return process.IO.GetMicrophoneSamples(handle, buffer, offset, count);
        }

        public TimeSpan GetSampleDuration(int sizeInBytes)
        {
            return SourceSoundEffect.GetSampleDuration(sizeInBytes, SampleRate, SourceAudioChannels.Mono);
        }

        public int GetSampleSizeInBytes(TimeSpan duration)
        {
            return SourceSoundEffect.GetSampleSizeInBytes(duration, SampleRate, SourceAudioChannels.Mono);
        }

        public void Start()
        {
            process.IO.StartMicrophone(handle);
            State = SourceMicrophoneState.Started;
        }

        public void Stop()
        {
            process.IO.StopMicrophone(handle);
            State = SourceMicrophoneState.Stopped;
        }

        public void CheckBuffer()
        {
            if (BufferReady != null &&
                GetSampleDuration(process.IO.GetMicrophoneQueuedBytes(handle)) > bufferDuration)
                BufferReady(this, EventArgs.Empty);
        }
    }
}
