using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Celeste.Audio.Framework;
using Celeste.Audio.Interop;

namespace Celeste.Audio.Sound
{
    public sealed class SourceDynamicSoundEffectInstance : SourceSoundEffectInstance
    {
        internal SourceFAudioLayout.FAudioWaveFormatEx format;

        private readonly int _sampleRate;

        private readonly SourceAudioChannels _channels;

        private readonly List<IntPtr> _queuedBuffers;

        private readonly List<uint> _queuedSizes;

        private const int MINIMUM_BUFFER_CHECK = 3;

        public int PendingBufferCount => _queuedBuffers.Count;

        public override bool IsLooped
        {
            get => false;
            set { }
        }

        public event EventHandler<EventArgs> BufferNeeded;

        public SourceDynamicSoundEffectInstance(SourceAudioProcess process, int sampleRate,
            SourceAudioChannels channels) :
            base(process)
        {
            _sampleRate = sampleRate;
            _channels = channels;
            isDynamic = true;
            format = default;
            format.wFormatTag = 1;
            format.nChannels = (ushort)channels;
            format.nSamplesPerSec = (uint)sampleRate;
            format.wBitsPerSample = 16;
            format.nBlockAlign = (ushort)(2 * format.nChannels);
            format.nAvgBytesPerSec = format.nBlockAlign * format.nSamplesPerSec;
            format.cbSize = 0;
            _queuedBuffers = [];
            _queuedSizes = [];
            InitDSPSettings(format.nChannels);
        }

        ~SourceDynamicSoundEffectInstance()
        {
            Dispose();
        }

        public TimeSpan GetSampleDuration(int sizeInBytes)
        {
            return SourceSoundEffect.GetSampleDuration(sizeInBytes, _sampleRate, _channels);
        }

        public int GetSampleSizeInBytes(TimeSpan duration)
        {
            return SourceSoundEffect.GetSampleSizeInBytes(duration, _sampleRate, _channels);
        }

        public override void Play()
        {
            Update();
            base.Play();
            lock (Process.Dispatch.Streams)
            {
                if (!Process.Dispatch.Streams.Contains(this)) Process.Dispatch.Streams.Add(this);
            }
        }

        public void SubmitBuffer(byte[] buffer)
        {
            SubmitBuffer(buffer, 0, buffer.Length);
        }

        public void SubmitBuffer(byte[] buffer, int offset, int count)
        {
            var intPtr = IO.Malloc(count);
            Marshal.Copy(buffer, offset, intPtr, count);
            lock (_queuedBuffers)
            {
                _queuedBuffers.Add(intPtr);
                if (State != SourceSoundState.Stopped)
                {
                    var pBuffer = default(SourceFAudioLayout.FAudioBuffer);
                    pBuffer.AudioBytes = (uint)count;
                    pBuffer.pAudioData = intPtr;
                    pBuffer.PlayLength = pBuffer.AudioBytes / (uint)_channels / (uint)(format.wBitsPerSample / 8);
                    IO.FAudioSourceVoice_SubmitSourceBuffer(handle, ref pBuffer, IntPtr.Zero);
                }
                else
                {
                    _queuedSizes.Add((uint)count);
                }
            }
        }

        public void SubmitFloatBufferEXT(float[] buffer)
        {
            SubmitFloatBufferEXT(buffer, 0, buffer.Length);
        }

        public void SubmitFloatBufferEXT(float[] buffer, int offset, int count)
        {
            if (State != SourceSoundState.Stopped && format.wFormatTag == 1)
                throw new InvalidOperationException("Submit a float buffer before Playing!");

            format.wFormatTag = 3;
            format.wBitsPerSample = 32;
            format.nBlockAlign = (ushort)(4 * format.nChannels);
            format.nAvgBytesPerSec = format.nBlockAlign * format.nSamplesPerSec;
            var intPtr = IO.Malloc(count * 4);
            Marshal.Copy(buffer, offset, intPtr, count);
            lock (_queuedBuffers)
            {
                _queuedBuffers.Add(intPtr);
                if (State != SourceSoundState.Stopped)
                {
                    var pBuffer = default(SourceFAudioLayout.FAudioBuffer);
                    pBuffer.AudioBytes = (uint)(count * 4);
                    pBuffer.pAudioData = intPtr;
                    pBuffer.PlayLength = pBuffer.AudioBytes / (uint)_channels / (uint)(format.wBitsPerSample / 8);
                    IO.FAudioSourceVoice_SubmitSourceBuffer(handle, ref pBuffer, IntPtr.Zero);
                }
                else
                {
                    _queuedSizes.Add((uint)(count * 4));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        internal void QueueInitialBuffers()
        {
            var pBuffer = default(SourceFAudioLayout.FAudioBuffer);
            lock (_queuedBuffers)
            {
                for (var i = 0; i < _queuedBuffers.Count; i++)
                {
                    pBuffer.AudioBytes = _queuedSizes[i];
                    pBuffer.pAudioData = _queuedBuffers[i];
                    pBuffer.PlayLength = pBuffer.AudioBytes / (uint)_channels / (uint)(format.wBitsPerSample / 8);
                    IO.FAudioSourceVoice_SubmitSourceBuffer(handle, ref pBuffer, IntPtr.Zero);
                }

                _queuedSizes.Clear();
            }
        }

        internal void ClearBuffers()
        {
            lock (_queuedBuffers)
            {
                foreach (var queuedBuffer in _queuedBuffers) IO.Free(queuedBuffer);

                _queuedBuffers.Clear();
                _queuedSizes.Clear();
            }
        }

        public void Update()
        {
            if (State != SourceSoundState.Playing) return;

            if (handle != IntPtr.Zero)
            {
                IO.FAudioSourceVoice_GetState(handle, out var pVoiceState, 256u);
                while (PendingBufferCount > pVoiceState.BuffersQueued)
                    lock (_queuedBuffers)
                    {
                        IO.Free(_queuedBuffers[0]);
                        _queuedBuffers.RemoveAt(0);
                    }
            }

            var num = 3 - PendingBufferCount;
            while (num > 0 && BufferNeeded != null)
            {
                BufferNeeded(this, null);
                num--;
            }
        }
    }
}
