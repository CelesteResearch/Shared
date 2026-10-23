using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Gameplay.Audio.Parameters
{
    public static class FmodParameterWriter
    {
        // The original gameplay parameter writers ignore an absent authored
        // parameter. The native event API remains strict for other consumers.
        public static void SetOptional(FmodStudioRuntime runtime, FmodEventInstance instance, string name, float value)
        {
            try
            {
                instance.SetParameter(name, value);
            }
            catch (FmodException error) when (error.Result == FmodResult.ERR_EVENT_NOTFOUND)
            {
                runtime.ReportParameterFailure(instance.Path, name, value, error.Result);
            }
        }
    }
}
