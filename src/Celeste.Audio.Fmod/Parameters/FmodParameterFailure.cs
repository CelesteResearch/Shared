using Celeste.Audio.Fmod.Interop;

namespace Celeste.Audio.Fmod.Parameters
{
    public sealed class FmodParameterFailure
    {
        public string EventPath { get; internal set; }
        public string Parameter { get; internal set; }
        public float Value { get; internal set; }
        public FmodResult Result { get; internal set; }
    }
}
