using System;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Mixing
{
    public sealed class FmodBus
    {
        private readonly FmodStudioRuntime owner;
        private readonly IntPtr handle;
        public string Path { get; }

        internal FmodBus(FmodStudioRuntime owner, IntPtr handle, string path)
        {
            this.owner = owner;
            this.handle = handle;
            Path = path;
        }

        private IntPtr Handle
        {
            get
            {
                owner.Alive();
                return handle;
            }
        }

        private void Check(FmodResult result, string operation)
        {
            FmodStudioRuntime.Check(result, operation + " " + Path);
        }

        public float Volume
        {
            get
            {
                Check(
                    owner.DeviceIO.StudioBusGetVolume(Handle, out var value,
                        out _), "Get bus volume");
                return value;
            }
            set => Check(owner.DeviceIO.StudioBusSetVolume(Handle, value),
                "Set bus volume");
        }

        public bool Paused
        {
            get
            {
                Check(owner.DeviceIO.StudioBusGetPaused(Handle, out var value),
                    "Get bus pause");
                return value != 0;
            }
            set => Check(
                owner.DeviceIO.StudioBusSetPaused(Handle, value ? 1 : 0),
                "Set bus pause");
        }

        public bool Muted
        {
            get
            {
                Check(owner.DeviceIO.StudioBusGetMute(Handle, out var value),
                    "Get bus mute");
                return value != 0;
            }
            set => Check(
                owner.DeviceIO.StudioBusSetMute(Handle, value ? 1 : 0),
                "Set bus mute");
        }

        public void StopAllEvents(bool allowFadeout = true)
        {
            Check(
                owner.DeviceIO.StudioBusStopAllEvents(Handle,
                    allowFadeout ? 0 : 1),
                "Stop bus events");
        }
    }
}
