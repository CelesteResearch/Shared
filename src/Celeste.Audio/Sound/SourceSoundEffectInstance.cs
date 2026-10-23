using System;
using Celeste.Audio.Framework;
using Celeste.Audio.Interop;
using Celeste.Audio.IO;
using Celeste.Core.Mathematics;

namespace Celeste.Audio.Sound
{
    public class SourceSoundEffectInstance : IDisposable
    {
        protected readonly SourceAudioProcess Process;
        protected ISourceFAudioIO IO => Process.IO;
        private bool _internalLooped;

        private float _internalPan;

        private float _internalPitch;

        private SourceSoundState _internalState = SourceSoundState.Stopped;

        private float _internalVolume = 1f;

        internal IntPtr handle;

        internal bool isDynamic;

        private readonly SourceSoundEffect _parentEffect;

        private WeakReference _selfReference;

        private bool _hasStarted;

        private bool _is3D;

        private bool _usingReverb;

        private SourceFAudioLayout.F3DAUDIO_DSP_SETTINGS _dspSettings;

        public bool IsDisposed { get; protected set; }

        public virtual bool IsLooped
        {
            get => _internalLooped;
            set
            {
                if (_hasStarted) throw new InvalidOperationException();

                _internalLooped = value;
            }
        }

        public float Pan
        {
            get => _internalPan;
            set
            {
                if (IsDisposed) throw new ObjectDisposedException("SourceSoundEffectInstance");

                if (value > 1f || value < -1f) throw new ArgumentOutOfRangeException("value");

                _internalPan = value;
                if (!_is3D)
                {
                    SetPanMatrixCoefficients();
                    if (handle != IntPtr.Zero)
                        IO.FAudioVoice_SetOutputMatrix(handle, Process.Device().MasterVoice,
                            _dspSettings.SrcChannelCount,
                            _dspSettings.DstChannelCount, _dspSettings.pMatrixCoefficients, 0u);
                }
            }
        }

        public float Pitch
        {
            get => _internalPitch;
            set
            {
                _internalPitch = ScalarMath.Clamp(value, -1f, 1f);
                if (handle != IntPtr.Zero) UpdatePitch();
            }
        }

        public SourceSoundState State
        {
            get
            {
                if (!isDynamic && handle != IntPtr.Zero && _internalState == SourceSoundState.Playing)
                {
                    IO.FAudioSourceVoice_GetState(handle, out var pVoiceState, 256u);
                    if (pVoiceState.BuffersQueued == 0) Stop(true);
                }

                return _internalState;
            }
        }

        public float Volume
        {
            get => _internalVolume;
            set
            {
                _internalVolume = value;
                if (handle != IntPtr.Zero) IO.FAudioVoice_SetVolume(handle, _internalVolume, 0u);
            }
        }

        public SourceSoundEffectInstance(SourceAudioProcess process, SourceSoundEffect parent = null)
        {
            Process = process;
            Process.Device();
            _selfReference = new(this, true);
            _parentEffect = parent;
            isDynamic = this is SourceDynamicSoundEffectInstance;
            _hasStarted = false;
            _is3D = false;
            _usingReverb = false;
            _internalState = SourceSoundState.Stopped;
            if (!isDynamic) InitDSPSettings(_parentEffect.channels);

            if (_parentEffect != null) _parentEffect.Instances.Add(_selfReference);
        }

