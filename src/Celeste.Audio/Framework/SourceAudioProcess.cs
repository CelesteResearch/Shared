using System;
using Celeste.Audio.Sound;
using Celeste.Audio.Interop;

namespace Celeste.Audio.Framework
{
    public sealed class SourceAudioProcess : IDisposable
    {
        internal readonly float[] StereoAzimuth = new float[2];
        internal readonly System.Runtime.InteropServices.GCHandle StereoAzimuthHandle;
        public Celeste.Audio.IO.ISourceFAudioIO IO { get; }
        public Celeste.Core.Framework.Time.ISourceTimeSpanPolicy TimeSpans { get; }
        public SourceAudioMediaDispatchState Dispatch { get; }
        internal SourceAudioContext Context;
        private readonly object createLock = new object();
        private bool disposed;

        public SourceAudioProcess(Celeste.Audio.IO.ISourceFAudioIO io, SourceAudioMediaDispatchState dispatch,
            Celeste.Core.Framework.Time.ISourceTimeSpanPolicy timeSpans)
        {
            IO = io;
            Dispatch = dispatch;
            TimeSpans = timeSpans;
            StereoAzimuthHandle =
                System.Runtime.InteropServices.GCHandle.Alloc(StereoAzimuth,
                    System.Runtime.InteropServices.GCHandleType.Pinned);
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
            set { IO.FAudioVoice_SetVolume(Device().MasterVoice, value, 0u); }
        }

        public float DistanceScale
        {
            get { return Device().CurveDistanceScaler; }
            set
            {
                if (value <= 0f)
                {
                    throw new ArgumentOutOfRangeException("value <= 0.0f");
                }

                Device().CurveDistanceScaler = value;
            }
        }

        public float DopplerScale
        {
            get { return Device().DopplerScale; }
            set
            {
                if (value < 0f)
                {
                    throw new ArgumentOutOfRangeException("value < 0.0f");
                }

                Device().DopplerScale = value;
            }
        }

        public float SpeedOfSound
        {
            get { return Device().SpeedOfSound; }
            set
            {
                SourceAudioContext fAudioContext = Device();
                fAudioContext.SpeedOfSound = value;
                IO.F3DAudioInitialize(fAudioContext.DeviceDetails.OutputFormat.dwChannelMask,
                    fAudioContext.SpeedOfSound,
                    fAudioContext.Handle3D);
            }
        }

        internal SourceAudioContext Device()
        {
            if (Context != null)
            {
                return Context;
            }

            lock (createLock)
            {
                if (Context != null)
                {
                    return Context;
                }

                SourceAudioContext.Create(this);
                if (Context == null)
                {
                    throw new SourceNoAudioHardwareException();
                }
            }

            return Context;
        }
    }
}
