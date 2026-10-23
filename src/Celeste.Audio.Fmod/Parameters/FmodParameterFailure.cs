namespace Celeste.Audio.Fmod.Parameters
{
    public sealed class FmodParameterFailure
    {
        public string EventPath { get; internal set; }
        public string Parameter { get; internal set; }
        public float Value { get; internal set; }
        public global::Celeste.Audio.Fmod.Interop.FmodResult Result { get; internal set; }
    }
}
