using System;

namespace Celeste.Audio.Sound
{
    using Celeste.Audio.Framework;
    using Celeste.Audio.Interop;

    public class SourceSoundEffectInstance : IDisposable
    {
        protected readonly SourceAudioProcess Process;
        protected Celeste.Audio.IO.ISourceFAudioIO IO => Process.IO;
        private bool INTERNAL_looped;

        private float INTERNAL_pan;

        private float INTERNAL_pitch;

        private SourceSoundState INTERNAL_state = SourceSoundState.Stopped;

        private float INTERNAL_volume = 1f;

        internal IntPtr handle;

        internal bool isDynamic;

        private SourceSoundEffect parentEffect;

        private WeakReference selfReference;

        private bool hasStarted;

        private bool is3D;

        private bool usingReverb;

        private SourceFAudioLayout.F3DAUDIO_DSP_SETTINGS dspSettings;

        public bool IsDisposed { get; protected set; }

        public virtual bool IsLooped
        {
            get { return INTERNAL_looped; }
            set
            {
                if (hasStarted)
                {
                    throw new InvalidOperationException();
                }

                INTERNAL_looped = value;
            }
        }

        public float Pan
        {
            get { return INTERNAL_pan; }
            set
            {
                if (IsDisposed)
                {
                    throw new ObjectDisposedException("SourceSoundEffectInstance");
                }

                if (value > 1f || value < -1f)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                INTERNAL_pan = value;
                if (!is3D)
                {
                    SetPanMatrixCoefficients();
                    if (handle != IntPtr.Zero)
                    {
                        IO.FAudioVoice_SetOutputMatrix(handle, Process.Device().MasterVoice,
                            dspSettings.SrcChannelCount,
                            dspSettings.DstChannelCount, dspSettings.pMatrixCoefficients, 0u);
                    }
                }
            }
        }

        public float Pitch
        {
            get { return INTERNAL_pitch; }
            set
            {
                INTERNAL_pitch = Celeste.Core.Mathematics.ScalarMath.Clamp(value, -1f, 1f);
                if (handle != IntPtr.Zero)
                {
                    UpdatePitch();
                }
            }
        }

        public SourceSoundState State
        {
            get
            {
                if (!isDynamic && handle != IntPtr.Zero && INTERNAL_state == SourceSoundState.Playing)
                {
                    IO.FAudioSourceVoice_GetState(handle, out var pVoiceState, 256u);
                    if (pVoiceState.BuffersQueued == 0)
                    {
                        Stop(immediate: true);
                    }
                }

                return INTERNAL_state;
            }
        }

        public float Volume
        {
            get { return INTERNAL_volume; }
            set
            {
                INTERNAL_volume = value;
                if (handle != IntPtr.Zero)
                {
                    IO.FAudioVoice_SetVolume(handle, INTERNAL_volume, 0u);
                }
            }
        }

        public SourceSoundEffectInstance(SourceAudioProcess process, SourceSoundEffect parent = null)
        {
            Process = process;
            Process.Device();
            selfReference = new WeakReference(this, trackResurrection: true);
            parentEffect = parent;
            isDynamic = this is SourceDynamicSoundEffectInstance;
            hasStarted = false;
            is3D = false;
            usingReverb = false;
            INTERNAL_state = SourceSoundState.Stopped;
            if (!isDynamic)
            {
                InitDSPSettings(parentEffect.channels);
            }

            if (parentEffect != null)
            {
                parentEffect.Instances.Add(selfReference);
            }
        }

        ~SourceSoundEffectInstance()
        {
            if (!IsDisposed && State == SourceSoundState.Playing)
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
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Apply3D(SourceAudioListener listener, SourceAudioEmitter emitter)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            if (emitter == null)
            {
                throw new ArgumentNullException("emitter");
            }

            if (IsDisposed)
            {
                throw new ObjectDisposedException("SourceSoundEffectInstance");
            }

            is3D = true;
            SourceAudioContext fAudioContext = Process.Device();
            emitter.emitterData.CurveDistanceScaler = fAudioContext.CurveDistanceScaler;
            emitter.emitterData.ChannelCount = dspSettings.SrcChannelCount;
            IO.F3DAudioCalculate(fAudioContext.Handle3D, ref listener.listenerData, ref emitter.emitterData, 33u,
                ref dspSettings);
            if (handle != IntPtr.Zero)
            {
                UpdatePitch();
                IO.FAudioVoice_SetOutputMatrix(handle, Process.Device().MasterVoice, dspSettings.SrcChannelCount,
                    dspSettings.DstChannelCount, dspSettings.pMatrixCoefficients, 0u);
            }
        }

