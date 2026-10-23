using System;

namespace Celeste.Audio.Fmod.Mixing
{
    public sealed class FmodVca
    {
        private readonly global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime owner;
        private readonly IntPtr handle;
        public string Path { get; }

        internal FmodVca(global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime owner, IntPtr handle, string path)
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
                global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime.Check(
                    owner.DeviceIO.StudioVCAGetVolume(Handle, out float value,
                        out _),
                    "Get VCA volume " + Path);
                return value;
            }
            set => global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime.Check(
                owner.DeviceIO.StudioVCASetVolume(Handle, value),
                "Set VCA volume " + Path);
        }
    }
}
