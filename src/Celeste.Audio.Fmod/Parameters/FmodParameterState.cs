namespace Celeste.Audio.Fmod.Parameters
{
    public sealed class FmodParameterState
    {
        public FmodParameterInfo Description { get; internal set; }
        public string Name => Description.Name;
        public float Minimum => Description.Minimum;
        public float Maximum => Description.Maximum;
        public float Value { get; internal set; }
        public float FinalValue { get; internal set; }
    }
}
