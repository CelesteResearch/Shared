using System;
using System.Numerics;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Runtime;
using Celeste.Core.Audio;

namespace Celeste.Audio.Fmod.Events
{
    // A borrowed native handle remains usable after FMOD release while the event is alive.
    public sealed partial class FmodEventReference : FmodSourceHandleBase,
        ISourceAudioEventReference
    {
        internal readonly FmodStudioRuntime Owner;
        internal IntPtr Handle => rawPtr;
        public string Path { get; }

        internal FmodEventReference(FmodStudioRuntime owner, IntPtr handle, string path) : base(handle, owner.DeviceIO)
        {
            Owner = owner;
            Path = path;
        }

        void ISourceAudioEventReference.SetParameter(string name, float value)
        {
            SetParameter(name, value);
        }

        void ISourceAudioEventReference.Release()
        {
            Release();
        }

        void ISourceAudioEventReference.Stop(bool allowFadeOut)
        {
            Stop(allowFadeOut);
        }

        public SourceAudioPlaybackState PlaybackState
        {
            get
            {
                Owner.DeviceIO.StudioEventInstanceGetPlaybackState(Handle, out var state);
                return (SourceAudioPlaybackState)state;
            }
        }

        public FmodEventDescriptionReference GetDescription()
        {
            var result = Owner.DeviceIO.StudioEventInstanceGetDescription(Handle, out var description);
            return result != FmodResult.OK ? null : new FmodEventDescriptionReference(description, Owner.DeviceIO);
        }

        public FmodResult SetPitch(float pitch)
        {
            return Owner.DeviceIO.StudioEventInstanceSetPitch(Handle, pitch);
        }

        void ISourceAudioEventReference.SetPitch(float pitch)
        {
            SetPitch(pitch);
        }

        public FmodResult GetVolume(out float volume, out float finalVolume)
        {
            return Owner.DeviceIO.StudioEventInstanceGetVolume(Handle, out volume, out finalVolume);
        }

        void ISourceAudioEventReference.GetVolume(out float volume, out float finalVolume)
        {
            GetVolume(out volume, out finalVolume);
        }

        public FmodResult SetVolume(float volume)
        {
            return Owner.DeviceIO.StudioEventInstanceSetVolume(Handle, volume);
        }

        void ISourceAudioEventReference.SetVolume(float volume)
        {
            SetVolume(volume);
        }

        void ISourceAudioEventReference.Start()
        {
            Start();
        }

        public FmodResult Start()
        {
            return Owner.DeviceIO.StudioEventInstanceStart(Handle);
        }

        public FmodResult TriggerCue()
        {
            return Owner.DeviceIO.StudioEventInstanceTriggerCue(Handle);
        }

        public FmodResult Release()
        {
            return Owner.DeviceIO.StudioEventInstanceRelease(Handle);
        }

        public bool GetPaused()
        {
            Owner.DeviceIO.StudioEventInstanceGetPaused(Handle, out var paused);
            return paused != 0;
        }

        void ISourceAudioEventReference.SetPaused(bool paused)
        {
            SetPaused(paused);
        }

        public FmodResult SetPaused(bool paused)
        {
            return Owner.DeviceIO.StudioEventInstanceSetPaused(Handle, paused ? 1 : 0);
        }

        public FmodResult Stop(bool allowFadeOut = true)
        {
            return Owner.DeviceIO.StudioEventInstanceStop(Handle, allowFadeOut ? 0 : 1);
        }

        public FmodResult SetParameter(string name, float value)
        {
            return Owner.DeviceIO.StudioEventInstanceSetParameterValue(Handle, FmodStudioRuntime.Utf8(name), value);
        }

        public FmodResult SetPosition(Vector3 position)
        {
            var attributes = FmodAttributes.At(position.X, position.Y, position.Z);
            return Owner.DeviceIO.StudioEventInstanceSet3DAttributes(Handle, ref attributes);
        }
    }
}
