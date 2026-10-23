using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Events
{
    public sealed partial class FmodEventReference
    {
        public FmodResult GetParameterValue(string name, out float value, out float finalValue) =>
            Owner.DeviceIO.StudioEventInstanceGetParameterValue(Handle, FmodStudioRuntime.Utf8(name), out value,
                out finalValue);
    }
}
