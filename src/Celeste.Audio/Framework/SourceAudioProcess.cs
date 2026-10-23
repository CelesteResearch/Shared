using System;
using System.Runtime.InteropServices;
using Celeste.Audio.IO;
using Celeste.Audio.Sound;
using Celeste.Core.Framework.Time;

namespace Celeste.Audio.Framework
{
    public sealed class SourceAudioProcess : IDisposable
    {
        internal readonly float[] StereoAzimuth = new float[2];
        internal readonly GCHandle StereoAzimuthHandle;
        public ISourceFAudioIO IO { get; }
        public ISourceTimeSpanPolicy TimeSpans { get; }
        public SourceAudioMediaDispatchState Dispatch { get; }
        internal SourceAudioContext Context;

        private readonly object createLock = new();

        private bool disposed;

        public SourceAudioProcess(ISourceFAudioIO io, SourceAudioMediaDispatchState dispatch,
            ISourceTimeSpanPolicy timeSpans)
        {
            IO = io;
            Dispatch = dispatch;
            TimeSpans = timeSpans;
            StereoAzimuthHandle =
                GCHandle.Alloc(StereoAzimuth,
                    GCHandleType.Pinned);
        }

        public void Dispose()
        {
            lock (createLock)
            {
                if (disposed) return;
                disposed = true;
                try
                {
                    Context?.Dispose();
                }
                finally
                {
                    if (StereoAzimuthHandle.IsAllocated) StereoAzimuthHandle.Free();
                }
            }
        }

        public float MasterVolume
        {
            get
            {
                IO.FAudioVoice_GetVolume(Device().MasterVoice, out var pVolume);
                return pVolume;
            }
            set => IO.FAudioVoice_SetVolume(Device().MasterVoice, value, 0u);
        }

        public float DistanceScale
        {
            get => Device().CurveDistanceScaler;
            set
            {
                if (value <= 0f) throw new ArgumentOutOfRangeException("value <= 0.0f");

                Device().CurveDistanceScaler = value;
            }
        }

        public float DopplerScale
        {
            get => Device().DopplerScale;
            set
            {
                if (value < 0f) throw new ArgumentOutOfRangeException("value < 0.0f");

                Device().DopplerScale = value;
            }
        }

        public float SpeedOfSound
        {
            get => Device().SpeedOfSound;
            set
            {
                var fAudioContext = Device();
                fAudioContext.SpeedOfSound = value;
                IO.F3DAudioInitialize(fAudioContext.DeviceDetails.OutputFormat.dwChannelMask,
                    fAudioContext.SpeedOfSound,
                    fAudioContext.Handle3D);
            }
        }

        internal SourceAudioContext Device()
        {
            if (Context != null) return Context;

            lock (createLock)
            {
                if (Context != null) return Context;

                SourceAudioContext.Create(this);
                if (Context == null) throw new SourceNoAudioHardwareException();
            }

            return Context;
        }
    }
}
