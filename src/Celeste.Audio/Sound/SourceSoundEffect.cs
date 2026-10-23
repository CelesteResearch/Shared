using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Celeste.Audio.Sound
{
    using Celeste.Audio.Framework;
    using Celeste.Audio.Interop;

    public sealed class SourceSoundEffect : IDisposable
    {
        internal readonly SourceAudioProcess Process;
        private Celeste.Audio.IO.ISourceFAudioIO IO => Process.IO;


        internal List<WeakReference> Instances = new List<WeakReference>();

        internal SourceFAudioLayout.FAudioBuffer handle;

        internal IntPtr formatPtr;

        internal ushort channels;

        internal uint sampleRate;

        internal uint loopStart;

        internal uint loopLength;


        public TimeSpan Duration => Process.TimeSpans.FromSeconds((double)handle.PlayLength / (double)sampleRate);

        public bool IsDisposed { get; private set; }

        public string Name { get; set; }


        public SourceSoundEffect(SourceAudioProcess process, byte[] buffer, int sampleRate,
            SourceAudioChannels channels)
            : this(process, null, buffer, 0, buffer.Length, null, 1, (ushort)channels, (uint)sampleRate,
                (uint)(sampleRate * ((ushort)channels * 2)), (ushort)((ushort)channels * 2), 16, 0, 0)
        {
        }

        public SourceSoundEffect(SourceAudioProcess process, byte[] buffer, int offset, int count, int sampleRate,
            SourceAudioChannels channels, int loopStart, int loopLength)
            : this(process, null, buffer, offset, count, null, 1, (ushort)channels, (uint)sampleRate,
                (uint)(sampleRate * ((ushort)channels * 2)), (ushort)((ushort)channels * 2), 16, loopStart, loopLength)
        {
        }

        public unsafe SourceSoundEffect(SourceAudioProcess process, string name, byte[] buffer, int offset, int count,
            byte[] extraData, ushort wFormatTag, ushort nChannels, uint nSamplesPerSec, uint nAvgBytesPerSec,
            ushort nBlockAlign, ushort wBitsPerSample, int loopStart, int loopLength)
        {
            Process = process;
            Process.Device();
            Name = name;
            channels = nChannels;
            sampleRate = nSamplesPerSec;
            this.loopStart = (uint)loopStart;
            this.loopLength = (uint)loopLength;
            if (extraData == null)
            {
                formatPtr = IO.Malloc(
                    System.Runtime.InteropServices.Marshal.SizeOf(typeof(SourceFAudioLayout.FAudioWaveFormatEx)));
            }
            else
            {
                formatPtr = IO.Malloc(
                    System.Runtime.InteropServices.Marshal.SizeOf(typeof(SourceFAudioLayout.FAudioWaveFormatEx)) +
                    extraData.Length);
                Marshal.Copy(extraData, 0,
                    formatPtr + System.Runtime.InteropServices.Marshal.SizeOf(
                        typeof(SourceFAudioLayout.FAudioWaveFormatEx)), extraData.Length);
            }

            SourceFAudioLayout.FAudioWaveFormatEx* ptr = (SourceFAudioLayout.FAudioWaveFormatEx*)(void*)formatPtr;
            ptr->wFormatTag = wFormatTag;
            ptr->nChannels = nChannels;
            ptr->nSamplesPerSec = nSamplesPerSec;
            ptr->nAvgBytesPerSec = nAvgBytesPerSec;
            ptr->nBlockAlign = nBlockAlign;
            ptr->wBitsPerSample = wBitsPerSample;
            ptr->cbSize = (ushort)((extraData != null) ? ((uint)extraData.Length) : 0u);
            handle = default(SourceFAudioLayout.FAudioBuffer);
            handle.Flags = 64u;
            handle.pContext = IntPtr.Zero;
            handle.AudioBytes = (uint)count;
            handle.pAudioData = IO.Malloc(count);
            Marshal.Copy(buffer, offset, handle.pAudioData, count);
            handle.PlayBegin = 0u;
            switch (wFormatTag)
            {
                case 1:
                    handle.PlayLength = (uint)(count / nChannels / (wBitsPerSample / 8));
                    break;
                case 2:
                    handle.PlayLength = (uint)(count / nBlockAlign * ((nBlockAlign / nChannels - 6) * 2));
                    break;
                case 358:
                {
                    SourceFAudioLayout.FAudioXMA2WaveFormatEx* ptr2 =
                        (SourceFAudioLayout.FAudioXMA2WaveFormatEx*)(void*)formatPtr;
                    handle.PlayLength = ptr2->dwPlayLength;
                    break;
                }
            }

            handle.LoopBegin = 0u;
            handle.LoopLength = 0u;
            handle.LoopCount = 0u;
        }

        ~SourceSoundEffect()
        {
            if (Instances.Count > 0)
            {
                GC.ReRegisterForFinalize(this);
            }
            else
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            WeakReference[] array = Instances.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                object target = array[i].Target;
                if (target != null)
                {
                    (target as IDisposable).Dispose();
                }
            }

            Instances.Clear();
            IO.Free(formatPtr);
            IO.Free(handle.pAudioData);
            IsDisposed = true;
        }

        public bool Play()
        {
            return Play(1f, 0f, 0f);
        }

        public bool Play(float volume, float pitch, float pan)
        {
            SourceSoundEffectInstance soundEffectInstance = new SourceSoundEffectInstance(Process, this);
            soundEffectInstance.Volume = volume;
            soundEffectInstance.Pitch = pitch;
            soundEffectInstance.Pan = pan;
            soundEffectInstance.Play();
            if (soundEffectInstance.State != SourceSoundState.Playing)
            {
                soundEffectInstance.Dispose();
                return false;
            }

            return true;
        }

        public SourceSoundEffectInstance CreateInstance()
        {
            return new SourceSoundEffectInstance(Process, this);
        }

        public static TimeSpan GetSampleDuration(int sizeInBytes, int sampleRate, SourceAudioChannels channels)
        {
            sizeInBytes /= 2;
            int milliseconds = (int)((float)(sizeInBytes / (int)channels) / ((float)sampleRate / 1000f));
            return new TimeSpan(0, 0, 0, 0, milliseconds);
        }

        public static int GetSampleSizeInBytes(TimeSpan duration, int sampleRate, SourceAudioChannels channels)
        {
            return (int)(duration.TotalSeconds * (double)sampleRate * (double)channels * 2.0);
        }

        public static SourceSoundEffect FromStream(Stream stream, SourceAudioProcess process)
        {
            int num = 0;
            int num2 = 0;
            ushort wFormatTag;
            ushort nChannels;
            uint nSamplesPerSec;
            uint nAvgBytesPerSec;
            ushort nBlockAlign;
            ushort wBitsPerSample;
            byte[] array;
            using (BinaryReader binaryReader = new BinaryReader(stream))
            {
                if (new string(binaryReader.ReadChars(4)) != "RIFF")
                {
                    throw new NotSupportedException("Specified stream is not a wave file.");
                }

                binaryReader.ReadUInt32();
                if (new string(binaryReader.ReadChars(4)) != "WAVE")
                {
                    throw new NotSupportedException("Specified stream is not a wave file.");
                }

                string text = new string(binaryReader.ReadChars(4));
                while (text != "fmt ")
                {
                    binaryReader.ReadBytes(binaryReader.ReadInt32());
                    text = new string(binaryReader.ReadChars(4));
                }

                int num3 = binaryReader.ReadInt32();
                wFormatTag = binaryReader.ReadUInt16();
                nChannels = binaryReader.ReadUInt16();
                nSamplesPerSec = binaryReader.ReadUInt32();
                nAvgBytesPerSec = binaryReader.ReadUInt32();
                nBlockAlign = binaryReader.ReadUInt16();
                wBitsPerSample = binaryReader.ReadUInt16();
                if (num3 > 16)
                {
                    binaryReader.ReadBytes(num3 - 16);
                }

                string text2 = new string(binaryReader.ReadChars(4));
                while (text2.ToLowerInvariant() != "data")
                {
                    binaryReader.ReadBytes(binaryReader.ReadInt32());
                    text2 = new string(binaryReader.ReadChars(4));
                }

                if (text2 != "data")
                {
                    throw new NotSupportedException("Specified wave file is not supported.");
                }

                int count = binaryReader.ReadInt32();
                array = binaryReader.ReadBytes(count);
                while (binaryReader.PeekChar() != -1)
                {
                    char[] array2 = binaryReader.ReadChars(4);
                    if (array2.Length < 4)
                    {
                        break;
                    }

                    byte[] array3 = binaryReader.ReadBytes(4);
                    if (array3.Length < 4)
                    {
                        break;
                    }

                    string text3 = new string(array2);
                    int count2 = BitConverter.ToInt32(array3, 0);
                    if (text3 == "smpl")
                    {
                        binaryReader.ReadUInt32();
                        binaryReader.ReadUInt32();
                        binaryReader.ReadUInt32();
                        binaryReader.ReadUInt32();
                        binaryReader.ReadUInt32();
                        binaryReader.ReadUInt32();
                        binaryReader.ReadUInt32();
                        uint num4 = binaryReader.ReadUInt32();
                        int num5 = binaryReader.ReadInt32();
                        for (int i = 0; i < num4; i++)
                        {
                            binaryReader.ReadUInt32();
                            binaryReader.ReadUInt32();
                            int num6 = binaryReader.ReadInt32();
                            int num7 = binaryReader.ReadInt32();
                            binaryReader.ReadUInt32();
                            binaryReader.ReadUInt32();
                            if (i == 0)
                            {
                                num = num6;
                                num2 = num7;
                            }
                        }

                        if (num5 != 0)
                        {
                            binaryReader.ReadBytes(num5);
                        }
                    }
                    else
                    {
                        binaryReader.ReadBytes(count2);
                    }
                }
            }

            return new SourceSoundEffect(process, null, array, 0, array.Length, null, wFormatTag, nChannels,
                nSamplesPerSec,
                nAvgBytesPerSec, nBlockAlign, wBitsPerSample, num, num2 - num);
        }
    }
}