        public void Apply3D(SourceAudioListener[] listeners, SourceAudioEmitter emitter)
        {
            if (listeners == null)
            {
                throw new ArgumentNullException("listeners");
            }

            if (listeners.Length == 1)
            {
                Apply3D(listeners[0], emitter);
                return;
            }

            throw new NotSupportedException("Only one listener is supported.");
        }

        public virtual void Play()
        {
            if (State == SourceSoundState.Playing)
            {
                return;
            }

            if (State == SourceSoundState.Paused)
            {
                IO.FAudioSourceVoice_Start(handle, 0u, 0u);
                INTERNAL_state = SourceSoundState.Playing;
                return;
            }

            SourceAudioContext fAudioContext = Process.Device();
            if (isDynamic)
            {
                IO.FAudio_CreateSourceVoice(fAudioContext.Handle, out handle,
                    ref (this as SourceDynamicSoundEffectInstance).format, 8u, 2f, IntPtr.Zero, IntPtr.Zero,
                    IntPtr.Zero);
            }
            else
            {
                IO.FAudio_CreateSourceVoice(fAudioContext.Handle, out handle, parentEffect.formatPtr, 8u, 2f,
                    IntPtr.Zero,
                    IntPtr.Zero, IntPtr.Zero);
            }

            if (handle == IntPtr.Zero)
            {
                return;
            }

            IO.FAudioVoice_SetVolume(handle, INTERNAL_volume, 0u);
            UpdatePitch();
            if (is3D || Pan != 0f)
            {
                IO.FAudioVoice_SetOutputMatrix(handle, Process.Device().MasterVoice, dspSettings.SrcChannelCount,
                    dspSettings.DstChannelCount, dspSettings.pMatrixCoefficients, 0u);
            }

            if (isDynamic)
            {
                (this as SourceDynamicSoundEffectInstance).QueueInitialBuffers();
            }
            else
            {
                if (IsLooped)
                {
                    parentEffect.handle.LoopCount = 255u;
                    parentEffect.handle.LoopBegin = parentEffect.loopStart;
                    parentEffect.handle.LoopLength = parentEffect.loopLength;
                }
                else
                {
                    parentEffect.handle.LoopCount = 0u;
                    parentEffect.handle.LoopBegin = 0u;
                    parentEffect.handle.LoopLength = 0u;
                }

                IO.FAudioSourceVoice_SubmitSourceBuffer(handle, ref parentEffect.handle, IntPtr.Zero);
            }

            IO.FAudioSourceVoice_Start(handle, 0u, 0u);
            INTERNAL_state = SourceSoundState.Playing;
            hasStarted = true;
        }

        public void Pause()
        {
            if (handle != IntPtr.Zero && State == SourceSoundState.Playing)
            {
                IO.FAudioSourceVoice_Stop(handle, 0u, 0u);
                INTERNAL_state = SourceSoundState.Paused;
            }
        }

        public void Resume()
        {
            SourceSoundState state = State;
            if (handle == IntPtr.Zero)
            {
                Play();
            }
            else if (state == SourceSoundState.Paused)
            {
                IO.FAudioSourceVoice_Start(handle, 0u, 0u);
                INTERNAL_state = SourceSoundState.Playing;
            }
        }

        public void Stop()
        {
            Stop(immediate: true);
        }

        public void Stop(bool immediate)
        {
            if (handle == IntPtr.Zero)
            {
                return;
            }

            if (immediate)
            {
                IO.FAudioSourceVoice_Stop(handle, 0u, 0u);
                IO.FAudioSourceVoice_FlushSourceBuffers(handle);
                IO.FAudioVoice_DestroyVoice(handle);
                handle = IntPtr.Zero;
                usingReverb = false;
                INTERNAL_state = SourceSoundState.Stopped;
                if (isDynamic)
                {
                    lock (Process.Dispatch.Streams)
                    {
                        Process.Dispatch.Streams.Remove(this as SourceDynamicSoundEffectInstance);
                    }

                    (this as SourceDynamicSoundEffectInstance).ClearBuffers();
                }
            }
            else
            {
                if (isDynamic)
                {
                    throw new InvalidOperationException();
                }

                IO.FAudioSourceVoice_ExitLoop(handle, 0u);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                Stop(immediate: true);
                if (parentEffect != null)
                {
                    parentEffect.Instances.Remove(selfReference);
                }

                selfReference = null;
                IO.Free(dspSettings.pMatrixCoefficients);
                IsDisposed = true;
            }
        }

