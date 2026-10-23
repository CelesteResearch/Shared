using System;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Mixing
{
    public sealed class FmodVca
    {
        private readonly FmodStudioRuntime owner;
        private readonly IntPtr handle;
        public string Path { get; }

        internal FmodVca(FmodStudioRuntime owner, IntPtr handle, string path)
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

        public float Volume
        {
            get
            {
                FmodStudioRuntime.Check(
                    owner.DeviceIO.StudioVCAGetVolume(Handle, out var value,
                        out _),
                    "Get VCA volume " + Path);
                return value;
            }
            set => FmodStudioRuntime.Check(
                owner.DeviceIO.StudioVCASetVolume(Handle, value),
                "Set VCA volume " + Path);
        }
    }
}