        ~SourceSoundEffectInstance()
        {
            if (!IsDisposed && State == SourceSoundState.Playing)
                GC.ReRegisterForFinalize(this);
            else
                Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Apply3D(SourceAudioListener listener, SourceAudioEmitter emitter)
        {
            if (listener == null) throw new ArgumentNullException("listener");

            if (emitter == null) throw new ArgumentNullException("emitter");

            if (IsDisposed) throw new ObjectDisposedException("SourceSoundEffectInstance");

            _is3D = true;
            var fAudioContext = Process.Device();
            emitter.emitterData.CurveDistanceScaler = fAudioContext.CurveDistanceScaler;
            emitter.emitterData.ChannelCount = _dspSettings.SrcChannelCount;
            IO.F3DAudioCalculate(fAudioContext.Handle3D, ref listener.listenerData, ref emitter.emitterData, 33u,
                ref _dspSettings);
            if (handle != IntPtr.Zero)
            {
                UpdatePitch();
                IO.FAudioVoice_SetOutputMatrix(handle, Process.Device().MasterVoice, _dspSettings.SrcChannelCount,
                    _dspSettings.DstChannelCount, _dspSettings.pMatrixCoefficients, 0u);
            }
        }

        public void Apply3D(SourceAudioListener[] listeners, SourceAudioEmitter emitter)
        {
            if (listeners == null) throw new ArgumentNullException("listeners");

            if (listeners.Length == 1)
            {
                Apply3D(listeners[0], emitter);
                return;
            }

            throw new NotSupportedException("Only one listener is supported.");
        }

        public virtual void Play()
        {
            if (State == SourceSoundState.Playing) return;

            if (State == SourceSoundState.Paused)
            {
                IO.FAudioSourceVoice_Start(handle, 0u, 0u);
                _internalState = SourceSoundState.Playing;
                return;
            }

            var fAudioContext = Process.Device();
            if (isDynamic)
                IO.FAudio_CreateSourceVoice(fAudioContext.Handle, out handle,
                    ref (this as SourceDynamicSoundEffectInstance).format, 8u, 2f, IntPtr.Zero, IntPtr.Zero,
                    IntPtr.Zero);
            else
                IO.FAudio_CreateSourceVoice(fAudioContext.Handle, out handle, _parentEffect.formatPtr, 8u, 2f,
                    IntPtr.Zero,
                    IntPtr.Zero, IntPtr.Zero);

            if (handle == IntPtr.Zero) return;

            IO.FAudioVoice_SetVolume(handle, _internalVolume, 0u);
            UpdatePitch();
            if (_is3D || Pan != 0f)
                IO.FAudioVoice_SetOutputMatrix(handle, Process.Device().MasterVoice, _dspSettings.SrcChannelCount,
                    _dspSettings.DstChannelCount, _dspSettings.pMatrixCoefficients, 0u);

            if (isDynamic)
            {
                (this as SourceDynamicSoundEffectInstance).QueueInitialBuffers();
            }
            else
            {
                if (IsLooped)
                {
                    _parentEffect.handle.LoopCount = 255u;
                    _parentEffect.handle.LoopBegin = _parentEffect.loopStart;
                    _parentEffect.handle.LoopLength = _parentEffect.loopLength;
                }
                else
                {
                    _parentEffect.handle.LoopCount = 0u;
                    _parentEffect.handle.LoopBegin = 0u;
                    _parentEffect.handle.LoopLength = 0u;
                }

                IO.FAudioSourceVoice_SubmitSourceBuffer(handle, ref _parentEffect.handle, IntPtr.Zero);
            }

            IO.FAudioSourceVoice_Start(handle, 0u, 0u);
            _internalState = SourceSoundState.Playing;
            _hasStarted = true;
        }

        public void Pause()
        {
            if (handle != IntPtr.Zero && State == SourceSoundState.Playing)
            {
                IO.FAudioSourceVoice_Stop(handle, 0u, 0u);
                _internalState = SourceSoundState.Paused;
            }
        }

        public void Resume()
        {
            var state = State;
            if (handle == IntPtr.Zero)
            {
                Play();
            }
            else if (state == SourceSoundState.Paused)
            {
                IO.FAudioSourceVoice_Start(handle, 0u, 0u);
                _internalState = SourceSoundState.Playing;
            }
        }

        public void Stop()
        {
            Stop(true);
        }

        public void Stop(bool immediate)
        {
            if (handle == IntPtr.Zero) return;

            if (immediate)
            {
                IO.FAudioSourceVoice_Stop(handle, 0u, 0u);
                IO.FAudioSourceVoice_FlushSourceBuffers(handle);
                IO.FAudioVoice_DestroyVoice(handle);
                handle = IntPtr.Zero;
                _usingReverb = false;
                _internalState = SourceSoundState.Stopped;
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
                if (isDynamic) throw new InvalidOperationException();

                IO.FAudioSourceVoice_ExitLoop(handle, 0u);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                Stop(true);
                if (_parentEffect != null) _parentEffect.Instances.Remove(_selfReference);

                _selfReference = null;
                IO.Free(_dspSettings.pMatrixCoefficients);
                IsDisposed = true;
            }
        }

        internal unsafe void InitDSPSettings(uint srcChannels)
        {
            _dspSettings = default;
            _dspSettings.DopplerFactor = 1f;
            _dspSettings.SrcChannelCount = srcChannels;
            _dspSettings.DstChannelCount = Process.Device().DeviceDetails.OutputFormat.Format.nChannels;
            var num = (int)(4 * _dspSettings.SrcChannelCount * _dspSettings.DstChannelCount);
            _dspSettings.pMatrixCoefficients = IO.Malloc(num);
            var ptr = (byte*)(void*)_dspSettings.pMatrixCoefficients;
            for (var i = 0; i < num; i++) ptr[i] = 0;

            SetPanMatrixCoefficients();
        }

        internal unsafe void INTERNAL_applyReverb(float rvGain)
        {
            if (!(handle == IntPtr.Zero))
            {
                if (!_usingReverb)
                {
                    Process.Device().AttachReverb(handle);
                    _usingReverb = true;
                }

                var ptr = (float*)(void*)_dspSettings.pMatrixCoefficients;
                *ptr = rvGain;
                if (_dspSettings.SrcChannelCount == 2) ptr[1] = rvGain;

                IO.FAudioVoice_SetOutputMatrix(handle, Process.Device().ReverbVoice, _dspSettings.SrcChannelCount, 1u,
                    _dspSettings.pMatrixCoefficients, 0u);
            }
        }

        internal void INTERNAL_applyLowPassFilter(float cutoff)
        {
            if (!(handle == IntPtr.Zero))
            {
                var pParameters = new SourceFAudioLayout.FAudioFilterParameters
                {
                    Type = SourceFAudioLayout.FAudioFilterType.FAudioLowPassFilter,
                    Frequency = cutoff,
                    OneOverQ = 1f,
                };
                IO.FAudioVoice_SetFilterParameters(handle, ref pParameters, 0u);
            }
        }

        internal void INTERNAL_applyHighPassFilter(float cutoff)
        {
            if (!(handle == IntPtr.Zero))
            {
                var pParameters = new SourceFAudioLayout.FAudioFilterParameters
                {
                    Type = SourceFAudioLayout.FAudioFilterType.FAudioHighPassFilter,
                    Frequency = cutoff,
                    OneOverQ = 1f,
                };
                IO.FAudioVoice_SetFilterParameters(handle, ref pParameters, 0u);
            }
        }

        internal void INTERNAL_applyBandPassFilter(float center)
        {
            if (!(handle == IntPtr.Zero))
            {
                var pParameters = new SourceFAudioLayout.FAudioFilterParameters
                {
                    Type = SourceFAudioLayout.FAudioFilterType.FAudioBandPassFilter,
                    Frequency = center,
                    OneOverQ = 1f,
                };
                IO.FAudioVoice_SetFilterParameters(handle, ref pParameters, 0u);
            }
        }

        private void UpdatePitch()
        {
            var dopplerScale = Process.Device().DopplerScale;
            var num = _is3D && dopplerScale != 0f ? _dspSettings.DopplerFactor * dopplerScale : 1f;
            IO.FAudioSourceVoice_SetFrequencyRatio(handle, (float)Math.Pow(2.0, _internalPitch) * num, 0u);
        }

        private unsafe void SetPanMatrixCoefficients()
        {
            var ptr = (float*)(void*)_dspSettings.pMatrixCoefficients;
            if (_dspSettings.SrcChannelCount == 1)
            {
                if (_dspSettings.DstChannelCount == 1)
                {
                    *ptr = 1f;
                    return;
                }

                *ptr = _internalPan > 0f ? 1f - _internalPan : 1f;
                ptr[1] = _internalPan < 0f ? 1f + _internalPan : 1f;
            }
            else if (_dspSettings.DstChannelCount == 1)
            {
                *ptr = 1f;
                ptr[1] = 1f;
            }
            else if (_internalPan <= 0f)
            {
                *ptr = 0.5f * _internalPan + 1f;
                ptr[1] = 0.5f * (0f - _internalPan);
                ptr[2] = 0f;
                ptr[3] = _internalPan + 1f;
            }
            else
            {
                *ptr = 0f - _internalPan + 1f;
                ptr[1] = 0f;
                ptr[2] = 0.5f * _internalPan;
                ptr[3] = 0.5f * (0f - _internalPan) + 1f;
            }
        }
    }
}