        internal unsafe void InitDSPSettings(uint srcChannels)
        {
            dspSettings = default(SourceFAudioLayout.F3DAUDIO_DSP_SETTINGS);
            dspSettings.DopplerFactor = 1f;
            dspSettings.SrcChannelCount = srcChannels;
            dspSettings.DstChannelCount = Process.Device().DeviceDetails.OutputFormat.Format.nChannels;
            int num = (int)(4 * dspSettings.SrcChannelCount * dspSettings.DstChannelCount);
            dspSettings.pMatrixCoefficients = IO.Malloc(num);
            byte* ptr = (byte*)(void*)dspSettings.pMatrixCoefficients;
            for (int i = 0; i < num; i++)
            {
                ptr[i] = 0;
            }

            SetPanMatrixCoefficients();
        }

        internal unsafe void INTERNAL_applyReverb(float rvGain)
        {
            if (!(handle == IntPtr.Zero))
            {
                if (!usingReverb)
                {
                    Process.Device().AttachReverb(handle);
                    usingReverb = true;
                }

                float* ptr = (float*)(void*)dspSettings.pMatrixCoefficients;
                *ptr = rvGain;
                if (dspSettings.SrcChannelCount == 2)
                {
                    ptr[1] = rvGain;
                }

                IO.FAudioVoice_SetOutputMatrix(handle, Process.Device().ReverbVoice, dspSettings.SrcChannelCount, 1u,
                    dspSettings.pMatrixCoefficients, 0u);
            }
        }

        internal void INTERNAL_applyLowPassFilter(float cutoff)
        {
            if (!(handle == IntPtr.Zero))
            {
                SourceFAudioLayout.FAudioFilterParameters pParameters = new SourceFAudioLayout.FAudioFilterParameters
                {
                    Type = SourceFAudioLayout.FAudioFilterType.FAudioLowPassFilter,
                    Frequency = cutoff,
                    OneOverQ = 1f
                };
                IO.FAudioVoice_SetFilterParameters(handle, ref pParameters, 0u);
            }
        }

        internal void INTERNAL_applyHighPassFilter(float cutoff)
        {
            if (!(handle == IntPtr.Zero))
            {
                SourceFAudioLayout.FAudioFilterParameters pParameters = new SourceFAudioLayout.FAudioFilterParameters
                {
                    Type = SourceFAudioLayout.FAudioFilterType.FAudioHighPassFilter,
                    Frequency = cutoff,
                    OneOverQ = 1f
                };
                IO.FAudioVoice_SetFilterParameters(handle, ref pParameters, 0u);
            }
        }

        internal void INTERNAL_applyBandPassFilter(float center)
        {
            if (!(handle == IntPtr.Zero))
            {
                SourceFAudioLayout.FAudioFilterParameters pParameters = new SourceFAudioLayout.FAudioFilterParameters
                {
                    Type = SourceFAudioLayout.FAudioFilterType.FAudioBandPassFilter,
                    Frequency = center,
                    OneOverQ = 1f
                };
                IO.FAudioVoice_SetFilterParameters(handle, ref pParameters, 0u);
            }
        }

        private void UpdatePitch()
        {
            float dopplerScale = Process.Device().DopplerScale;
            float num = ((is3D && dopplerScale != 0f) ? (dspSettings.DopplerFactor * dopplerScale) : 1f);
            IO.FAudioSourceVoice_SetFrequencyRatio(handle, (float)Math.Pow(2.0, INTERNAL_pitch) * num, 0u);
        }

        private unsafe void SetPanMatrixCoefficients()
        {
            float* ptr = (float*)(void*)dspSettings.pMatrixCoefficients;
            if (dspSettings.SrcChannelCount == 1)
            {
                if (dspSettings.DstChannelCount == 1)
                {
                    *ptr = 1f;
                    return;
                }

                *ptr = ((INTERNAL_pan > 0f) ? (1f - INTERNAL_pan) : 1f);
                ptr[1] = ((INTERNAL_pan < 0f) ? (1f + INTERNAL_pan) : 1f);
            }
            else if (dspSettings.DstChannelCount == 1)
            {
                *ptr = 1f;
                ptr[1] = 1f;
            }
            else if (INTERNAL_pan <= 0f)
            {
                *ptr = 0.5f * INTERNAL_pan + 1f;
                ptr[1] = 0.5f * (0f - INTERNAL_pan);
                ptr[2] = 0f;
                ptr[3] = INTERNAL_pan + 1f;
            }
            else
            {
                *ptr = 0f - INTERNAL_pan + 1f;
                ptr[1] = 0f;
                ptr[2] = 0.5f * INTERNAL_pan;
                ptr[3] = 0.5f * (0f - INTERNAL_pan) + 1f;
            }
        }
    }
}
