using System;
using System.Numerics;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Events
{
    // A borrowed native handle remains usable after FMOD release while the event is alive.
    public sealed partial class FmodEventReference : FmodSourceHandleBase,
        global::Celeste.Core.Audio.ISourceAudioEventReference
    {
        internal readonly FmodStudioRuntime Owner;
        internal IntPtr Handle => rawPtr;
        public string Path { get; }

        internal FmodEventReference(FmodStudioRuntime owner, IntPtr handle, string path) : base(handle, owner.DeviceIO)
        {
            Owner = owner;
            Path = path;
        }

        void global::Celeste.Core.Audio.ISourceAudioEventReference.SetParameter(string name, float value)
        {
            SetParameter(name, value);
        }

        void global::Celeste.Core.Audio.ISourceAudioEventReference.Release()
        {
            Release();
        }

        void global::Celeste.Core.Audio.ISourceAudioEventReference.Stop(bool allowFadeOut)
        {
            Stop(allowFadeOut);
        }

        public global::Celeste.Core.Audio.SourceAudioPlaybackState PlaybackState
        {
            get
            {
                Owner.DeviceIO.StudioEventInstanceGetPlaybackState(Handle, out FmodPlaybackState state);
                return (global::Celeste.Core.Audio.SourceAudioPlaybackState)state;
            }
        }

        public FmodEventDescriptionReference GetDescription()
        {
            var result = Owner.DeviceIO.StudioEventInstanceGetDescription(Handle, out IntPtr description);
            return result != FmodResult.OK ? null : new FmodEventDescriptionReference(description, Owner.DeviceIO);
        }

        public FmodResult SetPitch(float pitch) => Owner.DeviceIO.StudioEventInstanceSetPitch(Handle, pitch);
        void global::Celeste.Core.Audio.ISourceAudioEventReference.SetPitch(float pitch) => SetPitch(pitch);

        public FmodResult GetVolume(out float volume, out float finalVolume) =>
            Owner.DeviceIO.StudioEventInstanceGetVolume(Handle, out volume, out finalVolume);

        void global::Celeste.Core.Audio.ISourceAudioEventReference.GetVolume(out float volume, out float finalVolume)
            => GetVolume(out volume, out finalVolume);

        public FmodResult SetVolume(float volume) => Owner.DeviceIO.StudioEventInstanceSetVolume(Handle, volume);
        void global::Celeste.Core.Audio.ISourceAudioEventReference.SetVolume(float volume) => SetVolume(volume);
        void global::Celeste.Core.Audio.ISourceAudioEventReference.Start() => Start();

        public FmodResult Start() => Owner.DeviceIO.StudioEventInstanceStart(Handle);
        public FmodResult TriggerCue() => Owner.DeviceIO.StudioEventInstanceTriggerCue(Handle);
        public FmodResult Release() => Owner.DeviceIO.StudioEventInstanceRelease(Handle);

        public bool GetPaused()
        {
            Owner.DeviceIO.StudioEventInstanceGetPaused(Handle, out int paused);
            return paused != 0;
        }

        void global::Celeste.Core.Audio.ISourceAudioEventReference.SetPaused(bool paused) => SetPaused(paused);

        public FmodResult SetPaused(bool paused) =>
            Owner.DeviceIO.StudioEventInstanceSetPaused(Handle, paused ? 1 : 0);

        public FmodResult Stop(bool allowFadeOut = true) =>
            Owner.DeviceIO.StudioEventInstanceStop(Handle, allowFadeOut ? 0 : 1);

        public FmodResult SetParameter(string name, float value) =>
            Owner.DeviceIO.StudioEventInstanceSetParameterValue(Handle, FmodStudioRuntime.Utf8(name), value);

        public FmodResult SetPosition(Vector3 position)
        {
            var attributes = FmodAttributes.At(position.X, position.Y, position.Z);
            return Owner.DeviceIO.StudioEventInstanceSet3DAttributes(Handle, ref attributes);
        }
    }
}
