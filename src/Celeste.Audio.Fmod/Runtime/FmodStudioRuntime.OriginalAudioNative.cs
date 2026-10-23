using Celeste.Audio.Fmod.Interop;

namespace Celeste.Audio.Fmod.Runtime
{
    public sealed partial class FmodStudioRuntime
    {
        public FmodResult UpdateNative() => DeviceIO.StudioSystemUpdate(system);

        public bool BusMutedNative(string path, bool? mute = null)
        {
            bool muted = false;
            if (DeviceIO.StudioSystemGetBus(system, Utf8(path), out var bus) == FmodResult.OK)
            {
                if (mute.HasValue)
                    DeviceIO.StudioBusSetMute(bus, mute.Value ? 1 : 0);
                DeviceIO.StudioBusGetPaused(bus, out int value);
                muted = value != 0;
            }

            return muted;
        }
    }
}
