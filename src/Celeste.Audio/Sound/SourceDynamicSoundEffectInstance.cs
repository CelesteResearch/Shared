using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Sound
{
    using Celeste.Audio.Framework;
    using Celeste.Audio.Interop;

    public sealed class SourceDynamicSoundEffectInstance : SourceSoundEffectInstance
    {
        internal SourceFAudioLayout.FAudioWaveFormatEx format;

        private int sampleRate;

        private SourceAudioChannels channels;

        private List<IntPtr> queuedBuffers;

        private List<uint> queuedSizes;

        private const int MINIMUM_BUFFER_CHECK = 3;

        public int PendingBufferCount => queuedBuffers.Count;

        public override bool IsLooped
        {
            get { return false; }
            set { }
        }

        public event EventHandler<EventArgs> BufferNeeded;

        public SourceDynamicSoundEffectInstance(SourceAudioProcess process, int sampleRate,
            SourceAudioChannels channels) :
            base(process)
        {
            this.sampleRate = sampleRate;
            this.channels = channels;
            isDynamic = true;
            format = default(SourceFAudioLayout.FAudioWaveFormatEx);
            format.wFormatTag = 1;
            format.nChannels = (ushort)channels;
            format.nSamplesPerSec = (uint)sampleRate;
            format.wBitsPerSample = 16;
            format.nBlockAlign = (ushort)(2 * format.nChannels);
            format.nAvgBytesPerSec = format.nBlockAlign * format.nSamplesPerSec;
            format.cbSize = 0;
            queuedBuffers = new List<IntPtr>();
            queuedSizes = new List<uint>();
            InitDSPSettings(format.nChannels);
        }

        ~SourceDynamicSoundEffectInstance()
        {
            Dispose();
        }

        public TimeSpan GetSampleDuration(int sizeInBytes)
        {
            return SourceSoundEffect.GetSampleDuration(sizeInBytes, sampleRate, channels);
        }

        public int GetSampleSizeInBytes(TimeSpan duration)
        {
            return SourceSoundEffect.GetSampleSizeInBytes(duration, sampleRate, channels);
        }

        public override void Play()
        {
            Update();
            base.Play();
            lock (Process.Dispatch.Streams)
            {
                if (!Process.Dispatch.Streams.Contains(this))
                {
                    Process.Dispatch.Streams.Add(this);
                }
            }
        }

        public void SubmitBuffer(byte[] buffer)
        {
            SubmitBuffer(buffer, 0, buffer.Length);
        }

        public void SubmitBuffer(byte[] buffer, int offset, int count)
        {
            IntPtr intPtr = IO.Malloc(count);
            Marshal.Copy(buffer, offset, intPtr, count);
            lock (queuedBuffers)
            {
                queuedBuffers.Add(intPtr);
                if (base.State != SourceSoundState.Stopped)
                {
                    SourceFAudioLayout.FAudioBuffer pBuffer = default(SourceFAudioLayout.FAudioBuffer);
                    pBuffer.AudioBytes = (uint)count;
                    pBuffer.pAudioData = intPtr;
                    pBuffer.PlayLength = pBuffer.AudioBytes / (uint)channels / (uint)(format.wBitsPerSample / 8);
                    IO.FAudioSourceVoice_SubmitSourceBuffer(handle, ref pBuffer, IntPtr.Zero);
                }
                else
                {
                    queuedSizes.Add((uint)count);
                }
            }
        }

        public void SubmitFloatBufferEXT(float[] buffer)
        {
            SubmitFloatBufferEXT(buffer, 0, buffer.Length);
        }

        public void SubmitFloatBufferEXT(float[] buffer, int offset, int count)
        {
            if (base.State != SourceSoundState.Stopped && format.wFormatTag == 1)
            {
                throw new InvalidOperationException("Submit a float buffer before Playing!");
            }

            format.wFormatTag = 3;
            format.wBitsPerSample = 32;
            format.nBlockAlign = (ushort)(4 * format.nChannels);
            format.nAvgBytesPerSec = format.nBlockAlign * format.nSamplesPerSec;
            IntPtr intPtr = IO.Malloc(count * 4);
            Marshal.Copy(buffer, offset, intPtr, count);
            lock (queuedBuffers)
            {
                queuedBuffers.Add(intPtr);
                if (base.State != SourceSoundState.Stopped)
                {
                    SourceFAudioLayout.FAudioBuffer pBuffer = default(SourceFAudioLayout.FAudioBuffer);
                    pBuffer.AudioBytes = (uint)(count * 4);
                    pBuffer.pAudioData = intPtr;
                    pBuffer.PlayLength = pBuffer.AudioBytes / (uint)channels / (uint)(format.wBitsPerSample / 8);
                    IO.FAudioSourceVoice_SubmitSourceBuffer(handle, ref pBuffer, IntPtr.Zero);
                }
                else
                {
                    queuedSizes.Add((uint)(count * 4));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        internal void QueueInitialBuffers()
        {
            SourceFAudioLayout.FAudioBuffer pBuffer = default(SourceFAudioLayout.FAudioBuffer);
            lock (queuedBuffers)
            {
                for (int i = 0; i < queuedBuffers.Count; i++)
                {
                    pBuffer.AudioBytes = queuedSizes[i];
                    pBuffer.pAudioData = queuedBuffers[i];
                    pBuffer.PlayLength = pBuffer.AudioBytes / (uint)channels / (uint)(format.wBitsPerSample / 8);
                    IO.FAudioSourceVoice_SubmitSourceBuffer(handle, ref pBuffer, IntPtr.Zero);
                }

                queuedSizes.Clear();
            }
        }

        internal void ClearBuffers()
        {
            lock (queuedBuffers)
            {
                foreach (IntPtr queuedBuffer in queuedBuffers)
                {
                    IO.Free(queuedBuffer);
                }

                queuedBuffers.Clear();
                queuedSizes.Clear();
            }
        }

        public void Update()
        {
            if (base.State != SourceSoundState.Playing)
            {
                return;
            }

            if (handle != IntPtr.Zero)
            {
                IO.FAudioSourceVoice_GetState(handle, out var pVoiceState, 256u);
                while (PendingBufferCount > pVoiceState.BuffersQueued)
                {
                    lock (queuedBuffers)
                    {
                        IO.Free(queuedBuffers[0]);
                        queuedBuffers.RemoveAt(0);
                    }
                }
            }

            int num = 3 - PendingBufferCount;
            while (num > 0 && this.BufferNeeded != null)
            {
                this.BufferNeeded(this, null);
                num--;
            }
        }
    }
}
